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

        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Video URL")]
        public string VideoURL { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yy H:mm:ss}")]
        public DateTime InsertDate { get; set; }

        [Display(Name = "Food Type")]
        public int FoodTypeId { get; set; }

        public virtual FoodType FoodType { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}