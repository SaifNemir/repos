namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20220328Sa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChronicBooksDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        ChronicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chronics", t => t.ChronicId, cascadeDelete: false)
                .ForeignKey("dbo.ChronicsBooks", t => t.BookId, cascadeDelete: false)
                .Index(t => t.BookId)
                .Index(t => t.ChronicId);
            
            CreateTable(
                "dbo.Chronics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChronicName = c.String(),
                        Activated = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChronicsBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookNo = c.Int(nullable: false),
                        DocNo = c.Int(nullable: false),
                        BookType = c.Int(nullable: false),
                        BookDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CenterId = c.Int(nullable: false),
                        SubscriberId = c.Int(nullable: false),
                        Notes = c.String(),
                        UserId = c.Int(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        UpdateUser = c.Int(),
                        UpdateDate = c.DateTime(),
                        UserDeleted = c.Int(),
                        DeleteDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        RowStatus = c.Int(nullable: false),
                        LocalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CenterInfoes", t => t.CenterId, cascadeDelete: false)
                .ForeignKey("dbo.Subscribers", t => t.SubscriberId, cascadeDelete: false)
                .Index(t => t.CenterId)
                .Index(t => t.SubscriberId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChronicBooksDetails", "BookId", "dbo.ChronicsBooks");
            DropForeignKey("dbo.ChronicsBooks", "SubscriberId", "dbo.Subscribers");
            DropForeignKey("dbo.ChronicsBooks", "CenterId", "dbo.CenterInfoes");
            DropForeignKey("dbo.ChronicBooksDetails", "ChronicId", "dbo.Chronics");
            DropIndex("dbo.ChronicsBooks", new[] { "SubscriberId" });
            DropIndex("dbo.ChronicsBooks", new[] { "CenterId" });
            DropIndex("dbo.ChronicBooksDetails", new[] { "ChronicId" });
            DropIndex("dbo.ChronicBooksDetails", new[] { "BookId" });
            DropTable("dbo.ChronicsBooks");
            DropTable("dbo.Chronics");
            DropTable("dbo.ChronicBooksDetails");
        }
    }
}
