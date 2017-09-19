namespace TeamManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedAlertModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AlertModels", "AspNetUsersID", "dbo.AspNetUsers");
            DropIndex("dbo.AlertModels", new[] { "AspNetUsersID" });
            DropTable("dbo.AlertModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AlertModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlertMessage = c.String(nullable: false),
                        AspNetUsersID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.AlertModels", "AspNetUsersID");
            AddForeignKey("dbo.AlertModels", "AspNetUsersID", "dbo.AspNetUsers", "Id");
        }
    }
}
