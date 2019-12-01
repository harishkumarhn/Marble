using Marbale.BusinessObject;
using Marbale.BusinessObject.SiteSetup;
using Marbale.BusinessObject.Messages;
using Marbale.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Marble.Business
{
    public class SiteSetupBL
    {
        private SiteSetupData siteSetupData;
        string key = "sblw-3hn8-sqoy19";


        public SiteSetupBL()
        {
            siteSetupData = new SiteSetupData();
        }
        #region settings
        public List<Settings> GetSettings()
        {
            try
            {
                var typeListDataTable = siteSetupData.GetDatatypes();
                var typeList = new List<IdValue>();
                typeList.Add(new IdValue() { Id = 0, Value = "Select" });
                foreach (DataRow dr in typeListDataTable.Rows)
                {
                    IdValue idValues = new IdValue();
                    idValues.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                    idValues.Value = dr.IsNull("Type") ? "" : dr["Type"].ToString();
                    typeList.Add(idValues);
                }

                var dataTable = siteSetupData.GetSettings();
                List<Settings> listSettings = new List<Settings>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    Settings setting = new Settings();
                    setting.Active = dr.IsNull("Active") ? false : bool.Parse(dr["Active"].ToString());
                    setting.DefaultValue = dr.IsNull("DefaultValue") ? "" : dr["DefaultValue"].ToString();
                    setting.Description = dr.IsNull("Description") ? "" : dr["Description"].ToString();
                    setting.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                    setting.Caption = dr.IsNull("Caption") ? "" : dr["Caption"].ToString();
                    setting.LastUpdatedBy = dr.IsNull("LastUpdatedBy") ? "" : dr["LastUpdatedBy"].ToString();
                    setting.LastUpdatedDate = dr.IsNull("LastUpdatedDate") ? new DateTime() : Convert.ToDateTime(dr["LastUpdatedDate"]);
                    setting.Name = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                    setting.PosLevel = dr.IsNull("PosLevel") ? false : bool.Parse(dr["PosLevel"].ToString());
                    setting.ScreenGroup = dr.IsNull("ScreenGroup") ? "" : dr["ScreenGroup"].ToString();
                    setting.Type = dr.IsNull("Type") ? "" : dr["Type"].ToString();
                    setting.UserLevel = dr.IsNull("UserLevel") ? false : bool.Parse(dr["UserLevel"].ToString());
                    setting.BasicDataTypes = typeList;
                    listSettings.Add(setting);
                }

                return listSettings;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<AppSetting> GetAppSettings(string screen)
        {
            try
            {
                var dataTable = siteSetupData.GetAppSettings(screen);
                List<AppSetting> listSettings = new List<AppSetting>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    AppSetting setting = new AppSetting();
                    setting.Name = dr.IsNull("Name") ? "" : dr["Name"].ToString();//
                    setting.Caption = dr.IsNull("Caption") ? "" : dr["Caption"].ToString();//label
                    setting.Value = dr.IsNull("DefaultValue") ? "" : dr["DefaultValue"].ToString();// current values
                    setting.Type = dr.IsNull("Type") ? "" : dr["Type"].ToString();
                    setting.ScreenGroup = dr.IsNull("ScreenGroup") ? "" : dr["ScreenGroup"].ToString();

                    listSettings.Add(setting);
                }
                return listSettings;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int SaveSettings(List<Settings> settings)
        {
            int result = 0;
            try
            {
                foreach (var setting in settings)
                {
                    result = siteSetupData.UpdateSettings(setting.Id, setting.Name, setting.Caption, setting.Description, setting.DefaultValue, setting.Type,
                        setting.ScreenGroup, setting.LastUpdatedBy, setting.Active, setting.UserLevel, setting.PosLevel);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        public bool SavePOSConfiguration(List<AppSetting> appSetting)
        {
            try
            {
                foreach (var setting in appSetting)
                {
                    siteSetupData.SaveAppSettings(setting.Name, setting.Value, setting.ScreenGroup);
                }
                return true;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool SaveGameConfiguration(List<AppSetting> appSetting)
        {
            try
            {
                foreach (var setting in appSetting)
                {
                    siteSetupData.SaveAppSettings(setting.Name, setting.Value, setting.ScreenGroup);
                }
                return true;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        public List<UserRole> GetUserRoles()
        {
            var dataTable = siteSetupData.GetUserRoles();
            List<UserRole> userRoles = new List<UserRole>();
            foreach (DataRow dr in dataTable.Rows)
            {
                UserRole userRole = new UserRole();
                userRole.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                userRole.Role = dr.IsNull("Role") ? "" : dr["Role"].ToString();
                userRole.Description = dr.IsNull("Description") ? "" : dr["Description"].ToString();
                userRole.ManagerFlag = dr.IsNull("ManagerFlag") ? false : bool.Parse(dr["ManagerFlag"].ToString());
                userRole.AllowPOSAccess = dr.IsNull("AllowPOSAccess") ? false : bool.Parse(dr["AllowPOSAccess"].ToString());
                userRole.AllowShiftOpenClose = dr.IsNull("AllowShiftOpenClose") ? false : bool.Parse(dr["AllowShiftOpenClose"].ToString());
                userRole.POSClockInOut = dr.IsNull("POSClockInOut") ? false : bool.Parse(dr["POSClockInOut"].ToString());
                userRole.LastUpdatedBy = dr.IsNull("LastUpdatedBy") ? "" : dr["LastUpdatedBy"].ToString();
                userRole.LastUpdatedDate = dr.IsNull("LastUpdatedDate") ? new DateTime() : Convert.ToDateTime(dr["LastUpdatedDate"]);
                userRoles.Add(userRole);
            }
            return userRoles;
        }
        public List<MessagesModel> GetAllMessages()
        {
            var dataTable = siteSetupData.GetAllMessages();
            List<MessagesModel> message = new List<MessagesModel>();
            foreach (DataRow dr in dataTable.Rows)
            {
                MessagesModel m = new MessagesModel();
                m.MessageNo = dr.IsNull("MessageNo") ? 0 : int.Parse(dr["MessageNo"].ToString());
                m.MessageName = dr.IsNull("MessageName") ? "" : (dr["MessageName"].ToString());
                m.MessageDescription = dr.IsNull("MessageDescription") ? "" : (dr["MessageDescription"].ToString());
                message.Add(m);
            }
            return message;
        }
        public int UpdateMessages(List<MessagesModel> messageObject)
        {
            try
            {
                foreach (var item in messageObject)
                {
                    siteSetupData.UpdateMessages(item);
                }
                return 1;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public int UpdateTaskType(List<Marbale.BusinessObject.SiteSetup.TaskTypeModel> tasktype)
        {
            int s = 0;
            foreach (var item in tasktype)
            {
                s = siteSetupData.UpdateTaskType(item);
            }
            return s;


        }

        public List<TaskTypeModel> GetTaskType()
        {
            var datatable = siteSetupData.GetTaskType();
            List<TaskTypeModel> tasktype = new List<TaskTypeModel>();
            foreach (DataRow dr in datatable.Rows)
            {
                TaskTypeModel m = new TaskTypeModel();
                m.TaskTypeId = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                m.TaskType = dr.IsNull("Type") ? "" : (dr["Type"].ToString());
                m.TaskTypeName = dr.IsNull("Name") ? "" : (dr["Name"].ToString());
                m.RequiresManagerApproval = dr.IsNull("RequiresManagerApproval") ? false : bool.Parse(dr["RequiresManagerApproval"].ToString());
                m.DispalyinPOS = dr.IsNull("DisplayInPOS") ? false : bool.Parse(dr["DisplayInPOS"].ToString());
                tasktype.Add(m);
            }
            return tasktype;

        }
        public int InsertOrUpdateUserRoles(List<UserRole> userRoles)
        {
            try
            {
                return siteSetupData.InsertOrUpdateUserRoles(userRoles);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int InsertOrUpdateUsers(List<User> users)
        {
            try
            {
                return siteSetupData.InsertOrUpdateUsers(users);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int InsertOrUpdateSites(List<Site> sites)
        {
            try
            {
                return siteSetupData.InsertOrUpdateSites(sites);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<AppModuleAction> GetModuleActions()
        {
            var dataTable = siteSetupData.GetAppModuleActions();
            List<AppModuleAction> appModuleActions = new List<AppModuleAction>();
            foreach (DataRow dr in dataTable.Rows)
            {
                AppModuleAction appModuleAction = new AppModuleAction();
                appModuleAction.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                appModuleAction.Module = dr.IsNull("Module") ? "" : dr["Module"].ToString();
                appModuleAction.Root = dr.IsNull("Root") ? "" : dr["Root"].ToString();
                appModuleAction.Page = dr.IsNull("Page") ? "" : dr["Page"].ToString();
                appModuleAction.Active = dr.IsNull("Active") ? false : bool.Parse(dr["Active"].ToString());
                appModuleAction.DisplayOrder = dr.IsNull("DisplayOrder") ? 0 : int.Parse(dr["DisplayOrder"].ToString());
                appModuleActions.Add(appModuleAction);
            }

            return appModuleActions;
        }

        public List<AppModuleAction> GetModuleActionsByRole(int roleId)
        {
            var dataTable = siteSetupData.GetModuleActionsByRole(roleId);
            List<AppModuleAction> appModuleActions = new List<AppModuleAction>();
            foreach (DataRow dr in dataTable.Rows)
            {
                AppModuleAction appModuleAction = new AppModuleAction();
                appModuleAction.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                appModuleAction.Module = dr.IsNull("Module") ? "" : dr["Module"].ToString();
                appModuleAction.Root = dr.IsNull("Root") ? "" : dr["Root"].ToString();
                appModuleAction.Page = dr.IsNull("Page") ? "" : dr["Page"].ToString();
                appModuleAction.Active = dr.IsNull("Active") ? false : bool.Parse(dr["Active"].ToString());
                appModuleAction.DisplayOrder = dr.IsNull("DisplayOrder") ? 0 : int.Parse(dr["DisplayOrder"].ToString());
                appModuleAction.Checked = dr.IsNull("IsChecked") ? false : bool.Parse(dr["IsChecked"].ToString());
                appModuleActions.Add(appModuleAction);
            }

            return appModuleActions;
        }

        public List<User> GetUsers()
        {
            var roles = GetUserRoles();
            var rolesList = new List<IdValue>();
            rolesList.Add(new IdValue() { Id = 0, Value = "Select" });
            foreach (var role in roles)
            {
                IdValue idValues = new IdValue();
                idValues.Id = role.Id;
                idValues.Value = role.Role;
                rolesList.Add(idValues);
            }

            var statusList = new List<IdValue>();
            statusList.Add(new IdValue() { Id = 0, Value = "Select" });
            statusList.Add(new IdValue() { Id = 0, Value = "Active" });
            statusList.Add(new IdValue() { Id = 0, Value = "Inactive" });

            var dataTable = siteSetupData.GetUsers();
            List<User> users = new List<User>();
            foreach (DataRow dr in dataTable.Rows)
            {
                User user = new User();
                user.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                user.Role = dr.IsNull("Role") ? "" : dr["Role"].ToString();
                user.Name = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                user.LoginId = dr.IsNull("LoginId") ? "" : dr["LoginId"].ToString();
                user.Manager = dr.IsNull("Manager") ? "" : dr["Manager"].ToString();
                user.Department = dr.IsNull("Department") ? "" : dr["Department"].ToString();
                user.Email = dr.IsNull("Email") ? "" : dr["Email"].ToString();
                user.CompanyAdmin = dr.IsNull("CompanyAdmin") ? false : bool.Parse(dr["CompanyAdmin"].ToString());
                user.CreatedBy = dr.IsNull("CreatedBy") ? "" : dr["CreatedBy"].ToString();
                user.LastLoginTime = dr.IsNull("LastLoginTime") ? new DateTime() : Convert.ToDateTime(dr["LastLoginTime"].ToString());
                user.LastLogoutTime = dr.IsNull("LastLogoutTime") ? new DateTime() : Convert.ToDateTime(dr["LastLogoutTime"].ToString());
                user.EmpStartDate = dr.IsNull("EmpStartDate") ? new DateTime() : Convert.ToDateTime(dr["EmpStartDate"].ToString());
                user.EmpEndDate = dr.IsNull("EmpEndDate") ? new DateTime() : Convert.ToDateTime(dr["EmpEndDate"].ToString());
                user.EmpEndReason = dr.IsNull("EmpEndReason") ? "" : dr["EmpEndReason"].ToString();
                user.Status = dr.IsNull("Status") ? "" : dr["Status"].ToString();
                user.POSCounter = dr.IsNull("POSCounter") ? "" : dr["POSCounter"].ToString();
                user.LastUpdatedBy = dr.IsNull("LastUpdatedBy") ? "" : dr["LastUpdatedBy"].ToString();
                user.LastUpdatedDate = dr.IsNull("LastUpdatedDate") ? new DateTime() : Convert.ToDateTime(dr["LastUpdatedDate"]);
                user.InvalidAttempts = dr.IsNull("InvalidAttempts") ? 0 : int.Parse(dr["InvalidAttempts"].ToString());


                user.Roles = rolesList;
                user.Statuses = statusList;
                users.Add(user);
            }
            if (users.Count == 0)
            {
                users.Add(new User() { Roles = rolesList, Statuses = statusList });
            }
            return users;

        }

        public User GetUserById(int id)
        {
            User user = new User();

            List<IdValue> rolesList;
            List<IdValue> statusList;
            GetUserRoleAndStatusList(out rolesList, out statusList);
            if (id > 0)
            {
                var dataTable = siteSetupData.GetUserById(id);
                foreach (DataRow dr in dataTable.Rows)
                {
                    user.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                    user.Role = dr.IsNull("Role") ? "" : dr["Role"].ToString();
                    user.Name = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                    user.LoginId = dr.IsNull("LoginId") ? "" : dr["LoginId"].ToString();
                    user.Manager = dr.IsNull("Manager") ? "" : dr["Manager"].ToString();
                    user.Department = dr.IsNull("Department") ? "" : dr["Department"].ToString();
                    user.Email = dr.IsNull("Email") ? "" : dr["Email"].ToString();
                    user.CreatedBy = dr.IsNull("CreatedBy") ? "" : dr["CreatedBy"].ToString();
                    user.LastLoginTime = dr.IsNull("LastLoginTime") ? new DateTime() : Convert.ToDateTime(dr["LastLoginTime"].ToString());
                    user.LastLogoutTime = dr.IsNull("LastLogoutTime") ? new DateTime() : Convert.ToDateTime(dr["LastLogoutTime"].ToString());
                    user.EmpStartDate = dr.IsNull("EmpStartDate") ? new DateTime() : Convert.ToDateTime(dr["EmpStartDate"].ToString());
                    user.EmpEndDate = dr.IsNull("EmpEndDate") ? new DateTime() : Convert.ToDateTime(dr["EmpEndDate"].ToString());
                    user.EmpEndReason = dr.IsNull("EmpEndReason") ? "" : dr["EmpEndReason"].ToString();
                    user.Status = dr.IsNull("Status") ? "" : dr["Status"].ToString();
                    user.POSCounter = dr.IsNull("POSCounter") ? "" : dr["POSCounter"].ToString();
                    user.LastUpdatedBy = dr.IsNull("LastUpdatedBy") ? "" : dr["LastUpdatedBy"].ToString();
                    user.LastUpdatedDate = dr.IsNull("LastUpdatedDate") ? new DateTime() : Convert.ToDateTime(dr["LastUpdatedDate"]);
                    user.InvalidAttempts = dr.IsNull("InvalidAttempts") ? 0 : int.Parse(dr["InvalidAttempts"].ToString());

                    user.Roles = rolesList;
                    user.Statuses = statusList;
                }
            }
            else
            {
                user.Roles = rolesList;
                user.Statuses = statusList;
            }
            return user;

        }

        private void GetUserRoleAndStatusList(out List<IdValue> rolesList, out List<IdValue> statusList)
        {
            var roles = GetUserRoles();
            rolesList = new List<IdValue>();
            rolesList.Add(new IdValue() { Id = 0, Value = "Select" });
            foreach (var role in roles)
            {
                IdValue idValues = new IdValue();
                idValues.Id = role.Id;
                idValues.Value = role.Role;
                rolesList.Add(idValues);
            }

            statusList = new List<IdValue>();
            statusList.Add(new IdValue() { Id = 0, Value = "Select" });
            statusList.Add(new IdValue() { Id = 0, Value = "Active" });
            statusList.Add(new IdValue() { Id = 0, Value = "Inactive" });
        }

        public List<Buttons> GetAllValuesButtons()
        {
            List<Buttons> bList = new List<Buttons>();
            var dataTable = siteSetupData.GetAllValuesButtons();
            foreach (DataRow dr in dataTable.Rows)
            {
                Buttons b = new Buttons();
                b.Id = dr.IsNull("ButtonId") ? "" : dr["ButtonId"].ToString();
                b.Class = dr.IsNull("Class") ? "" : dr["Class"].ToString();
                b.MethodName = dr.IsNull("MethodName") ? "" : dr["MethodName"].ToString();
                b.Text = dr.IsNull("Text") ? "" : dr["Text"].ToString();
                b.Tittle = dr.IsNull("Tittle") ? "" : dr["Tittle"].ToString();
                b.BRTag = dr.IsNull("BRTag") ? "" : dr["BRTag"].ToString();
                bList.Add(b);
                //   b.Department = dr.IsNull("Department") ? "" : dr["Department"].ToString();
            }
            return bList;
        }


        public User ValidateUser(string username, string password)
        {
            DataTable dt = siteSetupData.ValidateUser(username, password);
            User user = new User();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    user.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                    user.Role = dr.IsNull("Role") ? "" : dr["Role"].ToString();
                    user.Name = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                    user.LoginId = dr.IsNull("LoginId") ? "" : dr["LoginId"].ToString();
                    user.Manager = dr.IsNull("Manager") ? "" : dr["Manager"].ToString();
                    user.Department = dr.IsNull("Department") ? "" : dr["Department"].ToString();
                    //user.Email = dr.IsNull("Email") ? "" : dr["Email"].ToString();
                    user.CreatedBy = dr.IsNull("CreatedBy") ? "" : dr["CreatedBy"].ToString();
                    user.LastLoginTime = dr.IsNull("LastLoginTime") ? new DateTime() : Convert.ToDateTime(dr["LastLoginTime"].ToString());
                    //user.LastLogoutTime = dr.IsNull("LastLogoutTime") ? new DateTime() : Convert.ToDateTime(dr["LastLogoutTime"].ToString());
                    user.EmpStartDate = dr.IsNull("EmpStartDate") ? new DateTime() : Convert.ToDateTime(dr["EmpStartDate"].ToString());
                    user.EmpEndDate = dr.IsNull("EmpEndDate") ? new DateTime() : Convert.ToDateTime(dr["EmpEndDate"].ToString());
                    user.EmpEndReason = dr.IsNull("EmpEndReason") ? "" : dr["EmpEndReason"].ToString();
                    user.Status = dr.IsNull("Status") ? "" : dr["Status"].ToString();
                    user.POSCounter = dr.IsNull("POSCounter") ? "" : dr["POSCounter"].ToString();
                    user.LastUpdatedBy = dr.IsNull("LastUpdatedBy") ? "" : dr["LastUpdatedBy"].ToString();
                    user.LastUpdatedDate = dr.IsNull("LastUpdatedDate") ? new DateTime() : Convert.ToDateTime(dr["LastUpdatedDate"]);
                    user.InvalidAttempts = dr.IsNull("InvalidAttempts") ? 0 : int.Parse(dr["InvalidAttempts"].ToString());
                    user.password = password;
                    break;
                }
            }
            return user;
        }
        public ProductKey GetProductKey(string siteId)
        {
            DataTable dt = siteSetupData.GetProductKey(siteId);
            ProductKey pk = new ProductKey();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    pk.SiteId = dr.IsNull("site_id") ? 0 : int.Parse(dr["site_id"].ToString());

                    if (!dr.IsNull("SiteKey"))
                    {
                        var bytes_s = (byte[])dr["SiteKey"];
                        pk.SiteKey = Encoding.ASCII.GetString(bytes_s, 0, bytes_s.Length);
                    }
                    if (!dr.IsNull("LicenseKey"))
                    {
                        var bytes_l = (byte[])dr["LicenseKey"];
                        pk.LicenseKey = Encoding.ASCII.GetString(bytes_l, 0, bytes_l.Length);
                        pk.ExpireOn = this.Decrypt(pk.LicenseKey, key).Split('|')[1];
                    }
                    break;
                }
            }
            return pk;
        }
        public int UpdateProductKey(ProductKey pk)
        {
            int result = -1;
            if (!string.IsNullOrWhiteSpace(pk.SiteKey) && !string.IsNullOrWhiteSpace(pk.LicenseKey))
            {
                var license = Decrypt(pk.LicenseKey, key);
                var array = license.Split('|');
                DateTime date;
                if (DateTime.TryParse(array[1], out date))
                {
                    result = siteSetupData.UpdateProductKey(pk);
                }
            }
            return result;
        }
        public string Decrypt(string input, string key)
        {
            byte[] resultArray;
            try
            {
                byte[] inputArray = Convert.FromBase64String(input);
                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tripleDES.CreateDecryptor();
                resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
            }
            catch (Exception ex)
            {
                throw;
            }
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        public List<Site> GetSites()
        {
            DataTable dt = siteSetupData.GetSites();
            List<Site> sites = new List<Site>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Site site = new Site();
                    site.SiteId = dr.IsNull("SiteId") ? 0 : int.Parse(dr["SiteId"].ToString());
                    site.SiteName = dr.IsNull("SiteName") ? "" : dr["SiteName"].ToString();
                    site.SiteAddress = dr.IsNull("SiteAddress") ? "" : dr["SiteAddress"].ToString();
                    site.Notes = dr.IsNull("Notes") ? "" : dr["Notes"].ToString();
                    site.Guid = (Guid)dr["Guid"];
                    site.SiteGUID = (Guid)dr["SiteGUID"];
                    Byte[] array = new Byte[64];

                    if (dr.IsNull("Logo"))
                    {
                        Array.Clear(array, 0, array.Length);
                    }
                    else
                    {
                        array = (byte[])dr["Logo"];
                    }
                    site.Logo = array;
                    site.CustomerKey = dr.IsNull("CustomerKey") ? "" : dr["CustomerKey"].ToString();
                    site.SiteCode = dr.IsNull("SiteCode") ? 0 : int.Parse(dr["SiteCode"].ToString());
                    site.Version = dr.IsNull("Version") ? "" : dr["Version"].ToString();
                    sites.Add(site);
                }

            }
            if (sites.Count == 0)
            {
                sites.Add(new Site());
            }
            return sites;
        }
        public List<Printer> GetPrinters()
        {
            DataTable dt = siteSetupData.GetPrinters();
            List<Printer> printers = new List<Printer>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Printer printer = new Printer();
                    printer.PrinterId = dr.IsNull("PrinterId") ? 0 : int.Parse(dr["PrinterId"].ToString());
                    printer.PrinterName = dr.IsNull("PrinterName") ? "" : dr["PrinterName"].ToString();
                    printer.PrinterLocation = dr.IsNull("PrinterLocation") ? "" : dr["PrinterLocation"].ToString();
                    printer.IPAddress = dr.IsNull("IPAddress") ? "" : dr["IPAddress"].ToString();
                    printer.KDSTerminal = dr.IsNull("KDSTerminal") ? false : bool.Parse(dr["KDSTerminal"].ToString());
                    printer.Remarks = dr.IsNull("Remarks") ? "" : dr["Remarks"].ToString();
                    printers.Add(printer);
                }

            }
            if (printers.Count == 0)
            {
                printers.Add(new Printer());
            }
            return printers;
        }
        public List<ReceiptPrintTemplateHeader> GetPrintTemplateHeaderAndItems()
        {
            DataTable dt = siteSetupData.GetPrintTemplateHeaders();
            List<ReceiptPrintTemplateHeader> templateHeaders = new List<ReceiptPrintTemplateHeader>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ReceiptPrintTemplateHeader templatHeader = new ReceiptPrintTemplateHeader();
                    templatHeader.TemplateId = dr.IsNull("TemplateId") ? 0 : int.Parse(dr["TemplateId"].ToString());
                    templatHeader.TemplateName = dr.IsNull("TemplateName") ? "" : dr["TemplateName"].ToString();
                    templatHeader.FontName = dr.IsNull("FontName") ? "" : dr["FontName"].ToString();
                    templatHeader.FontSize = dr.IsNull("FontSize") ? 0 : decimal.Parse(dr["FontSize"].ToString());
                    templatHeader.PrintTemplateItems = GetPrintTemplates(templatHeader.TemplateId);
                    templateHeaders.Add(templatHeader);
                }

            }
            if (templateHeaders.Count == 0)
            {
                templateHeaders.Add(new ReceiptPrintTemplateHeader());
            }
            return templateHeaders;
        }
        public List<ReceiptPrintTemplate> GetPrintTemplates(int headerId)
        {
            List<ReceiptPrintTemplate> templates = new List<ReceiptPrintTemplate>();
            var list = new List<IdValue>();
            list.Add(new IdValue() { Id = 1, Value = "Header" });
            list.Add(new IdValue() { Id = 2, Value = "Left" });
            list.Add(new IdValue() { Id = 3, Value = "Right" });
            list.Add(new IdValue() { Id = 4, Value = "Footer" });

            if (headerId > 0)
            {
                DataTable dt = siteSetupData.GetPrintTemplates(headerId);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ReceiptPrintTemplate template = new ReceiptPrintTemplate();
                        template.TemplateId = dr.IsNull("TemplateId") ? 0 : int.Parse(dr["TemplateId"].ToString());
                        template.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                        template.Section = dr.IsNull("Section") ? "" : dr["Section"].ToString();
                        template.Sequence = dr.IsNull("Sequence") ? 0 : int.Parse(dr["Sequence"].ToString());
                        template.Col1Alignment = dr.IsNull("Col1Alignment") ? "" : dr["Col1Alignment"].ToString();
                        template.Col1Data = dr.IsNull("Col1Data") ? "" : dr["Col1Data"].ToString();
                        template.Col2Alignment = dr.IsNull("Col2Alignment") ? "" : dr["Col2Alignment"].ToString();
                        template.Col2Data = dr.IsNull("Col2Data") ? "" : dr["Col2Data"].ToString();
                        template.Col3Alignment = dr.IsNull("Col3Alignment") ? "" : dr["Col3Alignment"].ToString();
                        template.Col3Data = dr.IsNull("Col1Data") ? "" : dr["Col1Data"].ToString();
                        template.Col4Alignment = dr.IsNull("Col4Alignment") ? "" : dr["Col4Alignment"].ToString();
                        template.Col4Data = dr.IsNull("Col4Data") ? "" : dr["Col4Data"].ToString();
                        template.Col5Alignment = dr.IsNull("Col5Alignment") ? "" : dr["Col5Alignment"].ToString();
                        template.Col5Data = dr.IsNull("Col5Data") ? "" : dr["Col5Data"].ToString();
                        template.FontName = dr.IsNull("FontName") ? "" : dr["FontName"].ToString();
                        template.FontSize = dr.IsNull("FontSize") ? 0 : decimal.Parse(dr["FontSize"].ToString());
                        template.AlignmentList = list;
                        templates.Add(template);
                    }

                }
            }
            if (templates.Count == 0)
            {
                templates.Add(new ReceiptPrintTemplate() { AlignmentList = list });
            }
            return templates;
        }

        public int InsertOrUpdatePrinters(List<Printer> printers)
        {
            try
            {
                return siteSetupData.InsertOrUpdatePrinters(printers);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int InsertOrUpdatePrintTemplateHeaderAndItems(ReceiptPrintTemplateHeader template)
        {
            try
            {
                return siteSetupData.InsertOrUpdatePrintTemplateHeaderAndItems(template);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
