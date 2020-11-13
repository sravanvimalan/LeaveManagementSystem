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
        public Employee GetEmployeeByID(int EmployeeID);
        public int AuthenticateUser(string Email, string Password);

        public List<ProjectManagerDTO> GetAllProjectManagers();








        /// <summary>
        /// consider above functions 
        /// </summary>
        /// <returns></returns>

        public List<Employee> GetAllEmployees();

        public void SetNewEmployee(Employee obj,Experience exp);
        public void DeleteEmployeeByEmployeeID(int EmployeeID);

        public List<Employee> GetEmployeesByDesignationId(int DesignationId);

        public List<Employee> GetAllVirtualHead();

        public List<Employee> GetEmployeeByDepartmentID(int DepartmentId);

        public void UpdateIsVirtualHeadFlag(int EmployeeId,bool value);

        public void UpdatePassword(string Password,int EmployeeID);

        public void UpdateProfileByEmployee(Employee profile);

        public void UpdateProfileByAdmin(Employee profile);

        public bool IsMobileExist(string mobile);
        public bool IsEmailExist(string email);
    }
}
