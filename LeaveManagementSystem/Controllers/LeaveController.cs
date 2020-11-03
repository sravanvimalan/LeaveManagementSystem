using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;
using LeaveManagementSystem.CustomAuthorizationFilter;
using LeaveManagementSystem.ServiceLayer;
using LeaveManagementSystem.ServiceLayer.IService;
using LeaveManagementSystem.ServiceLayer.Service;
using LeaveManagementSystem.ViewModel;
using LeaveManagementSystem.ViewModel.ViewModel;
using System.Net;
using System.Net.Mail;




namespace LeaveManagementSystem.Controllers
{
    [Authorize]
    public class LeaveController : Controller
    {
        ILeaveRequestService leaveRequestService;
        IEmployeeService employeeService;
        IDesignationService designationService;
        IDepartmentService departmentService;
        IVacationTypeService vacationTypeService;

        public LeaveController(ILeaveRequestService leaveRequestService, IEmployeeService employeeService, IDesignationService designationService, IDepartmentService departmentService, IVacationTypeService vacationTypeService)
        {
            this.leaveRequestService = leaveRequestService;
            this.employeeService = employeeService;
            this.designationService = designationService;
            this.departmentService = departmentService;
            this.vacationTypeService = vacationTypeService;
        }

        [Authorize]
        public ActionResult SendLeaveRequest()
        {

            RequestVacationViewModel requestVacationViewModel = new RequestVacationViewModel();

            requestVacationViewModel.VacationTypeList = vacationTypeService.GetAllVacationTypeList(vacationTypeService.GetAllVacationType());

            int designationId = designationService.GetDesignationIdByName("Project Manager");

            List<AdminProfileViewModel> list = employeeService.GetEmployeesByDesignationId(designationId);

            requestVacationViewModel.ApproverList = employeeService.ApproverList(list);

            return View(requestVacationViewModel);
        }
        [HttpPost]
        [Authorize]
        public ActionResult SendLeaveRequest(RequestVacationViewModel vacationRequestViewModel)
        {
            if (ModelState.IsValid)
            {
                vacationRequestViewModel.VacationTypeID = Convert.ToInt32(vacationRequestViewModel.VacationStringID);
                vacationRequestViewModel.CreatedOn = DateTime.Today;
                var employee = (AdminProfileViewModel)Session["EmployeeObj"];
                vacationRequestViewModel.CreatedBy = employee.EmployeeID;

                vacationRequestViewModel.LeaveStatus = "Pending"; //by default
                leaveRequestService.AddLeaveRequest(vacationRequestViewModel);
                return RedirectToAction("SendLeaveRequest");
            }
            else
            {
                ModelState.AddModelError("Request", "Invalid Request please try again");
                return RedirectToAction("SendLeaveRequest");
            }

        }

