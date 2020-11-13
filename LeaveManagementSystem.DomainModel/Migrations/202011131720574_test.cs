namespace LeaveManagementSystem.DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.RequestVacation", "CreatedBy");
            CreateIndex("dbo.RequestVacation", "ApproverID");
            AddForeignKey("dbo.RequestVacation", "ApproverID", "dbo.Employee", "EmployeeID", cascadeDelete: true);
            AddForeignKey("dbo.RequestVacation", "CreatedBy", "dbo.Employee", "EmployeeID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequestVacation", "CreatedBy", "dbo.Employee");
            DropForeignKey("dbo.RequestVacation", "ApproverID", "dbo.Employee");
            DropIndex("dbo.RequestVacation", new[] { "ApproverID" });
            DropIndex("dbo.RequestVacation", new[] { "CreatedBy" });
        }
    }
}
