namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdmRS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdmR = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HICKS_DCS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HICKSDC = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.US",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        U = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Medicines", "HICKS_DC", c => c.Int(nullable: false));
            AlterColumn("dbo.Medicines", "U", c => c.Int(nullable: false));
            AlterColumn("dbo.Medicines", "Adm_R", c => c.Int(nullable: false));
            CreateIndex("dbo.Medicines", "HICKS_DC");
            CreateIndex("dbo.Medicines", "U");
            CreateIndex("dbo.Medicines", "Adm_R");
            AddForeignKey("dbo.Medicines", "Adm_R", "dbo.AdmRS", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Medicines", "HICKS_DC", "dbo.HICKS_DCS", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Medicines", "U", "dbo.US", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicines", "U", "dbo.US");
            DropForeignKey("dbo.Medicines", "HICKS_DC", "dbo.HICKS_DCS");
            DropForeignKey("dbo.Medicines", "Adm_R", "dbo.AdmRS");
            DropIndex("dbo.Medicines", new[] { "Adm_R" });
            DropIndex("dbo.Medicines", new[] { "U" });
            DropIndex("dbo.Medicines", new[] { "HICKS_DC" });
            AlterColumn("dbo.Medicines", "Adm_R", c => c.String());
            AlterColumn("dbo.Medicines", "U", c => c.String());
            AlterColumn("dbo.Medicines", "HICKS_DC", c => c.String());
            DropTable("dbo.US");
            DropTable("dbo.HICKS_DCS");
            DropTable("dbo.AdmRS");
        }
    }
}
