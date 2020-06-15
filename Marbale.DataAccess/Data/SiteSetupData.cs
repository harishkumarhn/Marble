using Marbale.BusinessObject.Messages;
using Marbale.BusinessObject.SiteSetup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.DataAccess
{
    public class SiteSetupData
    {
        private DBConnection conn;

        public SiteSetupData()
        {
            conn = new DBConnection();
        }

        public DataTable GetSettings()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetSettings");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable GetAppSettings(string screen)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@screen", screen);
                return conn.executeSelectQuery("sp_GetAppSettings", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int UpdateSettings(int id, string name, string caption, string description, string defaultvalue,
            string type, string screenGroup, string updatedby, bool active, bool userLevel, bool posLevel)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[11];
                sqlParameters[0] = new SqlParameter("@id", id);
                sqlParameters[1] = new SqlParameter("@name", name);
                sqlParameters[2] = new SqlParameter("@description", description);
                sqlParameters[3] = new SqlParameter("@defaultvalue", defaultvalue);
                sqlParameters[4] = new SqlParameter("@type", type);
                sqlParameters[5] = new SqlParameter("@screengroup", screenGroup);
                sqlParameters[6] = new SqlParameter("@active", active);
                sqlParameters[7] = new SqlParameter("@userlevel", userLevel);
                sqlParameters[8] = new SqlParameter("@poslevel", posLevel);
                sqlParameters[9] = new SqlParameter("@updatedby", updatedby);
                sqlParameters[10] = new SqlParameter("@caption", caption);
                return conn.executeUpdateQuery("sp_UpdateSettings", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int SaveAppSettings(string name, string value, string screen)
        {
            try
            {

                SqlParameter[] sqlParameters = new SqlParameter[3];
                sqlParameters[0] = new SqlParameter("@name", name);
                sqlParameters[1] = new SqlParameter("@value", value);
                sqlParameters[2] = new SqlParameter("@screen", screen);
                return conn.executeUpdateQuery("sp_InsertOrUpdateAppSetting", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public DataTable GetDatatypes()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetDataTypes");
            }
            catch (Exception)
            {
                throw;
            }

        }
        public DataTable GetUserRoles()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetUserRoles");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable GetUsers()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetUsers");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable GetUserById(int id)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@id", id);
                return conn.executeSelectQuery("sp_GetUserById", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int InsertOrUpdateUserRoles(List<UserRole> userRoles)
        {
            try
            {
                foreach (var role in userRoles)
                {
                    SqlParameter[] sqlParameters = new SqlParameter[8];
                    sqlParameters[0] = new SqlParameter("@Id", role.Id);
                    sqlParameters[1] = new SqlParameter("@Role", role.Role);
                    sqlParameters[2] = new SqlParameter("@Description", role.Description);
                    sqlParameters[3] = new SqlParameter("@ManagerFlag", role.ManagerFlag);
                    sqlParameters[4] = new SqlParameter("@POSClockInOut", role.POSClockInOut);
                    sqlParameters[5] = new SqlParameter("@AllowPOSAccess", role.AllowPOSAccess);
                    sqlParameters[6] = new SqlParameter("@AllowShiftOpenClose", role.AllowShiftOpenClose);
                    sqlParameters[7] = new SqlParameter("@LastUpdatedBy", role.LastUpdatedBy == null ? "Harish" : role.LastUpdatedBy);
                    conn.executeUpdateQuery("sp_InsertOrUpdateUserRole", sqlParameters);

                    if (!string.IsNullOrWhiteSpace(role.AvailableModuleActions))
                    {
                        if (role.AvailableModuleActions.Contains("-Module") || role.AvailableModuleActions.Contains("-Root"))
                        {
                            string[] arr = role.AvailableModuleActions.Split(',');
                           // arr = arr.Skip(1).ToArray();
                            role.AvailableModuleActions = "";
                            foreach (var item in arr)
                            {
                                if(!(item.Contains("-Module") || item.Contains("-Root")))
                                role.AvailableModuleActions = role.AvailableModuleActions + item + ",";
                            }
                            role.AvailableModuleActions = role.AvailableModuleActions.Substring(0, role.AvailableModuleActions.Length - 1);

                        }
                        SqlParameter[] sqlParams = new SqlParameter[2];
                        sqlParams[0] = new SqlParameter("@RoleId", role.Id.ToString());
                        sqlParams[1] = new SqlParameter("@PageIds", role.AvailableModuleActions);
                        conn.executeUpdateQuery("sp_InsertUserRoleModuleAction", sqlParams);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return 0;
        }
        public int InsertOrUpdateUsers(User user)
        {
            try
            {
                    SqlParameter[] sqlParameters = new SqlParameter[16];
                    sqlParameters[0] = new SqlParameter("@Id", user.Id);
                    sqlParameters[1] = new SqlParameter("@Name", string.IsNullOrWhiteSpace(user.Name) ? "" : user.Name);
                    sqlParameters[2] = new SqlParameter("@LoginId", string.IsNullOrWhiteSpace(user.LoginId) ? "" : user.LoginId);
                    sqlParameters[3] = new SqlParameter("@Password", string.IsNullOrWhiteSpace(user.Password) ? Encoding.ASCII.GetBytes("") : Encoding.ASCII.GetBytes(user.Password));
                    sqlParameters[4] = new SqlParameter("@RoleId", user.RoleId);
                    sqlParameters[5] = new SqlParameter("@Email", string.IsNullOrWhiteSpace(user.Email) ? "" : user.Email);
                    sqlParameters[6] = new SqlParameter("@Manager", string.IsNullOrWhiteSpace(user.Manager) ? "" : user.Manager);
                    sqlParameters[7] = new SqlParameter("@Department", string.IsNullOrWhiteSpace(user.Department) ? "" : user.Department);
                    sqlParameters[8] = new SqlParameter("@CompanyAdmin", user.CompanyAdmin);
                    sqlParameters[9] = new SqlParameter("@EmpStartDate", user.EmpStartDate == new DateTime() ? DateTime.Now : user.EmpStartDate);
                    sqlParameters[10] = new SqlParameter("@EmpEndDate", user.EmpEndDate == new DateTime() ? DateTime.Now : user.EmpEndDate);
                    sqlParameters[11] = new SqlParameter("@EmpEndReason", string.IsNullOrWhiteSpace(user.EmpEndReason) ? "" : user.EmpEndReason);
                    sqlParameters[12] = new SqlParameter("@CreatedBy", string.IsNullOrWhiteSpace(user.CreatedBy) ? "Harish" : user.CreatedBy);
                    sqlParameters[13] = new SqlParameter("@LastUpdatedBy", user.LastUpdatedBy == null ? "Harish" : user.LastUpdatedBy);
                    sqlParameters[14] = new SqlParameter("@Status", string.IsNullOrWhiteSpace(user.Status) ? "" : user.Status);
                    sqlParameters[15] = new SqlParameter("@POSCounter", string.IsNullOrWhiteSpace(user.POSCounter) ? "" : user.POSCounter);

                    return conn.executeUpdateQuery("sp_InsertOrUpdateUser", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable GetUser(string username, string password)
        {
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@loginId", username);
            sqlParameters[1] = new SqlParameter("@password", Encoding.ASCII.GetBytes(password));

            return conn.executeSelectQuery("sp_GetUser", sqlParameters);
        }

        public DataTable GetAllMessages()
        {
            return conn.executeSelectQuery("sp_GetMessages");
        }


        public int UpdateMessages(MessagesModel messages)
        {
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@MessageNo", messages.MessageNo);
            sqlParameters[1] = new SqlParameter("@MessageName", messages.MessageName);
            sqlParameters[1].IsNullable = true;
            sqlParameters[2] = new SqlParameter("@MessageDescription", messages.MessageDescription);
            return conn.executeUpdateQuery("sp_UpdateMessages", sqlParameters);
        }


        public DataTable GetTaskType()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetTaskType");
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int UpdateTaskType(BusinessObject.SiteSetup.TaskTypeModel tasktype)
        {
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@TaskTypeId", tasktype.TaskTypeId);
            sqlParameters[1] = new SqlParameter("@TaskType", tasktype.TaskType);
            sqlParameters[2] = new SqlParameter("@TaskTypeName", tasktype.TaskTypeName);
            sqlParameters[3] = new SqlParameter("@RequiresManagerApproval", tasktype.RequiresManagerApproval);
            sqlParameters[4] = new SqlParameter("@DispalyinPOS", tasktype.DispalyinPOS);
            return conn.executeUpdateQuery("sp_UpdateTaskType", sqlParameters);
        }
        public DataTable GetAppModuleActions()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetAppModuleActions");
            }

            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetModuleActionsByRole(int roleId,bool isSuperUser = false)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@id", roleId);
                sqlParameters[1] = new SqlParameter("@isSuperUser", isSuperUser);
                return conn.executeSelectQuery("sp_GetRoleModuleActions", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable GetAllValuesButtons()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetAllValuesButtons");
            }

            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetProductKey(string siteId)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@SiteId", Convert.ToInt32(siteId));

                return conn.executeSelectQuery("sp_getProductKey", sqlParameters);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DataTable GetSites()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetSites");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable GetPrinters()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetPrinters");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable GetPrintTemplateHeaders()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetPrintTemplateHeaders");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable GetPrintTemplates(int templateId)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@templateId", templateId);
                return conn.executeSelectQuery("sp_GetPrintTemplatesById",sqlParameters);
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
                foreach (var site in sites)
                {
                    SqlParameter[] sqlParameters = new SqlParameter[11];
                    sqlParameters[0] = new SqlParameter("@siteId", site.SiteId);
                    sqlParameters[1] = new SqlParameter("@siteName", string.IsNullOrWhiteSpace(site.SiteName) ? "" : site.SiteName);
                    sqlParameters[2] = new SqlParameter("@siteAddress", string.IsNullOrWhiteSpace(site.SiteAddress) ? "" : site.SiteAddress);
                    sqlParameters[3] = new SqlParameter("@notes", string.IsNullOrWhiteSpace(site.Notes) ? "" : site.Notes);
                    sqlParameters[4] = new SqlParameter("@siteGUID", site.SiteGUID == null ? Guid.NewGuid() : site.SiteGUID);
                    sqlParameters[5] = new SqlParameter("@logo", SqlDbType.Image);
                    if (site.Logo == null)
                        sqlParameters[5].Value = DBNull.Value;
                    sqlParameters[6] = new SqlParameter("@guid", site.Guid == null ? Guid.NewGuid() : site.Guid);
                    sqlParameters[7] = new SqlParameter("@companyId", site.CompanyId);
                    sqlParameters[8] = new SqlParameter("@customerKey", string.IsNullOrWhiteSpace(site.CustomerKey) ? "" : site.CustomerKey);
                    sqlParameters[9] = new SqlParameter("@siteCode", site.SiteCode);
                    sqlParameters[10] = new SqlParameter("@version", string.IsNullOrWhiteSpace(site.Version) ? "" : site.Version);
                    conn.executeUpdateQuery("sp_InsertOrUpdateSite", sqlParameters);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return 0;
        }
        public int UpdateProductKey(ProductKey pk)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[4];
                sqlParameters[0] = new SqlParameter("@SiteId", pk.SiteId);
                sqlParameters[1] = new SqlParameter("@SiteKey", Encoding.ASCII.GetBytes(pk.SiteKey));
                sqlParameters[2] = new SqlParameter("@LicenseKey", Encoding.ASCII.GetBytes(pk.LicenseKey));
                sqlParameters[3] = new SqlParameter("@CardsCount", pk.CardsCount);
                return conn.executeUpdateQuery("sp_UpdateProductKey", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public int InsertOrUpdatePrinters(List<Printer> printers)
        {
            try
            {
                foreach (var printer in printers)
                {
                    SqlParameter[] sqlParameters = new SqlParameter[6];
                    sqlParameters[0] = new SqlParameter("@PrinterId", printer.PrinterId);
                    sqlParameters[1] = new SqlParameter("@PrinterName", string.IsNullOrWhiteSpace(printer.PrinterName) ? "" : printer.PrinterName);
                    sqlParameters[2] = new SqlParameter("@IPAddress", string.IsNullOrWhiteSpace(printer.IPAddress) ? "" : printer.IPAddress);
                    sqlParameters[3] = new SqlParameter("@PrinterLocation", string.IsNullOrWhiteSpace(printer.PrinterLocation) ? "" : printer.PrinterLocation);
                    sqlParameters[4] = new SqlParameter("@KDSTerminal", printer.KDSTerminal);
                    sqlParameters[5] = new SqlParameter("@Remarks", string.IsNullOrWhiteSpace(printer.Remarks) ? "" : printer.Remarks);
                    conn.executeUpdateQuery("sp_InsertOrUpdatePrinter", sqlParameters);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return 0;
        }
        public int InsertOrUpdatePrintTemplateHeaderAndItems(ReceiptPrintTemplateHeader template)
        {
            try
            {
                SqlParameter[] headerPrameter = new SqlParameter[4];
                headerPrameter[0] = new SqlParameter("@TemplateId", template.TemplateId);
                headerPrameter[1] = new SqlParameter("@TemplateName", string.IsNullOrWhiteSpace(template.TemplateName) ? "" : template.TemplateName);
                headerPrameter[2] = new SqlParameter("@FontName", string.IsNullOrWhiteSpace(template.FontName) ? "" : template.FontName);
                headerPrameter[3] = new SqlParameter("@FontSize", template.FontSize);
                var id = conn.executeUpdateQuery("sp_InsertOrUpdatePrintTemplateHeader", headerPrameter);

                if (template.PrintTemplateItems != null)
                {
                    foreach (var item in template.PrintTemplateItems)
                    {
                        SqlParameter[] templateItems = new SqlParameter[16];
                        templateItems[0] = new SqlParameter("@Id", item.Id);
                        templateItems[1] = new SqlParameter("@TemplateId", item.TemplateId == 0 ? id : item.TemplateId);
                        templateItems[2] = new SqlParameter("@Sequence", item.Sequence);
                        templateItems[3] = new SqlParameter("@Section", string.IsNullOrWhiteSpace(item.Section) ? "" : item.Section);
                        templateItems[4] = new SqlParameter("@FontName", string.IsNullOrWhiteSpace(item.FontName) ? "" : item.FontName);
                        templateItems[5] = new SqlParameter("@FontSize", item.FontSize);
                        templateItems[6] = new SqlParameter("@Col1Alignment", string.IsNullOrWhiteSpace(item.Col1Alignment) ? "" : item.Col1Alignment[0].ToString());
                        templateItems[7] = new SqlParameter("@Col1Data", string.IsNullOrWhiteSpace(item.Col1Data) ? "" : item.Col1Data);

                        templateItems[8] = new SqlParameter("@Col2Alignment", string.IsNullOrWhiteSpace(item.Col2Alignment) ? "" : item.Col2Alignment[0].ToString());
                        templateItems[9] = new SqlParameter("@Col2Data", string.IsNullOrWhiteSpace(item.Col2Data) ? "" : item.Col2Data);

                        templateItems[10] = new SqlParameter("@Col3Alignment", string.IsNullOrWhiteSpace(item.Col3Alignment) ? "" : item.Col3Alignment[0].ToString());
                        templateItems[11] = new SqlParameter("@Col3Data", string.IsNullOrWhiteSpace(item.Col3Data) ? "" : item.Col3Data);

                        templateItems[12] = new SqlParameter("@Col4Alignment", string.IsNullOrWhiteSpace(item.Col4Alignment) ? "" : item.Col4Alignment[0].ToString());
                        templateItems[13] = new SqlParameter("@Col4Data", string.IsNullOrWhiteSpace(item.Col4Data) ? "" : item.Col4Data);

                        templateItems[14] = new SqlParameter("@Col5Alignment", string.IsNullOrWhiteSpace(item.Col5Alignment) ? "" : item.Col5Alignment[0].ToString());
                        templateItems[15] = new SqlParameter("@Col5Data", string.IsNullOrWhiteSpace(item.Col5Data) ? "" : item.Col5Data);

                        conn.executeUpdateQuery("sp_InsertOrUpdatePrintTemplateItems", templateItems);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return 0;
        }
        public int InsertOrUpdatePaymentMode(List<PaymentMode> paymentModes)
        {
            int result;
            try
            {
                foreach (var mode in paymentModes)
                {
                    SqlParameter[] sqlParameters = new SqlParameter[12];
                    sqlParameters[0] = new SqlParameter("@PaymentModeId", mode.PaymentModeId);
                    sqlParameters[1] = new SqlParameter("@PaymentMode", string.IsNullOrWhiteSpace(mode.PaymentModeName) ? "" : mode.PaymentModeName);
                    sqlParameters[2] = new SqlParameter("@CreditCardSurchargePercentage", mode.CreditCardSurchargePercentage);
                    sqlParameters[3] = new SqlParameter("@DisplayOrder", mode.DisplayOrder);
                    sqlParameters[4] = new SqlParameter("@Guid", mode.Guid == null ? Guid.NewGuid() : mode.Guid);
                    sqlParameters[5] = new SqlParameter("@IsCash", mode.IsCash);
                    sqlParameters[6] = new SqlParameter("@IsDebitCard", mode.IsDebitCard);
                    sqlParameters[7] = new SqlParameter("@IsRoundOff", mode.IsRoundOff);
                    sqlParameters[8] = new SqlParameter("@ManagerApprovalRequired", mode.ManagerApprovalRequired);
                    sqlParameters[9] = new SqlParameter("@POSAvailable", mode.POSAvailable);
                    sqlParameters[10] = new SqlParameter("@SiteId", mode.SiteId);
                    sqlParameters[11] = new SqlParameter("@SynchStatus", mode.SynchStatus);
                    result = conn.executeUpdateQuery("sp_InsertOrUpdatePaymentMode", sqlParameters);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;

        }
        public DataTable GetPaymentModes()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetPaymentModes");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
