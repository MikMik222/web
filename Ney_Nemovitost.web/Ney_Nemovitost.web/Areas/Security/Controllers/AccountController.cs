using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Ney_Nemovitost.web.Models.ApplicationServices.Abstraction;
using Ney_Nemovitost.web.Controllers;
using Ney_Nemovitost.web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Ney_Nemovitost.web.Models.Database;
using System.Linq;
using Ney_Nemovitost.web.Models.Entities;
using System.Text.RegularExpressions;

namespace Ney_Nemovitost.web.Areas.Security.Controllers
{
    [Area("Security")]
    public class AccountController : Controller
    {
        readonly ISecurityApplicationService securityService;
        readonly NemovitostDBContext dbContext;
        public AccountController(ISecurityApplicationService securityService, NemovitostDBContext _dbContext)
        {
            dbContext = _dbContext;
            this.securityService = securityService;
        }


        public IActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel()
            {
                datumNarozeni = DateTime.Now,
                Predvolbys = dbContext.Predvolbies.ToList(),
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            registerVM.Username = registerVM.Username.Trim();
            ModelState.Remove(nameof(registerVM.Email));
            ModelState.Remove(nameof(registerVM.Predvolbys));
            registerVM.Predvolbys = dbContext.Predvolbies.ToList();
            if (ModelState.IsValid)
            {
                bool returnView = false;
                var user = dbContext.Users.FirstOrDefault(o => o.UserName == registerVM.Username);
                if(user != null)
                {
                    ViewBag.info = "Email is taken";
                    returnView = true;
                }
                string s = CheckValidation(registerVM);
                if (s.Length > 0) ViewBag.chyba = s;
                if (returnView || s.Length > 0) {
                    registerVM.Predvolbys = dbContext.Predvolbies.ToList();
                    return View(registerVM); 
                }
                ModelAdresa adresa = new ModelAdresa()
                {
                    Obec = registerVM.Obec,
                    UliceACisloPop = registerVM.UliceACisloPop,
                    Psc = registerVM.Psc
                };

                dbContext.Adresas.Add(adresa);
                dbContext.SaveChanges();
                registerVM.Id = adresa.Id;
                string[] errors = await securityService.Register(registerVM, Models.Identity.Roles.Vlastnik_Registrovany);
                if (errors == null)
                {
                    LoginViewModel loginViewModel = new LoginViewModel()
                    {
                        Username = registerVM.Username,
                        Password = registerVM.Password
                    };

                    return await Login(loginViewModel);
                }

            }

            return View(registerVM);
        }



        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            ModelState.Remove(nameof(loginVM.Username));
            if (ModelState.IsValid)
            {
                loginVM.LoginFailed = !await securityService.Login(loginVM);
                if (loginVM.LoginFailed == false)
                    return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", String.Empty), new { area = String.Empty });
            }

            return View(loginVM);
        }

        private static string CheckValidation(RegisterViewModel registerViewModel)
        {
            string chyba = "";
            if (string.IsNullOrWhiteSpace(registerViewModel.Username))
            {
                chyba += "Neplatný email\n";
            }
            else
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                if (regex.IsMatch(registerViewModel.Username) == false)
                {
                    chyba += "Neplatný email\n";
                }
            }
            if (registerViewModel.FirstName.Length > 50)
            {
                chyba += "Jmeno může mít maximálně 50 znaků\n";
            }
            if (registerViewModel.LastName.Length > 50)
            {
                chyba += "Příjmení může mít maximálně 50 znaků\n";
            }
            {
                string pattern = @"^\d{6}\/\d{4}$";
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                if (regex.IsMatch(registerViewModel.rodneCislo) == false)
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
                registerViewModel.Phone = registerViewModel.Phone.Replace(" ", "");
                string pattern = @"^\d{6,9}$";
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                if (regex.IsMatch(registerViewModel.Phone) == false)
                {
                    chyba += "Neplatné telefoní číslo\n";
                }
            }
            {
                string pattern = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}$";
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                if (regex.IsMatch(registerViewModel.Password) == false)
                {
                    chyba += "Nejsou splněny požadavky na heslo\n";
                }
            }

            return chyba;
        }


        public async Task<IActionResult> Logout()
        {
            await securityService.Logout();
            return RedirectToAction(nameof(Login));
        }

    }
}
