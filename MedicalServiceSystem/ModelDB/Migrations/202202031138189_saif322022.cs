namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saif322022 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApproveMedicines", "ApproveDuration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApproveMedicines", "ApproveDuration");
        }
    }
}
