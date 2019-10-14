using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipesProj.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        public string VideoURL { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime InsertDate { get; set; }
        public int FoodTypeID { get; set; }
        public virtual FoodType FoodType { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}