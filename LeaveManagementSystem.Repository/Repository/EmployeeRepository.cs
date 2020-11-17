using LeaveManagementSystem.DomainModel;
using LeaveManagementSystem.DomainModel.DTOClasses;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LeaveManagementSystem.Repository
{
    public class EmployeeRepository : IEmployeeRespository
    {
        LeaveManagementSystemDbcontext Db;

        public EmployeeRepository()
        {
            Db = new LeaveManagementSystemDbcontext();
        }

        public int AuthenticateUser(string email, string password)
        {
            Employee employee = Db.Employee.Where(temp => temp.EmailID == email && temp.Password == password).FirstOrDefault();
            if (employee != null)
            {
                return employee.EmployeeID;
            }
            return -1;

        }

        public void DeleteEmployeeByEmployeeID(int employeeID)
        {
            Employee obj = Db.Employee.Where(temp => temp.EmployeeID == employeeID).FirstOrDefault();
            if (obj != null)
            {
                obj.EmployeeStatus = false;
                Db.SaveChanges();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> list = Db.Employee.ToList();
            return list;
        }

      
        public List<Employee> GetEmployeeByDepartmentID(int departmentId)
        {
            List<Employee> employeeList = Db.Employee.Where(temp => temp.DepartmentID == departmentId).ToList();

            return employeeList;
        }

        public Employee GetEmployeeByID(int employeeId)
        {
            EmployeeDTO employeeDTO = new EmployeeDTO();

            var employee = Db.Employee.FirstOrDefault(temp => temp.EmployeeID == employeeId);

            
            return employee;
        }

        public List<Employee> GetEmployeesByDesignationId(int DesignationId)
        {
            throw new NotImplementedException();
        }

        public bool IsEmailExist(string email)
        {
            throw new NotImplementedException();
        }










        //public Employee GetEmployeeByID(int EmployeeID)
        //{
        //    Employee obj = Db.Employee.Where(temp => temp.EmployeeID == EmployeeID).FirstOrDefault();
        //    return obj;
        //}

        //    public List<Employee> GetEmployeesByDesignationId(int DesignationId)
        //    {
        //        List<Employee> list = Db.Employee.Where(temp => temp.DesignationID == DesignationId).ToList();

        //        return list;
        //    }

        //    public bool IsEmailExist(string email)
        //    {
        //        return Db.Employee.Any(temp => temp.EmailID == email);
        //    }

        public bool IsMobileExist(string mobile)
        {
            return Db.Employee.Any(temp => temp.MobileNumber == mobile);
        }

        public void AddEmployee(Employee employee)
        {
            Db.Experience.Add(employee.Experience);
            Db.Employee.Add(employee);
            Db.SaveChanges();
        }

        public void UpdateIsVirtualHead(int EmployeeId, bool value)
        {
            if(EmployeeId != 0 )
            {
                Employee employee = GetEmployeeByID(EmployeeId);
                employee.IsVirtualTeamHead = value;
                Db.SaveChanges();
            }
           
        }

        public void UpdatePassword(string password, int employeeID)
        {
            var Employee = Db.Employee.Where(temp => temp.EmployeeID == employeeID).FirstOrDefault();
            Employee.Password = password;
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
            //existProfile.CurrentStatus = profile.CurrentStatus;
            Db.SaveChanges();

        }

        public void UpdateProfileByEmployee(Employee employeeProfile)
        {
            Employee existProfile = Db.Employee.Where(temp => temp.EmployeeID == employeeProfile.EmployeeID).FirstOrDefault();

            existProfile.Image = employeeProfile.Image;
            existProfile.FirstName = employeeProfile.FirstName;
            existProfile.MiddleName = employeeProfile.MiddleName;
            existProfile.LastName = employeeProfile.LastName;
            existProfile.DateOfBirth = employeeProfile.DateOfBirth;
            existProfile.AddressLine1 = employeeProfile.AddressLine1;
            existProfile.AddressLine2 = employeeProfile.AddressLine2;
            existProfile.AddressLine3 = employeeProfile.AddressLine3;
            existProfile.GenderID = employeeProfile.GenderID;
            existProfile.Nationality = employeeProfile.Nationality;
            existProfile.MobileNumber = employeeProfile.MobileNumber;

            Db.SaveChanges();


        }

        public List<ProjectManagerDTO> GetAllProjectManagers()
        {
            var projectManagers = Db.Employee.Where(temp=>temp.Designation.DesignationName == "Project Manager").ToList();
                          

            var projectManagerDTO = new List<ProjectManagerDTO>();
            foreach (var item in projectManagers)
            {
                projectManagerDTO.Add(new ProjectManagerDTO
                {
                    EmployeeID = item.EmployeeID,
                    FirstName = item.FirstName,
                    MiddleName = item.MiddleName,
                    LastName = item.LastName
                }); 

                  
              
            }

            return projectManagerDTO;
           
        }
    }
}