        // GET: Leave
        [CustomAuthorizeAttribute("Project Manager", "VirtualHead","HR")]
        public ActionResult VerifyLeave()
        {
            var profile = (AdminProfileViewModel)(Session["EmployeeObj"]);
            if(profile.IsSpecialPermission == true)
            {
                List<RequestVacationViewModel> leaveRequest = new List<RequestVacationViewModel>();

                leaveRequest = leaveRequestService.GetAllRequestVacation();

                List<RequestVacationViewModel> leaveRequestForHR = new List<RequestVacationViewModel>();

                foreach (var item in  leaveRequest)
                {
                    if(item.LeaveStatus == "Pending")
                    {
                        leaveRequestForHR.Add(item);
                    }
                }
                foreach (var item in leaveRequestForHR)
                {
                    var employee = employeeService.GetEmployeeByID(item.CreatedBy);
                    item.RequesterName = employee.FirstName + " " + employee.MiddleName + " " + employee.LastName;
                    var vacationType = vacationTypeService.GetVacationTypeByVacationId(item.VacationTypeID);
                    item.VacationName = vacationType.VacationName;
                    int designationId = employee.DesignationID;
                    var designation = designationService.GetDesignationByDesignationID(designationId);
                    item.RequesterDesignation = designation.DesignationName;
                    var departmentObj = departmentService.GetDepartmentByDepartmentID(employee.DepartmentID);
                    item.RequesterDepartment = departmentObj.DepartmentName;
                    //item.ApproverID = profile.EmployeeID;

                }
                return View(leaveRequestForHR);
               
            }
            if(profile.IsVirtualTeamHead == true)
            {
                List<RequestVacationViewModel> leaveRequestForVT = new List<RequestVacationViewModel>();
              
                var leaveRequest = leaveRequestService.GetAllRequestVacation();
                foreach (var item in leaveRequest)
                {
                    int requesterEmpId = item.CreatedBy;
                    var employeeDetails = employeeService.GetEmployeeByID(requesterEmpId);
                    if(employeeDetails.DepartmentID == profile.DepartmentID && item.LeaveStatus == "Pending")
                    {
                        leaveRequestForVT.Add(item);
                        
                    }
                }
                foreach (var item in leaveRequestForVT)
                {
                    var employee = employeeService.GetEmployeeByID(item.CreatedBy);
                    item.RequesterName = employee.FirstName + " " + employee.MiddleName + " " + employee.LastName;
                    var vacationType = vacationTypeService.GetVacationTypeByVacationId(item.VacationTypeID);
                    item.VacationName = vacationType.VacationName;
                    int designationId = employee.DesignationID;
                    var designation = designationService.GetDesignationByDesignationID(designationId);
                    item.RequesterDesignation = designation.DesignationName;
                    var departmentObj = departmentService.GetDepartmentByDepartmentID(employee.DepartmentID);
                    item.RequesterDepartment = departmentObj.DepartmentName;
                    //item.ApproverID = profile.EmployeeID;

                }
                return View(leaveRequestForVT);
            }
            else
            {

                int employeeId = profile.EmployeeID;
                List<RequestVacationViewModel> requestVacation = leaveRequestService.GetLeaveRequestByApproveId(employeeId);

                foreach (var item in requestVacation)
                {
                    AdminProfileViewModel profileViewModel = employeeService.GetEmployeeByID(item.CreatedBy);

                    item.RequesterName = profileViewModel.FirstName + " " + profileViewModel.MiddleName + " " + profileViewModel.LastName;

                    DesignationViewModel designation = designationService.GetDesignationByDesignationID(profileViewModel.DesignationID);

                    item.RequesterDesignation = designation.DesignationName;

                    DepartmentViewModel departmentViewModel = departmentService.GetDepartmentByDepartmentID(profileViewModel.DepartmentID);

                    item.RequesterDepartment = departmentViewModel.DepartmentName;

                    VacationTypeViewModel vacationTypeViewModel = vacationTypeService.GetVacationTypeByVacationId(item.VacationTypeID);

                    item.VacationName = vacationTypeViewModel.VacationName;

                }
                TempData["RequestVacation"] = requestVacation;

                return View(requestVacation);
            }
            


        }
        [HttpPost]
        [CustomAuthorizeAttribute("Project Manager", "VirtualHead", "HR")]
        public ActionResult VerifyLeave(RequestVacationViewModel requestVacationViewModel)
        {
            var employee = (AdminProfileViewModel)Session["EmployeeObj"];
            requestVacationViewModel.ApproverID = employee.EmployeeID;
            leaveRequestService.UpdateLeaveRequest(requestVacationViewModel);

            return RedirectToAction("Verifyleave");
        }
        public ActionResult LeaveStatus()
        {
            AdminProfileViewModel profile = (AdminProfileViewModel)Session["EmployeeObj"];
            List<RequestVacationViewModel> requestVacation = new List<RequestVacationViewModel>();
            requestVacation = null;
             requestVacation = leaveRequestService.GetAllRequestByRequesterId(profile.EmployeeID);
            if(requestVacation.Count() != 0)
            {
                foreach (var item in requestVacation)
                {
                   
                    if(item.ApproverID != 0)
                    {
                        AdminProfileViewModel employee = employeeService.GetEmployeeByID(item.ApproverID);
                        item.ApproverName = employee.FirstName + " " + employee.MiddleName + " " + employee.LastName;
                    }
                  
                    VacationTypeViewModel vacationType = vacationTypeService.GetVacationTypeByVacationId(item.VacationTypeID);
                    item.VacationName = vacationType.VacationName;
                }
                return View(requestVacation);
            }

            return RedirectToAction("Leavestatus");
        }
        [CustomAuthorizeAttribute("Project Manager", "VirtualHead","HR")]
        public ActionResult LeaveDetail(int Id)     //show each emp leave details for admin
        {
            RequestVacationViewModel requestVacation = leaveRequestService.GetLeaveRequestByRequestID(Id);
           AdminProfileViewModel employee =  employeeService.GetEmployeeByID(requestVacation.CreatedBy);
            requestVacation.RequesterName = employee.FirstName + " " + employee.MiddleName + " " + employee.LastName;
            DesignationViewModel designation =  designationService.GetDesignationByDesignationID(employee.DesignationID);

            requestVacation.RequesterDesignation = designation.DesignationName;

            VacationTypeViewModel vacationType = vacationTypeService.GetVacationTypeByVacationId(requestVacation.VacationTypeID);

            requestVacation.VacationName = vacationType.VacationName;


            return View(requestVacation);
        }
        [HttpPost]
        [CustomAuthorizeAttribute("Project Manager", "VirtualHead", "HR")]
        public ActionResult LeaveDetail( AdminReplyViewModel adminReply)     
        {
            var employee = (AdminProfileViewModel)Session["EmployeeObj"];
            leaveRequestService.UpdateStatusAndResponse(adminReply.LeaveStatus, adminReply.Response, adminReply.RequestID,employee.EmployeeID);
            
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;


            smtp.Credentials = new NetworkCredential("forapptestpurpose@gmail.com",
               "tvokfhzelmfawwel");
            AdminProfileViewModel empProfile = employeeService.GetEmployeeByID(adminReply.CreatedBy);
            
            if(adminReply.LeaveStatus == "Accept")
            {
               smtp.Send("forapptestpurpose@gmail.com",empProfile.EmailID,
              "Your Leave Status","Hi "+empProfile.FirstName+" "+empProfile.MiddleName+" "+empProfile.LastName+"," +"\n\n\nYour leave request approved.");
            }
            else
            {
                smtp.Send("forapptestpurpose@gmail.com", empProfile.EmailID,
              "Your Leave Status", "Hi " + empProfile.FirstName + " " + empProfile.MiddleName + " " + empProfile.LastName + "," + "\n\n\nYour leave request rejected.");
            }
      
            return RedirectToAction("Verifyleave");
        }

       

    }
}