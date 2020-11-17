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
            context.Department.AddOrUpdate(new Department { DepartmentID = 4, DepartmentName = "HR" });


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

            //Normal Employee
            context.Employee.AddOrUpdate(new Employee { FirstName = "sravan", LastName = "V", JoinDate = new DateTime(2015, 10, 05), DateOfBirth = new DateTime(1997, 08, 12), EmployeeStatus = true, AddressLine1 = "attingal", Password = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", EmailID = "sravan@gmail.com", DesignationID = 1, DepartmentID = 1, GenderID = 1, QualificationID = 1, CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now, IsSpecialPermission = false, IsVirtualTeamHead = false, EmployeeID = 1, Nationality = "Indian", MobileNumber = "9847019736" });

            //Project Manager
            context.Employee.AddOrUpdate(new Employee { FirstName = "neeraj", LastName = "raj", JoinDate = new DateTime(2017, 10, 05), DateOfBirth = new DateTime(1995, 09, 02), EmployeeStatus = true, AddressLine1 = "attingal", Password = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", EmailID = "neeraj@gmail.com", DesignationID = 4, DepartmentID = 1, GenderID = 1, QualificationID = 1, CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now, IsSpecialPermission = false, IsVirtualTeamHead = false, EmployeeID = 2, Nationality = "Indian", MobileNumber = "9848519752" });

            //hr with special permission
            context.Employee.AddOrUpdate(new Employee { FirstName = "Kishore", LastName = "V", JoinDate = new DateTime(2013, 05, 05), DateOfBirth = new DateTime(1987, 08, 12), EmployeeStatus = true, AddressLine1 = "attingal", Password = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", EmailID = "kishore@gmail.com", DesignationID = 3, DepartmentID = 4, GenderID = 1, QualificationID = 1, CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now, IsSpecialPermission = true, IsVirtualTeamHead = false, EmployeeID = 3, Nationality = "Indian", MobileNumber = "9878959736" });

            //VT
            context.Employee.AddOrUpdate(new Employee { FirstName = "Mubin", LastName = "SM", JoinDate = new DateTime(2010, 11, 15), DateOfBirth = new DateTime(1980, 08, 12), EmployeeStatus = true, AddressLine1 = "attingal", Password = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", EmailID = "mubin@gmail.com", DesignationID = 1, DepartmentID = 1, GenderID = 1, QualificationID = 1, CreatedBy = 4, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now, IsSpecialPermission = false, IsVirtualTeamHead = true, EmployeeID = 1, Nationality = "Indian", MobileNumber = "9847014587" });
        }
    }
}
