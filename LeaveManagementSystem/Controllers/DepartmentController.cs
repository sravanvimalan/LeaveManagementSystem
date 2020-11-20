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
    [CustomAuthorizeAttribute("HasAdminPermission")]
    public class DepartmentController : Controller
    {
        IDepartmentService departmentService;
        IEmployeeService employeeService;

        public DepartmentController(IDepartmentService departmentService, IEmployeeService employeeService)
        {
            this.departmentService = departmentService;
            this.employeeService = employeeService;
        }


     
        public ActionResult DepartmentList()
        {

            List<DepartmentWithVirtualHeadViewModel> virtualHeadList = departmentService.GetAllDepartmentWithVirtualHead();

            return View(virtualHeadList);
        }
      


   
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
  
    public ActionResult ChangeVirtualHead(ChangeVHViewModel VirtualHead)
    {
            if(VirtualHead.NewVirtualTeamHeadID != null)
            {
                employeeService.UpdateIsVirtualHead(VirtualHead.ExistVirtualHeadID, false);
                employeeService.UpdateIsVirtualHead(Convert.ToInt32(VirtualHead.NewVirtualTeamHeadID), true);
            }
           

            return RedirectToAction("DepartmentList");

       

    }
   
    public ActionResult AddDepartment()
    {
        DepartmentViewModel department = new DepartmentViewModel();
        return View(department);
    }
    [HttpPost]
   
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
   


}
}