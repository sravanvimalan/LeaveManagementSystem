using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeaveManagementSystem.ServiceLayer;
using LeaveManagementSystem.DomainModel;
using LeaveManagementSystem.ViewModel;
using LeaveManagementSystem.ViewModel.ViewModel;
using LeaveManagementSystem.CustomAuthorizationFilter;

namespace LeaveManagementSystem.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        IDepartmentService departmentService;
        IEmployeeService employeeService;

        public DepartmentController(IDepartmentService departmentService, IEmployeeService employeeService)
        {
            this.departmentService = departmentService;
            this.employeeService = employeeService;
        }


        //[CustomAuthorizeAttribute("HR")]
        public ActionResult Index()
        {

          

            List<DepartmentWithVirtualHeadViewModel> virtualHeadList = departmentService.GetAllDepartmentWithVirtualHead();

            return View(virtualHeadList);

        }
      


    //[CustomAuthorizeAttribute("HR")]
    public ActionResult ChangeVirtualHead(int deptId,int empId,string deptName,string existVTName)
    {
           IEnumerable<SelectListItem> employeeList = employeeService.GetAllEmployeeByDepartmentID(deptId);

           ChangeVHViewModel changeVHViewModel = new ChangeVHViewModel();
           changeVHViewModel.ExistVirtualHeadID = empId;
           changeVHViewModel.ListOfAllEmployee = employeeList;
            changeVHViewModel.DepartmentName = deptName;
            changeVHViewModel.ExistVirtualHeadName = existVTName;
           return View(changeVHViewModel); 

    }
    [HttpPost]
    //[CustomAuthorizeAttribute("HR")]
    public ActionResult ChangeVirtualHead(ChangeVHViewModel VirtualHead)
    {
            if(VirtualHead.NewVirtualTeamHeadID != null)
            {
                employeeService.UpdateIsVirtualHead(VirtualHead.ExistVirtualHeadID, false);
                employeeService.UpdateIsVirtualHead(Convert.ToInt32(VirtualHead.NewVirtualTeamHeadID), true);
            }
           

            return RedirectToAction("index");

       

    }
    //[CustomAuthorizeAttribute("HR")]
    public ActionResult AddDepartment()
    {
        DepartmentViewModel department = new DepartmentViewModel();
        return View(department);
    }
    [HttpPost]
    //[CustomAuthorizeAttribute("HR")]
    public ActionResult AddDepartment(DepartmentViewModel department)
    {
        if (ModelState.IsValid)
        {
            departmentService.AddDepartment(department);
            return RedirectToAction("AddDepartment");

        }
        else
        {

            ModelState.AddModelError("error", "Insertion failed");
            return View(department);
        }




    }
    public string GetDepartment(string department)
    {
        if (departmentService.IsDepartmentExist(department))
        {
            return "found";
        }
        else
        {
            return "not found";
        }
    }


}
}