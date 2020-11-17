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
    //[Authorize]
    public class DesignationController : Controller
    {
        IDesignationService designationService;

        public DesignationController(IDesignationService designationService)
        {
            this.designationService = designationService;
        }
        //[CustomAuthorizeAttribute("HR")]
        public ActionResult AddDesignation()
        {
            DesignationViewModel designation = new DesignationViewModel();

            return View(designation);
        }
        //[CustomAuthorizeAttribute("HR")]
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
        public string GetDesignation(string designation)
        {
            if (designationService.IsDesignationExist(designation))
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