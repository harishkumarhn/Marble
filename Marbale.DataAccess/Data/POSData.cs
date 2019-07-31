using Marbale.BusinessObject;
using Marbale.BusinessObject.Messages;
using Marbale.BusinessObject.SiteSetup;
using Marbale.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.DataAccess.Data
{
    public class POSData
    {
        private DBConnection conn;

        public POSData()
        {
            conn = new DBConnection();
        }

        public DataTable ValidateUser(string loginId, string paswword)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@loginId", loginId);
                sqlParameters[1] = new SqlParameter("@password", paswword);

                return conn.executeSelectQuery("sp_ValidateUser", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

       
    }
}
