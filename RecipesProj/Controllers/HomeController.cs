using RecipesProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipesProj.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewBag.MainTitle = "MyRecipes";
            ViewBag.SubTitle = "all your favorites, in one place";

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Talk to us!";

            var azrieli = db.BranchLocation.FirstOrDefault(loc => loc.BranchNum == 1);
            var colman = db.BranchLocation.FirstOrDefault(loc => loc.BranchNum == 2);

            ViewData["azrieliLat"] = azrieli.Lat;
            ViewData["azrieliLong"] = azrieli.Long;
            ViewData["colmanLat"] = colman.Lat;
            ViewData["colmanLong"] = colman.Long;

            return View();
        }
    }
}