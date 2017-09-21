namespace TeamManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedalerts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlertModels", "DateSent", c => c.DateTime());
            AddColumn("dbo.AlertModels", "GameDate", c => c.DateTime());
            AddColumn("dbo.AlertModels", "Received", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AlertModels", "Received");
            DropColumn("dbo.AlertModels", "GameDate");
            DropColumn("dbo.AlertModels", "DateSent");
        }
    }
}
