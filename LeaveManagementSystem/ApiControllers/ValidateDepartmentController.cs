using LeaveManagementSystem.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LeaveManagementSystem.ApiControllers
{
    public class ValidateDepartmentController : ApiController
    {
        IDepartmentService departmentService;

        public ValidateDepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
        public string GetDepartment(string department)
        {
            if(departmentService.IsDepartmentExist(department))
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
