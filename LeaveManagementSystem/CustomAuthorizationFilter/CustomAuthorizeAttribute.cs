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
        private readonly string _permission;
    
        public CustomAuthorizeAttribute( string role)
        {
            this._permission = role;
        }
       
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;

            var permission = (bool)httpContext.Session[_permission];

            if(permission) { authorize = true; }

            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "UnAuthorized" },
                    { "action", "Unauthorized" }
               });
        }
    }
}
    
