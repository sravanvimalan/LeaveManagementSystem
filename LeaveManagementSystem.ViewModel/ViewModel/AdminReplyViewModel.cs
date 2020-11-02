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
        public int CreatedBy { get; set; }
    }
}
