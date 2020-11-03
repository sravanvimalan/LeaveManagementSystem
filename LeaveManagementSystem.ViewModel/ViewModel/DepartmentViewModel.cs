using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LeaveManagementSystem.ViewModel
{
    public class DepartmentViewModel
    {
        public int DepartmentID { get; set; }
        [Required]
        public string DepartmentName { get; set; }

        public IEnumerable<SelectListItem> Alldepartmentlist { get; set; }

        public IEnumerable<SelectListItem> AllEmployeelist { get; set; }
    }
}
