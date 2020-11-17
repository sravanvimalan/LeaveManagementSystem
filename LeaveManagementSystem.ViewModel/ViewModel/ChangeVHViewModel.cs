using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LeaveManagementSystem.ViewModel
{
    public class ChangeVHViewModel
    {
        public int ExistVirtualHeadID { get; set; }
        public string ExistVirtualHeadName { get; set; }
        public int NewVirtualTeamHeadIntId { get; set; }
        public string NewVirtualTeamHeadID { get; set; }
        public string DepartmentName { get; set; }
        public IEnumerable<SelectListItem> ListOfAllEmployee {get;set;}
     }
}
