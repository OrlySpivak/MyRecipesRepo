using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RecipesProj.Models
{
    public class StatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Stats
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Graph()
        {
            var result = (from r in db.Recipes select r).GroupBy(recipe => recipe.FoodType).Select(n => new
            {
                Type = n.Key.Type,
                Count = n.Count()
            }
            ).ToArray();
            // We can't send anonymos class to front.
            RecepiesPerType[] recepiesPerType = new RecepiesPerType[result.Length];
            for (int i = 0; i < result.Length; i++)
            {
                recepiesPerType[i] = new RecepiesPerType(result[i].Type, result[i].Count);
            }
            ViewBag.recepiesPerType = recepiesPerType;


            var result2 = (from r in db.Recipes select r).GroupBy(recipe => DbFunctions.TruncateTime(recipe.InsertDate)).Select(n => new
            {
                Date = n.Key,
                Count = n.Count()
            }
            ).OrderBy(n => n.Date).ToArray();
            // We can't send anonymos class to front.
            RecepiesPerDay[] recepiesPerDay = new RecepiesPerDay[result2.Length];
            for (int i = 0; i < result2.Length; i++)
            {
                if (result2[i].Date != null) // `TruncateTime` can return `null`.
                {
                    DateTime date = (DateTime)result2[i].Date;
                    recepiesPerDay[i] = new RecepiesPerDay(date, result2[i].Count);
                }
            }
            ViewBag.recepiesPerDay = recepiesPerDay;

            return View();
        }

        public class RecepiesPerType
        {
            public int Count { get; set; }
            public string Type { get; set; }

            public RecepiesPerType(string type, int count)
            {
                Count = count;
                Type = type;
            }
        }

        public class RecepiesPerDay
        {
            public int Count { get; set; }
            public string Date { get; set; }

            public RecepiesPerDay(DateTime date, int count)
            {
                Count = count;
                Date = date.Date.ToString("dd.MM.yy");
            }
        }
    }
}