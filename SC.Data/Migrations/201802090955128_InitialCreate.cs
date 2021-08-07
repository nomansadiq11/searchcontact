namespace SC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.CityID);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 500),
                        FirstName = c.String(maxLength: 200),
                        LastName = c.String(maxLength: 200),
                        Email = c.String(maxLength: 200),
                        Phone1 = c.String(maxLength: 200),
                        Phone2 = c.String(maxLength: 200),
                        Street = c.String(maxLength: 200),
                        Website = c.String(maxLength: 200),
                        Organization = c.String(maxLength: 500),
                        CommonOrganizationName = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ContactID);
            
            CreateTable(
                "dbo.ContactsDump",
                c => new
                    {
                        DumpID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Title = c.String(),
                        Email = c.String(),
                        Phone1 = c.String(),
                        Phone2 = c.String(),
                        Organization = c.String(),
                        CommonOrganizationName = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        County = c.String(),
                        Postal = c.String(),
                        Country = c.String(),
                        Website = c.String(),
                        Revenue = c.String(),
                        Employees = c.String(),
                        Industries = c.String(),
                        SICCode = c.String(),
                        SICDescription = c.String(),
                        Accuracy = c.String(),
                        JobFunction = c.String(),
                    })
                .PrimaryKey(t => t.DumpID);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.CountryID);
            
            CreateTable(
                "dbo.PostalCode",
                c => new
                    {
                        PCID = c.Int(nullable: false, identity: true),
                        PostCode = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.PCID);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        StateID = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.StateID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.State");
            DropTable("dbo.PostalCode");
            DropTable("dbo.Country");
            DropTable("dbo.ContactsDump");
            DropTable("dbo.Contact");
            DropTable("dbo.City");
        }
    }
}
