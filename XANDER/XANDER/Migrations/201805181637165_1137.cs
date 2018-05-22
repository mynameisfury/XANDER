namespace XANDER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1137 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "JobType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "JobType");
        }
    }
}
