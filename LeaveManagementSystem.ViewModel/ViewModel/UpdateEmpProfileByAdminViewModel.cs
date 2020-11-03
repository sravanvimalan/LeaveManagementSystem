using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.ViewModel
{
    public class UpdateEmpProfileByAdminViewModel
    {
        public int EmployeeID { get; set; }

        public string Image { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        
        public DateTime DateOfBirth { get; set; }
    
       
        public bool EmployeeStatus { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
       


        public string GenderStringId { get; set; }
        public int GenderID { get; set; }
        public string DepartmentStringId { get; set; }
        public int DepartmentID { get; set; }
        public string DesignationStringId { get; set; }
        public int DesignationID { get; set; }
        public string QualificationStringId { get; set; }
        public int QualificationID { get; set; }

       
        
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string MobileNumber { get; set; }
        

        public string DesignationName { get; set; }
        public bool IsSpecialPermission { get; set; }



        
       
      
       
    }
}
