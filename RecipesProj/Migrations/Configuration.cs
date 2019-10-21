namespace RecipesProj.Migrations
{
    using RecipesProj.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RecipesProj.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(RecipesProj.Models.ApplicationDbContext context)
        {
            context.BranchLocation.AddOrUpdate(
                  p => p.BranchNum,
                  new BranchLocation { Name = "Azrieli", BranchNum = 1, Lat = 32.075069, Long = 34.79084 },
                  new BranchLocation { Name = "College Of Management", BranchNum = 2, Lat = 31.96891, Long = 34.770729 }
                );
        }
    }
}
