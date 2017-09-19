namespace TeamManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedRatingModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RatingModels", "AspNetUsersID", c => c.String(maxLength: 128));
            CreateIndex("dbo.RatingModels", "AspNetUsersID");
            AddForeignKey("dbo.RatingModels", "AspNetUsersID", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.RatingModels", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RatingModels", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.RatingModels", "AspNetUsersID", "dbo.AspNetUsers");
            DropIndex("dbo.RatingModels", new[] { "AspNetUsersID" });
            DropColumn("dbo.RatingModels", "AspNetUsersID");
        }
    }
}
