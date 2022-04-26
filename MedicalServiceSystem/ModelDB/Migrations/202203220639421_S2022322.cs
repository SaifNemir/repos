namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class S2022322 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicalServices", "IsVisible", c => c.Boolean());
            AddColumn("dbo.MedicalServices", "FromTheList", c => c.Boolean(nullable: false));
            AddColumn("dbo.MedicalServices", "Percentag", c => c.Int(nullable: false));
            AddColumn("dbo.MedicineForReclaims", "IsVisible", c => c.Boolean(nullable: false));
            AddColumn("dbo.MedicineForReclaims", "FromTheList", c => c.Boolean(nullable: false));
            AddColumn("dbo.MedicineForReclaims", "Percentag", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MedicineForReclaims", "Percentag");
            DropColumn("dbo.MedicineForReclaims", "FromTheList");
            DropColumn("dbo.MedicineForReclaims", "IsVisible");
            DropColumn("dbo.MedicalServices", "Percentag");
            DropColumn("dbo.MedicalServices", "FromTheList");
            DropColumn("dbo.MedicalServices", "IsVisible");
        }
    }
}
