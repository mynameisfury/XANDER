namespace XANDER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuff1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Completed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "Completed");
        }
    }
}
