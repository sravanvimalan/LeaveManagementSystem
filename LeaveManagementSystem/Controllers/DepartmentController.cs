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
    public class DepartmentController : Controller
    {
        IDepartmentService departmentService;
        IEmployeeService employeeService;

        public DepartmentController(IDepartmentService departmentService, IEmployeeService employeeService)
        {
            this.departmentService = departmentService;
            this.employeeService = employeeService;
        }
        private IEnumerable<SelectListItem> GetAllDepartment(IEnumerable<DepartmentViewModel> departmentViewModels)
        {
            var selectList = new List<SelectListItem>();

            foreach (var item in departmentViewModels)
            {
                selectList.Add(new SelectListItem
                {
                    Text = item.DepartmentName,
                    Value = item.DepartmentID.ToString()
                }) ;
            }
            return selectList;
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
        private IEnumerable<SelectListItem> GetAllEmployeeOfDepartment(List<AdminProfileViewModel> employee)
        {
            var selectList = new List<SelectListItem>();

            foreach (var item in employee)
            {
                selectList.Add(new SelectListItem
                {
                    Value =item.EmployeeID.ToString(),
                    Text = item.FirstName + " " + item.MiddleName + " " + item.LastName
                });
            }
            return selectList;
        }
        [CustomAuthorizeAttribute("HR")]
        public ActionResult ChangeVirtualHead(int Id)
        {
            AdminProfileViewModel existingVH = employeeService.GetEmployeeByID(Id);
            List<AdminProfileViewModel> employeeList = employeeService.GetEmployeeByDepartmentID(existingVH.DepartmentID);

            AdminProfileViewModel newVitualHead = new AdminProfileViewModel();

            existingVH.EmployeeList = GetAllEmployeeOfDepartment(employeeList);

            return View(existingVH);



        }
        [HttpPost]
        [CustomAuthorizeAttribute("HR")]
        public ActionResult ChangeVirtualHead(NewVHViewModel newVirtualHead)
        {
            newVirtualHead.NewVirtualTeamHeadIntId = Convert.ToInt32(newVirtualHead.NewVirtualTeamHeadID);

            employeeService.UpdateIsVirtualHeadFlag(newVirtualHead.EmployeeID, false);

            employeeService.UpdateIsVirtualHeadFlag(newVirtualHead.NewVirtualTeamHeadIntId, true);

            

            

            return RedirectToAction("index");

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
            departmentService.AddDepartment(department);
            return RedirectToAction("AddDepartment");
        }


    }
}