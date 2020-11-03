using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeaveManagementSystem.ServiceLayer;
using LeaveManagementSystem.DomainModel;
using LeaveManagementSystem.ViewModel;
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
      

        [CustomAuthorizeAttribute("HR")]
        public ActionResult Index()
        {
         
            List<ListAllDepartmentAndVirtualHeadViewModel> listAllVirutalHead = new List<ListAllDepartmentAndVirtualHeadViewModel>();

            List<AdminProfileViewModel> virtualHeadList = employeeService.GetAllVirtualHead();

            foreach (var item in virtualHeadList)
            {
                listAllVirutalHead.Add(new ListAllDepartmentAndVirtualHeadViewModel
                {
                    EmployeeID = item.EmployeeID,
                    DepartmentID = item.DepartmentID,
                    VirtualHeadName = item.FirstName + " " + item.MiddleName + " " + item.LastName,
                    DepartmentName = item.Department.DepartmentName
                }) ;
            }
             

            return View(listAllVirutalHead);

        }
       
        [CustomAuthorizeAttribute("HR")]
        public ActionResult ChangeVirtualHead(int Id)
        {
            AdminProfileViewModel existingVH = employeeService.GetEmployeeByID(Id);
            List<AdminProfileViewModel> employeeList = employeeService.GetEmployeeByDepartmentID(existingVH.DepartmentID);

            AdminProfileViewModel newVitualHead = new AdminProfileViewModel();

            existingVH.EmployeeList = employeeService.GetAllEmployeeOfDepartment(employeeList);

            return View(existingVH);



        }
        [HttpPost]
        [CustomAuthorizeAttribute("HR")]
        public ActionResult ChangeVirtualHead(NewVHViewModel newVirtualHead)
        {
            if(ModelState.IsValid)
            {
                newVirtualHead.NewVirtualTeamHeadIntId = Convert.ToInt32(newVirtualHead.NewVirtualTeamHeadID);

                employeeService.UpdateIsVirtualHeadFlag(newVirtualHead.EmployeeID, false);

                employeeService.UpdateIsVirtualHeadFlag(newVirtualHead.NewVirtualTeamHeadIntId, true);

                return RedirectToAction("index");

            }
            else
            {
                ModelState.AddModelError("Error", "Error Occured");
                return RedirectToAction("index");
            }

        }
        [CustomAuthorizeAttribute("HR")]
        public ActionResult AddDepartment()
        {
            DepartmentViewModel department = new DepartmentViewModel();
            return View(department);
        }
        [HttpPost]
        [CustomAuthorizeAttribute("HR")]
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