using Microsoft.AspNetCore.Mvc;
using Ney_Nemovitost.web.Models.Database;
using Ney_Nemovitost.web.Models.Identity;
using Ney_Nemovitost.web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Ney_Nemovitost.web.Models.ViewModels;
using System.IO;

namespace Ney_Nemovitost.web.Areas.Vlastník.Controllers
{
    [Area("Vlastnik")]
    public class HistorieController : Controller
    {
        readonly NemovitostDBContext dbContext;
        public HistorieController(NemovitostDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public IActionResult VyberNemovitostNaHistorii(int option)
        {
            ViewBag.Option = option;
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

        public IActionResult ZobrazHistoriiCen(int id)
        {
            if (id == null) return NotFound();
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
            List<HistorieCen> historieCens = dbContext.HistorieCens.Where(x => x.idNemovitosti == modelNemovitost.ID)
                .OrderByDescending(o => o.ID)
                .Include(o => o.moznostiSluzeb)
                .OrderByDescending(o => o.ID)
                .ToList();
            HistorieCenViewModel viewModel = new HistorieCenViewModel()
            {
                modelNemovitost = modelNemovitost,
                historyCen = historieCens
            };
            return View(viewModel);
        }


        public IActionResult ZobrazHistoriiSmluv(int id)
        {
            if (id == null) return NotFound();
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
            List<ModelSmlouva> historieSmluv = dbContext.Smlouvy.Where(x => x.idNemovitost == modelNemovitost.ID)
                .OrderByDescending(o => o.ID)
                .ToList();
            HistorieSmluvViewModel viewModel = new HistorieSmluvViewModel()
            {
                modelNemovitost = modelNemovitost,
                modelSmlouvas = historieSmluv
            };
            return View(viewModel);
        }

        public ActionResult StahniSmouvu(int id)
        {
            User vlastnik = dbContext.Users
                .FirstOrDefault(o => o.UserName == User.Identity.Name);
            if (vlastnik == null) return NotFound();
            ModelSmlouva modelSmlouva = dbContext.Smlouvy.FirstOrDefault(x=>x.ID== id);
            if (modelSmlouva == null) return NotFound();
            if (modelSmlouva.idVlastnik != vlastnik.Id) return NotFound();
            var filePath = "wwwroot/smlouvy" + modelSmlouva.SrcToFile;
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            string fileName = $"Smlouva{DateTime.Now}.pdf";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
        public IActionResult VyberSmlouvuHisDod(int id)
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

        public IActionResult ZobrazHistoriiDodatku(int id, int smlouva)
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
            List<Dodatek> dodateks = dbContext.Dodateks
                .Where(x=>x.idSmlouva == modelSmlouva.ID)
                .Include(o=>o.typyDodatku)
                .OrderByDescending(o=>o.Id)
                .ToList();

            HistorieDodatkuViewModel model = new HistorieDodatkuViewModel()
            {
                modelSmlouva = modelSmlouva,
                dodateks = dodateks,
                modelNemovitost = modelNemovitost,
                najemnik = najemnik
            };
            return View(model);
        }
        public ActionResult StahniDodatek(int id)
        {
            User vlastnik = dbContext.Users
                .FirstOrDefault(o => o.UserName == User.Identity.Name);
            if (vlastnik == null) return NotFound();
            Dodatek dodatek = dbContext.Dodateks
                .FirstOrDefault(x => x.Id == id);
            if (dodatek == null) return NotFound();
            ModelSmlouva modelSmlouva = dbContext.Smlouvy
                .Where(o => o.idVlastnik == vlastnik.Id)
                .Where(o => o.ID == dodatek.idSmlouva)
                .FirstOrDefault();
            if(modelSmlouva == null) return NotFound();
            var filePath = "wwwroot/dodatky" + dodatek.srcToPdf;
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            string fileName = $"Dodatek{DateTime.Now}.pdf";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}
