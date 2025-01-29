using Microsoft.AspNetCore.Mvc;
using Ney_Nemovitost.web.Models.ViewModels;
using Ney_Nemovitost.web.Models.Database;
using Ney_Nemovitost.web.Models.Identity;
using Ney_Nemovitost.web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ney_Nemovitost.web.Areas.Vlastník.Controllers
{
    [Area("Vlastnik")]
    public class ZavadyController : Controller
    {
        readonly NemovitostDBContext dbContext;
        public ZavadyController(NemovitostDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public IActionResult RegisterZavada(int id)
        {
            if (id == null) return NotFound();
            User vlastnik = dbContext.Users
                .FirstOrDefault(o => o.UserName == User.Identity.Name);
            if (vlastnik == null) { return NotFound(); }
            ModelZavady modelZavady = new ModelZavady()
            {
                idNemovitost = id,
                datumNahlaseniFull = DateTime.Now,
                najemniks = dbContext.Najemniks.Where(o => o.vlastnikID == vlastnik.Id).ToList(),
                nazevOpravare = ""
            };

            return View(modelZavady);
        }

        public IActionResult VyberNemovitostZavady(int id)
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
            if (id == 1)
            {
                ViewBag.Akce = "prv";
            }

            return View(modelNemovitosts);
        }

        public IActionResult VyberZavadu(int id)
        {
            User vlastnik = dbContext.Users
                .Where(o => o.UserName == User.Identity.Name)
                .FirstOrDefault();
            if (vlastnik == null) { return NotFound(); }
            ModelNemovitost modelNemovitost = dbContext.Nemovitosts
                .Where(o => o.vlastnik2.Id == vlastnik.Id)
                .Include(o => o.adresa)
                .Include(o => o.optionNemovitost)
                .Include(o => o.dispoziceNemovitosti)
                .Include(o => o.enerNarocnost)
                .FirstOrDefault(o => o.ID == id);
            if (modelNemovitost == null) { return NotFound(); }
            if (modelNemovitost.idVlastnik != vlastnik.Id) { return NotFound(); }
            List<ModelZavady> zavadies = dbContext.Zavadies
                .OrderByDescending(o => o.ID)
                .Where(o => o.idNemovitost == id).ToList();
            ZavadyViewModel model = new ZavadyViewModel()
            {
                modelNemovitost = modelNemovitost,
                modelZavadies = zavadies,
            };
            return View(model);
        }

        public IActionResult EditZavady(int nemovitost, int idzav)
        {
            
            User vlastnik = dbContext.Users
                .FirstOrDefault(o => o.UserName == User.Identity.Name);
            if (vlastnik == null) { return NotFound(); }
            ModelNemovitost modelNemovitost = dbContext.Nemovitosts
                .Where(o => o.vlastnik2.Id == vlastnik.Id)
                .FirstOrDefault(o => o.ID == nemovitost);
            if (modelNemovitost == null) { return NotFound(); }
            if (modelNemovitost.idVlastnik != vlastnik.Id) { return NotFound(); }
            ModelZavady modelZavady = dbContext.Zavadies.FirstOrDefault(o => o.ID == idzav);
            if (modelZavady == null) { return NotFound(); }
            if (modelZavady.idmajitel != vlastnik.Id) { return NotFound(); }
            modelZavady.datumNahlaseniFull = new DateTime(modelZavady.datumNahlaseni.Year, modelZavady.datumNahlaseni.Month, modelZavady.datumNahlaseni.Day);
            modelZavady.datumOpravyFull = new DateTime(modelZavady.datumOpravy.Year, modelZavady.datumOpravy.Month, modelZavady.datumOpravy.Day);
            return View(modelZavady);
        }


        [HttpPost]
        public async Task<IActionResult> EditZavady(ModelZavady modelZav)
        {
            User vlastnik = dbContext.Users
                .Where(o => o.UserName == User.Identity.Name)
                .FirstOrDefault();

            if (vlastnik == null) { return NotFound(); }
            ModelZavady modelZavady = dbContext.Zavadies.FirstOrDefault(o => o.ID == modelZav.ID);
            if (modelZavady == null) { return NotFound(); }
            if (modelZavady.idmajitel != vlastnik.Id) { return NotFound(); }
            if (ModelState.IsValid)
            {
                modelZavady.cenaOpravy = modelZav.cenaOpravy;
                if(modelZav.nazevOpravare != null) modelZavady.nazevOpravare = modelZav.nazevOpravare;
                if(modelZav.popisOpravy != null)modelZavady.popisOpravy = modelZav.popisOpravy;
                modelZavady.popisZavady = modelZav.popisZavady;
                modelZavady.datumOpravy = DateOnly.Parse(modelZav.datumOpravyFull.ToString("dd.MM yyyy"));
                string s = CheckValue(modelZavady);

                if (s.Length > 0)
                {
                    ViewBag.chyba = s;
                    modelZav.najemniks = dbContext.Najemniks.Where(o => o.vlastnikID == vlastnik.Id).ToList();
                    modelZav.datumNahlaseniFull = new DateTime(modelZavady.datumNahlaseni.Year, modelZavady.datumNahlaseni.Month, modelZavady.datumNahlaseni.Day);
                    return View(modelZav);
                }
                dbContext.Update(modelZavady);
                dbContext.SaveChanges();

                return RedirectToAction(nameof(Index), "", new { area = "" });
            }

            modelZav.datumNahlaseniFull = new DateTime(modelZavady.datumNahlaseni.Year, modelZavady.datumNahlaseni.Month, modelZavady.datumNahlaseni.Day);
            modelZav.najemniks = dbContext.Najemniks.Where(o => o.vlastnikID == vlastnik.Id).ToList();
            return View(modelZav);


        }


        [HttpPost]
        public async Task<IActionResult> RegisterZavada(ModelZavady modelZavady)
        {
            User vlastnik = dbContext.Users
                .Where(o => o.UserName == User.Identity.Name)
                .FirstOrDefault();
            if (vlastnik == null) { return NotFound(); }
            if (ModelState.IsValid)
            {
                if (modelZavady.nazevOpravare == null) { modelZavady.nazevOpravare = ""; }
                if (modelZavady.popisOpravy == null) { modelZavady.popisOpravy = ""; }
                string s = CheckValue(modelZavady);
                if (DateTime.Compare(modelZavady.datumNahlaseniFull, DateTime.Now.Date) > 0)
                {
                    s += "Datum nahlášení nemůže být budoucí datum\n";
                }
                else if (DateTime.Compare(modelZavady.datumNahlaseniFull, DateTime.Now.Date.AddYears(-12)) < 0)
                {
                    s += "Datum nahlášení nemůže být starší 12 let\n";
                }
                if (s.Length > 0)
                {
                    ViewBag.chyba = s;
                    modelZavady.najemniks = dbContext.Najemniks.Where(o => o.vlastnikID == vlastnik.Id).ToList();
                    return View(modelZavady);
                }

                modelZavady.idmajitel = vlastnik.Id;
                ModelNemovitost modelNemovitost = dbContext.Nemovitosts
                    .FirstOrDefault(o => o.ID == modelZavady.idNemovitost);
                if (modelNemovitost == null) { return NotFound(); }
                if (modelNemovitost.idVlastnik != vlastnik.Id) { return NotFound(); }
                Najemnik najemnik = dbContext.Najemniks.FirstOrDefault(x => x.ID == modelZavady.idNajemnik);
                if (najemnik == null) return NotFound();
                if (najemnik.vlastnikID != vlastnik.Id) return NotFound();
                ModelZavady modelZavady1 = new ModelZavady()
                {
                    idmajitel = modelZavady.idmajitel,
                    idNemovitost = modelZavady.idNemovitost,
                    idNajemnik = modelZavady.idNajemnik,
                    cenaOpravy = modelZavady.cenaOpravy,
                };

                modelZavady1.datumNahlaseni = DateOnly.Parse(modelZavady.datumNahlaseniFull.ToString("dd.MM yyyy"));
                modelZavady1.datumOpravy = DateOnly.Parse(modelZavady.datumOpravyFull.ToString("dd.MM yyyy"));

                modelZavady1.nazevOpravare = modelZavady.nazevOpravare;
                modelZavady1.popisOpravy = modelZavady.popisOpravy;
                modelZavady1.popisZavady = modelZavady.popisZavady;
                dbContext.Add(modelZavady1);
                dbContext.SaveChanges();

                return RedirectToAction(nameof(Index), "", new { area = "" });
            }
            modelZavady.najemniks = dbContext.Najemniks.Where(o => o.vlastnikID == vlastnik.Id).ToList();
            return View(modelZavady);
        }

        private string CheckValue(ModelZavady modelZavady)
        {
            string chyba = "";
            if (DateTime.Compare(modelZavady.datumOpravyFull, DateTime.Now.Date) > 0)
            {
                chyba += "Datum nahlášení nemůže být budoucí datum\n";
            }
            if(modelZavady.popisOpravy.Length > 500)
            {
                chyba += "Popis opravy nemúže být delší než 500";
            }
            if (modelZavady.nazevOpravare.Length > 200)
            {
                chyba += "Název opravře nemúže být delší než 500";
            }
            if (modelZavady.popisZavady.Length > 200)
            {
                chyba += "Popis závady nemúže být delší než 500";
            }
            else if (modelZavady.popisZavady.Length < 3)
            {
                chyba += "Popis závady musí být minimálně 3";
            }
            return chyba;
        }
    }
}
