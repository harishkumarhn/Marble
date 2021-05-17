﻿using Marbale.BusinessObject.SiteSetup;
using Marble.Business;
using System.Linq;
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
        [AuthorizationFilter]
        public ActionResult Index()
        {
            var appModules = admin.GetAppModules("Admin");
            ViewBag.appModules = appModules;
            return View();
        }

        public ActionResult Login(string message = "")
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                @ViewBag.Message = message;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User objUser)
        {
            if (ModelState.IsValid)
            {
                var user = this.siteSetup.GetUser(objUser.LoginId, objUser.Password);
                if (user != null)
                {
                    var moduleActions = this.siteSetup.GetModuleActionsByRole(user.RoleId,false);

                    Session["UserID"] = user.LoginId.ToString();
                    Session["UserName"] = user.Name.ToString();
                    Session["Product"] = moduleActions.Where(x => x.Root == "Product").ToList();
                    Session["Communication"] = moduleActions.Where(x => x.Root == "Communication").ToList();
                    Session["SiteSetup"] = moduleActions.Where(x => x.Root == "Site Setup").ToList();
                    Session["Cards"] = moduleActions.Where(x => x.Root == "Cards").ToList();

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid UserId Or Password");
                }
            }
            return View(objUser);
        }
        public ActionResult Logout()
        {
            Session["UserID"] = null;
            Session["UserName"] = null;
            Session["AllowedPages"] = null;

            return RedirectToAction("Login");
        }
        public ActionResult ChangePassword(string message="")
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                @ViewBag.Message = message;
            }
            return View();
        }
        public ActionResult UpdatePassword(ChangeUserPassword user)
        {
            var result = siteSetup.ChangeUserPassword(Session["UserId"].ToString(), user.CurrentPassword, user.NewPassword);
            if (result > 0)
            {
                Session["UserID"] = null;
                Session["UserName"] = null;
                Session["AllowedPages"] = null;
                return RedirectToAction("Login", new { message = "Password changed please login again" });
            }
            else
            {
                return RedirectToAction("ChangePassword", new { message = "Password change failed please try again" });
            }
        }

    }
}
