using LeaveManagementSystem.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LeaveManagementSystem.ApiControllers
{
    public class ValidationController : ApiController
    {
        IEmployeeService employeeService;

        public ValidationController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string GetMobile(string mobile)
        {
            if(employeeService.IsMobileExist(mobile))
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
