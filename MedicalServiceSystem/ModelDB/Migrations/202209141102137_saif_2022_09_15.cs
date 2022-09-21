namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saif_2022_09_15 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChronicsBooks", "DocNo", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChronicsBooks", "DocNo", c => c.Int(nullable: false));
        }
    }
}
