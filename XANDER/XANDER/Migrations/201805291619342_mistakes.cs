namespace XANDER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mistakes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Username", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "Username");
        }
    }
}
