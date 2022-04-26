namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saif3220221 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApproveMedicineDetails", "ApproveDuration", c => c.Int(nullable: false));
            DropColumn("dbo.ApproveMedicines", "ApproveDuration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApproveMedicines", "ApproveDuration", c => c.Int(nullable: false));
            DropColumn("dbo.ApproveMedicineDetails", "ApproveDuration");
        }
    }
}
