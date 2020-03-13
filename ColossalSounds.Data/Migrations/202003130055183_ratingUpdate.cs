namespace ColossalSounds.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ratingUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accessory", "Rating_Id", "dbo.Rate");
            DropIndex("dbo.Accessory", new[] { "Rating_Id" });
            CreateTable(
                "dbo.ProductRating",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StarRating = c.Int(nullable: false),
                        InstrumentId = c.Int(nullable: false),
                        AccessoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accessory", t => t.AccessoryId, cascadeDelete: true)
                .ForeignKey("dbo.Instrument", t => t.InstrumentId, cascadeDelete: true)
                .Index(t => t.InstrumentId)
                .Index(t => t.AccessoryId);
            
            AddColumn("dbo.Accessory", "AverageRating", c => c.Double(nullable: false));
            AddColumn("dbo.Instrument", "AverageRating", c => c.Double(nullable: false));
            DropColumn("dbo.Accessory", "Rating_Id");
            DropTable("dbo.Rate");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Rate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StarRating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Accessory", "Rating_Id", c => c.Int());
            DropForeignKey("dbo.ProductRating", "InstrumentId", "dbo.Instrument");
            DropForeignKey("dbo.ProductRating", "AccessoryId", "dbo.Accessory");
            DropIndex("dbo.ProductRating", new[] { "AccessoryId" });
            DropIndex("dbo.ProductRating", new[] { "InstrumentId" });
            DropColumn("dbo.Instrument", "AverageRating");
            DropColumn("dbo.Accessory", "AverageRating");
            DropTable("dbo.ProductRating");
            CreateIndex("dbo.Accessory", "Rating_Id");
            AddForeignKey("dbo.Accessory", "Rating_Id", "dbo.Rate", "Id");
        }
    }
}
