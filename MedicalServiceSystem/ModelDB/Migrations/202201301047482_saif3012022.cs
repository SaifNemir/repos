namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saif3012022 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApproveMedicineTypes", "Activated", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApproveMedicineTypes", "Activated");
        }
    }
}
