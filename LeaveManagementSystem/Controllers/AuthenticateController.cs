using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeaveManagementSystem.ViewModel;
using LeaveManagementSystem.ServiceLayer;
using LeaveManagementSystem.ServiceLayer.Service.Session;
using System.Web.Security;


namespace LeaveManagementSystem.Controllers
{
    public class AuthenticateController : Controller
    {
        IEmployeeService employeeService;
        IDesignationService designationService;
        IDepartmentService departmentService;
        UserSessionModel userSessionModel;

        public AuthenticateController(IEmployeeService employeeService, IDesignationService designationService, IDepartmentService departmentService)
        {
            this.employeeService = employeeService;
            this.designationService = designationService;
            this.departmentService = departmentService;
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


                int employeeID = employeeService.AuthenticateUser(signInViewModel.EmailID, signInViewModel.Password);

                if(employeeID > 0)
                {
                    Session["EmployeeID"] = employeeID;
                    userSessionModel = new UserSessionModel();

                    EmployeeViewModel employeeViewModel = employeeService.GetEmployeeByID(employeeID);
                    userSessionModel.EmployeeID = employeeViewModel.EmployeeID;
                    userSessionModel.DepartmentID = employeeViewModel.DepartmentID;
                    userSessionModel.DesignationName = employeeViewModel.Designation.DesignationName;
                    userSessionModel.DepartmentName = employeeViewModel.Department. DepartmentName;
                    userSessionModel.JoinDate = employeeViewModel.JoinDate;
                    userSessionModel.FirstName = employeeViewModel.FirstName;
                    userSessionModel.MiddleName = employeeViewModel.MiddleName;
                    userSessionModel.LastName = employeeViewModel.LastName;
                    userSessionModel.Image = employeeViewModel.Image;

                    if (employeeViewModel.IsVirtualTeamHead == true || employeeViewModel.DesignationName == "ProjectManager")
                    {
                       userSessionModel.CanApproveLeaveRequest = true;
                    }

                    if (employeeViewModel.DepartmentName == "HR")
                    {
                        userSessionModel.HasAdminPermission = true;

                        if (employeeViewModel.IsSpecialPermission == true)
                        {
                            userSessionModel.CanApproveLeaveRequest = true;
                        }
                    } 

                    Session["EmployeeDetails"] = userSessionModel;
                    Session["EmployeeImage"] = userSessionModel.Image;

                    FormsAuthentication.SetAuthCookie(employeeViewModel.EmailID, false);
                    return RedirectToAction("home", "account");
                }
                else
                {
                    ModelState.AddModelError("signin", "Invalid email or password");
                    return View(signInViewModel);
                }

            }
            else
            {
                ModelState.AddModelError("signin", "Invalid email or password");
                return View("SignIn", signInViewModel);
            }

        }
       


    }
}