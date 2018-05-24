namespace XANDER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class p : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Workers", "Rating", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Workers", "Rating", c => c.Int(nullable: false));
        }
    }
}
