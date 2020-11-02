using LeaveManagementSystem.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LeaveManagementSystem.ApiControllers
{
    public class ValidateDesignationController : ApiController
    {
        IDesignationService designationService;

        public ValidateDesignationController(IDesignationService designationService)
        {
            this.designationService = designationService;
        }
        public string GetDesignation(string designation)
        {
            if(designationService.IsDesignationExist(designation))
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
