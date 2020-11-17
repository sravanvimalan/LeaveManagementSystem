using LeaveManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagementSystem.DomainModel;
using System.Web.Mvc;

namespace LeaveManagementSystem.ServiceLayer
{
    public interface IDesignationService
    {
       
        public bool IsDesignationExist(string designation);

        public List<DesignationViewModel> GetAllDesignations();
        public void AddDesignation(DesignationViewModel designationViewModel);
        public IEnumerable<SelectListItem> GetSelectListItemDesignation();
    }
}
