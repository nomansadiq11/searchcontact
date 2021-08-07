namespace SC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removetable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.PostalCode");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PostalCode",
                c => new
                    {
                        PCID = c.Int(nullable: false, identity: true),
                        PostCode = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.PCID);
            
        }
    }
}
