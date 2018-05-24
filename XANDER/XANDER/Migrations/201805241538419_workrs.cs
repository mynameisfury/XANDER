namespace XANDER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workrs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workers", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workers", "UserID");
        }
    }
}
