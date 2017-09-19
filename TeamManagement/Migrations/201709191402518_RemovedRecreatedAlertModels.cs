namespace TeamManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedRecreatedAlertModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlertModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlertMessage = c.String(nullable: false),
                        AspNetUsersId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUsersId)
                .Index(t => t.AspNetUsersId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlertModels", "AspNetUsersId", "dbo.AspNetUsers");
            DropIndex("dbo.AlertModels", new[] { "AspNetUsersId" });
            DropTable("dbo.AlertModels");
        }
    }
}
