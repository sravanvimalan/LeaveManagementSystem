using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaveManagementSystem.Controllers
{
    public class UnAuthorizedController : Controller
    {
        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}