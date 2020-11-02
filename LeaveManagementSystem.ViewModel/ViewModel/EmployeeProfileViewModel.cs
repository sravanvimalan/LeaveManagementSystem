using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.ViewModel
{
    public class EmployeeProfileViewModel
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
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string AddressLineThree { get; set; }
        public string EmailID { get; set; }
        public string BloodGroup { get; set; }
        public int GenderID { get; set; }
        public string Nationality { get; set; }
        public int MobileNumber { get; set; }
        public int DesignationID { get; set; }
        public int DepartmentID { get; set; }
    }
}
