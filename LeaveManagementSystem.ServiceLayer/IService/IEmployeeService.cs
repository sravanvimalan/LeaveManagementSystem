using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagementSystem.ViewModel;
using LeaveManagementSystem.DomainModel;
using LeaveManagementSystem.ViewModel.ViewModel;
using System.Web.Mvc;

namespace LeaveManagementSystem.ServiceLayer
{
    public interface IEmployeeService
    {
        public IEnumerable<SelectListItem> GetAllProjectManagers();
        public EmployeeViewModel GetEmployeeByID(int employeeID);
        public int AuthenticateUser(string email, string password);
        public List<EmployeeViewModel> GetAllEmployees();

        public void AddEmployee(AddEmployeeViewModel obj);
        public void DeleteEmployeeByEmployeeID(int employeeID);

       

        public List<EmployeeViewModel> GetAllVirtualHead();

        public IEnumerable<SelectListItem> GetAllEmployeeByDepartmentID(int departmentId);

        public void UpdateIsVirtualHead(int employeeId, bool value);

        public void UpdatePassword(string password, int employeeID);
        public void UpdateProfileByEmployee(UpdateProfileByEmployeeViewModel updateProfile);

        public bool IsMobileExist(string mobile);

        public bool IsEmailExist(string email);
        public void UpdateProfileByAdmin(EmployeeViewModel profile);
        public IEnumerable<SelectListItem> ApproverList(List<EmployeeViewModel> list);
        public IEnumerable<SelectListItem> GetAllEmployeeOfDepartment(List<EmployeeViewModel> employee);

        public List<EmployeeViewModel> ListEmployee(string name);
    }  
}
