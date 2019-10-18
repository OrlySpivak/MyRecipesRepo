namespace RecipesProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orly : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "FoodTypeID", "dbo.FoodTypes");
            DropIndex("dbo.Recipes", new[] { "FoodTypeID" });
            RenameColumn(table: "dbo.Recipes", name: "FoodTypeID", newName: "FoodType_ID1");
            AddColumn("dbo.Recipes", "FoodType_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Recipes", "FoodType_ID1", c => c.Int());
            CreateIndex("dbo.Recipes", "FoodType_ID1");
            AddForeignKey("dbo.Recipes", "FoodType_ID1", "dbo.FoodTypes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "FoodType_ID1", "dbo.FoodTypes");
            DropIndex("dbo.Recipes", new[] { "FoodType_ID1" });
            AlterColumn("dbo.Recipes", "FoodType_ID1", c => c.Int(nullable: false));
            DropColumn("dbo.Recipes", "FoodType_ID");
            RenameColumn(table: "dbo.Recipes", name: "FoodType_ID1", newName: "FoodTypeID");
            CreateIndex("dbo.Recipes", "FoodTypeID");
            AddForeignKey("dbo.Recipes", "FoodTypeID", "dbo.FoodTypes", "ID", cascadeDelete: true);
        }
    }
}
