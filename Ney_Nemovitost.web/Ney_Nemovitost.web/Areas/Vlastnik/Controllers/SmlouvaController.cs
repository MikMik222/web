using Microsoft.AspNetCore.Mvc;
using Ney_Nemovitost.web.Models.ViewModels;
using Ney_Nemovitost.web.Models.Database;
using Ney_Nemovitost.web.Models.Identity;
using Ney_Nemovitost.web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using IronPdf;

namespace Ney_Nemovitost.web.Areas.Vlastník.Controllers
{
    [Area("Vlastnik")]
    public class SmlouvaController : Controller
    {
        readonly NemovitostDBContext dbContext;
        public SmlouvaController(NemovitostDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public IActionResult RegisterSmlouva(int ?id)
        {
            if (id == null) return NotFound();
            User ?vlastnik = dbContext.Users
                .FirstOrDefault(o => o.UserName == User.Identity.Name);
            if (vlastnik == null) { return NotFound(); }
            ModelNemovitost modelNemovitost = dbContext.Nemovitosts
                .Where(o => o.vlastnik2.Id == vlastnik.Id)
                .FirstOrDefault(o => o.ID == id);
            if (modelNemovitost == null) { return NotFound(); }
            RegisterSmlouvaViewModel viewModel = new RegisterSmlouvaViewModel()
            {
                modelSmlouva = new ModelSmlouva() { idNemovitost = modelNemovitost.ID, idVlastnik = vlastnik.Id },
                najemnici = dbContext.Najemniks.Where(o => o.vlastnikID == vlastnik.Id).ToList(),
            };
            viewModel.dateOd = DateTime.Now;
            viewModel.dateDo = DateTime.Now.AddYears(1);
            return View(viewModel);
        }

        public IActionResult VyberNemovitost()
        {
            User vlastnik = dbContext.Users
                .FirstOrDefault(o => o.UserName == User.Identity.Name);
            if (vlastnik == null) { return NotFound(); }
            List<ModelNemovitost> modelNemovitosts = dbContext.Nemovitosts.Where(o => o.idVlastnik == vlastnik.Id)
                .Include(o => o.adresa)
                .Include(o => o.vlastnik2)
                .Include(o => o.enerNarocnost)
                .Include(o => o.optionNemovitost)
                .ToList();

            return View(modelNemovitosts);
        }


        [HttpPost]
        public async Task<IActionResult> RegisterSmlouva(RegisterSmlouvaViewModel registerViewModel)
        {

            User vlastnik = dbContext.Users
                .Where(o => o.UserName == User.Identity.Name)
                .Include(o => o.adresa)
                .Include(o => o.predvolby)
                .FirstOrDefault();
            if (vlastnik == null) { return NotFound(); }
            if (ModelState.IsValid)
            {
                string s = "";
                if(registerViewModel.maxPocetOsob < 1)
                {
                    s += "Maximální počet osob nemůže být 0\n";
                }
                if (registerViewModel.denVMesiciKdyZaplatit < 1 || registerViewModel.denVMesiciKdyZaplatit > 31)
                {
                    s += "Nevalidní den kdy v měsíci zaplatit\n";
                }
                if (registerViewModel.cisloUctu.Length < 3)
                {
                    s += "Minimální délka účtu je 3\n";
                }
                if (registerViewModel.cisloUctu.Length > 200)
                {
                    s += "Maximální délka účtu je 200\n";
                }
                if (DateTime.Compare(registerViewModel.dateOd, DateTime.Now.Date.AddYears(-1)) < 0)
                {
                    s += "Smlouva se nemůže vytvořit starší než 1 rok\n";
                }
                if (DateTime.Compare(registerViewModel.dateOd, registerViewModel.dateDo) > 0)
                {
                    s += "Datum začátku nemůže být později než ukončení\n";
                }
                if(s.Length> 0)
                {

                    registerViewModel.najemnici = dbContext.Najemniks.Where(o => o.vlastnikID == vlastnik.Id).ToList();
                    ViewBag.chyba = s;
                    return View(registerViewModel);
                }
                ModelNemovitost modelNemovitost = dbContext.Nemovitosts
                    .Where(o => o.ID == registerViewModel.modelSmlouva.idNemovitost)
                    .Include(o => o.adresa)
                    .Include(o => o.optionNemovitost)
                    .FirstOrDefault(o => o.vlastnik2.Id == vlastnik.Id);
                if (modelNemovitost == null) { return NotFound(); }
                //Document document = new Document();
                Najemnik najemnik = dbContext.Najemniks
                    .Where(o => o.ID == registerViewModel.modelSmlouva.idNajemnik)
                    .Include(o => o.modelAdresa)
                    .Include(o => o.predvolby)
                    .FirstOrDefault();
                if (najemnik == null) { return NotFound(); }

                var fileName = Guid.NewGuid().ToString() + ".pdf";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/smlouvy", fileName);

                var ChromePdfRenderer = new ChromePdfRenderer();  // new instance of ChromePdfRenderer

                var html = System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/htmlpdftemplate/smlouvy", "smlouva.html"));
                html = html.Replace("[[JMENO_VLASTNIK]]", $"{vlastnik.FirstName} {vlastnik.LastName}");
                html = html.Replace("[[DatNar_VLASTNIK]]", $"{vlastnik.datumNarozeni}");
                html = html.Replace("[[RodCis_VLASTNIK]]", $"{vlastnik.rodneCislo}");
                html = html.Replace("[[Bydliste_VLASTNIK]]", $"{vlastnik.adresa.UliceACisloPop}");
                html = html.Replace("[[Email_VLASTNIK]]", $"{vlastnik.UserName}");
                html = html.Replace("[[Tel_VLASTNIK]]", $"+{vlastnik.predvolby.predvolba}{vlastnik.PhoneNumber}");

                html = html.Replace("[[JMENO_NAJEMCE]]", $"{najemnik.jmeno} {najemnik.prijmeni}");
                html = html.Replace("[[DatNar_NAJEMCE]]", $"{najemnik.datumNarozeni}");
                html = html.Replace("[[RodCis_NAJEMCE]]", $"{najemnik.rodneCislo}");
                html = html.Replace("[[Bydliste_NAJEMCE]]", $"{najemnik.modelAdresa.UliceACisloPop}");
                html = html.Replace("[[Email_NAJEMCE]]", $"{najemnik.email}");
                html = html.Replace("[[Tel_NAJEMCE]]", $"+{najemnik.predvolby.predvolba}{najemnik.telefon}");

                html = html.Replace("[[ceho_jiny_pad]]", $"{modelNemovitost.optionNemovitost.VolbaJinyPad}");
                html = html.Replace("[[ceho_normalni_pad]]", $"{modelNemovitost.optionNemovitost.VolbaJinyPad}");

                html = html.Replace("[[ADRESA NEMOVITOSTI]]", $"{modelNemovitost.adresa.UliceACisloPop}, {modelNemovitost.adresa.Obec} {modelNemovitost.adresa.Psc}");
                html = html.Replace("[[POCET OSOB]]", $"{registerViewModel.maxPocetOsob}");
                html = html.Replace("[[DATUM OD]]", $"{DateOnly.Parse(registerViewModel.dateOd.ToString("dd.MM yyyy"))}");
                html = html.Replace("[[DATUM DO]]", $"{DateOnly.Parse(registerViewModel.dateDo.ToString("dd.MM yyyy"))}");
                html = html.Replace("[[CENANAJMU]]", $"{modelNemovitost.cenaNajmu}");
                html = html.Replace("[[CENA ENERGIE]]", $"{modelNemovitost.cenaEnergii}");
                html = html.Replace("[[CENA CELKEM]]", $"{modelNemovitost.cenaEnergii + modelNemovitost.cenaSluzeb + modelNemovitost.cenaNajmu}");
                html = html.Replace("[[DO KDY PENIZE]]", $"do {registerViewModel.denVMesiciKdyZaplatit}. dne v měsicí");
                html = html.Replace("[[CISLO UCTU]]", $"{registerViewModel.cisloUctu}");
                html = html.Replace("[[VRATNA KAUCE]]", $"{registerViewModel.vratnaKauce}");
                html = html.Replace("[[OBEC]]", $"{modelNemovitost.adresa.Obec}");
                html = html.Replace("[[DNESNI DATUM]]", $"{DateOnly.Parse(registerViewModel.dateOd.ToString("dd.MM yyyy"))}");
                html = html.Replace("[[CENA SLEVY]]", $"{registerViewModel.cenaSlevy}");


                using var pdf = ChromePdfRenderer.RenderHtmlAsPdf(html);

                pdf.SaveAs(filePath);

                registerViewModel.modelSmlouva.idVlastnik = vlastnik.Id;
                registerViewModel.modelSmlouva.SrcToFile = "/" + fileName;
                registerViewModel.modelSmlouva.platnaOd = DateOnly.Parse(registerViewModel.dateOd.ToString("dd.MM yyyy"));
                registerViewModel.modelSmlouva.platnaDo = DateOnly.Parse(registerViewModel.dateDo.ToString("dd.MM yyyy"));
                dbContext.Smlouvy.Add(registerViewModel.modelSmlouva);
                modelNemovitost.dostupnostOd = DateOnly.Parse(registerViewModel.dateDo.ToString("dd.MM yyyy"));
                dbContext.Update(modelNemovitost);
                dbContext.SaveChanges();

                return RedirectToAction(nameof(Index), "", new { area = "" });
            }
            registerViewModel.najemnici = dbContext.Najemniks.Where(o => o.vlastnikID == vlastnik.Id).ToList();
            return View(registerViewModel);

        }
    }
}
