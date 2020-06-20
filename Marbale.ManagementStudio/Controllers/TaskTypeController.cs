using Marbale.BusinessObject.SiteSetup;
using Marble.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarbaleManagementStudio.Controllers
{
    [AuthorizationFilter]
    public class TaskTypeController : Controller
    {
        //
        // GET: /TaskType/
        SiteSetupBL siteSetup = new SiteSetupBL();
        public ActionResult Index()
        {
            return View();
        }
      


    }
}
