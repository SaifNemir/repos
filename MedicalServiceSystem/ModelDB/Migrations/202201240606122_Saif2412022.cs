namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Saif2412022 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CenterInfoes", "Level1", c => c.Boolean(nullable: false));
            AddColumn("dbo.CenterInfoes", "Level2", c => c.Boolean(nullable: false));
            AddColumn("dbo.CenterInfoes", "Level3", c => c.Boolean(nullable: false));
            DropColumn("dbo.CenterInfoes", "CenterLevel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CenterInfoes", "CenterLevel", c => c.Int(nullable: false));
            DropColumn("dbo.CenterInfoes", "Level3");
            DropColumn("dbo.CenterInfoes", "Level2");
            DropColumn("dbo.CenterInfoes", "Level1");
        }
    }
}
