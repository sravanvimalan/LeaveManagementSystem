using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeaveManagementSystem.CustomAuthorizationFilter;
using LeaveManagementSystem.ServiceLayer;
using LeaveManagementSystem.ServiceLayer.IService;
using LeaveManagementSystem.ViewModel;

namespace LeaveManagementSystem.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        IEmployeeService employeeService;
        IGenderService genderService;
        IExperienceService experienceService;
        IQualificationService qualificationService;
        IDesignationService designationService;
        IDepartmentService departmentService;

        public EmployeeController(IEmployeeService employeeService, IGenderService genderService, IExperienceService experienceService, IQualificationService qualificationService, IDesignationService designationService, IDepartmentService departmentService)
        {
            this.employeeService = employeeService;
            this.genderService = genderService;
            this.experienceService = experienceService;
            this.qualificationService = qualificationService;
            this.designationService = designationService;
            this.departmentService = departmentService;
        }

        [CustomAuthorizeAttribute("HR")]
        public ActionResult ListEmployee(string Search = "")
        {
            List<AdminProfileViewModel> list = employeeService.GetAllEmployees();
            list = list.Where(temp => temp.FirstName.Contains(Search)).ToList();
            return View(list);
        }

        [CustomAuthorizeAttribute("HR")]
        public ActionResult AddNewEmployee()
        {
            AdminProfileViewModel adminProfileViewModel = new AdminProfileViewModel();

            var gender = genderService.GetAllGender();
            adminProfileViewModel.GenderList =genderService.GetSelectListItemsGender(gender);

            var qualification = qualificationService.GetAllQualification();

            adminProfileViewModel.QualificationList =qualificationService. GetSelectListItemQualification(qualification);

            var designation = designationService.GetAllDesignation();

            adminProfileViewModel.DesignationList =designationService.GetSelectListItemDesignation(designation);

            var department = departmentService.GetAllDepartment();

            adminProfileViewModel.DepartmentList =departmentService. GetSelectListItemsDepartment(department);
            
            return View(adminProfileViewModel);

        }
        [HttpPost]
        [CustomAuthorizeAttribute("HR")]
        public ActionResult AddNewEmployee(AdminProfileViewModel obj)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var File = Request.Files[0];
                    var ImgByte = new Byte[File.ContentLength + 10];
                    File.InputStream.Read(ImgByte, 0, File.ContentLength);
                    var Base64String = Convert.ToBase64String(ImgByte, 0, ImgByte.Length);
                    obj.Image = Base64String;
                }
                obj.GenderID = Convert.ToInt32(obj.GenderStringId);
                obj.DepartmentID = Convert.ToInt32(obj.DepartmentStringId);
                obj.DesignationID = Convert.ToInt32(obj.DesignationStringId);
                obj.QualificationID = Convert.ToInt32(obj.QualificationStringId);
                obj.ExperienceID = experienceService.GetLatestExperienceID() + 1;
                employeeService.SetNewEmployee(obj);
                return RedirectToAction("employee");
            }
            else
            {
                ModelState.AddModelError("newemployee", "Invalid employee details, please check and try again");
                return RedirectToAction("addnewemployee");
            }

        }

        [CustomAuthorizeAttribute("HR")]
        [Authorize]
        public ActionResult DeleteEmployee(int id)
        {
            employeeService.DeleteEmployeeByEmployeeID(id);
            return RedirectToAction("employee");
        }
        [CustomAuthorizeAttribute("HR")]
        [Authorize]
        public ActionResult AdminEditEmployee(int id)
        {
            AdminProfileViewModel adminProfileView = employeeService.GetEmployeeByID(id);
            var gender = genderService.GetAllGender();
            adminProfileView.GenderList =genderService.GetSelectListItemsGender(gender);

            var qualification = qualificationService.GetAllQualification();

            adminProfileView.QualificationList = qualificationService.GetSelectListItemQualification(qualification);

            var designation = designationService.GetAllDesignation();

            adminProfileView.DesignationList =designationService.GetSelectListItemDesignation(designation);

            var department = departmentService.GetAllDepartment();

            adminProfileView.DepartmentList =departmentService.GetSelectListItemsDepartment(department);
            return View(adminProfileView);
        }
        [HttpPost]
        [Authorize]
        public ActionResult AdminEditEmployee(UpdateEmpProfileByAdminViewModel profile)
        {
            if (ModelState.IsValid)
            {
                profile.DepartmentID = Convert.ToInt32(profile.DepartmentStringId);
                profile.DesignationID = Convert.ToInt32(profile.DesignationStringId);

                employeeService.UpdateProfileByAdmin(profile);

                return RedirectToAction("employee");
            }
            else
            {
                ModelState.AddModelError("profile", "Updation fail");
                return RedirectToAction("employee");
            }

        }
       

        public string GetMobile(string mobile)
        {

            bool value =  employeeService.IsMobileExist(mobile);

            if(value)
            {
                return "found";
            }
            else
            {
                return "not found";
            }

        }
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