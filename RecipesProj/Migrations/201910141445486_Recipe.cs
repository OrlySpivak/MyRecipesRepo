namespace RecipesProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Recipe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Recipe_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Recipes", t => t.Recipe_ID)
                .Index(t => t.Recipe_ID);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VideoURL = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        InsertDate = c.DateTime(nullable: false),
                        FoodTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FoodTypes", t => t.FoodTypeID, cascadeDelete: true)
                .Index(t => t.FoodTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredients", "Recipe_ID", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "FoodTypeID", "dbo.FoodTypes");
            DropIndex("dbo.Recipes", new[] { "FoodTypeID" });
            DropIndex("dbo.Ingredients", new[] { "Recipe_ID" });
            DropTable("dbo.Recipes");
            DropTable("dbo.Ingredients");
        }
    }
}
