using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ToDate { get; set; }
        public bool AmOnly { get; set; }
        public bool PmOnly { get; set; }
        public int VacationTypeID { get; set; }
        public string VacationName { get; set; }
        [Required]
        public string VacationStringID { get; set; }
        public int CreatorID { get; set; }
        public DateTime CreatedOn { get; set; }
        [Required]
        public string Comments { get; set; }
        [Required]
        public int ApproverID { get; set; }
        public string ApproverName { get; set; }
        public string LeaveStatus { get; set; }
        public bool? Isapproved { get; set; }
        [Required]
        public int NoOfDays { get; set; }

        public string Response { get; set; }

       
        public virtual VacationTypeViewModel VacationType { get; set; }
      
        public virtual EmployeeViewModel Approver { get; set; }

     
        public virtual EmployeeViewModel Creater { get; set; }

        public IEnumerable<SelectListItem> VacationTypeList { get; set; }
        public IEnumerable<SelectListItem> ApproverList { get; set; }

        
    }
}
