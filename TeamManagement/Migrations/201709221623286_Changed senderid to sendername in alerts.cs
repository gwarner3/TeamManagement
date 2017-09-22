namespace TeamManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changedsenderidtosendernameinalerts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlertModels", "AspNetSenderName", c => c.String());
            DropColumn("dbo.AlertModels", "AspNetSenderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AlertModels", "AspNetSenderId", c => c.String());
            DropColumn("dbo.AlertModels", "AspNetSenderName");
        }
    }
}
