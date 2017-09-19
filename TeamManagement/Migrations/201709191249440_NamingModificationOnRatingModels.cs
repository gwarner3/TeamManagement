namespace TeamManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NamingModificationOnRatingModels : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.RatingModels", new[] { "AspNetUsersID" });
            CreateIndex("dbo.RatingModels", "AspNetUsersId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.RatingModels", new[] { "AspNetUsersId" });
            CreateIndex("dbo.RatingModels", "AspNetUsersID");
        }
    }
}
