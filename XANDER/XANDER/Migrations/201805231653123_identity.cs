namespace XANDER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "WorkerID", "dbo.Workers");
            DropIndex("dbo.Jobs", new[] { "WorkerID" });
            AlterColumn("dbo.Jobs", "WorkerID", c => c.Int());
            CreateIndex("dbo.Jobs", "WorkerID");
            AddForeignKey("dbo.Jobs", "WorkerID", "dbo.Workers", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "WorkerID", "dbo.Workers");
            DropIndex("dbo.Jobs", new[] { "WorkerID" });
            AlterColumn("dbo.Jobs", "WorkerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Jobs", "WorkerID");
            AddForeignKey("dbo.Jobs", "WorkerID", "dbo.Workers", "ID", cascadeDelete: true);
        }
    }
}
