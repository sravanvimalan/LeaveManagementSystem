using LeaveManagementSystem.DomainModel;
using LeaveManagementSystem.ServiceLayer;
using LeaveManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaveManagementSystem.Controllers
{
    public class RemoteValidationController : Controller
    {
        IEmployeeService employeeService;
        IDesignationService designationService;
        IDepartmentService departmentService;

        public RemoteValidationController(IEmployeeService employeeService, IDesignationService designationService, IDepartmentService departmentService)
        {
            this.employeeService = employeeService;
            this.designationService = designationService;
            this.departmentService = departmentService;
        }

        [HttpGet]

        public JsonResult GetMobile(string number)
        {

            bool value = employeeService.IsMobileExist(number);

            if (value)
            {

                return Json(new { msg = "found" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { msg = "not found" }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpGet]
        public JsonResult GetEmail(string email)
        {
            bool value = employeeService.IsEmailExist(email);

            if (value)
            {
                return Json(new { msg = "found" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { msg = "not found" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetDesignation(string designation)
        {
            if (designationService.IsDesignationExist(designation))
            {
                return Json(new { msg = "found" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { msg = "not found" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetDepartment(string department)
        {
            if (departmentService.IsDepartmentExist(department))
            {
                return Json(new { msg = "found" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { msg = "not found" }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}