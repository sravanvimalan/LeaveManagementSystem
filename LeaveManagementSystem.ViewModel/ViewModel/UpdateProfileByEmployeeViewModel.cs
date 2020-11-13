using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LeaveManagementSystem.ViewModel.ViewModel
{
    public class UpdateProfileByEmployeeViewModel
    {
        public int EmployeeID { get; set; }
        public string Image { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        //[Required]
        public int GenderID { get; set; }
        public string GenderName { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        public IEnumerable<SelectListItem> GenderList { get; set; }
    }
}
