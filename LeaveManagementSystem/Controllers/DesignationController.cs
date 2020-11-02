using System;
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
    public class DesignationController : Controller
    {
        IDesignationService designationService;

        public DesignationController(IDesignationService designationService)
        {
            this.designationService = designationService;
        }
        [CustomAuthorizeAttribute("HR")]
        public ActionResult AddDesignation()
        {
            DesignationViewModel designation = new DesignationViewModel();

            return View(designation);
        }
        [CustomAuthorizeAttribute("HR")]
        [HttpPost]
        public ActionResult AddDesignation(DesignationViewModel designation)
        {
            designationService.AddDesignation(designation);

            return RedirectToAction("AddDesignation");

        }






    }
}