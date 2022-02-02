namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saif3112022 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SysForms", "UserId");
            DropColumn("dbo.SysForms", "DateIn");
            DropColumn("dbo.SysForms", "UpdateUser");
            DropColumn("dbo.SysForms", "UpdateDate");
            DropColumn("dbo.SysForms", "UserDeleted");
            DropColumn("dbo.SysForms", "DeleteDate");
            DropColumn("dbo.SysForms", "Status");
            DropColumn("dbo.SysForms", "RowStatus");
            DropColumn("dbo.SysForms", "LocalityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SysForms", "LocalityId", c => c.Int(nullable: false));
            AddColumn("dbo.SysForms", "RowStatus", c => c.Int(nullable: false));
            AddColumn("dbo.SysForms", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.SysForms", "DeleteDate", c => c.DateTime());
            AddColumn("dbo.SysForms", "UserDeleted", c => c.Int());
            AddColumn("dbo.SysForms", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.SysForms", "UpdateUser", c => c.Int());
            AddColumn("dbo.SysForms", "DateIn", c => c.DateTime(nullable: false));
            AddColumn("dbo.SysForms", "UserId", c => c.Int(nullable: false));
        }
    }
}
