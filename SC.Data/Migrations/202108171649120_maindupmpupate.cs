namespace SC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maindupmpupate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactsDump", "RecordID", c => c.String());
            AddColumn("dbo.ContactsDump", "JobTitle", c => c.String());
            AddColumn("dbo.ContactsDump", "ContactPhone1", c => c.String());
            AddColumn("dbo.ContactsDump", "ContactPhone2", c => c.String());
            AddColumn("dbo.ContactsDump", "PrimaryJobFunction", c => c.String());
            AddColumn("dbo.ContactsDump", "AllJobFunctions", c => c.String());
            AddColumn("dbo.ContactsDump", "JobLevel", c => c.String());
            AddColumn("dbo.ContactsDump", "CompanyName", c => c.String());
            AddColumn("dbo.ContactsDump", "D_U_N_S", c => c.String());
            AddColumn("dbo.ContactsDump", "CompanyPhone", c => c.String());
            AddColumn("dbo.ContactsDump", "LocationType", c => c.String());
            AddColumn("dbo.ContactsDump", "StreetAddress", c => c.String());
            AddColumn("dbo.ContactsDump", "PostalCode", c => c.String());
            AddColumn("dbo.ContactsDump", "WebAddress", c => c.String());
            AddColumn("dbo.ContactsDump", "RevenueRange", c => c.String());
            AddColumn("dbo.ContactsDump", "EmployeeRange", c => c.String());
            AddColumn("dbo.ContactsDump", "PrimaryIndustry", c => c.String());
            AddColumn("dbo.ContactsDump", "AllIndustries", c => c.String());
            AddColumn("dbo.ContactsDump", "PrimarySICCode", c => c.String());
            AddColumn("dbo.ContactsDump", "PrimarySICDescription", c => c.String());
            AddColumn("dbo.ContactsDump", "PrimaryNAICS1_1", c => c.String());
            DropColumn("dbo.ContactsDump", "Title");
            DropColumn("dbo.ContactsDump", "Phone1");
            DropColumn("dbo.ContactsDump", "Phone2");
            DropColumn("dbo.ContactsDump", "Organization");
            DropColumn("dbo.ContactsDump", "CommonOrganizationName");
            DropColumn("dbo.ContactsDump", "Street");
            DropColumn("dbo.ContactsDump", "Postal");
            DropColumn("dbo.ContactsDump", "Website");
            DropColumn("dbo.ContactsDump", "Industries");
            DropColumn("dbo.ContactsDump", "SICCode");
            DropColumn("dbo.ContactsDump", "SICDescription");
            DropColumn("dbo.ContactsDump", "Accuracy");
            DropColumn("dbo.ContactsDump", "JobFunction");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactsDump", "JobFunction", c => c.String());
            AddColumn("dbo.ContactsDump", "Accuracy", c => c.String());
            AddColumn("dbo.ContactsDump", "SICDescription", c => c.String());
            AddColumn("dbo.ContactsDump", "SICCode", c => c.String());
            AddColumn("dbo.ContactsDump", "Industries", c => c.String());
            AddColumn("dbo.ContactsDump", "Website", c => c.String());
            AddColumn("dbo.ContactsDump", "Postal", c => c.String());
            AddColumn("dbo.ContactsDump", "Street", c => c.String());
            AddColumn("dbo.ContactsDump", "CommonOrganizationName", c => c.String());
            AddColumn("dbo.ContactsDump", "Organization", c => c.String());
            AddColumn("dbo.ContactsDump", "Phone2", c => c.String());
            AddColumn("dbo.ContactsDump", "Phone1", c => c.String());
            AddColumn("dbo.ContactsDump", "Title", c => c.String());
            DropColumn("dbo.ContactsDump", "PrimaryNAICS1_1");
            DropColumn("dbo.ContactsDump", "PrimarySICDescription");
            DropColumn("dbo.ContactsDump", "PrimarySICCode");
            DropColumn("dbo.ContactsDump", "AllIndustries");
            DropColumn("dbo.ContactsDump", "PrimaryIndustry");
            DropColumn("dbo.ContactsDump", "EmployeeRange");
            DropColumn("dbo.ContactsDump", "RevenueRange");
            DropColumn("dbo.ContactsDump", "WebAddress");
            DropColumn("dbo.ContactsDump", "PostalCode");
            DropColumn("dbo.ContactsDump", "StreetAddress");
            DropColumn("dbo.ContactsDump", "LocationType");
            DropColumn("dbo.ContactsDump", "CompanyPhone");
            DropColumn("dbo.ContactsDump", "D_U_N_S");
            DropColumn("dbo.ContactsDump", "CompanyName");
            DropColumn("dbo.ContactsDump", "JobLevel");
            DropColumn("dbo.ContactsDump", "AllJobFunctions");
            DropColumn("dbo.ContactsDump", "PrimaryJobFunction");
            DropColumn("dbo.ContactsDump", "ContactPhone2");
            DropColumn("dbo.ContactsDump", "ContactPhone1");
            DropColumn("dbo.ContactsDump", "JobTitle");
            DropColumn("dbo.ContactsDump", "RecordID");
        }
    }
}
