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

        public RemoteValidationController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        //[HttpGet]
        //public JsonResult IsMailExist(string password, string email)
        //{

        //    bool isExist = false;
        //    EmployeeViewModel employee = employeeService.AuthenticateUser(email, password);
        //    if(employee != null)
        //    {
        //        isExist = true;
        //    }
        //    return Json(isExist, JsonRequestBehavior.AllowGet);
        //}
        //To check only EmpName   
        //[HttpGet]
        //public JsonResult IsEmpNameExist(string Empname)
        //{

        //    bool isExist = EmployeeStaticData.UserList.Where(u => u.EmpName.ToLowerInvariant().Equals(Empname.ToLower())) != null;
        //    return Json(!isExist, JsonRequestBehavior.AllowGet);
        //}
        
        
    }
}