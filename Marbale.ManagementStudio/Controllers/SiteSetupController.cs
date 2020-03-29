using Marbale.BusinessObject;
using Marbale.BusinessObject.Messages;
using Marbale.BusinessObject.SiteSetup;
using Marble.Business;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using MarbaleManagementStudio.Models;
using System.Web;
using System;

namespace MarbaleManagementStudio.Controllers
{
    [AuthorizationFilter]
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
            return View("~/Views/SiteSetup/ConfigurationTabs/Settings/Settings.cshtml");
        }
        #region EmailSedning
        public void email_send(HttpPostedFileBase fileUploader, HttpPostedFileBase fileUploader1)
        {
            //var datatable = siteSetup.GetAppSettings("Email");
            //List<AppSetting> app = new List<AppSetting>();
            //app = datatable.ToList();
            //var DisplayNameFor_PDF_Creation = app[2].Value;
            //var SMTP_Host_Name_ip_address = app[3].Value;
            //var Port_Number_of_SMTP_Host = app[4].Value;
            //var SMTP_Login_Username = app[5].Value;
            //var SMTP_Login_Password = app[6].Value;
            //var Display_Name_for_From_Address = app[7].Value;
            //MailMessage mail = new MailMessage();
            //SmtpClient SmtpServer = new SmtpClient(SMTP_Host_Name_ip_address);
            //mail.From = new MailAddress(SMTP_Login_Username);
            //mail.To.Add(Display_Name_for_From_Address);
            //mail.Subject = "Test Mail of Marble From Shridhar";
            //mail.Body = "Sample Message from SHridhar";
            //if (!string.IsNullOrEmpty(app[0].Value))
            //{
            //    var filename =  app[0].Value;
            //    mail.Attachments.Add(new Attachment(filename));
            //}
            //if (!string.IsNullOrEmpty(app[0].Value))
            //{
            //    var filename = app[1].Value;
            //    mail.Attachments.Add(new Attachment(filename));
            //}

            //SmtpServer.Port = 587;
            //SmtpServer.Credentials = new System.Net.NetworkCredential(SMTP_Login_Username, SMTP_Login_Password);
            //SmtpServer.EnableSsl = true;
            //try
            //{
            //    SmtpServer.Send(mail);
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}



        }

        #endregion
        #region Appsettings
        public ActionResult UpdateAppSettings(List<AppSetting> appSettings)
        {


            bool status = siteSetup.SavePOSConfiguration(appSettings);
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Values()
        {
            List<Buttons> buttons = siteSetup.GetAllValuesButtons();
            return View("~/Views/SiteSetup/ConfigurationTabs/Values/Values.cshtml", buttons);
        }
        public ActionResult POS(string ValType)
        {
            var datatable = siteSetup.GetAppSettings(ValType);

            ViewBag.POSForm = datatable;

            return PartialView("~/Views/SiteSetup/ConfigurationTabs/Values/POS.cshtml");
        }
        public ActionResult Card()
        {
            var datatable = siteSetup.GetAppSettings("Card");
            ViewBag.CardForm = datatable;
            return PartialView("~/Views/SiteSetup/ConfigurationTabs/Values/Card.cshtml");
        }
        public ActionResult BackUp(string ValType)
        {
            var datatable = siteSetup.GetAppSettings("BackUp");
            ViewBag.BackupRestore = datatable;
            return View("~/Views/SiteSetup/ConfigurationTabs/Values/BackUp.cshtml");
        }

        public int UpdateSettings(List<Settings> settings)
        {
            return siteSetup.SaveSettings(settings);
        }
        public ActionResult Messages()
        {
            var datatable = siteSetup.GetAllMessages();
            ViewBag.Messages = datatable;
            return View();
        }
        public int UpdateMessages(List<MessagesModel> messageObject)
        {
            int status = siteSetup.UpdateMessages(messageObject);
            if (status == 1)
            {
                RedirectToAction("SiteSetUp", "Messages");
            }
            return status;
        }
        #endregion


        #region Limit
        public ActionResult Limit()
        {
            var datatable = siteSetup.GetAppSettings("Limit");
            ViewBag.LimitForm = datatable;
            return View("~/Views/SiteSetup/ConfigurationTabs/Values/Limit.cshtml");
        }
        #endregion
        #region Transaction
        public ActionResult Transaction()
        {
            var datatable = siteSetup.GetAppSettings("Transaction");
            ViewBag.Transaction = datatable;
            return View("~/Views/SiteSetup/ConfigurationTabs/Values/Transaction.cshtml");
        }
        #endregion

        #region Price
        public ActionResult Price()
        {
            var datatable = siteSetup.GetAppSettings("Price");
            ViewBag.Price = datatable;
            return View("~/Views/SiteSetup/ConfigurationTabs/Values/Price.cshtml");
        }
        #endregion
        #region Email
        public ActionResult Email()
        {
            var datatable = siteSetup.GetAppSettings("Email");
            ViewBag.Email = datatable;
            return View("~/Views/SiteSetup/ConfigurationTabs/Values/Email.cshtml");
        }
        #endregion
        #region Print
        public ActionResult Print()
        {
            var datatable = siteSetup.GetAppSettings("Print");
            ViewBag.Print = datatable;
            return View("~/Views/SiteSetup/ConfigurationTabs/Values/Print.cshtml");
        }
        #endregion
        #region Formats
        public ActionResult Formats()
        {
            var datatable = siteSetup.GetAppSettings("Formats");
            ViewBag.Formats = datatable;
            return View("~/Views/SiteSetup/ConfigurationTabs/Values/Formats.cshtml");
        }
        #endregion
        #region Inventory
        public ActionResult Inventory()
        {
            var datatable = siteSetup.GetAppSettings("Inventory");
            ViewBag.Inventory = datatable;
            return View("~/Views/SiteSetup/ConfigurationTabs/Values/Inventory.cshtml");

        }
        #endregion
        #region Redemption
        public ActionResult Redemption()
        {
            var datatable = siteSetup.GetAppSettings("Redemption");
            ViewBag.Redemption = datatable;
            return View("~/Views/SiteSetup/ConfigurationTabs/Values/Redemption.cshtml");
        }
        #endregion
        #region Payment
        public ActionResult Payment()
        {
            var datatable = siteSetup.GetAppSettings("Payment");
            ViewBag.Payment = datatable;
            return View("~/Views/SiteSetup/ConfigurationTabs/Values/Payment.cshtml");
        }
        #endregion
        #region Signage
        public ActionResult Signage()
        {
            var datatable = siteSetup.GetAppSettings("Signage");
            ViewBag.SignageForm = datatable;
            return View("~/Views/SiteSetup/ConfigurationTabs/Values/Signage.cshtml");
        }


        #endregion
        #region Server
        public ActionResult Server()
        {
            var datatable = siteSetup.GetAppSettings("Server");
            ViewBag.Server = datatable;
            return View("~/Views/SiteSetup/ConfigurationTabs/Values/Server.cshtml");
        }
        #endregion

        #region User role
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
        public JsonResult ModuleActionPermission(int roleId)
        {
            List<Module> moduleTree = new List<Module>();
            var moduleActions = siteSetup.GetModuleActionsByRole(roleId,true);
            GetTreeViewModel(moduleTree, moduleActions);
            return Json(moduleTree, JsonRequestBehavior.AllowGet);
        }
        private static void GetTreeViewModel(List<Module> moduleTree, List<AppModuleAction> moduleActions)
        {
            List<string> modules = new List<string>();
            foreach (var module in moduleActions.GroupBy(x => x.Module))
            {
                modules.Add(module.ToList()[0].Module);
            }

            foreach (var moduleName in modules)
            {
                Module module = new Module();
                module.name = moduleName;
                module.value = moduleName + "-Module";

                List<Root> roots = new List<Root>();
                module.items = roots;

                var rootsInModule = moduleActions.FindAll(x => x.Module == moduleName).ToList();
                var rootsArray = rootsInModule.GroupBy(x => x.Root).Select(t => t.First());

                foreach (var rootItem in rootsArray)
                {
                    Root rootObj = new Root();

                    rootObj.name = rootItem.Root;
                    rootObj.value = rootItem.Root + "-Root";
                    rootObj.items = new List<Page>();

                    var pagesInRoot = moduleActions.FindAll(x => x.Root == rootItem.Root).ToList();
                    List<string> pagesArray = new List<string>();
                    foreach (var page in pagesInRoot)
                    {
                        rootObj.items.Add(new Page()
                        {
                            name = page.Page,
                            value = page.Id.ToString(),
                            @checked = page.Checked
                        });
                    }
                    roots.Add(rootObj);

                }

                moduleTree.Add(module);
            }
        }
        #endregion
        #region Users
        public ActionResult Users()
        {
            var users = siteSetup.GetUsers();
            ViewBag.users = users;
            return View();
        }
        public ActionResult EditUser(int id = 0)
        {
            var user = siteSetup.GetUserById(id);
            return View(user);
        }

        [HttpPost]
        public JsonResult InsertOrUpdateUsers(List<User> users)
        {
            var message = string.Empty;

            foreach (var user in users)
            {
                message = message + InsertOrUpdateUserObject(user);
            }
            return Json(new { ok = string.IsNullOrEmpty(message), message = message });
        }
        private string InsertOrUpdateUserObject(User user)
        {
            var message = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    siteSetup.InsertOrUpdateUsers(user);
                }
                else
                {
                    message = string.Join(" | ", ModelState.Values
                                  .SelectMany(v => v.Errors)
                                  .Select(e => e.ErrorMessage));
                }
            }
            catch (Exception e)
            {
                LogError.Instance.LogException("InsertOrUpdateUsers", e);
                throw;
            }
            return message;
        }

        public string AddOrEditUser(User user)
        {
            return InsertOrUpdateUserObject(user);
        }

        #endregion
        #region Customer
        public ActionResult Customer()
        {
            List<AppSetting> data = siteSetup.GetAppSettings("customer");
            var types = new List<customIDVa>();
            types.Add(new customIDVa() { Value = 0, Text = "NotUsed" });
            types.Add(new customIDVa() { Value = 1, Text = "Option" });
            types.Add(new customIDVa() { Value = 2, Text = "Mendatory" });
            //    ViewBag.PartialTypes = types;
            //   List<CustomDropdown> myLevels = Enum.GetValues(typeof(CustomDropdown)).Cast<CustomDropdown>().ToList();
            ViewBag.RequiredLevel = new SelectList(types);
            return View("~/Views/SiteSetup/ConfigurationTabs/Values/Customer.cshtml", data);
        }
        #endregion

        #region Site
        public ActionResult ProductKey()
        {
            string SiteId = System.Web.Configuration.WebConfigurationManager.AppSettings["SiteId"];
            ViewBag.ProductKey = siteSetup.GetProductKey(SiteId);
            return View();
        }

        public int UpdateProductKey(ProductKey siteData)
        {
            return siteSetup.UpdateProductKey(siteData);
        }

        public ActionResult Sites()
        {
            ViewBag.Sites = siteSetup.GetSites();
            return View();
        }
        public int UpdateSites(List<Site> sites)
        {
            return siteSetup.InsertOrUpdateSites(sites);
        }

        #endregion

        #region Printer
        public ActionResult Printer()
        {
            return View("~/Views/SiteSetup/Printer/Printer.cshtml");
        }
        public ActionResult PrinterList()
        {
            ViewBag.Printers = siteSetup.GetPrinters();
            return View("~/Views/SiteSetup/Printer/PrinterList.cshtml");
        }
        public int UpdatePrinters(List<Printer> Printers)
        {
            return siteSetup.InsertOrUpdatePrinters(Printers);
        }
        public ActionResult PrintTemplate()
        {
            ViewBag.PrintTemplateHeadersAndItems = siteSetup.GetPrintTemplateHeaderAndItems();
            ViewBag.FontNameList = new string[] { "auto", "cursive", "fantasy", "inherit", "monospace", "sans-serif", "serif", "unset" };
            return View("~/Views/SiteSetup/Printer/PrintTemplate.cshtml");
        }
        public ActionResult PrintTemplateDataItems(int headerId)
        {
            ViewBag.PrintTemplate = siteSetup.GetPrintTemplates(headerId);
            ViewBag.FontNameList = new string[] { "auto", "cursive", "fantasy", "inherit", "monospace", "sans-serif", "serif", "unset" };
            return PartialView("~/Views/SiteSetup/Printer/PrintTemplateDataItems.cshtml");
        }
        public int UpdatePrintTemplate(ReceiptPrintTemplateHeader template)
        {
            return siteSetup.InsertOrUpdatePrintTemplateHeaderAndItems(template);
        }
        #endregion
    }

}
