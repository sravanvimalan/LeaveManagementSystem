using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace LeaveManagementSystem.ViewModel
{
    public class SignInViewModel
    {
        [Required]

        public string EmailID { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
