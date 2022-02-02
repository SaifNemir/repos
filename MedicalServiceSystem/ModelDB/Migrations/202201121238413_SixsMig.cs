namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SixsMig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MedicineTemps", "UpdateUser", c => c.Int());
            AlterColumn("dbo.MedicineTemps", "DeleteUser", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MedicineTemps", "DeleteUser", c => c.Int(nullable: false));
            AlterColumn("dbo.MedicineTemps", "UpdateUser", c => c.Int(nullable: false));
        }
    }
}
