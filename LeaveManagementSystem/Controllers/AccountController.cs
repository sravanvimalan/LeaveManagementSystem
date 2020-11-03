using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeaveManagementSystem.ViewModel;
using LeaveManagementSystem.ServiceLayer;
using LeaveManagementSystem.DomainModel;
using System.Dynamic;
using LeaveManagementSystem.ServiceLayer.IService;
using System.Web.Mvc.Html;
using LeaveManagementSystem.ViewModel.ViewModel;
using System.Web.Http.Filters;
using LeaveManagementSystem.CustomAuthorizationFilter;
using System.Runtime.Remoting;
using System.Web.Security;

namespace LeaveManagementSystem.Controllers
{

    
    public class AccountController : Controller
    {
        IGenderService genderService;
        IQualificationService qualificationService;
        IDepartmentService departmentService;
        IDesignationService designationService;
        IEmployeeService employeeService;
        IExperienceService experienceService;
        ILeaveRequestService leaveRequestService;
        IVacationTypeService vacationTypeService;

        public AccountController(IGenderService genderService, IQualificationService qualificationService, IDepartmentService departmentService, IDesignationService designationService, IEmployeeService employeeService, IExperienceService experienceService, ILeaveRequestService leaveRequestService, IVacationTypeService vacationTypeService)
        {
            this.genderService = genderService;
            this.qualificationService = qualificationService;
            this.departmentService = departmentService;
            this.designationService = designationService;
            this.employeeService = employeeService;
            this.experienceService = experienceService;
            this.leaveRequestService = leaveRequestService;
            this.vacationTypeService = vacationTypeService;
        }
        
        public ActionResult SignIn()
        {
            SignInViewModel signInViewModel = new SignInViewModel();
            return View(signInViewModel);
        }
        [HttpPost]
        public ActionResult SignIn(SignInViewModel signInViewModel)
        {
            if (ModelState.IsValid)
            {

                signInViewModel.Password = SHA256HashGenerator.GenerateHash(signInViewModel.Password);
                AdminProfileViewModel obj = employeeService.GetEmployeeByEmailAndPassword(signInViewModel.EmailID, signInViewModel.Password);

                if (obj != null)
                {
                   
                    var designation = designationService.GetDesignationByDesignationID(obj.DesignationID);
                    obj.DesignationName = designation.DesignationName;
                    Session["EmployeeObj"] = obj;
                    Session["EmployeeEmail"] = obj.EmailID;
                    Session["DesignationName"] = designation.DesignationName;
                    if (obj.IsVirtualTeamHead == true)
                    {
                        Session["VirtualHead"] = "VirtualHead";
                    }
                    if (obj.IsSpecialPermission == true)
                    {
                        Session["HR"] = "HR";
                    }
                    FormsAuthentication.SetAuthCookie(Convert.ToString(Session["EmployeeEmail"]), false);
            
                    return RedirectToAction("home");
                }
                else
                {
                    ModelState.AddModelError("signin", "Invalid email or password");
                    return View("SignIn", signInViewModel);
                }
               
            }
            else
            {
                ModelState.AddModelError("signin", "Invalid email or password");
                return View("SignIn", signInViewModel);
            }
         
        }
      
       
       [Authorize]
        public ActionResult UpdatePassword()
        {
            UpdatePasswordViewModel updatePasswordViewModel = new UpdatePasswordViewModel();
            AdminProfileViewModel adminProfileViewModel = (AdminProfileViewModel)Session["EmployeeObj"];
            updatePasswordViewModel.EmployeeID = adminProfileViewModel.EmployeeID;
            return View(updatePasswordViewModel);
        }
        [HttpPost]
        [Authorize]
        public ActionResult UpdatePassword(UpdatePasswordViewModel updatePasswordViewModel)
        {
            if(ModelState.IsValid)
            {
                updatePasswordViewModel.Password = SHA256HashGenerator.GenerateHash(updatePasswordViewModel.Password);

                employeeService.UpdatePassword(updatePasswordViewModel.Password, updatePasswordViewModel.EmployeeID);
                return RedirectToAction("UpdatePassword");
            }
            else
            {
                ModelState.AddModelError("password", "Invalid Format");
                return RedirectToAction("UpdatePassword");
            }
         
        }
        [Authorize]
        public ActionResult UpdateProfile()
        {
           
            UpdateProfileViewModel updateProfileViewModel = new UpdateProfileViewModel();
            AdminProfileViewModel profile = (AdminProfileViewModel)Session["EmployeeObj"];
            updateProfileViewModel.EmployeeID = profile.EmployeeID;
            updateProfileViewModel.FirstName = profile.FirstName;
            updateProfileViewModel.MiddleName = profile.MiddleName;
            updateProfileViewModel.LastName = profile.LastName;
            updateProfileViewModel.Image = profile.Image;
            updateProfileViewModel.AddressLine1 = profile.AddressLine1;
            updateProfileViewModel.AddressLine2 = profile.AddressLine2;
            updateProfileViewModel.AddressLine3 = profile.AddressLine3;
            updateProfileViewModel.Nationality = profile.Nationality;
            updateProfileViewModel.MobileNumber = profile.MobileNumber;
            updateProfileViewModel.DateOfBirth = profile.DateOfBirth;
            updateProfileViewModel.GenderID = profile.GenderID;
            updateProfileViewModel.GenderList = genderService.GenderList();
            updateProfileViewModel.GenderName = genderService.GetGenderById(profile.GenderID);
            return View(updateProfileViewModel);
        }
        [HttpPost]
        [Authorize]
        public ActionResult UpdateProfile(UpdateProfileViewModel profile)
        {
            if(ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var File = Request.Files[0];
                    var ImgByte = new Byte[File.ContentLength + 10];
                    File.InputStream.Read(ImgByte, 0, File.ContentLength);
                    var Base64String = Convert.ToBase64String(ImgByte, 0, ImgByte.Length);
                    profile.Image = Base64String;
                }
                employeeService.UpdateProfileByEmployee(profile);
                Session["EmployeeObj"] = employeeService.GetEmployeeByID(profile.EmployeeID);

                return RedirectToAction("Updateprofile");
            }
            else
            {
                ModelState.AddModelError("profile", "Invalid Details");
                return RedirectToAction("Updateprofile");
            }
           
        }
       
      
        [Authorize]
        public ActionResult Home()
        {
            AdminProfileViewModel profileViewModel = (AdminProfileViewModel)Session["EmployeeObj"];

            return View(profileViewModel);
        }
        public ActionResult Unauthorized()
        {
            return View();
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["EmployeeObj"] = string.Empty;
            Session["DesignationName"] = string.Empty;
            return RedirectToAction("signin");
        }
       
    }
}