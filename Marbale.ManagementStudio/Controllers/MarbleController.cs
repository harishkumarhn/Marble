using Marble.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarbaleManagementStudio.Controllers
{
    public class MarbleController : Controller
    {
        private AdminBL admin;
        public MarbleController()
        {
            admin = new AdminBL();
        }

        public ActionResult Index()
        {
            var appModules = admin.GetAppModules("Admin");
            ViewBag.appModules = appModules;
            return View();
        }

    }
}
