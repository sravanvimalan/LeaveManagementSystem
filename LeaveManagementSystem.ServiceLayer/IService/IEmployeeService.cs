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
        public EmployeeViewModel GetEmployeeByID(int EmployeeID);
        public int AuthenticateUser(string Email, string Password);
        public List<EmployeeViewModel> GetAllEmployees();

        public void AddEmployee(AddEmployeeViewModel obj);
        public void DeleteEmployeeByEmployeeID(int EmployeeID);

       

        public List<EmployeeViewModel> GetAllVirtualHead();

        public IEnumerable<SelectListItem> GetAllEmployeeByDepartmentID(int DepartmentId);

        public void UpdateIsVirtualHead(int EmployeeId, bool value);

        public void UpdatePassword(string Password, int EmployeeID);
        public void UpdateProfileByEmployee(UpdateProfileByEmployeeViewModel updateProfile);

        public bool IsMobileExist(string mobile);

        public bool IsEmailExist(string email);
        public void UpdateProfileByAdmin(EmployeeViewModel profile);
        public IEnumerable<SelectListItem> ApproverList(List<EmployeeViewModel> list);
        public IEnumerable<SelectListItem> GetAllEmployeeOfDepartment(List<EmployeeViewModel> employee);
    }  
}
