namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Saif_2022_9_4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reclaims", "SectorName", c => c.String());
            AddColumn("dbo.Reclaims", "SectorId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reclaims", "SectorId");
            DropColumn("dbo.Reclaims", "SectorName");
        }
    }
}
