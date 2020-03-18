namespace ColossalSounds.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customer", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
