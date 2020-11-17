namespace LeaveManagementSystem.DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Designation",
                c => new
                    {
                        DesignationID = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.DesignationID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 150),
                        MiddleName = c.String(maxLength: 150),
                        LastName = c.String(nullable: false, maxLength: 150),
                        JoinDate = c.DateTime(nullable: false),
                        DateOfBirth = c.DateTime(name: " DateOfBirth", nullable: false),
                        QualificationID = c.Int(name: " QualificationID"),
                        ExperienceID = c.Int(),
                        EmployeeStatus = c.Boolean(name: " EmployeeStatus", nullable: false),
                        AddressLine1 = c.String(maxLength: 150),
                        AddressLine2 = c.String(maxLength: 150),
                        AddressLine3 = c.String(maxLength: 150),
                        EmailID = c.String(nullable: false, maxLength: 150),
                        GenderID = c.Int(name: " GenderID", nullable: false),
                        Nationality = c.String(maxLength: 150),
                        MobileNumber = c.String(name: " MobileNumber ", nullable: false, maxLength: 150),
                        DesignationID = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                        Password = c.String(nullable: false, maxLength: 150),
                        IsVirtualTeamHead = c.Boolean(nullable: false),
                        IsSpecialPermission = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.Designation", t => t.DesignationID, cascadeDelete: true)
                .ForeignKey("dbo.Experience", t => t.ExperienceID)
                .ForeignKey("dbo.Gender", t => t.GenderID, cascadeDelete: true)
                .ForeignKey("dbo.Qualification", t => t.QualificationID)
                .Index(t => t.QualificationID)
                .Index(t => t.ExperienceID)
                .Index(t => t.GenderID)
                .Index(t => t.DesignationID)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Experience",
                c => new
                    {
                        ExperienceID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(maxLength: 150),
                        JobRole = c.String(maxLength: 150),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ExperienceID);
            
            CreateTable(
                "dbo.Gender",
                c => new
                    {
                        GenderID = c.Int(nullable: false, identity: true),
                        GenderName = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.GenderID);
            
            CreateTable(
                "dbo.Qualification",
                c => new
                    {
                        QualificationID = c.Int(nullable: false, identity: true),
                        QualificationName = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.QualificationID);
            
            CreateTable(
                "dbo.RequestVacation",
                c => new
                    {
                        RequestID = c.Int(nullable: false, identity: true),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        AmOnly = c.Boolean(),
                        PmOnly = c.Boolean(),
                        VacationTypeID = c.Int(nullable: false),
                        CreatorID = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        Comments = c.String(maxLength: 150),
                        ApproverID = c.Int(nullable: false),
                        LeaveStatus = c.String(maxLength: 8000, unicode: false),
                        Response = c.String(maxLength: 200),
                        NoOfDays = c.Int(name: "No Of Days", nullable: false),
                    })
                .PrimaryKey(t => t.RequestID)
                .ForeignKey("dbo.Employee", t => t.ApproverID, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.CreatorID)
                .ForeignKey("dbo.VacationType", t => t.VacationTypeID, cascadeDelete: true)
                .Index(t => t.VacationTypeID)
                .Index(t => t.CreatorID)
                .Index(t => t.ApproverID);
            
            CreateTable(
                "dbo.VacationType",
                c => new
                    {
                        VacationTypeID = c.Int(nullable: false, identity: true),
                        VacationName = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.VacationTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequestVacation", "VacationTypeID", "dbo.VacationType");
            DropForeignKey("dbo.RequestVacation", "CreatorID", "dbo.Employee");
            DropForeignKey("dbo.RequestVacation", "ApproverID", "dbo.Employee");
            DropForeignKey("dbo.Employee", " QualificationID", "dbo.Qualification");
            DropForeignKey("dbo.Employee", " GenderID", "dbo.Gender");
            DropForeignKey("dbo.Employee", "ExperienceID", "dbo.Experience");
            DropForeignKey("dbo.Employee", "DesignationID", "dbo.Designation");
            DropForeignKey("dbo.Employee", "DepartmentID", "dbo.Department");
            DropIndex("dbo.RequestVacation", new[] { "ApproverID" });
            DropIndex("dbo.RequestVacation", new[] { "CreatorID" });
            DropIndex("dbo.RequestVacation", new[] { "VacationTypeID" });
            DropIndex("dbo.Employee", new[] { "DepartmentID" });
            DropIndex("dbo.Employee", new[] { "DesignationID" });
            DropIndex("dbo.Employee", new[] { " GenderID" });
            DropIndex("dbo.Employee", new[] { "ExperienceID" });
            DropIndex("dbo.Employee", new[] { " QualificationID" });
            DropTable("dbo.VacationType");
            DropTable("dbo.RequestVacation");
            DropTable("dbo.Qualification");
            DropTable("dbo.Gender");
            DropTable("dbo.Experience");
            DropTable("dbo.Employee");
            DropTable("dbo.Designation");
            DropTable("dbo.Department");
        }
    }
}
