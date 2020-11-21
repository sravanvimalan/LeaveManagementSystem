using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LeaveManagementSystem.DomainModel;
using LeaveManagementSystem.DomainModel.DTOClasses;

namespace LeaveManagementSystem.Repository
{
    public interface IEmployeeRespository
    {
        public List<Employee> ListEmployee(string name);
        public Employee GetEmployeeByID(int employeeID);
        public int AuthenticateUser(string email, string password);
        public List<ProjectManagerDTO> GetAllProjectManagers();
        public List<Employee> GetAllEmployees();

        public void AddEmployee(Employee employee);
        public void DeleteEmployeeByEmployeeID(int employeeID);


        public List<Employee> GetEmployeeByDepartmentID(int departmentId);

        public void UpdateIsVirtualHead(int employeeId,bool value);

        public void UpdatePassword(string password,int employeeID);

        public void UpdateProfileByEmployee(Employee profile);

        public void UpdateProfileByAdmin(Employee profile);

        public bool IsMobileExist(string mobile);
        public bool IsEmailExist(string email);
    }
}
