namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saif_2022_07_03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicineForReclaims", "MaxCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MedicineForReclaims", "MaxCost");
        }
    }
}
