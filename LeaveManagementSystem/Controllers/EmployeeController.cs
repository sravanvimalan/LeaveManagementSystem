using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeaveManagementSystem.CustomAuthorizationFilter;
using LeaveManagementSystem.ServiceLayer;
using LeaveManagementSystem.ServiceLayer.IService;
using LeaveManagementSystem.ServiceLayer.Service.Session;
using LeaveManagementSystem.ViewModel;
using LeaveManagementSystem.ViewModel.ViewModel;

namespace LeaveManagementSystem.Controllers
{
    [Authorize]
    [CustomAuthorizeAttribute("HasAdminPermission")]

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

       
        public ActionResult ListEmployee(string search="")
        {
            if(search != "")
             return View(employeeService.ListEmployee(search));
            else
            {
                List<EmployeeViewModel> list = employeeService.GetAllEmployees();
                return View(list);
            }
        }

        
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

       
        [Authorize]
        public ActionResult DeleteEmployee(int id)
        {
            employeeService.DeleteEmployeeByEmployeeID(id);
            return RedirectToAction("ListEmployee");
        }
        
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
                employeeViewModel.GenderID = Convert.ToInt32(employeeViewModel.SelectedGenderID);
                employeeViewModel.DepartmentID = Convert.ToInt32(employeeViewModel.SelectedDepartmentID);
                employeeViewModel.DesignationID = Convert.ToInt32(employeeViewModel.SelectedDesignationID);
                employeeViewModel.QualificationID = Convert.ToInt32(employeeViewModel.SelectedQualificationID);
                employeeViewModel.ModifiedBy = Convert.ToInt32(Session["EmployeeID"]);
                employeeViewModel.ModifiedOn = DateTime.Now;
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
       
       
        
    }
}