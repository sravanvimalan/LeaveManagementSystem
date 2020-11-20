﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeaveManagementSystem.CustomAuthorizationFilter;
using LeaveManagementSystem.DomainModel;
using LeaveManagementSystem.ServiceLayer;
using LeaveManagementSystem.ViewModel;

namespace LeaveManagementSystem.Controllers
{
    [Authorize]
    [CustomAuthorizeAttribute("HasAdminPermission")]
    public class DesignationController : Controller
    {
        IDesignationService designationService;

        public DesignationController(IDesignationService designationService)
        {
            this.designationService = designationService;
        }
       
        public ActionResult AddDesignation()
        {
            DesignationViewModel designation = new DesignationViewModel();

            return View(designation);
        }
        
        [HttpPost]
        public ActionResult AddDesignation(DesignationViewModel designation)
        {
            if(ModelState.IsValid)
            {
                designationService.AddDesignation(designation);
                 return RedirectToAction("AddDesignation");
            }
            else
            {
                ModelState.AddModelError("x", "Insertion failed");
                return View(designation);
            }
           

        }

        public ActionResult ListDesignation()
        {
            var designations = designationService.GetAllDesignations();
            return View(designations);
        }
       






    }
}

