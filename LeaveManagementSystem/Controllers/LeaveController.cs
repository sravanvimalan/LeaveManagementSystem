﻿using System;
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
using LeaveManagementSystem.ServiceLayer.Service.Session;

namespace LeaveManagementSystem.Controllers
{
    [Authorize]
    [CustomAuthorizeAttribute("CanApproveLeaveRequest")]
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

        [OverrideAuthorization]
        public ActionResult SendLeaveRequest()
        {
            ViewBag.Response = TempData["Response"];
            RequestVacationViewModel requestVacationViewModel = new RequestVacationViewModel();

            requestVacationViewModel.VacationTypeList = vacationTypeService.GetAllVacationTypeList();

            requestVacationViewModel.ApproverList = employeeService.GetAllProjectManagers();

            requestVacationViewModel.FromDate = DateTime.Now;
            requestVacationViewModel.ToDate = DateTime.Now;
            requestVacationViewModel.NoOfDays = 1;

            return View(requestVacationViewModel);
        }
        [HttpPost]
        [OverrideAuthorization]
        public ActionResult SendLeaveRequest(RequestVacationViewModel vacationRequestViewModel)
        {
            if (ModelState.IsValid)
            {
                vacationRequestViewModel.VacationTypeID = Convert.ToInt32(vacationRequestViewModel.VacationStringID);
                vacationRequestViewModel.CreatedOn = DateTime.Today;

                vacationRequestViewModel.CreatorID = Convert.ToInt32(Session["EmployeeID"]);

                vacationRequestViewModel.LeaveStatus = "Pending"; 
                leaveRequestService.AddLeaveRequest(vacationRequestViewModel);
                TempData["Response"] = "Updated Successfuly";
                return RedirectToAction("SendLeaveRequest");
            }
            else
            {
                ModelState.AddModelError("Request", "Invalid Request please try again");
                return View(vacationRequestViewModel);
            }

        }

        [CustomAuthorizeAttribute("CanApproveLeaveRequest")]
        public ActionResult VerifyLeave()
        {
            var employee = (UserSessionModel)(Session["EmployeeDetails"]);
            var requestVacations = leaveRequestService.GetAllLeaveRequest(employee.DesignationName, employee.DepartmentName, employee.DepartmentID, employee.EmployeeID);

            return View(requestVacations);
        }
        [OverrideAuthorization]
        public ActionResult LeaveStatus()
        {
             var requestVacation = leaveRequestService.GetAllRequestByEmployeeId(Convert.ToInt32(Session["EmployeeID"]));
            if (requestVacation.Count() != 0)
            {
                foreach (var item in requestVacation)
                {

                    if (item.ApproverID != 0)
                    {
                        EmployeeViewModel employee = employeeService.GetEmployeeByID(item.ApproverID);
                        item.ApproverName = employee.FirstName + " " + employee.MiddleName + " " + employee.LastName;
                    }

                    item.VacationName = item.VacationType.VacationName;

                }

            }
                return View(requestVacation);
            
        }
        [CustomAuthorizeAttribute("CanApproveLeaveRequest")]
        public ActionResult LeaveDetail(int Id)    
        {
            RequestVacationViewModel requestVacation = leaveRequestService.GetLeaveRequestByID(Id);
            return View(requestVacation);
        }
        [HttpPost]
        [CustomAuthorizeAttribute("CanApproveLeaveRequest")]
        public ActionResult LeaveDetail( AdminReplyViewModel adminReply)     
        {
            leaveRequestService.UpdateStatusAndResponse(adminReply.LeaveStatus, adminReply.Response, adminReply.RequestID,Convert.ToInt32(Session["EmployeeID"]));
      
            return RedirectToAction("Verifyleave");
        }

       

    }
}