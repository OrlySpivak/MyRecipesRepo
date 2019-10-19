using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipesProj.Controllers
{
    public class HomeController : Controller
    {
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

            return View();
        }
    }
}