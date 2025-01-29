
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ney_Nemovitost.web.Models.Database;
using Ney_Nemovitost.web.Models.Entities;
using Ney_Nemovitost.web.Models.Identity;


namespace Ney_Nemovitost.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly NemovitostDBContext dbContext;

        public HomeController(ILogger<HomeController> logger, NemovitostDBContext nemovitostDBContext)
        {
            dbContext = nemovitostDBContext;
            _logger = logger;
        }

        public IActionResult Index()
        {


            User vlastnik = dbContext.Users
    .FirstOrDefault(o => o.UserName == User.Identity.Name);
            if (vlastnik != null)
            {
                List<ModelNemovitost> modelNemovitosts = dbContext.Nemovitosts
                    .Where(o => o.idVlastnik == vlastnik.Id)
                    .Include(o => o.adresa)
                    .Include(o => o.dispoziceNemovitosti).ToList();
                if(modelNemovitosts.Count > 6 ) { modelNemovitosts = modelNemovitosts.Take(6).ToList(); }
                if (modelNemovitosts != null)
                {
                    foreach(var item in modelNemovitosts)
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

        public IActionResult Privacy()
        {
            return View();
        }

    }
}