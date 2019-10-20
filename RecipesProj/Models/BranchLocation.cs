using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipesProj.Models
{
    public class BranchLocation
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int BranchNum { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}