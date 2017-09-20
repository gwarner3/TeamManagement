namespace TeamManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedTeamModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Players_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "Players_Id");
            AddForeignKey("dbo.AspNetUsers", "Players_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Players_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "Players_Id" });
            DropColumn("dbo.AspNetUsers", "Players_Id");
        }
    }
}
