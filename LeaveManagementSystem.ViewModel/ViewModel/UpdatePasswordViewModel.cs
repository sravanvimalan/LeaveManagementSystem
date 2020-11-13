using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.ViewModel.ViewModel
{
    public class UpdatePasswordViewModel
    {
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(5)] 
  
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [MinLength(5)]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

    }
}
