namespace TeamManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedsenderidtoalertmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlertModels", "AspNetSenderId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AlertModels", "AspNetSenderId");
        }
    }
}
