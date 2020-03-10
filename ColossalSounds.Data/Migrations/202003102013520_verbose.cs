namespace ColossalSounds.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class verbose : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Instrument", "ClassificationId", "dbo.InstrumentClassification");
            DropPrimaryKey("dbo.InstrumentClassification");
            AddColumn("dbo.InstrumentClassification", "ClassificationId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.InstrumentClassification", "ClassificationId");
            AddForeignKey("dbo.Instrument", "ClassificationId", "dbo.InstrumentClassification", "ClassificationId", cascadeDelete: true);
            DropColumn("dbo.InstrumentClassification", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InstrumentClassification", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Instrument", "ClassificationId", "dbo.InstrumentClassification");
            DropPrimaryKey("dbo.InstrumentClassification");
            DropColumn("dbo.InstrumentClassification", "ClassificationId");
            AddPrimaryKey("dbo.InstrumentClassification", "Id");
            AddForeignKey("dbo.Instrument", "ClassificationId", "dbo.InstrumentClassification", "ClassificationId", cascadeDelete: true);
        }
    }
}
