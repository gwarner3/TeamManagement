namespace TeamManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEventNameColumnToGameScheduleModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameScheduleModels", "EventName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameScheduleModels", "EventName");
        }
    }
}
