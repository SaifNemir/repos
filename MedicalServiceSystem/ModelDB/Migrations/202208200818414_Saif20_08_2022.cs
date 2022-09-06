namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Saif20_08_2022 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Approves", "InsurId", "dbo.Subscribers");
            DropForeignKey("dbo.ApproveMedicines", "InsurId", "dbo.Subscribers");
            DropForeignKey("dbo.ChronicsBooks", "SubscriberId", "dbo.Subscribers");
            DropForeignKey("dbo.Reclaims", "SubscriberId", "dbo.Subscribers");
            DropForeignKey("dbo.RefuseMedicines", "InsurId", "dbo.Subscribers");
            DropIndex("dbo.Approves", new[] { "InsurId" });
            DropIndex("dbo.ApproveMedicines", new[] { "InsurId" });
            DropIndex("dbo.ChronicsBooks", new[] { "SubscriberId" });
            DropIndex("dbo.Reclaims", new[] { "SubscriberId" });
            DropIndex("dbo.RefuseMedicines", new[] { "InsurId" });
            CreateTable(
                "dbo.StopSubsribers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StopDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        InsurNo = c.String(),
                        IsStoped = c.Boolean(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ApproveMedicines", "PhoneNo", c => c.String());
            AddColumn("dbo.ApproveMedicines", "InsurNo", c => c.String());
            AddColumn("dbo.ApproveMedicines", "InsurName", c => c.String());
            AddColumn("dbo.ApproveMedicines", "Gender", c => c.String());
            AddColumn("dbo.ApproveMedicines", "Address", c => c.String());
            AddColumn("dbo.ApproveMedicines", "Server", c => c.String());
            AddColumn("dbo.ApproveMedicines", "ClientId", c => c.String());
            AddColumn("dbo.ApproveMedicines", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ApproveMedicines", "Notes", c => c.String());
            AddColumn("dbo.ChronicsBooks", "PhoneNo", c => c.String());
            AddColumn("dbo.ChronicsBooks", "InsurNo", c => c.String());
            AddColumn("dbo.ChronicsBooks", "InsurName", c => c.String());
            AddColumn("dbo.ChronicsBooks", "Gender", c => c.String());
            AddColumn("dbo.ChronicsBooks", "Address", c => c.String());
            AddColumn("dbo.ChronicsBooks", "Server", c => c.String());
            AddColumn("dbo.ChronicsBooks", "ClientId", c => c.String());
            AddColumn("dbo.ChronicsBooks", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reclaims", "PhoneNo", c => c.String());
            AddColumn("dbo.Reclaims", "InsurNo", c => c.String());
            AddColumn("dbo.Reclaims", "InsurName", c => c.String());
            AddColumn("dbo.Reclaims", "Gender", c => c.String());
            AddColumn("dbo.Reclaims", "Address", c => c.String());
            AddColumn("dbo.Reclaims", "Server", c => c.String());
            AddColumn("dbo.Reclaims", "ClientId", c => c.String());
            AddColumn("dbo.Reclaims", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.RefuseMedicines", "PhoneNo", c => c.String());
            AddColumn("dbo.RefuseMedicines", "InsurNo", c => c.String());
            AddColumn("dbo.RefuseMedicines", "InsurName", c => c.String());
            AddColumn("dbo.RefuseMedicines", "Gender", c => c.String());
            AddColumn("dbo.RefuseMedicines", "Address", c => c.String());
            AddColumn("dbo.RefuseMedicines", "Server", c => c.String());
            AddColumn("dbo.RefuseMedicines", "ClientId", c => c.String());
            AddColumn("dbo.RefuseMedicines", "BirthDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Approves", "InsurId");
            DropColumn("dbo.ApproveMedicines", "InsurId");
            DropColumn("dbo.ChronicsBooks", "SubscriberId");
            DropColumn("dbo.Reclaims", "SubscriberId");
            DropColumn("dbo.RefuseMedicines", "InsurId");
            DropTable("dbo.Subscribers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Subscribers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNo = c.String(),
                        InsurNo = c.String(),
                        InsurName = c.String(),
                        Gender = c.String(),
                        Address = c.String(),
                        Server = c.String(),
                        ClientId = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        StopCard = c.DateTime(),
                        IsStoped = c.Boolean(),
                        Notes = c.String(),
                        localityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.RefuseMedicines", "InsurId", c => c.Int(nullable: false));
            AddColumn("dbo.Reclaims", "SubscriberId", c => c.Int(nullable: false));
            AddColumn("dbo.ChronicsBooks", "SubscriberId", c => c.Int(nullable: false));
            AddColumn("dbo.ApproveMedicines", "InsurId", c => c.Int(nullable: false));
            AddColumn("dbo.Approves", "InsurId", c => c.Int(nullable: false));
            DropColumn("dbo.RefuseMedicines", "BirthDate");
            DropColumn("dbo.RefuseMedicines", "ClientId");
            DropColumn("dbo.RefuseMedicines", "Server");
            DropColumn("dbo.RefuseMedicines", "Address");
            DropColumn("dbo.RefuseMedicines", "Gender");
            DropColumn("dbo.RefuseMedicines", "InsurName");
            DropColumn("dbo.RefuseMedicines", "InsurNo");
            DropColumn("dbo.RefuseMedicines", "PhoneNo");
            DropColumn("dbo.Reclaims", "BirthDate");
            DropColumn("dbo.Reclaims", "ClientId");
            DropColumn("dbo.Reclaims", "Server");
            DropColumn("dbo.Reclaims", "Address");
            DropColumn("dbo.Reclaims", "Gender");
            DropColumn("dbo.Reclaims", "InsurName");
            DropColumn("dbo.Reclaims", "InsurNo");
            DropColumn("dbo.Reclaims", "PhoneNo");
            DropColumn("dbo.ChronicsBooks", "BirthDate");
            DropColumn("dbo.ChronicsBooks", "ClientId");
            DropColumn("dbo.ChronicsBooks", "Server");
            DropColumn("dbo.ChronicsBooks", "Address");
            DropColumn("dbo.ChronicsBooks", "Gender");
            DropColumn("dbo.ChronicsBooks", "InsurName");
            DropColumn("dbo.ChronicsBooks", "InsurNo");
            DropColumn("dbo.ChronicsBooks", "PhoneNo");
            DropColumn("dbo.ApproveMedicines", "Notes");
            DropColumn("dbo.ApproveMedicines", "BirthDate");
            DropColumn("dbo.ApproveMedicines", "ClientId");
            DropColumn("dbo.ApproveMedicines", "Server");
            DropColumn("dbo.ApproveMedicines", "Address");
            DropColumn("dbo.ApproveMedicines", "Gender");
            DropColumn("dbo.ApproveMedicines", "InsurName");
            DropColumn("dbo.ApproveMedicines", "InsurNo");
            DropColumn("dbo.ApproveMedicines", "PhoneNo");
            DropTable("dbo.StopSubsribers");
            CreateIndex("dbo.RefuseMedicines", "InsurId");
            CreateIndex("dbo.Reclaims", "SubscriberId");
            CreateIndex("dbo.ChronicsBooks", "SubscriberId");
            CreateIndex("dbo.ApproveMedicines", "InsurId");
            CreateIndex("dbo.Approves", "InsurId");
            AddForeignKey("dbo.RefuseMedicines", "InsurId", "dbo.Subscribers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reclaims", "SubscriberId", "dbo.Subscribers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ChronicsBooks", "SubscriberId", "dbo.Subscribers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApproveMedicines", "InsurId", "dbo.Subscribers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Approves", "InsurId", "dbo.Subscribers", "Id", cascadeDelete: true);
        }
    }
}
