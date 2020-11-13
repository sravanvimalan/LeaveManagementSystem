namespace LeaveManagementSystem.DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatorID : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.RequestVacation", name: "CreatedBy", newName: "CreatorID");
            RenameIndex(table: "dbo.RequestVacation", name: "IX_CreatedBy", newName: "IX_CreatorID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.RequestVacation", name: "IX_CreatorID", newName: "IX_CreatedBy");
            RenameColumn(table: "dbo.RequestVacation", name: "CreatorID", newName: "CreatedBy");
        }
    }
}
