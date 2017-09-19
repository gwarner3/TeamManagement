namespace TeamManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedAlertModelAndAddedRatingsModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RatingModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RatingModels");
        }
    }
}
