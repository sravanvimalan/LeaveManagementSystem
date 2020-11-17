namespace LeaveManagementSystem.DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removerequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Employee", "DesignationID", "dbo.Designation");
            DropForeignKey("dbo.Employee", " GenderID", "dbo.Gender");
            DropIndex("dbo.Employee", new[] { " GenderID" });
            DropIndex("dbo.Employee", new[] { "DesignationID" });
            DropIndex("dbo.Employee", new[] { "DepartmentID" });
            AlterColumn("dbo.Employee", "FirstName", c => c.String(maxLength: 150));
            AlterColumn("dbo.Employee", "LastName", c => c.String(maxLength: 150));
            AlterColumn("dbo.Employee", "EmailID", c => c.String(maxLength: 150));
            AlterColumn("dbo.Employee", " GenderID", c => c.Int());
            AlterColumn("dbo.Employee", " MobileNumber ", c => c.String(maxLength: 150));
            AlterColumn("dbo.Employee", "DesignationID", c => c.Int());
            AlterColumn("dbo.Employee", "DepartmentID", c => c.Int());
            AlterColumn("dbo.Employee", "CreatedBy", c => c.Int());
            AlterColumn("dbo.Employee", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Employee", "Password", c => c.String(maxLength: 150));
            CreateIndex("dbo.Employee", " GenderID");
            CreateIndex("dbo.Employee", "DesignationID");
            CreateIndex("dbo.Employee", "DepartmentID");
            AddForeignKey("dbo.Employee", "DepartmentID", "dbo.Department", "DepartmentID");
            AddForeignKey("dbo.Employee", "DesignationID", "dbo.Designation", "DesignationID");
            AddForeignKey("dbo.Employee", " GenderID", "dbo.Gender", "GenderID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", " GenderID", "dbo.Gender");
            DropForeignKey("dbo.Employee", "DesignationID", "dbo.Designation");
            DropForeignKey("dbo.Employee", "DepartmentID", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "DepartmentID" });
            DropIndex("dbo.Employee", new[] { "DesignationID" });
            DropIndex("dbo.Employee", new[] { " GenderID" });
            AlterColumn("dbo.Employee", "Password", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Employee", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employee", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Employee", "DepartmentID", c => c.Int(nullable: false));
            AlterColumn("dbo.Employee", "DesignationID", c => c.Int(nullable: false));
            AlterColumn("dbo.Employee", " MobileNumber ", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Employee", " GenderID", c => c.Int(nullable: false));
            AlterColumn("dbo.Employee", "EmailID", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Employee", "LastName", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Employee", "FirstName", c => c.String(nullable: false, maxLength: 150));
            CreateIndex("dbo.Employee", "DepartmentID");
            CreateIndex("dbo.Employee", "DesignationID");
            CreateIndex("dbo.Employee", " GenderID");
            AddForeignKey("dbo.Employee", " GenderID", "dbo.Gender", "GenderID", cascadeDelete: true);
            AddForeignKey("dbo.Employee", "DesignationID", "dbo.Designation", "DesignationID", cascadeDelete: true);
            AddForeignKey("dbo.Employee", "DepartmentID", "dbo.Department", "DepartmentID", cascadeDelete: true);
        }
    }
}
