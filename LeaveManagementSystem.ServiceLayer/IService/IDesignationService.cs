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
        public List<Designation> GetAllDesignation();

        public int GetDesignationIdByName(string DesignationName);

        public DesignationViewModel GetDesignationByDesignationID(int DesignationID);

        public bool IsDesignationExist(string designation);

        //public int GetLatestDesignationId();

        public void AddDesignation(DesignationViewModel designationViewModel);
        public IEnumerable<SelectListItem> GetSelectListItemDesignation(IEnumerable<Designation> designation);
    }
}
