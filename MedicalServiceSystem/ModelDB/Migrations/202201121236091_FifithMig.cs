namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FifithMig : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MedicineTemps", "ListId");
            DropColumn("dbo.MedicineTemps", "NeedApprovement");
            DropColumn("dbo.MedicineTemps", "ApproveByCall");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MedicineTemps", "ApproveByCall", c => c.Boolean(nullable: false));
            AddColumn("dbo.MedicineTemps", "NeedApprovement", c => c.Boolean(nullable: false));
            AddColumn("dbo.MedicineTemps", "ListId", c => c.Int(nullable: false));
        }
    }
}
