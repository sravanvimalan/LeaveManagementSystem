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
        public AdminProfileViewModel GetEmployeeByID(int EmployeeID);
        public AdminProfileViewModel GetEmployeeByEmailAndPassword(string Email, string Password);
        public List<AdminProfileViewModel> GetAllEmployees();

        public void SetNewEmployee(AdminProfileViewModel obj);
        public void DeleteEmployeeByEmployeeID(int EmployeeID);

        public List<AdminProfileViewModel> GetEmployeesByDesignationId(int DesignationId);

        public List<AdminProfileViewModel> GetAllVirtualHead();

        public List<AdminProfileViewModel> GetEmployeeByDepartmentID(int DepartmentId);

        public void UpdateIsVirtualHeadFlag(int EmployeeId, bool value);

        public void UpdatePassword(string Password, int EmployeeID);
        public void UpdateProfileByEmployee(UpdateProfileViewModel updateProfile);

        public bool IsMobileExist(string mobile);

        public bool IsEmailExist(string email);
        public void UpdateProfileByAdmin(UpdateEmpProfileByAdminViewModel profile);
        public IEnumerable<SelectListItem> ApproverList(List<AdminProfileViewModel> list);
        public IEnumerable<SelectListItem> GetAllEmployeeOfDepartment(List<AdminProfileViewModel> employee);
    }  
}
