using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LeaveManagementSystem.ViewModel.ViewModel
{
    public class UpdateProfileViewModel
    {
        public int EmployeeID { get; set; }
        public string Image { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public int GenderID { get; set; }
        public string GenderName { get; set; }
        public string Nationality { get; set; }
        public string MobileNumber { get; set; }

        public IEnumerable<SelectListItem> GenderList { get; set; }
    }
}
