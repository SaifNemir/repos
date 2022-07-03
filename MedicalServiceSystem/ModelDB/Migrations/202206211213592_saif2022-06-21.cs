namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saif20220621 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subscribers", "StopCard", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subscribers", "StopCard", c => c.DateTime(nullable: false));
        }
    }
}
