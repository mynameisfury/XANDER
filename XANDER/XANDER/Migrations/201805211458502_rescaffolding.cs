namespace XANDER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rescaffolding : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "DueDate", c => c.String());
            DropColumn("dbo.Clients", "Email");
            DropColumn("dbo.Clients", "Password");
            DropColumn("dbo.Clients", "PaymentInfoID");
            DropColumn("dbo.Workers", "Email");
            DropColumn("dbo.Workers", "Password");
            DropColumn("dbo.Workers", "PaymentInfoID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workers", "PaymentInfoID", c => c.Int(nullable: false));
            AddColumn("dbo.Workers", "Password", c => c.String());
            AddColumn("dbo.Workers", "Email", c => c.String());
            AddColumn("dbo.Clients", "PaymentInfoID", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "Password", c => c.String());
            AddColumn("dbo.Clients", "Email", c => c.String());
            DropColumn("dbo.Jobs", "DueDate");
        }
    }
}
