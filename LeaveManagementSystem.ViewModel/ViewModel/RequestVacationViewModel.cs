using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LeaveManagementSystem.ViewModel
{
    public class RequestVacationViewModel
    {
        public int RequestID { get; set; }
        public string RequesterName { get; set; }
        public string RequesterDesignation { get; set; }
        public string RequesterDepartment { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool AmOnly { get; set; }
        public bool PmOnly { get; set; }
        public int VacationTypeID { get; set; }
        public string VacationName { get; set; }
        public string VacationStringID { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Comments { get; set; }
        public int ApproverID { get; set; }
        public string ApproverName { get; set; }
        public string LeaveStatus { get; set; }
        public bool? Isapproved { get; set; }
       
        public string Response { get; set; }
        public IEnumerable<SelectListItem> VacationTypeList { get; set; }
        public IEnumerable<SelectListItem> ApproverList { get; set; }

        
    }
}
