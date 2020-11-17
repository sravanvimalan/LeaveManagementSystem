using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.DomainModel.DTOClasses
{
    public class DepartmentWithVirtualHeadDTO
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int? EmployeeID { get; set; }
        public string EmployeeName { get; set; }
    }
}
