namespace SC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columnforselectedsearch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SelectedSearch", "cDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SelectedSearch", "cDate");
        }
    }
}
