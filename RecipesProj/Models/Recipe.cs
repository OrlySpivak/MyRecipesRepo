using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RecipesProj.Models
{
    public class Recipe
    {
        [Key]
        public int ID { get; set; }
        public string VideoURL { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime InsertDate { get; set; }
        public int FoodType_ID { get; set; }
        public virtual FoodType FoodType { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}