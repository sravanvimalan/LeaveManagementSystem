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
      
       
        public void AddDepartment(DepartmentViewModel obj);
      
       
        public bool IsDepartmentExist(string department);

        public IEnumerable<SelectListItem> GetSelectListItemsDepartment();

        public List<DepartmentWithVirtualHeadViewModel> GetAllDepartmentWithVirtualHead();




    }
}
