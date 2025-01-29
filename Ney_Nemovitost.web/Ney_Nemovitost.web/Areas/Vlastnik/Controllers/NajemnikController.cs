using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Ney_Nemovitost.web.Models.ApplicationServices.Abstraction;
using Ney_Nemovitost.web.Controllers;
using Ney_Nemovitost.web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Ney_Nemovitost.web.Models.Database;
using System.Linq;
using Microsoft.VisualBasic;
using Ney_Nemovitost.web.Models.Entities;
using Ney_Nemovitost.web.Models.Identity;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace Ney_Nemovitost.web.Areas.Vlastník.Controllers
{
    [Area("Vlastnik")]
    public class NajemnikController : Controller
    {
        readonly NemovitostDBContext dbContext;
        public NajemnikController(NemovitostDBContext _dbContext)
        {
            dbContext = _dbContext;
        }


        public IActionResult RegisterNajemnik()
        {
            RegisterNajmceViewModel viewModel = new RegisterNajmceViewModel()
            {
                date = DateTime.Now,
                predvolbys = dbContext.Predvolbies.ToList()
            };
            return View(viewModel);
        }

        public IActionResult VyberNajemnik()
        {
            User vlastnik = dbContext.Users
                .FirstOrDefault(o => o.UserName == User.Identity.Name);
            if (vlastnik == null) return NotFound();
            List<Najemnik> najemniks = dbContext.Najemniks
                .Where(o => o.vlastnikID == vlastnik.Id)
                .ToList();
            return View(najemniks);
        }

        public IActionResult EditNajemnik(int id)
        {
            User vlastnik = dbContext.Users
                .FirstOrDefault(o => o.UserName == User.Identity.Name);
            if (vlastnik == null) { return NotFound(); }
            Najemnik najemnik = dbContext.Najemniks
                .Where(o => o.vlastnikID == vlastnik.Id)
                .Where(o => o.ID == id)
                .Include(o => o.modelAdresa)
                .FirstOrDefault();
            if (najemnik == null) return NotFound();
            RegisterNajmceViewModel viewModel = new RegisterNajmceViewModel()
            {
                najemnik = najemnik,
                predvolbys = dbContext.Predvolbies.ToList(),
                Obec = najemnik.modelAdresa.Obec,
                Psc = najemnik.modelAdresa.Psc,
                UliceACisloPop = najemnik.modelAdresa.UliceACisloPop,
                date = new DateTime(najemnik.datumNarozeni.Year, najemnik.datumNarozeni.Month, najemnik.datumNarozeni.Day)
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditNajemnik(RegisterNajmceViewModel registerViewModel)
        {
            User vlastnik = dbContext.Users
                .FirstOrDefault(o => o.UserName == User.Identity.Name);
            if (vlastnik == null) { return NotFound(); }
            ModelState.Remove("predvolbys");

            if (ModelState.IsValid)
            {
                string chyba = CheckValidation(registerViewModel);
                if (chyba.Length > 0)
                {
                    registerViewModel.predvolbys = dbContext.Predvolbies.ToList();
                    ViewBag.chyba = chyba;
                    return View(registerViewModel);
                }
                Najemnik najemnik = dbContext.Najemniks
                .FirstOrDefault(o => o.ID == registerViewModel.najemnik.ID);
                if (najemnik == null) return NotFound();
                if (najemnik.vlastnikID != vlastnik.Id) return NotFound();
                //if (registerViewModel.najemnik.vlastnikID != vlastnik.Id) return NotFound();
                int idAdresaVlastnika = najemnik.idAdresa;

                najemnik.prijmeni = registerViewModel.najemnik.prijmeni;
                najemnik.jmeno = registerViewModel.najemnik.jmeno;
                najemnik.rodneCislo = registerViewModel.najemnik.rodneCislo;
                najemnik.email = registerViewModel.najemnik.email;
                najemnik.idPredvolby = registerViewModel.najemnik.idPredvolby;
                najemnik.telefon = registerViewModel.najemnik.telefon;
                najemnik.datumNarozeni = DateOnly.Parse(registerViewModel.date.ToString("yyyy-MM-dd"));
                ModelAdresa modelAdresa = new ModelAdresa()
                {
                    Id = idAdresaVlastnika,
                    Obec = registerViewModel.Obec,
                    Psc = registerViewModel.Psc,
                    UliceACisloPop = registerViewModel.UliceACisloPop,
                };
                dbContext.Update(modelAdresa);
                dbContext.Update(najemnik);
                dbContext.SaveChanges();

                return RedirectToAction(nameof(Index), "", new { area = "" });
            }
            registerViewModel.predvolbys = dbContext.Predvolbies.ToList();
            return View(registerViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> RegisterNajemnik(RegisterNajmceViewModel registerViewModel)
        {
            User vlastnik = dbContext.Users
                .FirstOrDefault(o => o.UserName == User.Identity.Name);
            if (vlastnik == null) { return NotFound(); }

            ModelState.Remove("predvolbys");

            if (ModelState.IsValid)
            {
                string chyba = CheckValidation(registerViewModel);
                if (chyba.Length > 0)
                {
                    registerViewModel.predvolbys = dbContext.Predvolbies.ToList();
                    ViewBag.chyba = chyba;
                    return View(registerViewModel);
                }
                registerViewModel.najemnik.vlastnikID = vlastnik.Id;
                registerViewModel.najemnik.datumNarozeni = DateOnly.Parse(registerViewModel.date.ToString("yyyy-MM-dd"));
                ModelAdresa modelAdresa = new ModelAdresa()
                {
                    Obec = registerViewModel.Obec,
                    Psc = registerViewModel.Psc,
                    UliceACisloPop = registerViewModel.UliceACisloPop,
                };
                dbContext.Add(modelAdresa);
                dbContext.SaveChanges();
                registerViewModel.najemnik.idAdresa = modelAdresa.Id;
                dbContext.Add(registerViewModel.najemnik);
                dbContext.SaveChanges();

                return RedirectToAction(nameof(Index), "", new { area = "" });
            }
            registerViewModel.predvolbys = dbContext.Predvolbies.ToList();
            return View(registerViewModel);
        }

        private static string CheckValidation(RegisterNajmceViewModel registerViewModel)
        {
            string chyba = "";
            if (string.IsNullOrWhiteSpace(registerViewModel.najemnik.email))
            {
                chyba += "Neplatný email\n";
            }
            else
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                if (regex.IsMatch(registerViewModel.najemnik.email) == false)
                {
                    chyba += "Neplatný email\n";
                }
            }
            if (registerViewModel.najemnik.jmeno.Length > 50)
            {
                chyba += "Jmeno může mít maximálně 50 znaků\n";
            }
            if (registerViewModel.najemnik.prijmeni.Length > 50)
            {
                chyba += "Příjmení může mít maximálně 50 znaků\n";
            }
            {
                string pattern = @"^\d{6}\/\d{4}$";
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                if (regex.IsMatch(registerViewModel.najemnik.rodneCislo) == false)
                {
                    chyba += "Neplatné rodné číslo\n";
                }
            }
            if (registerViewModel.UliceACisloPop.Length > 150)
            {
                chyba += "Ulice a číslo popisný může mít maximálně 150 znaků\n";
            }
            else if (registerViewModel.UliceACisloPop.Length < 3)
            {
                chyba += "Ulice a číslo popisný musí mít minimálně 3 znaky\n";
            }

            if (registerViewModel.Obec.Length > 100)
            {
                chyba += "Obec může mít maximálně 100 znaků\n";
            }
            else if (registerViewModel.Obec.Length < 2)
            {
                chyba += "Obec musí mít minimálně 2 znaky\n";
            }
            {
                registerViewModel.Psc = registerViewModel.Psc.Replace(" ", "");
                string pattern = @"^\d{5}$";
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                if (regex.IsMatch(registerViewModel.Psc) == false)
                {
                    chyba += "Neplatné PSČ\n";
                }
            }
            {
                registerViewModel.najemnik.telefon = registerViewModel.najemnik.telefon.Replace(" ", "");
                string pattern = @"^\d{6,9}$";
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                if (regex.IsMatch(registerViewModel.najemnik.telefon) == false)
                {
                    chyba += "Neplatné telefoní číslo\n";
                }
            }

            return chyba;
        }
    }
}
