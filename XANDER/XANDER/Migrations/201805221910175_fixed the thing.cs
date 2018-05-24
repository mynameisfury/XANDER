namespace XANDER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedthething : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WorkerTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Jobs", "JobTypeID", c => c.Int(nullable: false));
            AddColumn("dbo.Workers", "WorkerTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Jobs", "JobTypeID");
            CreateIndex("dbo.Workers", "WorkerTypeID");
            AddForeignKey("dbo.Jobs", "JobTypeID", "dbo.JobTypes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Workers", "WorkerTypeID", "dbo.WorkerTypes", "ID", cascadeDelete: true);
            DropColumn("dbo.Jobs", "JobType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "JobType", c => c.String());
            DropForeignKey("dbo.Workers", "WorkerTypeID", "dbo.WorkerTypes");
            DropForeignKey("dbo.Jobs", "JobTypeID", "dbo.JobTypes");
            DropIndex("dbo.Workers", new[] { "WorkerTypeID" });
            DropIndex("dbo.Jobs", new[] { "JobTypeID" });
            DropColumn("dbo.Workers", "WorkerTypeID");
            DropColumn("dbo.Jobs", "JobTypeID");
            DropTable("dbo.WorkerTypes");
            DropTable("dbo.JobTypes");
        }
    }
}
