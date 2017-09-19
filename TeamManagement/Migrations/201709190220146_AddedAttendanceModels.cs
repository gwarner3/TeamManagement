namespace TeamManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAttendanceModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttendanceModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        AbsentDate = c.DateTime(nullable: false),
                        Event = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AttendanceModels");
        }
    }
}
