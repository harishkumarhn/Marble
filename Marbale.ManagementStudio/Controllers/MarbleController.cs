using Marbale.BusinessObject.SiteSetup;
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
        private SiteSetupBL siteSetup;

        public MarbleController()
        {
            siteSetup = new SiteSetupBL();
            admin = new AdminBL();
        }

        public ActionResult Index()
        {
            var appModules = admin.GetAppModules("Admin");
            ViewBag.appModules = appModules;
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User objUser)
        {
            if (ModelState.IsValid)
            {
                var obj = this.siteSetup.GetUser(objUser.LoginId, objUser.Password);
                if (obj != null)
                {
                    Session["UserID"] = obj.LoginId.ToString();
                    Session["UserName"] = obj.Name.ToString();
                    return RedirectToAction("Index");
                }
            }
            return View(objUser);
        }
        public ActionResult Logout()
        {
            Session["UserID"] = null;
            return RedirectToAction("Login");
        }

    }
}
