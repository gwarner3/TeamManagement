namespace TeamManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingdatabase : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "Players_Id", newName: "Player_Id");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_Players_Id", newName: "IX_Player_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_Player_Id", newName: "IX_Players_Id");
            RenameColumn(table: "dbo.AspNetUsers", name: "Player_Id", newName: "Players_Id");
        }
    }
}
