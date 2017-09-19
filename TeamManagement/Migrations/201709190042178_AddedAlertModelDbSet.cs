namespace TeamManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAlertModelDbSet : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GameSchedules", newName: "GameScheduleModels");
            CreateTable(
                "dbo.AlertModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlertMessage = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AlertModels");
            RenameTable(name: "dbo.GameScheduleModels", newName: "GameSchedules");
        }
    }
}
