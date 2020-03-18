namespace ColossalSounds.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rolesTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "Discriminator");
        }
    }
}
