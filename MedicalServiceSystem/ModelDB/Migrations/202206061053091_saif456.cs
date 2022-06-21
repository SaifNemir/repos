namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saif456 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReclaimMedicalReasonsLists", "Activated", c => c.Boolean(nullable: false));
            AddColumn("dbo.ReclaimMedicineReasonsLists", "Activated", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReclaimMedicineReasonsLists", "Activated");
            DropColumn("dbo.ReclaimMedicalReasonsLists", "Activated");
        }
    }
}
