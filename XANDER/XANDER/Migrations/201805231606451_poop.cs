namespace XANDER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poop : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "DueDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "DueDate", c => c.String());
        }
    }
}
