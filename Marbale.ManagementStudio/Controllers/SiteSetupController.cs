using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarbaleManagementStudio.Controllers
{
    public class SiteSetupController : Controller
    {
        //
        // GET: /SiteSetup/

        public ActionResult Configuration()
        {
            return View();
        }
        public ActionResult Settings()
        {
            return View();
        }
        public ActionResult Values()
        {
            return PartialView();
        }
        public ActionResult POS()
        {
            return PartialView();
        }
        public ActionResult Card()
        {
            return PartialView();
        }
        

    }
}
