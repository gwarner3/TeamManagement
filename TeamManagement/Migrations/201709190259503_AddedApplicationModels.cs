namespace TeamManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedApplicationModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ApplicationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ApplicationModels");
        }
    }
}
