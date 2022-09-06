namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saif6_8_2022 : DbMigration
    {
        public override void Up()
        {
           
            
            CreateTable(
                "dbo.RefuseMedicineDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RefuseId = c.Int(nullable: false),
                        RefuseReason = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RefuseMedicines", t => t.RefuseId, cascadeDelete: true)
                .Index(t => t.RefuseId);
            
            CreateTable(
                "dbo.RefuseMedicines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InsurId = c.Int(nullable: false),
                        ReqCenterId = c.Int(nullable: false),
                        ExcCenterId = c.Int(nullable: false),
                        RefuseDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subscribers", t => t.InsurId, cascadeDelete: true)
                .Index(t => t.InsurId);
            
            
        }
        
        public override void Down()
        {
          
            DropForeignKey("dbo.RefuseMedicineDetails", "RefuseId", "dbo.RefuseMedicines");
            DropForeignKey("dbo.RefuseMedicines", "InsurId", "dbo.Subscribers");
           
            DropIndex("dbo.RefuseMedicines", new[] { "InsurId" });
            DropIndex("dbo.RefuseMedicineDetails", new[] { "RefuseId" });
            DropTable("dbo.RefuseMedicines");
            DropTable("dbo.RefuseMedicineDetails");
                  }
    }
}
