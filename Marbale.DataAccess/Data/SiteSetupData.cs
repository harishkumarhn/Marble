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

                    if (!string.IsNullOrWhiteSpace(role.AavalibleModuleActions))
                    {
                        if (role.AavalibleModuleActions.Contains("-Module") || role.AavalibleModuleActions.Contains("-Root"))
                        {
                            string[] arr = role.AavalibleModuleActions.Split(',');
                            arr = arr.Skip(1).ToArray(); 
                            role.AavalibleModuleActions = "";
                            foreach(var item in arr)
                            {
                                role.AavalibleModuleActions = role.AavalibleModuleActions + item + ",";
                            }
                            role.AavalibleModuleActions = role.AavalibleModuleActions.Substring(0, role.AavalibleModuleActions.Length - 1);

                        }
                        SqlParameter[] sqlParams = new SqlParameter[2];
                        sqlParams[0] = new SqlParameter("@RoleId", role.Id.ToString());
                        sqlParams[1] = new SqlParameter("@PageIds", role.AavalibleModuleActions);
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
        public int InsertOrUpdateUsers(List<User> users)
        {
            try
            {
                foreach (var user in users)
                {
                    SqlParameter[] sqlParameters = new SqlParameter[15];
                    sqlParameters[0] = new SqlParameter("@Id", user.Id);
                    sqlParameters[1] = new SqlParameter("@Name", string.IsNullOrWhiteSpace(user.Name) ? "" : user.Name);
                    sqlParameters[2] = new SqlParameter("@LoginId", string.IsNullOrWhiteSpace(user.LoginId) ? "" : user.LoginId);
                    sqlParameters[3] = new SqlParameter("@Role", string.IsNullOrWhiteSpace(user.Role) ? "" : user.Role);
                    sqlParameters[4] = new SqlParameter("@Email", string.IsNullOrWhiteSpace(user.Email) ? "" : user.Email);
                    sqlParameters[5] = new SqlParameter("@Manager", string.IsNullOrWhiteSpace(user.Manager) ? "" : user.Manager);
                    sqlParameters[6] = new SqlParameter("@Department", string.IsNullOrWhiteSpace(user.Department) ? "" : user.Department);
                    sqlParameters[7] = new SqlParameter("@CompanyAdmin", user.CompanyAdmin);
                    sqlParameters[8] = new SqlParameter("@EmpStartDate", user.EmpStartDate == new DateTime() ? DateTime.Now : user.EmpStartDate);
                    sqlParameters[9] = new SqlParameter("@EmpEndDate", user.EmpEndDate == new DateTime() ? DateTime.Now : user.EmpEndDate);
                    sqlParameters[10] = new SqlParameter("@EmpEndReason", string.IsNullOrWhiteSpace(user.EmpEndReason) ? "" : user.EmpEndReason);
                    sqlParameters[11] = new SqlParameter("@CreatedBy", string.IsNullOrWhiteSpace(user.CreatedBy) ? "Harish" : user.CreatedBy);
                    sqlParameters[12] = new SqlParameter("@LastUpdatedBy", user.LastUpdatedBy == null ? "Harish" : user.LastUpdatedBy);
                    sqlParameters[13] = new SqlParameter("@Status", string.IsNullOrWhiteSpace(user.Status) ? "" : user.Status);
                    sqlParameters[14] = new SqlParameter("@POSCounter", string.IsNullOrWhiteSpace(user.POSCounter) ? "" : user.POSCounter);

                    conn.executeUpdateQuery("sp_InsertOrUpdateUser", sqlParameters);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return 0;
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
            sqlParameters[2] = new SqlParameter("@MessageDescription", messages.MessageDescription);
            return conn.executeUpdateQuery("sp_UpdateMessages", sqlParameters);
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

        public DataTable GetModuleActionsByRole(int roleId)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@id", roleId);
                return conn.executeSelectQuery("sp_GetRoleModuleActions", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
