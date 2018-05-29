namespace XANDER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pleasegod : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "TimeStamp", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "TimeStamp", c => c.DateTime(nullable: false));
        }
    }
}
