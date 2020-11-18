using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeaveManagementSystem.CustomAuthorizationFilter;
using LeaveManagementSystem.ServiceLayer;
using LeaveManagementSystem.ServiceLayer.IService;
using LeaveManagementSystem.ViewModel;
using LeaveManagementSystem.ViewModel.ViewModel;

namespace LeaveManagementSystem.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        IEmployeeService employeeService;
        IGenderService genderService;
       
        IQualificationService qualificationService;
        IDesignationService designationService;
        IDepartmentService departmentService;

        public EmployeeController(IEmployeeService employeeService, IGenderService genderService,  IQualificationService qualificationService, IDesignationService designationService, IDepartmentService departmentService)
        {
            this.employeeService = employeeService;
            this.genderService = genderService;
           
            this.qualificationService = qualificationService;
            this.designationService = designationService;
            this.departmentService = departmentService;
        }

        //[CustomAuthorizeAttribute("HR")]
        public ActionResult ListEmployee(string Search = "")
        {
            List<EmployeeViewModel> list = employeeService.GetAllEmployees();
            list = list.Where(temp => temp.FirstName.Contains(Search)).ToList();
            return View(list);
        }

        //[CustomAuthorizeAttribute("HR")]
        public ActionResult AddEmployee()
        {
            AddEmployeeViewModel addEmployeeViewModel = new AddEmployeeViewModel();

            addEmployeeViewModel.EmployeeStatus = true;
            addEmployeeViewModel.GenderList =genderService.GenderList();
            addEmployeeViewModel.QualificationList =qualificationService. GetSelectListItemQualification();
            addEmployeeViewModel.DesignationList =designationService.GetSelectListItemDesignation();
            addEmployeeViewModel.DepartmentList =departmentService. GetSelectListItemsDepartment();
            
            return View(addEmployeeViewModel);

        }
        [HttpPost]
        //[CustomAuthorizeAttribute("HR")]
        public ActionResult AddEmployee(AddEmployeeViewModel addEmployeeViewModel)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var File = Request.Files[0];
                    var ImgByte = new Byte[File.ContentLength + 10];
                    File.InputStream.Read(ImgByte, 0, File.ContentLength);
                    var Base64String = Convert.ToBase64String(ImgByte, 0, ImgByte.Length);
                    addEmployeeViewModel.Image = Base64String;
                }
                
                employeeService.AddEmployee(addEmployeeViewModel);
                return RedirectToAction("ListEmployee");
            }
            else
            {
                ModelState.AddModelError("newemployee", "Invalid employee details, please check and try again");
                addEmployeeViewModel.GenderList = genderService.GenderList();
                addEmployeeViewModel.QualificationList = qualificationService.GetSelectListItemQualification();
                addEmployeeViewModel.DesignationList = designationService.GetSelectListItemDesignation();
                addEmployeeViewModel.DepartmentList = departmentService.GetSelectListItemsDepartment();
                return View(addEmployeeViewModel);
            }

        }

        //[CustomAuthorizeAttribute("HR")]
        [Authorize]
        public ActionResult DeleteEmployee(int id)
        {
            employeeService.DeleteEmployeeByEmployeeID(id);
            return RedirectToAction("ListEmployee");
        }
        //[CustomAuthorizeAttribute("HR")]
        //[Authorize]
        public ActionResult AdminEditEmployee(int id)
        {
            EmployeeViewModel EmployeeViewModel = employeeService.GetEmployeeByID(id);
            EmployeeViewModel.GenderList = genderService.GenderList();
            EmployeeViewModel.QualificationList = qualificationService.GetSelectListItemQualification();
            EmployeeViewModel.DesignationList = designationService.GetSelectListItemDesignation();
            EmployeeViewModel.DepartmentList = departmentService.GetSelectListItemsDepartment();
            EmployeeViewModel.GenderName = EmployeeViewModel.Gender.GenderName;
            EmployeeViewModel.QualificationName = EmployeeViewModel.Qualification.QualificationName;
            EmployeeViewModel.DepartmentName = EmployeeViewModel.Department.DepartmentName;
            EmployeeViewModel.DesignationName = EmployeeViewModel.Designation.DesignationName;
            EmployeeViewModel.SelectedGenderID = Convert.ToString(EmployeeViewModel.Gender.GenderID);
            EmployeeViewModel.SelectedDesignationID = Convert.ToString(EmployeeViewModel.Designation.DesignationID);
            EmployeeViewModel.SelectedDepartmentID = Convert.ToString(EmployeeViewModel.Department.DepartmentID);
            EmployeeViewModel.SelectedQualificationID = Convert.ToString(EmployeeViewModel.Qualification.QualificationID);
           
           

            return View(EmployeeViewModel);
        }
        [HttpPost]
        //[Authorize]
        public ActionResult AdminEditEmployee(EmployeeViewModel employeeViewModel)
        {

            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var File = Request.Files[0];
                    var ImgByte = new Byte[File.ContentLength + 10];
                    File.InputStream.Read(ImgByte, 0, File.ContentLength);
                    var Base64String = Convert.ToBase64String(ImgByte, 0, ImgByte.Length);
                    employeeViewModel.Image = Base64String;
                }

                employeeService.UpdateProfileByAdmin(employeeViewModel);
                return RedirectToAction("ListEmployee");
            }
            else
            {
               
                ModelState.AddModelError("newemployee", "Invalid employee details, please check and try again");
                //employeeViewModel = employeeService.GetEmployeeByID(employeeViewModel.EmployeeID);
                employeeViewModel.GenderList = genderService.GenderList();
                employeeViewModel.QualificationList = qualificationService.GetSelectListItemQualification();
                employeeViewModel.DesignationList = designationService.GetSelectListItemDesignation();
                employeeViewModel.DepartmentList = departmentService.GetSelectListItemsDepartment();
                return View(employeeViewModel);
            }

        }
       
        [HttpGet]
        public JsonResult GetMobile(string mobile)
        {

            bool value =  employeeService.IsMobileExist(mobile);

            if(value)
            {
                return Json(new { msg = " found" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { msg = " not found" }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpGet]
        public string GetEmail(string email)
        {
            bool value = employeeService.IsEmailExist(email);

            if (value)
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