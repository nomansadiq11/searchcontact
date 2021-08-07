namespace SC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class selectedsearchtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SelectedSearch",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SelectedSearch");
        }
    }
}
