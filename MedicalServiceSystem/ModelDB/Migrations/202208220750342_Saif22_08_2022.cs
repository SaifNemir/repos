namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Saif22_08_2022 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "LocalityId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "LocalityId");
        }
    }
}
