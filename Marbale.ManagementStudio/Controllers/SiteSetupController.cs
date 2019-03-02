﻿using Marbale.Business;
using Marbale.BusinessObject;
using Marbale.BusinessObject.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarbaleManagementStudio.Controllers
{
    public class SiteSetupController : Controller
    {
        ProductBL pb = new ProductBL();
       
        //
        // GET: /SiteSetup/

        public ActionResult Configuration()
        {
            return View();
        }
        public ActionResult Settings()
        {
           
        var datatable = pb.GetSettings();
        ViewBag.GetSetting = datatable;
            return View();
        }
        public ActionResult UpdateAppSettings(List<AppSetting> appSettings)
        {

            bool status = pb.SavePOSConfiguration(appSettings);
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Values()
        {
           
            return PartialView();
        }
        public ActionResult POS(string ValType)
        {
            var datatable = pb.GetAppSettings(ValType);

            ViewBag.POSForm = datatable;
    
            return PartialView();
        }
        public ActionResult Card()
        {
            var datatable = pb.GetAppSettings("Card");
            ViewBag.CardForm = datatable;
            return PartialView();
        }
        public string UpdateSettings(List<Settings> settings)
        {
            bool status = pb.SaveSettings(settings);
            return "Updated";
        }
        public ActionResult Messages()
        {
            var datatable = pb.GetAllMessages();
            ViewBag.Messages = datatable;
            return View();
        }
        public int UpdateMessages(List<MessagesModel> messageObject)
        {
          int status=  pb.UpdateMessages(messageObject);
          if (status == 1)
          {
               RedirectToAction("SiteSetUp", "Messages");
          }
          return status;
            
          
        }

    }
}
