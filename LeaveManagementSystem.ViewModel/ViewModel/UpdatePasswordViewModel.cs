using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.ViewModel.ViewModel
{
    public class UpdatePasswordViewModel
    {
        public int EmployeeID { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
