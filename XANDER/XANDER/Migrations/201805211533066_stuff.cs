namespace XANDER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workers", "ProfileDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workers", "ProfileDescription");
        }
    }
}
