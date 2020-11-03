using LeaveManagementSystem.DomainModel;
using LeaveManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LeaveManagementSystem.ServiceLayer
{
    public interface IDepartmentService
    {
        public List<DepartmentViewModel> GetAllDepartment();
        public int GetLatestDepartmentID();

        public void AddDepartment(DepartmentViewModel obj);
        public int GetDepartmentIdByName(string DepartmentName);
        public DepartmentViewModel GetDepartmentByDepartmentID(int DepartmentID);

        public bool IsDepartmentExist(string department);

        public IEnumerable<SelectListItem> GetSelectListItemsDepartment(IEnumerable<DepartmentViewModel> department);






    }
}
