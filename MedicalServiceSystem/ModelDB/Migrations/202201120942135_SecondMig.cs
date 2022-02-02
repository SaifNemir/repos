namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMig : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserGroups", "UserId");
            DropColumn("dbo.UserGroups", "DateIn");
            DropColumn("dbo.UserGroups", "UpdateUser");
            DropColumn("dbo.UserGroups", "UpdateDate");
            DropColumn("dbo.UserGroups", "UserDeleted");
            DropColumn("dbo.UserGroups", "DeleteDate");
            DropColumn("dbo.UserGroups", "Status");
            DropColumn("dbo.UserGroups", "RowStatus");
            DropColumn("dbo.UserGroups", "LocalityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserGroups", "LocalityId", c => c.Int(nullable: false));
            AddColumn("dbo.UserGroups", "RowStatus", c => c.Int(nullable: false));
            AddColumn("dbo.UserGroups", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.UserGroups", "DeleteDate", c => c.DateTime());
            AddColumn("dbo.UserGroups", "UserDeleted", c => c.Int());
            AddColumn("dbo.UserGroups", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.UserGroups", "UpdateUser", c => c.Int());
            AddColumn("dbo.UserGroups", "DateIn", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserGroups", "UserId", c => c.Int(nullable: false));
        }
    }
}
