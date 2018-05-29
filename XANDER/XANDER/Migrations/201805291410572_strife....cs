namespace XANDER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class strife : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MessageBody = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                        ClientID = c.Int(nullable: false),
                        WorkerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.Workers", t => t.WorkerID, cascadeDelete: true)
                .Index(t => t.ClientID)
                .Index(t => t.WorkerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "WorkerID", "dbo.Workers");
            DropForeignKey("dbo.Messages", "ClientID", "dbo.Clients");
            DropIndex("dbo.Messages", new[] { "WorkerID" });
            DropIndex("dbo.Messages", new[] { "ClientID" });
            DropTable("dbo.Messages");
        }
    }
}
