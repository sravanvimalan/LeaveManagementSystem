using LeaveManagementSystem.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LeaveManagementSystem.ApiControllers
{
    public class ValidateEmailController : ApiController
    {
        IEmployeeService employeeService;

        public ValidateEmailController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string GetEmail(string email)
        {
            if(employeeService.IsEmailExist(email))
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
