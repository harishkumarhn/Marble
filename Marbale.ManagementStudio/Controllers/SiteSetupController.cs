using Marbale.BusinessObject;
using Marbale.BusinessObject.Messages;
using Marbale.BusinessObject.SiteSetup;
using Marble.Business;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using MarbaleManagementStudio.Models;

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
        //public ActionResult Messages()
        //{
        //    var datatable = siteSetup.GetAllMessages();
        //    ViewBag.Messages = datatable;
        //    return View();
        //}
        //public int UpdateMessages(List<MessagesModel> messageObject)
        //{
        //    int status = siteSetup.UpdateMessages(messageObject);
        //    if (status == 1)
        //    {
        //        RedirectToAction("SiteSetUp", "Messages");
        //    }
        //    return status;
        //}
            
        public ActionResult UserRoles()
        {
            var userRoles = siteSetup.GetUserRoles();
            ViewBag.userRoles = userRoles;
            return View();
        }
        public int UpdateUserRoles(List<UserRole> userRoles)
        {
            var result = siteSetup.InsertOrUpdateUserRoles(userRoles);
            return 0;
        }
        public JsonResult ModuleActionPermission()
        {
            List<Module> moduleTree = new List<Module>();

            var moduleActions = siteSetup.GetModuleActions();


            List<string> modules = new List<string>();
            foreach (var module in moduleActions.GroupBy(x => x.Module))
            {
                modules.Add(module.ToList()[0].Module);
            }

            foreach (var moduleName in modules)
            {
                Module module = new Module();
                module.name = moduleName;

                List<Root> roots = new List<Root>();
                module.items = roots;
                
                var rootsInModule = moduleActions.FindAll(x => x.Module == moduleName).ToList();
                var rootsArray = rootsInModule.GroupBy(x => x.Root).Select(t => t.First());

                foreach (var rootItem in rootsArray)
                {
                    Root rootObj = new Root();

                    rootObj.name = rootItem.Root;
                    rootObj.items = new List<Page>();

                    var pagesInRoot = moduleActions.FindAll(x => x.Root == rootItem.Root).ToList();
                    List<string> pagesArray = new List<string>();
                    foreach (var page in pagesInRoot)
                    {
                        rootObj.items.Add(new Page() { name = page.Page });
                    }
                    roots.Add(rootObj);

                }

                moduleTree.Add(module);
            }


            //var modules = moduleActions.GroupBy(x => x.Module);

            //foreach (var module in modules)
            //{
            //    var moduleName = module.ToList()[0].Module;
            //    var roots = module.GroupBy(x => x.Root);

            //    foreach (var root in roots)
            //    {
            //        Module action = new Module();
            //        action.name = root.ToList()[0].Root;
            //        action.value = root.ToList()[0].Id;
            //        action.items = new List<Root>();

            //        var pages = root.GroupBy(x => x.Page);
            //        foreach (var page in pages)
            //        {
            //            var root = new Root();
            //            item.name = page.ToList()[0].Page;
            //            item.value = page.ToList()[0].Id;
            //            action.items.Add(item);
            //        }
            //        moduleTree.Add(action);                   
            //    }
            //}

            return Json(moduleTree, JsonRequestBehavior.AllowGet);
        }
    }

}
