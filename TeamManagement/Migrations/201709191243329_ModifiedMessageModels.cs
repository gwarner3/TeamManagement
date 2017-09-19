namespace TeamManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedMessageModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MessageModels", "AspNetUsersId", c => c.String(maxLength: 128));
            CreateIndex("dbo.MessageModels", "AspNetUsersId");
            AddForeignKey("dbo.MessageModels", "AspNetUsersId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.MessageModels", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MessageModels", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.MessageModels", "AspNetUsersId", "dbo.AspNetUsers");
            DropIndex("dbo.MessageModels", new[] { "AspNetUsersId" });
            DropColumn("dbo.MessageModels", "AspNetUsersId");
        }
    }
}
