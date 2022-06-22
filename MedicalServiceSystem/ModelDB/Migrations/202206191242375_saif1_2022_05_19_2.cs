namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saif1_2022_05_19_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscribers", "StopCard", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subscribers", "StopCard");
        }
    }
}
