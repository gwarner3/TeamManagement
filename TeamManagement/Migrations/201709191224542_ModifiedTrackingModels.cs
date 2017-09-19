namespace TeamManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedTrackingModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrackingModels", "AspNetUsersId", c => c.String());
            AlterColumn("dbo.TrackingModels", "PlayerId", c => c.String());
            DropColumn("dbo.TrackingModels", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrackingModels", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.TrackingModels", "PlayerId", c => c.Int(nullable: false));
            DropColumn("dbo.TrackingModels", "AspNetUsersId");
        }
    }
}
