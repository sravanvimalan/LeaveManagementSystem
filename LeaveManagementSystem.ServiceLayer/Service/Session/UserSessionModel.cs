using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.ServiceLayer.Service.Session
{
    public class UserSessionModel
    {
        public int EmployeeID { get; set; }
        public string Image { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get;set; }
        public DateTime JoinDate { get; set; }
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public bool CanApproveLeaveRequest { get; set; }
        public bool HasAdminPermission { get; set; }
    }
}
