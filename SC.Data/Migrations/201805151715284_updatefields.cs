namespace SC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatefields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contact", "Title", c => c.String());
            AlterColumn("dbo.Contact", "FirstName", c => c.String());
            AlterColumn("dbo.Contact", "LastName", c => c.String());
            AlterColumn("dbo.Contact", "Email", c => c.String());
            AlterColumn("dbo.Contact", "Phone1", c => c.String());
            AlterColumn("dbo.Contact", "Phone2", c => c.String());
            AlterColumn("dbo.Contact", "Street", c => c.String());
            AlterColumn("dbo.Contact", "Website", c => c.String());
            AlterColumn("dbo.Contact", "Organization", c => c.String());
            AlterColumn("dbo.Contact", "CommonOrganizationName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contact", "CommonOrganizationName", c => c.String(maxLength: 500));
            AlterColumn("dbo.Contact", "Organization", c => c.String(maxLength: 500));
            AlterColumn("dbo.Contact", "Website", c => c.String(maxLength: 200));
            AlterColumn("dbo.Contact", "Street", c => c.String(maxLength: 200));
            AlterColumn("dbo.Contact", "Phone2", c => c.String(maxLength: 200));
            AlterColumn("dbo.Contact", "Phone1", c => c.String(maxLength: 200));
            AlterColumn("dbo.Contact", "Email", c => c.String(maxLength: 200));
            AlterColumn("dbo.Contact", "LastName", c => c.String(maxLength: 200));
            AlterColumn("dbo.Contact", "FirstName", c => c.String(maxLength: 200));
            AlterColumn("dbo.Contact", "Title", c => c.String(maxLength: 500));
        }
    }
}
