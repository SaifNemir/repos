namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saif24220222 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CenterInfoes", "Level4", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CenterInfoes", "Level4");
        }
    }
}
