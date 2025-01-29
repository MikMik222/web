using Microsoft.AspNetCore.Mvc;
using Ney_Nemovitost.web.Models.Database;
using Ney_Nemovitost.web.Models.Identity;
using Ney_Nemovitost.web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using IronPdf;
using Ney_Nemovitost.web.Models.ViewModels;


namespace Ney_Nemovitost.web.Areas.Vlastník.Controllers
{
    [Area("Vlastnik")]
    public class DodatekController : Controller
    {
        readonly NemovitostDBContext dbContext;
        public DodatekController(NemovitostDBContext _dbContext)
        {
            dbContext = _dbContext;
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
        public IActionResult VyberSmlouvu(int id)
        {
            User vlastnik = dbContext.Users
                .FirstOrDefault(o => o.UserName == User.Identity.Name);
            if (vlastnik == null) { return NotFound(); }

            ModelNemovitost modelNemovitost = dbContext.Nemovitosts
                .Where(o => o.vlastnik2.Id == vlastnik.Id)
                .Include(o => o.adresa)
                .Include(o => o.optionNemovitost)
                .Include(o => o.dispoziceNemovitosti)
                .Include(o => o.enerNarocnost)
                .FirstOrDefault(o => o.ID == id);
            if (modelNemovitost == null) { return NotFound(); }
            if (modelNemovitost.idVlastnik != vlastnik.Id) return NotFound();
            List<ModelSmlouva> modelSmlouva = dbContext.Smlouvy.Where(o => o.idVlastnik == vlastnik.Id)
                .Where(o => o.idNemovitost == id)
                .OrderByDescending(o=>o.ID)
                .Include(o => o.najemnik).ToList();
            HistorieSmluvViewModel historieSmluvViewModel = new HistorieSmluvViewModel()
            {
                modelSmlouvas = modelSmlouva,
                modelNemovitost = modelNemovitost,
            };
            return View(historieSmluvViewModel);
        }



        public IActionResult VyberTypDodatku(int id, int smlouva)
        {
            if (id == null || smlouva == null) return NotFound();
            User vlastnik = dbContext.Users
                .FirstOrDefault(o => o.UserName == User.Identity.Name);
            if (vlastnik == null) { return NotFound(); }
            ModelNemovitost modelNemovitost = dbContext.Nemovitosts
                .Include(x => x.optionNemovitost)
                .Include(x => x.adresa)
                .Where(o => o.idVlastnik == vlastnik.Id)
                .FirstOrDefault(o => o.ID == id);
            if (modelNemovitost == null) { return NotFound(); }
            ModelSmlouva modelSmlouva = dbContext.Smlouvy.Where(o => o.idVlastnik == vlastnik.Id)
                .FirstOrDefault(o => o.ID == smlouva);
            Najemnik najemnik = dbContext.Najemniks
                .Include(o => o.predvolby)
                .FirstOrDefault(x => x.ID == modelSmlouva.idNajemnik);
            if (najemnik == null) return NotFound();
            if (modelSmlouva == null) { return NotFound(); }
            List<TypyDodatku> typyDodatkus = dbContext.TypyDodatkus.ToList();
            DodatekViewModel dodatekViewModel = new DodatekViewModel()
            {
                modelNemovitost = modelNemovitost,
                modelSmlouva = modelSmlouva,
                najemnik = najemnik,
                typyDodatkus = typyDodatkus
            };
            return View(dodatekViewModel);
        }

        public IActionResult VytvorDodatek(int id, int smlouva, int dodatek)
        {
            if (id == null || smlouva == null) return NotFound();
            User vlastnik = dbContext.Users
                .FirstOrDefault(o => o.UserName == User.Identity.Name);
            if (vlastnik == null) { return NotFound(); }
            ModelNemovitost modelNemovitost = dbContext.Nemovitosts
                .Where(o => o.idVlastnik == vlastnik.Id)
                .FirstOrDefault(o => o.ID == id);
            if (modelNemovitost == null) { return NotFound(); }
            ModelSmlouva modelSmlouva = dbContext.Smlouvy.Where(o => o.idVlastnik == vlastnik.Id)
                .FirstOrDefault(o => o.ID == smlouva);
            if (modelSmlouva == null) { return NotFound(); }
            List<TypyDodatku> typyDodatkus = dbContext.TypyDodatkus.ToList();
            if (dbContext.TypyDodatkus.FirstOrDefault(o => o.Id == dodatek) == null) { return NotFound(); }

            RegisterDodatekFinalViewModel model = new RegisterDodatekFinalViewModel()
            {
                idDodatku = dodatek,
                idSmlouva = smlouva,

            };
            if (dodatek == 3)
            {

                List<HistorieCen> historieCens = dbContext.HistorieCens.Where(x => x.idNemovitosti == modelNemovitost.ID)
                    .OrderByDescending(o => o.ID)
                    .ToList();
                foreach (int value in Enumerable.Range(1, 8))
                {
                    int cena = (int)historieCens.Where(x => x.idSluzby == value).Select(x => x.cena).First();
                    if (value == 1) model.cenaPronajem = cena;
                    else if (value == 2) model.cenaVody = cena;
                    else if (value == 3) model.cenaPlynu = cena;
                    else if (value == 4) model.cenaElektriky = cena;
                    else if (value == 5) model.cenaInternetu = cena;
                    else if (value == 6) model.cenaUklidu = cena;
                    else if (value == 7) model.cenaOdpadu = cena;
                    else if (value == 8) model.cenaSpolecneEleketriky = cena;
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> VytvorDodatek(RegisterDodatekFinalViewModel dodatek)
        {
            User vlastnik = dbContext.Users
                .Include(o => o.adresa)
                .Include(o => o.predvolby)
                .FirstOrDefault(o => o.UserName == User.Identity.Name);
            if (vlastnik == null) { return NotFound(); }
            ModelSmlouva modelSmlouva = dbContext.Smlouvy
                .FirstOrDefault(o => o.ID == dodatek.idSmlouva);
            if (modelSmlouva == null) { return NotFound(); }
            if (modelSmlouva.idVlastnik != vlastnik.Id) { return NotFound(); }
            ModelNemovitost modelNemovitost = dbContext.Nemovitosts
                .Include(o => o.adresa)
                .Include(o => o.optionNemovitost)
                .FirstOrDefault(o => o.ID == modelSmlouva.idNemovitost);
            if (modelNemovitost == null) { return NotFound(); }
            //Document document = new Document();
            string htmlString = "";
            var fileName = Guid.NewGuid().ToString() + ".pdf";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/dodatky", fileName);
            if (dodatek.idDodatku == 1)
            {
                if (dodatek.maxPocetOseb < 1)
                {
                    ViewBag.chyba = "Nevalidní počet osob";
                    return View(dodatek);
                }
                dodatek.datumUkonceni = DateTime.Now;
                htmlString = System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/htmlpdftemplate/dodatky", "dodatek_maximalni_pocet_osob.html"));
                htmlString = htmlString.Replace("[[číslo]]", $"{dodatek.maxPocetOseb}");
            }
            else if (dodatek.idDodatku == 2)
            {
                if (DateTime.Compare(modelSmlouva.platnaOd.ToDateTime(TimeOnly.Parse("0:0 AM")), dodatek.datumUkonceni) > 0)
                {

                    ViewBag.chyba = "Smlouva nemůže být ukončená dříve než začne platit";
                    return View(dodatek);
                }
                htmlString = System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/htmlpdftemplate/dodatky", "dodatek_doba_najmu.html"));
                DateOnly novyUkonceni = DateOnly.Parse(dodatek.datumUkonceni.ToString("dd.MM yyyy"));
                modelNemovitost.dostupnostOd = novyUkonceni;
                modelSmlouva.platnaDo = novyUkonceni;
                htmlString = htmlString.Replace("[[datum]]", $"{novyUkonceni}");
                dbContext.Update(modelNemovitost);
                dbContext.Update(modelSmlouva);
            }
            else if (dodatek.idDodatku == 3)
            {
                string chyby = "";

                double novaCenaEnergii = SectiEnergie(dodatek);
                double novaCenaSluzeb = SectiSluzby(dodatek);
                DateOnly date = DateOnly.Parse(dodatek.datumUkonceni.ToString("dd.MM yyyy"));
                if (dodatek.cenaPronajem < 0) chyby += "Cena nájmu nemůže být  menší než 0\n";
                if (dodatek.cenaPlynu < 0) chyby += "Cena plynu nemůže být  menší než 0\n";
                if (dodatek.cenaVody < 0) chyby += "Cena vody nemůže být  menší než 0\n";
                if (dodatek.cenaElektriky < 0) chyby += "Cena elektřiny nemůže být  menší než 0\n";
                if (dodatek.cenaSpolecneEleketriky < 0) chyby += "Cena společné elektřiny nemůže být  menší než 0\n";
                if (dodatek.cenaOdpadu < 0) chyby += "Cena odpadu nemůže být  menší než 0\n";
                if (dodatek.cenaInternetu < 0) chyby += "Cena internetu nemůže být  menší než 0\n";
                if (dodatek.cenaUklidu < 0) chyby += "Cena úklidu nemůže být  menší než 0\n";
                if (modelNemovitost.cenaEnergii == novaCenaEnergii && modelNemovitost.cenaSluzeb == novaCenaSluzeb && modelNemovitost.cenaNajmu == dodatek.cenaPronajem)
                {
                    chyby += "Není změněna žádná cena\n";
                }

                if (chyby.Length > 0)
                {
                    chyby = chyby.Remove(chyby.Length - 1);
                    ViewBag.chyba = chyby;
                    return View(dodatek);
                }

                List<HistorieCen> historieCens = dbContext.HistorieCens.Where(x => x.idNemovitosti == modelNemovitost.ID)
                    .OrderByDescending(o => o.ID)
                    .ToList();
                if (modelNemovitost.cenaNajmu != dodatek.cenaPronajem)
                {
                    HistorieCen historieCen = historieCens.First(o => o.idSluzby == 1);
                    DateTime a = historieCen.cenaPlatnaOd.ToDateTime(TimeOnly.Parse("0:0 AM"));
                    int rozdilDatumu = DateTime.Compare(a, dodatek.datumUkonceni);
                    if (rozdilDatumu <= 0)
                    {
                        double cena = historieCen.cena;
                        if (rozdilDatumu < 0)
                        {
                            dbContext.Add(new HistorieCen() { idNemovitosti = modelNemovitost.ID, cena = cena, cenaPlatnaOd = DateOnly.Parse(dodatek.datumUkonceni.ToString("yyyy-MM-dd")), idSluzby = 1 });
                        }
                        else
                        {
                            historieCen.cena = cena;
                            dbContext.Update(historieCen);
                        }

                    }
                    else
                    {
                        chyby += "Datum změny nájmu je dříve než definované datum\n";
                    }
                    modelNemovitost.cenaNajmu = dodatek.cenaPronajem;
                }
                if (modelNemovitost.cenaEnergii != novaCenaEnergii || modelNemovitost.cenaSluzeb != novaCenaSluzeb)
                {
                    if (modelNemovitost.cenaEnergii != novaCenaEnergii)
                    {
                        modelNemovitost.cenaEnergii = novaCenaEnergii;
                        foreach (int value in Enumerable.Range(2, 3))
                        {
                            HistorieCen historieCen = historieCens.First(o => o.idSluzby == value);
                            DateTime a = historieCen.cenaPlatnaOd.ToDateTime(TimeOnly.Parse("0:0 AM"));
                            int rozdilDatumu = DateTime.Compare(historieCen.cenaPlatnaOd.ToDateTime(TimeOnly.Parse("0:0 AM")), dodatek.datumUkonceni);
                            if (rozdilDatumu <= 0)
                            {
                                double cena = historieCen.cena;
                                if (value == 2) cena = dodatek.cenaVody;
                                else if (value == 3) cena = dodatek.cenaPlynu;
                                else if (value == 4) cena = dodatek.cenaElektriky;
                                if (cena != historieCen.cena)
                                {
                                    if (rozdilDatumu < 0)
                                    {
                                        dbContext.Add(new HistorieCen() { idNemovitosti = modelNemovitost.ID, cena = cena, cenaPlatnaOd = DateOnly.Parse(dodatek.datumUkonceni.ToString("yyyy-MM-dd")), idSluzby = value });
                                    }
                                    else
                                    {
                                        historieCen.cena = cena;
                                        dbContext.Update(historieCen);
                                    }
                                }
                            }
                            else
                            {
                                chyby += "Datum změny energie je dříve než definované datum\n";
                                continue;
                            }
                        }
                    }
                    if (modelNemovitost.cenaSluzeb != novaCenaSluzeb)
                    {
                        modelNemovitost.cenaSluzeb = novaCenaSluzeb;
                        foreach (int value in Enumerable.Range(5, 4))
                        {
                            HistorieCen historieCen = historieCens.First(o => o.idSluzby == value);
                            DateTime a = historieCen.cenaPlatnaOd.ToDateTime(TimeOnly.Parse("0:0 AM"));
                            int rozdilDatumu = DateTime.Compare(historieCen.cenaPlatnaOd.ToDateTime(TimeOnly.Parse("0:0 AM")), dodatek.datumUkonceni);
                            if (rozdilDatumu <= 0)
                            {
                                double cena = historieCen.cena;
                                if (value == 5) cena = dodatek.cenaInternetu;
                                else if (value == 6) cena = dodatek.cenaUklidu;
                                else if (value == 7) cena = dodatek.cenaOdpadu;
                                else if (value == 8) cena = dodatek.cenaSpolecneEleketriky;
                                if (cena != historieCen.cena)
                                {
                                    if (rozdilDatumu < 0)
                                    {
                                        dbContext.Add(new HistorieCen() { idNemovitosti = modelNemovitost.ID, cena = cena, cenaPlatnaOd = DateOnly.Parse(dodatek.datumUkonceni.ToString("yyyy-MM-dd")), idSluzby = value });
                                    }
                                    else
                                    {
                                        historieCen.cena = cena;
                                        dbContext.Update(historieCen);
                                    }
                                }
                            }
                            else
                            {
                                chyby += "Datum změny služeb je dříve než definované datum\n";
                                continue;
                            }
                        }

                        
                    }
                    if (chyby.Length > 0)
                    {
                        chyby = chyby.Remove(chyby.Length - 1);
                        ViewBag.chyba = chyby;
                        return View(dodatek);
                    }
                }
                dbContext.Update(modelNemovitost);
                htmlString = System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/htmlpdftemplate/dodatky", "dodatek_cena_najmu_a_sluzeb.html"));
                htmlString = htmlString.Replace("[[pronajem]]", $"{dodatek.cenaPronajem}");
                htmlString = htmlString.Replace("[[energie]]", $"{modelNemovitost.cenaEnergii}");
                htmlString = htmlString.Replace("[[sluzby]]", $"{modelNemovitost.cenaSluzeb}");
                htmlString = htmlString.Replace("[[datum]]", $"{date}");
            }
            else
            {
                ViewBag.chyba = "Vybrán nevalidní dodatek";
                return View(dodatek);
            }
            Najemnik najemnik = dbContext.Najemniks
                .Where(o => o.ID == modelSmlouva.idNajemnik)
                .Include(o => o.modelAdresa)
                .Include(o => o.predvolby)
                .FirstOrDefault();
            if (najemnik == null) { return NotFound(); }
            htmlString = htmlString.Replace("[[ADRESA NEMOVITOSTI]]", $"{modelNemovitost.adresa.UliceACisloPop}, {modelNemovitost.adresa.Obec} {modelNemovitost.adresa.Psc}");
            htmlString = htmlString.Replace("[[JMENO_VLASTNIK]]", $"{vlastnik.FirstName} {vlastnik.LastName}");
            htmlString = htmlString.Replace("[[DatNar_VLASTNIK]]", $"{vlastnik.datumNarozeni}");
            htmlString = htmlString.Replace("[[RodCis_VLASTNIK]]", $"{vlastnik.rodneCislo}");
            htmlString = htmlString.Replace("[[Bydliste_VLASTNIK]]", $"{vlastnik.adresa.UliceACisloPop}");
            htmlString = htmlString.Replace("[[Email_VLASTNIK]]", $"{vlastnik.UserName}");
            htmlString = htmlString.Replace("[[Tel_VLASTNIK]]", $"+{vlastnik.predvolby.predvolba}{vlastnik.PhoneNumber}");

            htmlString = htmlString.Replace("[[JMENO_NAJEMCE]]", $"{najemnik.jmeno} {najemnik.prijmeni}");
            htmlString = htmlString.Replace("[[DatNar_NAJEMCE]]", $"{najemnik.datumNarozeni}");
            htmlString = htmlString.Replace("[[RodCis_NAJEMCE]]", $"{najemnik.rodneCislo}");
            htmlString = htmlString.Replace("[[Bydliste_NAJEMCE]]", $"{najemnik.modelAdresa.UliceACisloPop}");
            htmlString = htmlString.Replace("[[Email_NAJEMCE]]", $"{najemnik.email}");
            htmlString = htmlString.Replace("[[Tel_NAJEMCE]]", $"+{najemnik.predvolby.predvolba}{najemnik.telefon}");
            htmlString = htmlString.Replace("[[číslo dodatku]]", $"{dbContext.Dodateks.Count(o => o.idNemovitost == modelSmlouva.idNemovitost) + 1}");
            htmlString = htmlString.Replace("[[DNESNI DATUM]]", $"{DateOnly.Parse(DateTime.Now.ToString("dd.MM yyyy"))}");
            htmlString = htmlString.Replace("[[ceho_jiny_pad]]", $"{modelNemovitost.optionNemovitost.VolbaJinyPad}");
            htmlString = htmlString.Replace("[[OBEC]]", $"{modelNemovitost.adresa.Obec}");
            var ChromePdfRenderer = new ChromePdfRenderer();
            using var pdf = ChromePdfRenderer.RenderHtmlAsPdf(htmlString);
            pdf.SaveAs(filePath);
            Dodatek model = new Dodatek()
            {
                datumPlatnosti = DateOnly.Parse(dodatek.datumUkonceni.ToString("dd.MM yyyy")),
                idSmlouva = modelSmlouva.ID,
                idDodatku = dodatek.idDodatku,
                idNemovitost = modelSmlouva.idNemovitost,
                srcToPdf = "/" + fileName,
            };
            dbContext.Add(model);
            dbContext.SaveChanges();

            
            return RedirectToAction(nameof(Index), "", new { area = "" });
        }

        private double SectiSluzby(RegisterDodatekFinalViewModel registerViewModel)
        {
            return registerViewModel.cenaInternetu + registerViewModel.cenaUklidu + registerViewModel.cenaOdpadu + registerViewModel.cenaSpolecneEleketriky;
        }
        private double SectiEnergie(RegisterDodatekFinalViewModel registerViewModel)
        {
            return registerViewModel.cenaVody + registerViewModel.cenaElektriky + registerViewModel.cenaPlynu;
        }
    }
}
