namespace RecipesProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class name : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredients", "Recipe_ID", "dbo.Recipes");
            DropIndex("dbo.Ingredients", new[] { "Recipe_ID" });
            CreateTable(
                "dbo.RecipeIngredients",
                c => new
                    {
                        Recipe_ID = c.Int(nullable: false),
                        Ingredient_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_ID, t.Ingredient_ID })
                .ForeignKey("dbo.Recipes", t => t.Recipe_ID, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_ID, cascadeDelete: true)
                .Index(t => t.Recipe_ID)
                .Index(t => t.Ingredient_ID);
            
            DropColumn("dbo.Ingredients", "Recipe_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredients", "Recipe_ID", c => c.Int());
            DropForeignKey("dbo.RecipeIngredients", "Ingredient_ID", "dbo.Ingredients");
            DropForeignKey("dbo.RecipeIngredients", "Recipe_ID", "dbo.Recipes");
            DropIndex("dbo.RecipeIngredients", new[] { "Ingredient_ID" });
            DropIndex("dbo.RecipeIngredients", new[] { "Recipe_ID" });
            DropTable("dbo.RecipeIngredients");
            CreateIndex("dbo.Ingredients", "Recipe_ID");
            AddForeignKey("dbo.Ingredients", "Recipe_ID", "dbo.Recipes", "ID");
        }
    }
}
