using Marbale.Reports.Models;
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
        /// <summary>
        /// All reports
        /// </summary>
        /// <returns></returns>
        public ActionResult AllReports()
        {
            List<ReportMenuViewModel> modelList = new List<ReportMenuViewModel>();
            modelList.Add(new ReportMenuViewModel()
            {
                Name = "Transaction",
                Column1 = new Column1() { DisplayName = "Transaction Report1", URL = "\\transaction\\transactionReport" },
                Column2 = new Column2() { DisplayName = "Transaction Report2", URL = "\\transaction\\transactionReport" }
            });
            ViewBag.models = modelList;
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
