namespace Shaker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventory", "Liquor", c => c.String());
            AddColumn("dbo.Inventory", "Juice", c => c.String());
            AddColumn("dbo.Inventory", "Fruit", c => c.String());
            AddColumn("dbo.Inventory", "Other", c => c.String());
            DropColumn("dbo.Inventory", "InventoryLiquor");
            DropColumn("dbo.Inventory", "InventoryJuice");
            DropColumn("dbo.Inventory", "InventoryFruit");
            DropColumn("dbo.Inventory", "InventoryOther");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inventory", "InventoryOther", c => c.String());
            AddColumn("dbo.Inventory", "InventoryFruit", c => c.String());
            AddColumn("dbo.Inventory", "InventoryJuice", c => c.String());
            AddColumn("dbo.Inventory", "InventoryLiquor", c => c.String());
            DropColumn("dbo.Inventory", "Other");
            DropColumn("dbo.Inventory", "Fruit");
            DropColumn("dbo.Inventory", "Juice");
            DropColumn("dbo.Inventory", "Liquor");
        }
    }
}
