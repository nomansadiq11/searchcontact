namespace SC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecontactcolumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "CountryID", c => c.Int(nullable: false));
            AddColumn("dbo.Contact", "StateID", c => c.Int(nullable: false));
            AddColumn("dbo.Contact", "CityID", c => c.Int(nullable: false));
            AddColumn("dbo.Contact", "PostalID", c => c.Int(nullable: false));
            AddColumn("dbo.Contact", "JobFunctionID", c => c.Int(nullable: false));
            AddColumn("dbo.Contact", "AccuracyID", c => c.Int(nullable: false));
            AddColumn("dbo.Contact", "SICID", c => c.Int(nullable: false));
            AddColumn("dbo.Contact", "IndustriesID", c => c.Int(nullable: false));
            AddColumn("dbo.Contact", "EmployeesID", c => c.Int(nullable: false));
            AddColumn("dbo.Contact", "RevenueID", c => c.Int(nullable: false));
            AddColumn("dbo.Contact", "COUNTYID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contact", "COUNTYID");
            DropColumn("dbo.Contact", "RevenueID");
            DropColumn("dbo.Contact", "EmployeesID");
            DropColumn("dbo.Contact", "IndustriesID");
            DropColumn("dbo.Contact", "SICID");
            DropColumn("dbo.Contact", "AccuracyID");
            DropColumn("dbo.Contact", "JobFunctionID");
            DropColumn("dbo.Contact", "PostalID");
            DropColumn("dbo.Contact", "CityID");
            DropColumn("dbo.Contact", "StateID");
            DropColumn("dbo.Contact", "CountryID");
        }
    }
}
