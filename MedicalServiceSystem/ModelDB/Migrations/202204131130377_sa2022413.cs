namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sa2022413 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChronicBookTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ChronicsBooks", "BookTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.ChronicsBooks", "BookTypeId");
            AddForeignKey("dbo.ChronicsBooks", "BookTypeId", "dbo.ChronicBookTypes", "Id", cascadeDelete: false);
            DropColumn("dbo.ChronicsBooks", "BookType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ChronicsBooks", "BookType", c => c.Int(nullable: false));
            DropForeignKey("dbo.ChronicsBooks", "BookTypeId", "dbo.ChronicBookTypes");
            DropIndex("dbo.ChronicsBooks", new[] { "BookTypeId" });
            DropColumn("dbo.ChronicsBooks", "BookTypeId");
            DropTable("dbo.ChronicBookTypes");
        }
    }
}
