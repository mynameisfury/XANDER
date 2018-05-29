namespace XANDER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pleasegod46withextradip : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Filepath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "Filepath");
        }
    }
}
