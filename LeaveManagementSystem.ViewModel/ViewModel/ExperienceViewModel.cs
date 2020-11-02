using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.ViewModel
{
    public class ExperienceViewModel
    {
        public int ExperienceID { get; set; }
        public string CompanyName { get; set; }
        public string JobRole { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
