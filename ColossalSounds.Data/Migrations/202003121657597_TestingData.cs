namespace ColossalSounds.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestingData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction", "Id", "dbo.Accessory");
            DropForeignKey("dbo.Transaction", "InstrumentId", "dbo.Instrument");
            DropIndex("dbo.Transaction", new[] { "Id" });
            DropIndex("dbo.Transaction", new[] { "InstrumentId" });
            AlterColumn("dbo.Customer", "PhoneNumber", c => c.String());
            DropColumn("dbo.Transaction", "Id");
            DropColumn("dbo.Transaction", "InstrumentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "InstrumentId", c => c.Int());
            AddColumn("dbo.Transaction", "Id", c => c.Int());
            AlterColumn("dbo.Customer", "PhoneNumber", c => c.Double(nullable: false));
            CreateIndex("dbo.Transaction", "InstrumentId");
            CreateIndex("dbo.Transaction", "Id");
            AddForeignKey("dbo.Transaction", "InstrumentId", "dbo.Instrument", "InstrumentId");
            AddForeignKey("dbo.Transaction", "Id", "dbo.Accessory", "Id");
        }
    }
}
