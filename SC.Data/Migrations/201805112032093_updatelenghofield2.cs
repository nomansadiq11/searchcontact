namespace SC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatelenghofield2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contact", "StateID", c => c.Long(nullable: false));
            AlterColumn("dbo.Contact", "PostalID", c => c.Long(nullable: false));
            AlterColumn("dbo.Contact", "JobFunctionID", c => c.Long(nullable: false));
            AlterColumn("dbo.Contact", "AccuracyID", c => c.Long(nullable: false));
            AlterColumn("dbo.Contact", "SICID", c => c.Long(nullable: false));
            AlterColumn("dbo.Contact", "IndustriesID", c => c.Long(nullable: false));
            AlterColumn("dbo.Contact", "EmployeesID", c => c.Long(nullable: false));
            AlterColumn("dbo.Contact", "RevenueID", c => c.Long(nullable: false));
            AlterColumn("dbo.Contact", "COUNTYID", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contact", "COUNTYID", c => c.Int(nullable: false));
            AlterColumn("dbo.Contact", "RevenueID", c => c.Int(nullable: false));
            AlterColumn("dbo.Contact", "EmployeesID", c => c.Int(nullable: false));
            AlterColumn("dbo.Contact", "IndustriesID", c => c.Int(nullable: false));
            AlterColumn("dbo.Contact", "SICID", c => c.Int(nullable: false));
            AlterColumn("dbo.Contact", "AccuracyID", c => c.Int(nullable: false));
            AlterColumn("dbo.Contact", "JobFunctionID", c => c.Int(nullable: false));
            AlterColumn("dbo.Contact", "PostalID", c => c.Int(nullable: false));
            AlterColumn("dbo.Contact", "StateID", c => c.Int(nullable: false));
        }
    }
}
