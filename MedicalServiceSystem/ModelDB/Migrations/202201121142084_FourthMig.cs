namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthMig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Medicines", "UpdateUser", c => c.Int());
            AlterColumn("dbo.Medicines", "DeleteUser", c => c.Int());
            AlterColumn("dbo.MedicineTemps", "HICKS_DC", c => c.Int(nullable: false));
            AlterColumn("dbo.MedicineTemps", "U", c => c.Int(nullable: false));
            AlterColumn("dbo.MedicineTemps", "Adm_R", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MedicineTemps", "Adm_R", c => c.String());
            AlterColumn("dbo.MedicineTemps", "U", c => c.String());
            AlterColumn("dbo.MedicineTemps", "HICKS_DC", c => c.String());
            AlterColumn("dbo.Medicines", "DeleteUser", c => c.Int(nullable: false));
            AlterColumn("dbo.Medicines", "UpdateUser", c => c.Int(nullable: false));
        }
    }
}
