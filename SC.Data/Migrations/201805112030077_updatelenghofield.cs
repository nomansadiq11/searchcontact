namespace SC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatelenghofield : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contact", "CityID", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contact", "CityID", c => c.Int(nullable: false));
        }
    }
}
