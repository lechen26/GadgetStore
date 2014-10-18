namespace GadgetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        PhotoUrl = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        PhotoUrl = c.String(),
                        CategoryId = c.Int(nullable: false),
                        ManufactureId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseAmount = c.Int(nullable: false),
                        AddedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Manufactures", t => t.ManufactureId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.ManufactureId);
            
            CreateTable(
                "dbo.Manufactures",
                c => new
                    {
                        ManufactureId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        PhotoUrl = c.String(),
                    })
                .PrimaryKey(t => t.ManufactureId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Items", new[] { "ManufactureId" });
            DropIndex("dbo.Items", new[] { "CategoryId" });
            DropForeignKey("dbo.Items", "ManufactureId", "dbo.Manufactures");
            DropForeignKey("dbo.Items", "CategoryId", "dbo.Categories");
            DropTable("dbo.Manufactures");
            DropTable("dbo.Items");
            DropTable("dbo.Categories");
        }
    }
}
