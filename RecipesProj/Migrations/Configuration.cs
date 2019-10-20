namespace RecipesProj.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using RecipesProj.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RecipesProj.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(RecipesProj.Models.ApplicationDbContext context)
        {
            var branchLocations = new List<BranchLocation>
            {
                new BranchLocation{BranchNum = 1, Name = "Azrieli", Lat = 32.075069, Long = 34.790840},
                new BranchLocation{BranchNum = 2, Name = "College Of Management", Lat = 31.968910, Long = 34.770729},
            };

            branchLocations.ForEach(bl => context.BranchLocation.Add(bl));
            context.SaveChanges();
        }
    }
}
