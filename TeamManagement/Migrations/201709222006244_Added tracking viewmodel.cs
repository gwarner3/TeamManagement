namespace TeamManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedtrackingviewmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrackingModels", "Rating_Id", c => c.Int());
            CreateIndex("dbo.TrackingModels", "Rating_Id");
            AddForeignKey("dbo.TrackingModels", "Rating_Id", "dbo.RatingModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrackingModels", "Rating_Id", "dbo.RatingModels");
            DropIndex("dbo.TrackingModels", new[] { "Rating_Id" });
            DropColumn("dbo.TrackingModels", "Rating_Id");
        }
    }
}
