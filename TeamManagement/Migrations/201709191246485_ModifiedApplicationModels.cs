namespace TeamManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedApplicationModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationModels", "AspNetUsersId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ApplicationModels", "AspNetUsersId");
            AddForeignKey("dbo.ApplicationModels", "AspNetUsersId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.ApplicationModels", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationModels", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ApplicationModels", "AspNetUsersId", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationModels", new[] { "AspNetUsersId" });
            DropColumn("dbo.ApplicationModels", "AspNetUsersId");
        }
    }
}
