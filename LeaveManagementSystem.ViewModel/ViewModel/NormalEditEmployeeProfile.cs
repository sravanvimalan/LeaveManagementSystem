using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.ViewModel
{
    public class NormalEditEmployeeProfile
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string AddressLineThree { get; set; }
        public string BloodGroup { get; set; }
        public int GenderID { get; set; }
        public string Nationality { get; set; }
        public int MobileNumber { get; set; }
    }
}
