using Microsoft.AspNetCore.Mvc;
using Ney_Nemovitost.web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Ney_Nemovitost.web.Models.Database;
using Ney_Nemovitost.web.Models.Entities;
using Ney_Nemovitost.web.Models.Identity;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace Ney_Nemovitost.web.Areas.Vlastník.Controllers
{
    [Area("Vlastnik")]
    public class NemovitostController : Controller
    {
        readonly NemovitostDBContext dbContext;
        public NemovitostController(NemovitostDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public IActionResult DetailNemovitosti(int id)
        {
            User vlastnik = dbContext.Users
                .FirstOrDefault(o => o.UserName == User.Identity.Name);
            if (vlastnik == null) { return NotFound(); }
            ModelNemovitost modelNemovitost = dbContext.Nemovitosts
                .Include(o => o.dispoziceNemovitosti)
                .Include(o => o.enerNarocnost)
                .Include(o => o.adresa)
                .Include(o => o.optionNemovitost)
                .FirstOrDefault(o => o.ID == id);
            if (modelNemovitost == null) { return NotFound(); }
            if (modelNemovitost.idVlastnik != vlastnik.Id) { return NotFound(); }
            modelNemovitost.fotografie = dbContext.FotoNemovitis
                .Where(o => o.Id_Nemo == id).ToList();
            List<HistorieCen> historieCens = dbContext.HistorieCens.Where(x => x.idNemovitosti == modelNemovitost.ID)
                .OrderByDescending(o => o.ID)
                .ToList();
            DetailNemovitostViewModel viewModel = new DetailNemovitostViewModel()
            {
                modelNemovitost = modelNemovitost,

            };
            foreach (int value in Enumerable.Range(2, 7))
            {
                int cena = (int)historieCens.Where(x => x.idSluzby == value).Select(x => x.cena).First();
                if (value == 2) viewModel.cenaVody = cena;
                else if (value == 3) viewModel.cenaPlynu = cena;
                else if (value == 4) viewModel.cenaElektriky = cena;
                else if (value == 5) viewModel.cenaInternetu = cena;
                else if (value == 6) viewModel.cenaUklidu = cena;
                else if (value == 7) viewModel.cenaOdpadu = cena;
                else if (value == 8) viewModel.cenaSpolecneEleketriky = cena;

            }
            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> EditNemovitost(RegisterNemovitostViewModel registerViewModel)
        {
            ModelState.Remove("FotoNems");
            ModelState.Remove("Images");
            ModelState.Remove("Dispozices");
            ModelState.Remove("enerNarocnostNemovitostis");
            ModelState.Remove("typBudovy");

            if (ModelState.IsValid)
            {
                User vlastnik = dbContext.Users
                .FirstOrDefault(o => o.UserName == User.Identity.Name);
                if (vlastnik == null) { return NotFound(); }
                
                ModelNemovitost modelNemovitost = dbContext.Nemovitosts
                    .Include(o => o.adresa)
                    .FirstOrDefault(o => o.ID == registerViewModel.modelNemovitost.ID);
                if (modelNemovitost == null) { return NotFound(); }
                if (modelNemovitost.idVlastnik != vlastnik.Id) { return NotFound(); }
                string s = CheckValue(registerViewModel);
                if (DateTime.Compare(modelNemovitost.dostupnostOd.ToDateTime(TimeOnly.Parse("0:0 AM")), registerViewModel.date) != 0)
                {
                    if (DateTime.Compare(registerViewModel.date, DateTime.Now.Date) < 0)
                    {
                        s += "Dostupnost nemůže být dříve než dnešek\n";
                    }
                }
                double novaCenaEnergii = SectiEnergie(registerViewModel);
                double novaCenaSluzeb = SectiSluzby(registerViewModel);
                if (modelNemovitost.cenaEnergii != novaCenaEnergii || modelNemovitost.cenaSluzeb != novaCenaSluzeb || modelNemovitost.cenaNajmu != registerViewModel.modelNemovitost.cenaNajmu)
                {
                    List<HistorieCen> historieCens = dbContext.HistorieCens.Where(x => x.idNemovitosti == modelNemovitost.ID)
                        .OrderByDescending(o => o.ID)
                        .ToList();
                    if (modelNemovitost.cenaNajmu != registerViewModel.modelNemovitost.cenaNajmu)
                    {
                        HistorieCen historieCen = historieCens.First(o => o.idSluzby == 1);
                        DateTime a = historieCen.cenaPlatnaOd.ToDateTime(TimeOnly.Parse("0:0 AM"));
                        int rozdilDatumu = DateTime.Compare(a, registerViewModel.datumOd);
                        if (rozdilDatumu <= 0)
                        {
                               if (rozdilDatumu < 0)
                                {
                                    dbContext.Add(new HistorieCen() { idNemovitosti = modelNemovitost.ID, cena = registerViewModel.modelNemovitost.cenaNajmu, cenaPlatnaOd = DateOnly.Parse(registerViewModel.datumOd.ToString("yyyy-MM-dd")), idSluzby = 1 });
                                }
                                else
                                {
                                    historieCen.cena = registerViewModel.modelNemovitost.cenaNajmu;
                                    dbContext.Update(historieCen);
                                }
                        }
                        else
                        {
                            s += "Datum změny nájmu je dříve než definované datum\n";
                        }
                        modelNemovitost.cenaNajmu = registerViewModel.modelNemovitost.cenaNajmu;
                    }
                    if (modelNemovitost.cenaEnergii != novaCenaEnergii)
                    {
                        modelNemovitost.cenaEnergii = novaCenaEnergii;
                        foreach (int value in Enumerable.Range(2, 3))
                        {
                            HistorieCen historieCen = historieCens.First(o => o.idSluzby == value);
                            DateTime a = historieCen.cenaPlatnaOd.ToDateTime(TimeOnly.Parse("0:0 AM"));
                            int rozdilDatumu = DateTime.Compare(a, registerViewModel.datumOd);
                            if (rozdilDatumu <= 0)
                            {
                                double cena = historieCen.cena;
                                if (value == 2) cena = registerViewModel.cenaVody;
                                else if (value == 3) cena = registerViewModel.cenaPlynu;
                                else if (value == 4) cena = registerViewModel.cenaElektriky;
                                if (cena != historieCen.cena)
                                {
                                    if (rozdilDatumu < 0)
                                    {
                                        dbContext.Add(new HistorieCen() { idNemovitosti = modelNemovitost.ID, cena = cena, cenaPlatnaOd = DateOnly.Parse(registerViewModel.datumOd.ToString("yyyy-MM-dd")), idSluzby = value });
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
                                s += "Datum změny energie je dříve než definované datum\n";
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
                            int rozdilDatumu = DateTime.Compare(historieCen.cenaPlatnaOd.ToDateTime(TimeOnly.Parse("0:0 AM")), registerViewModel.datumOd);
                            if (rozdilDatumu <= 0)
                            {
                                double cena = historieCen.cena;
                                if (value == 5) cena = registerViewModel.cenaInternetu;
                                else if (value == 6) cena = registerViewModel.cenaUklidu;
                                else if (value == 7) cena = registerViewModel.cenaOdpadu;
                                else if (value == 8) cena = registerViewModel.cenaSpolecneEleketriky;
                                if (cena != historieCen.cena)
                                {
                                    if (rozdilDatumu < 0)
                                    {
                                        dbContext.Add(new HistorieCen() { idNemovitosti = modelNemovitost.ID, cena = cena, cenaPlatnaOd = DateOnly.Parse(registerViewModel.datumOd.ToString("yyyy-MM-dd")), idSluzby = value });
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
                                s += "Datum změny služeb je dříve než definované datum\n";
                                continue;
                            }
                        }
                    }
                }
                if (s.Length != 0)
                    {
                        registerViewModel.Dispozices = dbContext.dispoziceNemovitostis.ToList();
                        registerViewModel.enerNarocnostNemovitostis = dbContext.EnerNarocnostNemovitostis.ToList();
                        registerViewModel.typBudovy = dbContext.NemovitostTyps.ToList();
                        ViewBag.chyba = s;
                        return View(registerViewModel);
                    }
                dbContext.SaveChanges();
                modelNemovitost.cenaNajmu = registerViewModel.modelNemovitost.cenaNajmu;
                modelNemovitost.dostupnostOd = DateOnly.Parse(registerViewModel.date.ToString("yyyy-MM-dd"));
                modelNemovitost.idDizpozice = registerViewModel.modelNemovitost.idDizpozice;
                modelNemovitost.idTypBudovy = registerViewModel.modelNemovitost.idTypBudovy;
                modelNemovitost.idEneNarocnosti = registerViewModel.modelNemovitost.idEneNarocnosti;


                modelNemovitost.adresa.UliceACisloPop = registerViewModel.UliceACisloPop;
                modelNemovitost.adresa.Obec = registerViewModel.Obec;
                modelNemovitost.adresa.Psc = registerViewModel.Psc.Replace(" ", "");

                dbContext.Update(modelNemovitost);
                dbContext.Update(modelNemovitost.adresa);
                dbContext.SaveChanges();
                int indexNem = modelNemovitost.ID;

                List<FotoNem> fotoNems = new List<FotoNem>();
                if (registerViewModel.Images != null)
                {
                    foreach (var foto in registerViewModel.Images)
                    {
                        var fileName = Path.Combine("imgs/fotoNem", Guid.NewGuid().ToString() + Path.GetExtension(foto.FileName));
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);

                        // Save the file to disk
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await foto.CopyToAsync(stream);
                        }
                        FotoNem fotoNem1 = new FotoNem()
                        {
                            Id_Nemo = indexNem,
                            ImageSrc = "/" + fileName
                        };
                        dbContext.Add(fotoNem1);
                    }
                    dbContext.SaveChanges();
                }
                return RedirectToAction(nameof(Index), "", new { area = "" });
            }
            registerViewModel.Dispozices = dbContext.dispoziceNemovitostis.ToList();
            registerViewModel.enerNarocnostNemovitostis = dbContext.EnerNarocnostNemovitostis.ToList();
            registerViewModel.typBudovy = dbContext.NemovitostTyps.ToList();
            return View(registerViewModel);
        }

        [HttpPost]
        public JsonResult DeleteImage(int id)
        {
            User vlastnik = dbContext.Users
                .FirstOrDefault(o => o.UserName == User.Identity.Name);

            if (vlastnik != null)
            {
                FotoNem fotoNem = dbContext.FotoNemovitis
                    .Include(o => o.modelNemovitost)
                    .FirstOrDefault(o => o.Id == id);
                if (fotoNem != null && fotoNem.modelNemovitost.idVlastnik == vlastnik.Id)
                {
                    dbContext.FotoNemovitis.Remove(fotoNem);
                    dbContext.SaveChanges();
                    System.IO.File.Delete("wwwroot" + fotoNem.ImageSrc);
                    return Json(new { success = true });
                }
            }


            return Json(new { success = false });
        }

        public IActionResult MeNemovitosti()
        {
            User vlastnik = dbContext.Users
.FirstOrDefault(o => o.UserName == User.Identity.Name);
            if (vlastnik != null)
            {
                List<ModelNemovitost> modelNemovitosts = dbContext.Nemovitosts
                    .Where(o => o.idVlastnik == vlastnik.Id)
                    .Include(o => o.adresa)
                    .Include(o => o.dispoziceNemovitosti).ToList();
                if (modelNemovitosts != null)
                {
                    foreach (var item in modelNemovitosts)
                    {
                        FotoNem fotoNem = dbContext.FotoNemovitis.FirstOrDefault(o => o.Id_Nemo == item.ID);
                        if (fotoNem != null)
                        {
                            List<FotoNem> fotoNems = new List<FotoNem> { fotoNem };
                            item.fotografie = fotoNems;
                        }

                    }
                }
                return View(modelNemovitosts);
            }
            return View();
        }

        public IActionResult VyberNemovitostNem()
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

        public IActionResult EditNemovitost(int ?id)
        {
            if (id == null) return NotFound();
            User vlastnik = dbContext.Users
                .FirstOrDefault(o => o.UserName == User.Identity.Name);
            if (vlastnik == null) { return NotFound(); }
            ModelNemovitost modelNemovitost = dbContext.Nemovitosts
                .Where(o => o.vlastnik2.Id == vlastnik.Id)
                .Include(o => o.adresa)
                .FirstOrDefault(o => o.ID == id);
            if (modelNemovitost == null) { return NotFound(); }
            List<HistorieCen> historieCens = dbContext.HistorieCens.Where(x => x.idNemovitosti == modelNemovitost.ID)
                .OrderByDescending(o => o.ID)
                .ToList();
            RegisterNemovitostViewModel viewModel = new RegisterNemovitostViewModel()
            {
                Dispozices = dbContext.dispoziceNemovitostis.ToList(),
                enerNarocnostNemovitostis = dbContext.EnerNarocnostNemovitostis.ToList(),
                typBudovy = dbContext.NemovitostTyps.ToList(),
                date = new DateTime(modelNemovitost.dostupnostOd.Year, modelNemovitost.dostupnostOd.Month, modelNemovitost.dostupnostOd.Day),
                Psc = modelNemovitost.adresa.Psc,
                Obec = modelNemovitost.adresa.Obec,
                UliceACisloPop = modelNemovitost.adresa.UliceACisloPop,
                FotoNems = dbContext.FotoNemovitis.Where(o => o.Id_Nemo == modelNemovitost.ID).ToList(),
                modelNemovitost = modelNemovitost,
                datumOd = DateTime.Now,
            };
            foreach (int value in Enumerable.Range(2, 7))
            {
                int cena = (int)historieCens.Where(x => x.idSluzby == value).Select(x => x.cena).First();
                if (value == 2) viewModel.cenaVody = cena;
                else if (value == 3) viewModel.cenaPlynu = cena;
                else if (value == 4) viewModel.cenaElektriky = cena;
                else if (value == 5) viewModel.cenaInternetu = cena;
                else if (value == 6) viewModel.cenaUklidu = cena;
                else if (value == 7) viewModel.cenaOdpadu = cena;
                else if (value == 8) viewModel.cenaSpolecneEleketriky = cena;

            }
            return View(viewModel);
        }

        public IActionResult RegisterNemovitost()
        {
            RegisterNemovitostViewModel viewModel = new RegisterNemovitostViewModel()
            {
                date = DateTime.Now,
                Dispozices = dbContext.dispoziceNemovitostis.ToList(),
                enerNarocnostNemovitostis = dbContext.EnerNarocnostNemovitostis.ToList(),
                typBudovy = dbContext.NemovitostTyps.ToList(),
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterNemovitost(RegisterNemovitostViewModel registerViewModel)
        {
            ModelState.Remove("FotoNems");
            ModelState.Remove("Images");
            ModelState.Remove("Dispozices");
            ModelState.Remove("enerNarocnostNemovitostis");
            ModelState.Remove("typBudovy");
            ModelState.Remove("datumOd");

            if (ModelState.IsValid)
            {
                registerViewModel.modelNemovitost.cenaSluzeb = SectiSluzby(registerViewModel);
                registerViewModel.modelNemovitost.cenaEnergii = SectiEnergie(registerViewModel);

                registerViewModel.modelNemovitost.dostupnostOd = DateOnly.Parse(registerViewModel.date.ToString("yyyy-MM-dd"));
                User vlastnik = dbContext.Users
                    .FirstOrDefault(o => o.UserName == User.Identity.Name);
                if (vlastnik == null) { return NotFound(); }

                string s = CheckValue(registerViewModel);
                if (DateTime.Compare(registerViewModel.date, DateTime.Now.Date) < 0)
                {
                    s += "Dostupnost nemůže být dříve než dnešek\n";
                }
                if (s.Length != 0)
                {
                    registerViewModel.Dispozices = dbContext.dispoziceNemovitostis.ToList();
                    registerViewModel.enerNarocnostNemovitostis = dbContext.EnerNarocnostNemovitostis.ToList();
                    registerViewModel.typBudovy = dbContext.NemovitostTyps.ToList();
                    ViewBag.chyba = s;
                    return View(registerViewModel);
                }
                registerViewModel.modelNemovitost.idVlastnik = vlastnik.Id;

                ModelAdresa modelAdresa = new ModelAdresa()
                {
                    Obec = registerViewModel.Obec,
                    Psc = registerViewModel.Psc.Replace(" ", ""),
                    UliceACisloPop = registerViewModel.UliceACisloPop,
                };
                dbContext.Add(modelAdresa);
                dbContext.SaveChanges();
                registerViewModel.modelNemovitost.idAdresa = modelAdresa.Id;
                dbContext.Add(registerViewModel.modelNemovitost);

                dbContext.SaveChanges();
                int indexNem = registerViewModel.modelNemovitost.ID;
                if (indexNem == 0) { return NotFound(); }
                DateOnly platnaOd = DateOnly.Parse(registerViewModel.date.ToString("yyyy-MM-dd"));
                List<HistorieCen> historieCens = new List<HistorieCen>()
                {
                    new HistorieCen(){ idNemovitosti = indexNem, cena = registerViewModel.modelNemovitost.cenaNajmu, cenaPlatnaOd = platnaOd, idSluzby = 1},
                };
                dbContext.Add(new HistorieCen() { idNemovitosti = indexNem, cena = registerViewModel.modelNemovitost.cenaNajmu, cenaPlatnaOd = platnaOd, idSluzby = 1 });
                dbContext.Add(new HistorieCen() { idNemovitosti = indexNem, cena = registerViewModel.cenaVody, cenaPlatnaOd = platnaOd, idSluzby = 2 });
                dbContext.Add(new HistorieCen() { idNemovitosti = indexNem, cena = registerViewModel.cenaPlynu, cenaPlatnaOd = platnaOd, idSluzby = 3 });
                dbContext.Add(new HistorieCen() { idNemovitosti = indexNem, cena = registerViewModel.cenaElektriky, cenaPlatnaOd = platnaOd, idSluzby = 4 });
                dbContext.Add(new HistorieCen() { idNemovitosti = indexNem, cena = registerViewModel.cenaInternetu, cenaPlatnaOd = platnaOd, idSluzby = 5 });
                dbContext.Add(new HistorieCen() { idNemovitosti = indexNem, cena = registerViewModel.cenaUklidu, cenaPlatnaOd = platnaOd, idSluzby = 6 });
                dbContext.Add(new HistorieCen() { idNemovitosti = indexNem, cena = registerViewModel.cenaOdpadu, cenaPlatnaOd = platnaOd, idSluzby = 7 });
                dbContext.Add(new HistorieCen() { idNemovitosti = indexNem, cena = registerViewModel.cenaSpolecneEleketriky, cenaPlatnaOd = platnaOd, idSluzby = 8 });
                dbContext.SaveChanges();
                List<FotoNem> fotoNems = new List<FotoNem>();
                if (registerViewModel.Images != null)
                {
                    foreach (var foto in registerViewModel.Images)
                    {
                        var fileName = Path.Combine("imgs/fotoNem", Guid.NewGuid().ToString() + Path.GetExtension(foto.FileName));
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await foto.CopyToAsync(stream);
                        }
                        FotoNem fotoNem1 = new FotoNem()
                        {
                            Id_Nemo = indexNem,
                            ImageSrc = "/" + fileName
                        };
                        dbContext.Add(fotoNem1);
                    }
                    dbContext.SaveChanges();
                }
                return RedirectToAction(nameof(Index), "", new { area = "" });
            }
            registerViewModel.Dispozices = dbContext.dispoziceNemovitostis.ToList();
            registerViewModel.enerNarocnostNemovitostis = dbContext.EnerNarocnostNemovitostis.ToList();
            registerViewModel.typBudovy = dbContext.NemovitostTyps.ToList();
            return View(registerViewModel);
        }

        private double SectiSluzby(RegisterNemovitostViewModel registerViewModel)
        {
            return registerViewModel.cenaInternetu + registerViewModel.cenaUklidu + registerViewModel.cenaOdpadu + registerViewModel.cenaSpolecneEleketriky;
        }
        private double SectiEnergie(RegisterNemovitostViewModel registerViewModel)
        {
            return registerViewModel.cenaVody + registerViewModel.cenaElektriky + registerViewModel.cenaPlynu;
        }
        private string CheckValue(RegisterNemovitostViewModel registerViewModel)
        {
            registerViewModel.Psc = registerViewModel.Psc.Replace(" ", "");
            string chyba = "";
            if (registerViewModel.modelNemovitost.cenaEnergii < 0)
            {
                chyba += "Cena energií nemůže být menší než 0\n";
            }
            if (registerViewModel.modelNemovitost.cenaSluzeb < 0)
            {
                chyba += "Cena služeb nemůže být menší než 0\n";
            }
            if (registerViewModel.modelNemovitost.cenaNajmu < 0)
            {
                chyba += "Cena nájmu nemůže být menší než 0\n";
            }
            if(registerViewModel.UliceACisloPop.Length < 3)
            {
                chyba += "minimální délka ulice a čísla pop. je 3\n";
            }
            if (registerViewModel.UliceACisloPop.Length > 150)
            {
                chyba += "maximální délka ulice a čísla pop. je 150\n";
            }
            if (registerViewModel.Obec.Length < 1)
            {
                chyba += "minimální délka obce a čísla pop. je 1\n";
            }
            if (registerViewModel.Obec.Length > 150)
            {
                chyba += "maximální délka obce je 150\n";
            }
            string pattern = @"^\d{5}$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(registerViewModel.Psc) == false)
            {
                chyba += "Neplatné PSČ\n";
            }

            return chyba;
        }
    }
}
