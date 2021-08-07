namespace SC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idudpateforcontact : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Contact");
            AlterColumn("dbo.Contact", "ContactID", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Contact", "ContactID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Contact");
            AlterColumn("dbo.Contact", "ContactID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Contact", "ContactID");
        }
    }
}
