using LeaveManagementSystem.DomainModel;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Repository
{
    public class EmployeeRepository : IEmployeeRespository
    {
        LeaveManagementSystemDbcontext Db;

        public EmployeeRepository()
        {
            Db = new LeaveManagementSystemDbcontext();
        }

        public void DeleteEmployeeByEmployeeID(int EmployeeID)
        {
            Employee obj = Db.Employee.Where(temp => temp.EmployeeID == EmployeeID).FirstOrDefault();
            if(obj != null)
            {
                Db.Employee.Remove(obj);
                Db.SaveChanges();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> list = Db.Employee.ToList();
            return list;
        }

        public List<Employee> GetAllVirtualHead()
        {
            List<Employee> list = Db.Employee.Where(temp => temp.IsVirtualTeamHead == true).ToList();
            return list;
        }

        public List<Employee> GetEmployeeByDepartmentID(int DepartmentId)
        {
            List<Employee> employeeList = Db.Employee.Where(temp => temp.DepartmentID == DepartmentId).ToList();

            return employeeList;
        }

        public Employee GetEmployeeByEmailAndPassword(string Email, string Password)
        {
            Employee obj = Db.Employee.Where(temp => temp.EmailID == Email & temp.Password == Password).FirstOrDefault();

            return obj;
        }

        public Employee GetEmployeeByID(int EmployeeID)
        {
            Employee obj = Db.Employee.Where(temp => temp.EmployeeID == EmployeeID).FirstOrDefault();
            return obj;
        }

        public List<Employee> GetEmployeesByDesignationId(int DesignationId)
        {
            List<Employee> list = Db.Employee.Where(temp => temp.DesignationID == DesignationId).ToList();

            return list;
        }

        public bool IsEmailExist(string email)
        {
            return Db.Employee.Any(temp => temp.EmailID == email);
        }

        public bool IsMobileExist(string mobile)
        {
            return Db.Employee.Any(temp => temp.MobileNumber == mobile);
        }

        public void SetNewEmployee(Employee obj,Experience exp)
        {
            Db.Experience.Add(exp);
            Db.SaveChanges();
            Db.Employee.Add(obj);
            Db.SaveChanges();
        }

        public void UpdateIsVirtualHeadFlag(int EmployeeId,bool value)
        {
            Employee employee = GetEmployeeByID(EmployeeId);
            employee.IsVirtualTeamHead = value;
            Db.SaveChanges();
        }

        public void UpdatePassword(string Password,int EmployeeID)
        {
            var Employee = Db.Employee.Where(temp => temp.EmployeeID == EmployeeID).FirstOrDefault();
            Employee.Password = Password;
            Db.SaveChanges();
        }

        public void UpdateProfileByAdmin(Employee profile)
        {
            Employee existProfile = Db.Employee.Where(temp => temp.EmployeeID == profile.EmployeeID).FirstOrDefault();

            existProfile.Image = profile.Image;
            existProfile.FirstName = profile.FirstName;
            existProfile.MiddleName = profile.MiddleName;
            existProfile.LastName = profile.LastName;
            existProfile.EmployeeStatus = profile.EmployeeStatus;
            existProfile.AddressLine1 = profile.AddressLine1;
            existProfile.AddressLine2 = profile.AddressLine2;
            existProfile.AddressLine3 = profile.AddressLine3;
            existProfile.DepartmentID = profile.DepartmentID;
            existProfile.DesignationID = profile.DesignationID;
            existProfile.DateOfBirth = profile.DateOfBirth;
            existProfile.IsSpecialPermission = profile.IsSpecialPermission;
            existProfile.CurrentStatus = profile.CurrentStatus;
            Db.SaveChanges();
            
        }

        public void UpdateProfileByEmployee(Employee profile)
        {
            Employee existProfile = Db.Employee.Where(temp => temp.EmployeeID == profile.EmployeeID).FirstOrDefault();

            existProfile.Image = profile.Image;
            existProfile.FirstName = profile.FirstName;
            existProfile.MiddleName = profile.MiddleName;
            existProfile.LastName = profile.LastName;
            existProfile.DateOfBirth = profile.DateOfBirth;
            existProfile.AddressLine1 = profile.AddressLine1;
            existProfile.AddressLine2 = profile.AddressLine2;
            existProfile.AddressLine3 = profile.AddressLine3;
            existProfile.GenderID = profile.GenderID;
            existProfile.Nationality = profile.Nationality;
            existProfile.MobileNumber = profile.MobileNumber;

            Db.SaveChanges();
            




        }
    }
}
