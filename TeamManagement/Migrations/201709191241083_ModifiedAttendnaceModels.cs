namespace TeamManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedAttendnaceModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AttendanceModels", "AspNetUsersID", c => c.String(maxLength: 128));
            CreateIndex("dbo.AttendanceModels", "AspNetUsersID");
            AddForeignKey("dbo.AttendanceModels", "AspNetUsersID", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AttendanceModels", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AttendanceModels", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.AttendanceModels", "AspNetUsersID", "dbo.AspNetUsers");
            DropIndex("dbo.AttendanceModels", new[] { "AspNetUsersID" });
            DropColumn("dbo.AttendanceModels", "AspNetUsersID");
        }
    }
}
