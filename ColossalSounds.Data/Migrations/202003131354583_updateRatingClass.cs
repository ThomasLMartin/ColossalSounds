namespace ColossalSounds.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateRatingClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductRating", "AccessoryId", "dbo.Accessory");
            DropForeignKey("dbo.ProductRating", "InstrumentId", "dbo.Instrument");
            DropIndex("dbo.ProductRating", new[] { "InstrumentId" });
            DropIndex("dbo.ProductRating", new[] { "AccessoryId" });
            DropPrimaryKey("dbo.ProductRating");
            DropColumn("dbo.ProductRating", "Id");
            AddColumn("dbo.ProductRating", "RatingId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ProductRating", "InstrumentId", c => c.Int());
            AlterColumn("dbo.ProductRating", "AccessoryId", c => c.Int());
            AddPrimaryKey("dbo.ProductRating", "RatingId");
            CreateIndex("dbo.ProductRating", "InstrumentId");
            CreateIndex("dbo.ProductRating", "AccessoryId");
            AddForeignKey("dbo.ProductRating", "AccessoryId", "dbo.Accessory", "Id");
            AddForeignKey("dbo.ProductRating", "InstrumentId", "dbo.Instrument", "InstrumentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductRating", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ProductRating", "InstrumentId", "dbo.Instrument");
            DropForeignKey("dbo.ProductRating", "AccessoryId", "dbo.Accessory");
            DropIndex("dbo.ProductRating", new[] { "AccessoryId" });
            DropIndex("dbo.ProductRating", new[] { "InstrumentId" });
            DropPrimaryKey("dbo.ProductRating");
            AlterColumn("dbo.ProductRating", "AccessoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductRating", "InstrumentId", c => c.Int(nullable: false));
            DropColumn("dbo.ProductRating", "RatingId");
            AddPrimaryKey("dbo.ProductRating", "Id");
            CreateIndex("dbo.ProductRating", "AccessoryId");
            CreateIndex("dbo.ProductRating", "InstrumentId");
            AddForeignKey("dbo.ProductRating", "InstrumentId", "dbo.Instrument", "InstrumentId", cascadeDelete: true);
            AddForeignKey("dbo.ProductRating", "AccessoryId", "dbo.Accessory", "Id", cascadeDelete: true);
        }
    }
}
