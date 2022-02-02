namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saif2712022 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApproveMedicineTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApproveType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ApproveMedicines", "ApproveTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.ApproveMedicines", "ApproveTypeId");
            AddForeignKey("dbo.ApproveMedicines", "ApproveTypeId", "dbo.ApproveMedicineTypes", "Id", cascadeDelete:false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApproveMedicines", "ApproveTypeId", "dbo.ApproveMedicineTypes");
            DropIndex("dbo.ApproveMedicines", new[] { "ApproveTypeId" });
            DropColumn("dbo.ApproveMedicines", "ApproveTypeId");
            DropTable("dbo.ApproveMedicineTypes");
        }
    }
}
