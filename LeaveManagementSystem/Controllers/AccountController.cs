﻿using System;
using System.Web.Mvc;
using LeaveManagementSystem.ViewModel;
using LeaveManagementSystem.ServiceLayer;
using LeaveManagementSystem.ViewModel.ViewModel;
using System.Web.Security;
using LeaveManagementSystem.ServiceLayer.Service.Session;

namespace LeaveManagementSystem.Controllers
{ 
    public class AccountController : Controller
    {
        IGenderService genderService;
        IDesignationService designationService;
        IEmployeeService employeeService;

        public AccountController(IGenderService genderService, IDesignationService designationService, IEmployeeService employeeService)
        {
            this.genderService = genderService;
            this.designationService = designationService;
            this.employeeService = employeeService;
        }

       
       
       [Authorize]
        public ActionResult UpdatePassword()
        {
            ViewBag.Response = TempData["Response"];
            UpdatePasswordViewModel updatePasswordViewModel = new UpdatePasswordViewModel();
           
            updatePasswordViewModel.EmployeeID = Convert.ToInt32(Session["EmployeeID"]);
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
                TempData["Response"] = "Updated Successfuly";
                return RedirectToAction("UpdatePassword");
            }
            else
            {
              
                return View(updatePasswordViewModel);
            }
         
        }
        [Authorize]
        public ActionResult UpdateProfile()
        {
            ViewBag.Response = TempData["Response"];
            UpdateProfileByEmployeeViewModel updateProfileByEmployeeViewModel = new UpdateProfileByEmployeeViewModel();

            EmployeeViewModel employeeViewModel = employeeService.GetEmployeeByID(Convert.ToInt32(Session["EmployeeID"]));

            updateProfileByEmployeeViewModel.EmployeeID = Convert.ToInt32(Session["EmployeeID"]);
            updateProfileByEmployeeViewModel.Image = employeeViewModel.Image;
            updateProfileByEmployeeViewModel.FirstName = employeeViewModel.FirstName;
            updateProfileByEmployeeViewModel.MiddleName = employeeViewModel.MiddleName;
            updateProfileByEmployeeViewModel.LastName = employeeViewModel.LastName;
            updateProfileByEmployeeViewModel.AddressLine1 = employeeViewModel.AddressLine1;
            updateProfileByEmployeeViewModel.AddressLine2 = employeeViewModel.AddressLine2;
            updateProfileByEmployeeViewModel.AddressLine3 = employeeViewModel.AddressLine3;
            updateProfileByEmployeeViewModel.Nationality = employeeViewModel.Nationality;
            updateProfileByEmployeeViewModel.MobileNumber = employeeViewModel.MobileNumber;
            updateProfileByEmployeeViewModel.DateOfBirth = employeeViewModel.DateOfBirth;
            updateProfileByEmployeeViewModel.GenderID = employeeViewModel.GenderID;
            updateProfileByEmployeeViewModel.GenderList = genderService.GenderList();
            updateProfileByEmployeeViewModel.GenderName = employeeViewModel.GenderName;
            return View(updateProfileByEmployeeViewModel);
        }
        [HttpPost]
        [Authorize]
        public ActionResult UpdateProfile(UpdateProfileByEmployeeViewModel updateProfileByEmployeeViewModel)
        {
            if(ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var File = Request.Files[0];
                    var ImgByte = new Byte[File.ContentLength + 10];
                    File.InputStream.Read(ImgByte, 0, File.ContentLength);
                    var Base64String = Convert.ToBase64String(ImgByte, 0, ImgByte.Length);
                    updateProfileByEmployeeViewModel.Image = Base64String;
                }
                Session["EmployeeImage"] = updateProfileByEmployeeViewModel.Image;
                employeeService.UpdateProfileByEmployee(updateProfileByEmployeeViewModel);
                TempData["Response"] = "Updated Successfuly";
                return RedirectToAction("updateprofile");
            }
            else
            { 
                ModelState.AddModelError("profile", "Invalid Details");
                updateProfileByEmployeeViewModel.GenderList = genderService.GenderList();
                return View(updateProfileByEmployeeViewModel);
            }
           
        }
       
      
        [Authorize]
        public ActionResult Home(EmployeeViewModel employeeViewModel)
        {
            employeeViewModel = employeeService.GetEmployeeByID(Convert.ToInt32(Session["EmployeeID"]));
            return View(employeeViewModel);
        }
        public ActionResult Unauthorized()
        {
            return View();
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("signin","authenticate");
        }

      

    }
}