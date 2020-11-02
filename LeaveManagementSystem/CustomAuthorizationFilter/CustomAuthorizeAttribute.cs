using LeaveManagementSystem.ServiceLayer;
using LeaveManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LeaveManagementSystem.DomainModel;

namespace LeaveManagementSystem.CustomAuthorizationFilter
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string[] allowedroles;
    
        public CustomAuthorizeAttribute(params string[] roles)
        {
            this.allowedroles = roles;
        }
       
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            var designationName = Convert.ToString(httpContext.Session["DesignationName"]);

            var VirtualHead = Convert.ToString(httpContext.Session["VirtualHead"]);

            var HR = Convert.ToString(httpContext.Session["HR"]);
            foreach (var item in allowedroles)
            {
                if(item == designationName || item == VirtualHead || item == HR )
                {
                    authorize = true;
                }
                
            }



            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "Account" },
                    { "action", "Unauthorized" }
               });
        }
    }
}
    
