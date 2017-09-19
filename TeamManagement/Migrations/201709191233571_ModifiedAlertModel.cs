namespace TeamManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedAlertModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlertModels", "AspNetUsersID", c => c.String(maxLength: 128));
            CreateIndex("dbo.AlertModels", "AspNetUsersID");
            AddForeignKey("dbo.AlertModels", "AspNetUsersID", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AlertModels", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AlertModels", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.AlertModels", "AspNetUsersID", "dbo.AspNetUsers");
            DropIndex("dbo.AlertModels", new[] { "AspNetUsersID" });
            DropColumn("dbo.AlertModels", "AspNetUsersID");
        }
    }
}
