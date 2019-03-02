using Marbale.BusinessObject;
using Marble.Business;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MarbaleManagementStudio.Controllers
{
    public class SiteSetupController : Controller
    {
        SiteSetupBL siteSetup = new SiteSetupBL();

        //
        // GET: /SiteSetup/

        public ActionResult Configuration()
        {
            return View();
        }
        public ActionResult Settings()
        {
            var settings = siteSetup.GetSettings();
            ViewBag.GetSetting = settings;
            return View();
        }
        public ActionResult UpdateAppSettings(List<AppSetting> appSettings)
        {
            bool status = siteSetup.SavePOSConfiguration(appSettings);
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Values()
        {
            return PartialView();
        }
        public ActionResult POS(string ValType)
        {
            var datatable = siteSetup.GetAppSettings(ValType);

            ViewBag.POSForm = datatable;

            return PartialView();
        }
        public ActionResult Card()
        {
            var datatable = siteSetup.GetAppSettings("Card");
            ViewBag.CardForm = datatable;
            return PartialView();
        }
        public string UpdateSettings(List<Settings> settings)
        {
            bool status = siteSetup.SaveSettings(settings);
            return "Updated";
        }

    }
}
