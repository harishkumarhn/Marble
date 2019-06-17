using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marbale.Reports.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/

        public ActionResult Run()
        {
            return View();
        }
        public ActionResult Schedule()
        {
            return View();
        }
        public ActionResult Management()
        {
            return View();
        }

    }
}
