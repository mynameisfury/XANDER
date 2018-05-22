namespace XANDER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1041 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "JobName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Workers", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Workers", "LastName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Workers", "LastName", c => c.String());
            AlterColumn("dbo.Workers", "FirstName", c => c.String());
            AlterColumn("dbo.Jobs", "JobName", c => c.String());
        }
    }
}
