namespace TeamManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGameSchedulesDbSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameDate = c.DateTime(nullable: false),
                        GameTime = c.DateTime(nullable: false),
                        Opponent = c.String(nullable: false),
                        LocationName = c.String(),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zip = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GameSchedules");
        }
    }
}
