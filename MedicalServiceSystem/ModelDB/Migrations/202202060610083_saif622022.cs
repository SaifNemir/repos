namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saif622022 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApproveMedicines", "Atachment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApproveMedicines", "Atachment");
        }
    }
}
