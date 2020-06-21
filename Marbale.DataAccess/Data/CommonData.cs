using Marbale.BusinessObject.SiteSetup;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Marbale.DataAccess
{
    public class CommonData
    {
        private DBConnection conn;

        public CommonData()
        {
            conn = new DBConnection();
        }
        public int DeleteById(int Id, string from, bool isDataItem = false)
        {
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@Id", Id);
            sqlParameters[1] = new SqlParameter("@from", from);
            sqlParameters[2] = new SqlParameter("@isDataItem", isDataItem);

            return conn.executeUpdateQuery("sp_DeleteById", sqlParameters);
        }

        public DataTable GetDefalutCashMode()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetDefalutCash");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable GetListItems(int groupId)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@groupId", groupId);
                return conn.executeSelectQuery("sp_GetListItems", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int ChangePassword(string UserId, string currentPassword, string NewPassword)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[3];
                sqlParameters[0] = new SqlParameter("@userId", string.IsNullOrWhiteSpace(UserId) ? "" : UserId);
                sqlParameters[1] = new SqlParameter("@currentPassword", Encoding.ASCII.GetBytes(currentPassword));
                sqlParameters[2] = new SqlParameter("@password", Encoding.ASCII.GetBytes(NewPassword));
                return conn.executeUpdateQuery("sp_ChangeUserPassword", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
