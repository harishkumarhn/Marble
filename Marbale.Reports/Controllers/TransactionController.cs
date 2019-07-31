using Marbale.Reports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marbale.Reports.Controllers
{
    public class TransactionController : Controller
    {
        //
        // GET: /Transaction/

        public ActionResult Index()
        {
            List<ReportMenuViewModel> modelList = new List<ReportMenuViewModel>();
            modelList.Add(new ReportMenuViewModel()
            {
                Column1 = new Column1() { DisplayName = "Transaction Report", URL = "Transaction/TransactionReport" },
                Column2 = new Column2() { DisplayName = "Transaction Report", URL = "Transaction/TransactionReport" }
            });
            ViewBag.models = modelList;
            return View();
        }
        public ActionResult TransactionReport()
        {
            List<ReportMenuViewModel> modelList = new List<ReportMenuViewModel>();
            modelList.Add(new ReportMenuViewModel()
            {
                Column1 = new Column1() { DisplayName = "Transaction Report", URL = "Transaction/TransactionReport" },
                Column2 = new Column2() { DisplayName = "Transaction Report", URL = "Transaction/TransactionReport" }
            });
            ViewBag.models = modelList;
            return View();
        } 


    }
}
