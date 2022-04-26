namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20220324S : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CenterInfoes", "IsVisible", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CenterInfoes", "IsVisible");
        }
    }
}
