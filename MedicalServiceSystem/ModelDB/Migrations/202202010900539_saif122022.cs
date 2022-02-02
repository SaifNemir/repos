namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saif122022 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Approves", "UserId", "dbo.Users");
            DropForeignKey("dbo.Uploads", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.UserPermissions", "UserId", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Users", "Id");
            AddForeignKey("dbo.Approves", "UserId", "dbo.Users", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Uploads", "Users_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.UserPermissions", "UserId", "dbo.Users", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPermissions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Uploads", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.Approves", "UserId", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "Id");
            AddForeignKey("dbo.UserPermissions", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Uploads", "Users_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Approves", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
