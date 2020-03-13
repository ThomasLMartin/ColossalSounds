namespace ColossalSounds.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAccessory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductRating", "AccessoryId", "dbo.Accessory");
            DropForeignKey("dbo.Review", "AccessoryId", "dbo.Accessory");
            DropPrimaryKey("dbo.Accessory");
            DropColumn("dbo.Accessory", "Id");
            AddColumn("dbo.Accessory", "AccessoryId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Accessory", "AccessoryId");
            AddForeignKey("dbo.ProductRating", "AccessoryId", "dbo.Accessory", "AccessoryId");
            AddForeignKey("dbo.Review", "AccessoryId", "dbo.Accessory", "AccessoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accessory", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Review", "AccessoryId", "dbo.Accessory");
            DropForeignKey("dbo.ProductRating", "AccessoryId", "dbo.Accessory");
            DropPrimaryKey("dbo.Accessory");
            DropColumn("dbo.Accessory", "AccessoryId");
            AddPrimaryKey("dbo.Accessory", "Id");
            AddForeignKey("dbo.Review", "AccessoryId", "dbo.Accessory", "AccessoryId");
            AddForeignKey("dbo.ProductRating", "AccessoryId", "dbo.Accessory", "AccessoryId");
        }
    }
}
