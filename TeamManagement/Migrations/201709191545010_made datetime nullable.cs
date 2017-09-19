namespace TeamManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madedatetimenullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "PlayerJoinDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "PlayerJoinDate", c => c.DateTime(nullable: false));
        }
    }
}
