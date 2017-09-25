namespace TeamManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedraitngplayerusertoplayerId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RatingModels", "AspNetUsersId", "dbo.AspNetUsers");
            DropIndex("dbo.RatingModels", new[] { "AspNetUsersId" });
            AddColumn("dbo.RatingModels", "AspNetPlayerId", c => c.String());
            AlterColumn("dbo.RatingModels", "AspNetUsersId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RatingModels", "AspNetUsersId", c => c.String(maxLength: 128));
            DropColumn("dbo.RatingModels", "AspNetPlayerId");
            CreateIndex("dbo.RatingModels", "AspNetUsersId");
            AddForeignKey("dbo.RatingModels", "AspNetUsersId", "dbo.AspNetUsers", "Id");
        }
    }
}
