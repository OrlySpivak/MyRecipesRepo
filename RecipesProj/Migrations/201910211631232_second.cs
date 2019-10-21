namespace RecipesProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Recipes", new[] { "FoodTypeID" });
            CreateTable(
                "dbo.BranchLocations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BranchNum = c.Int(nullable: false),
                        Lat = c.Double(nullable: false),
                        Long = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Recipes", "FoodTypeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Recipes", new[] { "FoodTypeId" });
            DropTable("dbo.BranchLocations");
            CreateIndex("dbo.Recipes", "FoodTypeID");
        }
    }
}
