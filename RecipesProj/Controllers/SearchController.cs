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
    public class SearchController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Search
        public ActionResult Index()
        {
            var recipes = db.Recipes.ToList();
            return View(recipes);
        }

        // GET: Search with params
        
        public ActionResult Results(string id = null)
        {
            var allRecipes = db.Recipes.ToList();
            var recipes = new List<Recipe>();
            if (!string.IsNullOrEmpty(id))
            {
                // By recipe name
                recipes.AddRange(allRecipes.Where(recipe => recipe.Name.ToLowerInvariant().Contains(id.ToLowerInvariant())));
                // By ingrediant name
                recipes.AddRange(allRecipes.Where(recipe => recipe.Ingredients.Select(ing => ing.Name.ToLowerInvariant()).Contains(id)));
            }
            return View(recipes);
        }

    }
}