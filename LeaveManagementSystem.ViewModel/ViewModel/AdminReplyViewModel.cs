using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.ViewModel.ViewModel
{
    public class AdminReplyViewModel
    {
        public int RequestID { get; set; }
        public string LeaveStatus { get; set; }
        public string Response { get; set; }
       
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }

        public virtual EmployeeViewModel Creater { get; set; }
    }
}
