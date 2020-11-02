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
            signInViewModel.Password = SHA256HashGenerator.GenerateHash(signInViewModel.Password);
            AdminProfileViewModel obj = employeeService.GetEmployeeByEmailAndPassword(signInViewModel.EmailID, signInViewModel.Password);

            if(obj != null)
            {
                var designation = designationService.GetDesignationByDesignationID(obj.DesignationID);
                obj.DesignationName = designation.DesignationName;
                Session["EmployeeObj"] = obj;
                Session["DesignationName"] = designation.DesignationName;
                if(obj.IsVirtualTeamHead == true)
                {
                    Session["VirtualHead"] = "VirtualHead";
                }
                if(obj.IsSpecialPermission == true)
                {
                    Session["HR"] = "HR";
                }
                
                return RedirectToAction("home");
            }
            return RedirectToAction("SignIn");
        }
        [CustomAuthorizeAttribute("HR")]
        public ActionResult Employee(string Search = "")
        {
            List<AdminProfileViewModel> list = employeeService.GetAllEmployees();
            list = list.Where(temp => temp.FirstName.Contains(Search)).ToList();
            return View(list);
        }
       
      
        private IEnumerable<SelectListItem> GetSelectListItemsGender(IEnumerable<Gender> genders)
        {

            var selectList = new List<SelectListItem>();


            foreach (var item in genders)
            {
                selectList.Add(new SelectListItem
                {
                    Value = item.GenderID.ToString(),
                    Text = item.GenderName
                });
            }

            return selectList;
        }
        private IEnumerable<SelectListItem> GetSelectListItemQualification(IEnumerable<Qualification> qualification)
        {
            var selectList = new List<SelectListItem>();

            foreach (var item in qualification)
            {
                selectList.Add(new SelectListItem
                {
                    Value = item.QualificationID.ToString(),
                    Text = item.QualificationName
                }) ;
                
                
            }
            return selectList;
        }
        private IEnumerable<SelectListItem> GetSelectListItemDesignation(IEnumerable<Designation> designation)
        {
            var selectList = new List<SelectListItem>();

            foreach (var item in designation)
            {
                selectList.Add(new SelectListItem
                {
                    Text = item.DesignationName,
                    Value = item.DesignationID.ToString()
                }); 
            }

            return selectList;
        }
        private IEnumerable<SelectListItem> GetSelectListItemsDepartment(IEnumerable<DepartmentViewModel> department)
        {
            var selectList = new List<SelectListItem>();

            foreach(var item in department)
            {
                selectList.Add(new SelectListItem
                {
                    Value = item.DepartmentID.ToString(),
                    Text = item.DepartmentName
                });
            }
            return selectList;
        }
        [CustomAuthorizeAttribute("HR")]
        public ActionResult AddNewEmployee()
        {
            AdminProfileViewModel adminProfileViewModel = new AdminProfileViewModel();

            var gender = genderService.GetAllGender();
            adminProfileViewModel.GenderList= GetSelectListItemsGender(gender);

            var qualification = qualificationService.GetAllQualification();

            adminProfileViewModel.QualificationList = GetSelectListItemQualification(qualification);

            var designation = designationService.GetAllDesignation();

            adminProfileViewModel.DesignationList = GetSelectListItemDesignation(designation);

            var department = departmentService.GetAllDepartment();

            adminProfileViewModel.DepartmentList = GetSelectListItemsDepartment(department);
            //adminProfileViewModel.EmployeeID = 5;
            return View(adminProfileViewModel);

        }
        [HttpPost]
        [CustomAuthorizeAttribute("HR")]
        public ActionResult AddNewEmployee(AdminProfileViewModel obj)
        {
            if(Request.Files.Count >= 1 )
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
            obj.ExperienceID = experienceService.GetLatestExperienceID()+1;
            employeeService.SetNewEmployee(obj);
            return RedirectToAction("employee");
        }
       
        public ActionResult UpdatePassword()
        {
            UpdatePasswordViewModel updatePasswordViewModel = new UpdatePasswordViewModel();
            AdminProfileViewModel adminProfileViewModel = (AdminProfileViewModel)Session["EmployeeObj"];
            updatePasswordViewModel.EmployeeID = adminProfileViewModel.EmployeeID;
            return View(updatePasswordViewModel);
        }
        [HttpPost]
        public ActionResult UpdatePassword(UpdatePasswordViewModel updatePasswordViewModel)
        {
            updatePasswordViewModel.Password = SHA256HashGenerator.GenerateHash(updatePasswordViewModel.Password);

            employeeService.UpdatePassword(updatePasswordViewModel.Password, updatePasswordViewModel.EmployeeID);
            

            return RedirectToAction("UpdatePassword");
        }
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
        public ActionResult UpdateProfile(UpdateProfileViewModel profile)
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
        private IEnumerable<SelectListItem> GetAllVacationType(IEnumerable<VacationType> vacationType)
        {
            var selectList = new List<SelectListItem>();
            foreach (var item in vacationType)
            {
                selectList.Add(new SelectListItem
                {
                    Value = item.VacationTypeID.ToString(),
                    Text = item.VacationName
                });
            }
            return selectList;
           
        }
        private IEnumerable<SelectListItem> ApproverList (List<AdminProfileViewModel> list)
        {
            var selectlist = new List<SelectListItem>();

            foreach (var item in list)
            {
                selectlist.Add(new SelectListItem
                {
                    Text = item.FirstName + " "+ item.MiddleName +" "+ item.LastName,
                    Value = item.EmployeeID.ToString()

                }) ;
            }
            return selectlist;
        }
        
        public ActionResult SendLeaveRequest()
        {
            
            RequestVacationViewModel requestVacationViewModel = new RequestVacationViewModel();
            
            requestVacationViewModel.VacationTypeList = GetAllVacationType(vacationTypeService.GetAllVacationType());

            int designationId = designationService.GetDesignationIdByName("Project Manager");

            List<AdminProfileViewModel> list =     employeeService.GetEmployeesByDesignationId(designationId);

            requestVacationViewModel.ApproverList = ApproverList(list);

            return View(requestVacationViewModel);
        }
        [HttpPost]
        public ActionResult SendLeaveRequest(RequestVacationViewModel vacationRequestViewModel)
        {
            vacationRequestViewModel.VacationTypeID = Convert.ToInt32(vacationRequestViewModel.VacationStringID);
            vacationRequestViewModel.CreatedOn = DateTime.Today;
            var employee= (AdminProfileViewModel)Session["EmployeeObj"];
            vacationRequestViewModel.CreatedBy = employee.EmployeeID;
          
            vacationRequestViewModel.LeaveStatus = "Pending"; //by default
            leaveRequestService.AddLeaveRequest(vacationRequestViewModel);
            return RedirectToAction("SendLeaveRequest");
        }

        [CustomAuthorizeAttribute("HR")]
        public ActionResult DeleteEmployee(int id)
        {
            employeeService.DeleteEmployeeByEmployeeID(id);
            return RedirectToAction("employee");
        }
        [CustomAuthorizeAttribute("HR")]
        public ActionResult AdminEditEmployee(int id)
        {
            AdminProfileViewModel adminProfileView =   employeeService.GetEmployeeByID(id);
            var gender = genderService.GetAllGender();
            adminProfileView.GenderList = GetSelectListItemsGender(gender);

            var qualification = qualificationService.GetAllQualification();

            adminProfileView.QualificationList = GetSelectListItemQualification(qualification);

            var designation = designationService.GetAllDesignation();

            adminProfileView.DesignationList = GetSelectListItemDesignation(designation);

            var department = departmentService.GetAllDepartment();

            adminProfileView.DepartmentList = GetSelectListItemsDepartment(department);
            return View(adminProfileView);
        }
        [HttpPost]
        public ActionResult AdminEditEmployee(UpdateEmpProfileByAdminViewModel profile)
        {
            profile.DepartmentID = Convert.ToInt32(profile.DepartmentStringId);
            profile.DesignationID = Convert.ToInt32(profile.DesignationStringId);

            employeeService.UpdateProfileByAdmin(profile);
           
            return RedirectToAction("employee");
        }
        public ActionResult Home()
        {
            AdminProfileViewModel profileViewModel = (AdminProfileViewModel)Session["EmployeeObj"];

            //profileViewModel.GenderName = genderService.GetGenderById(profileViewModel.GenderID);

            //profileViewModel.QualificationName = qualificationService.GetQualificationById(profileViewModel.QualificationId);
            return View(profileViewModel);
        }
        public ActionResult Unauthorized()
        {
            return View();
        }
       public ActionResult Logout()
        {
            Session["EmployeeObj"] = string.Empty;
            Session["DesignationName"] = string.Empty;
            return RedirectToAction("signin");
        }
       
    }
}