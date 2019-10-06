using Marbale.BusinessObject;
using Marbale.BusinessObject.Messages;
using Marbale.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.DataAccess
{
    public class CommonData
    {
        private DBConnection conn;

        public CommonData()
        {
            conn = new DBConnection();
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


    }
}
