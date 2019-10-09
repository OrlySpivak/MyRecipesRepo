namespace RecipesProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecepie : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Ingredients", "Recipe_ID", c => c.Int());
            CreateIndex("dbo.Ingredients", "Recipe_ID");
            AddForeignKey("dbo.Ingredients", "Recipe_ID", "dbo.Recipes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredients", "Recipe_ID", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "FoodTypeID", "dbo.FoodTypes");
            DropIndex("dbo.Recipes", new[] { "FoodTypeID" });
            DropIndex("dbo.Ingredients", new[] { "Recipe_ID" });
            DropColumn("dbo.Ingredients", "Recipe_ID");
            DropTable("dbo.Recipes");
        }
    }
}
