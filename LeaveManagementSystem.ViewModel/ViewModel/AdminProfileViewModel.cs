using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LeaveManagementSystem.ViewModel
{
    public class AdminProfileViewModel
    {
        public int EmployeeID { get; set; }

        public string Image { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int QualificationID { get; set; }
        public int ExperienceID { get; set; }
        public bool EmployeeStatus { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string EmailID { get; set; }
        
       
        public string GenderStringId { get; set; }
        public string DepartmentStringId { get; set; }
        public string DesignationStringId { get; set; }
        public string QualificationStringId { get; set; }
        public int GenderID { get; set; }
        //public string GenderName { get; set; }
        //public int QualificationId { get; set; }
      
        //public string QualificationName { get; set; }
        public string Nationality { get; set; }
        public string  MobileNumber { get; set; }
        public int DesignationID { get; set; }

        public string DesignationName { get; set; }  
        public int DepartmentID { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Password { get; set; }

        public bool IsSpecialPermission { get; set; }
        
        public bool IsVirtualTeamHead { get; set; }

        public bool CurrentStatus { get; set; }

        public string CompanyName { get; set; }
        public string JobRole { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string NewVirtualTeamHeadID { get; set; }
        public IEnumerable<SelectListItem> GenderList { get; set; }
        public IEnumerable<SelectListItem> QualificationList { get; set; }
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
        public IEnumerable<SelectListItem> DesignationList { get; set; }
        public IEnumerable<SelectListItem> EmployeeList { get; set; }

        public virtual DepartmentViewModel Department { get; set; }
      

    }
}
