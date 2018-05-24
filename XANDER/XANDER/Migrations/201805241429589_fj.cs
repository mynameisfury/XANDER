namespace XANDER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fj : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workers", "Username", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workers", "Username");
        }
    }
}
