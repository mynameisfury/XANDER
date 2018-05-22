namespace XANDER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uhhhhh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "ClientID", c => c.Int(nullable: false));
            AddColumn("dbo.Jobs", "WorkerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Jobs", "ClientID");
            CreateIndex("dbo.Jobs", "WorkerID");
            AddForeignKey("dbo.Jobs", "ClientID", "dbo.Clients", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Jobs", "WorkerID", "dbo.Workers", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "WorkerID", "dbo.Workers");
            DropForeignKey("dbo.Jobs", "ClientID", "dbo.Clients");
            DropIndex("dbo.Jobs", new[] { "WorkerID" });
            DropIndex("dbo.Jobs", new[] { "ClientID" });
            DropColumn("dbo.Jobs", "WorkerID");
            DropColumn("dbo.Jobs", "ClientID");
        }
    }
}
