namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saif2512022 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApproveMedicines", "ApproveCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApproveMedicines", "ApproveCode");
        }
    }
}
