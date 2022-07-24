namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saif_2022_07_06 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reclaims", "IsMedicine", c => c.Boolean());
            AddColumn("dbo.Reclaims", "IsMedical", c => c.Boolean());
            AddColumn("dbo.Reclaims", "RefuseMedical", c => c.Boolean());
            AddColumn("dbo.Reclaims", "RefuseMedicine", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reclaims", "RefuseMedicine");
            DropColumn("dbo.Reclaims", "RefuseMedical");
            DropColumn("dbo.Reclaims", "IsMedical");
            DropColumn("dbo.Reclaims", "IsMedicine");
        }
    }
}
