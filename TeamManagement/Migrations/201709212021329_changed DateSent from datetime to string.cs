namespace TeamManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedDateSentfromdatetimetostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AlertModels", "DateSent", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AlertModels", "DateSent", c => c.DateTime());
        }
    }
}
