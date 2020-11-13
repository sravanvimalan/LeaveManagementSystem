namespace LeaveManagementSystem.DomainModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LeaveManagementSystem.DomainModel.LeaveManagementSystemDbcontext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LeaveManagementSystem.DomainModel.LeaveManagementSystemDbcontext context)
        {
            context.Gender.AddOrUpdate(new Gender { GenderID = 1, GenderName = "male" });
            context.Gender.AddOrUpdate(new Gender { GenderID = 2, GenderName = "female" });
            context.Gender.AddOrUpdate(new Gender { GenderID = 3, GenderName = "neutral" });

            context.Department.AddOrUpdate(new Department { DepartmentID = 1, DepartmentName = "Sales And Marketing" });
            context.Department.AddOrUpdate(new Department { DepartmentID = 2, DepartmentName = "Accounts And Finance" });
            context.Department.AddOrUpdate(new Department { DepartmentID = 3, DepartmentName = "Research And Development" });


            context.Designation.AddOrUpdate(new Designation { DesignationID = 1, DesignationName = "Trainee Engineer" });
            context.Designation.AddOrUpdate(new Designation { DesignationID = 2, DesignationName = "System Analyst" });
            context.Designation.AddOrUpdate(new Designation { DesignationID = 3, DesignationName = "HR Trainee" });
            context.Designation.AddOrUpdate(new Designation { DesignationID = 4, DesignationName = "Project Manager" });

            context.Qualification.AddOrUpdate(new Qualification { QualificationID = 1, QualificationName = "Post Graduate" });
            context.Qualification.AddOrUpdate(new Qualification { QualificationID = 2, QualificationName = "Graduate" });


            context.VacationType.AddOrUpdate(new VacationType { VacationName = "Loss Of Pay", VacationTypeID = 1 });
            context.VacationType.AddOrUpdate(new VacationType { VacationName = "Compensatory", VacationTypeID = 2 });
            context.VacationType.AddOrUpdate(new VacationType { VacationName = "Maternity", VacationTypeID = 3 });
            context.VacationType.AddOrUpdate(new VacationType { VacationName = "Paternity", VacationTypeID = 4 });


            context.Employee.AddOrUpdate(new Employee { FirstName="sravan",LastName = "V",JoinDate=new DateTime(2020,10,05),DateOfBirth = new DateTime(1997,08,12),EmployeeStatus=true,AddressLine1="attingal",,})
        }
    }
}
