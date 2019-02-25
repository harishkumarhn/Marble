using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.DataAccess
{
    public class AdminData
    {
         private DBConnection conn;

        public AdminData()
        {
            conn = new DBConnection();
        }

        public DataTable GetAppModules(string module)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@module", module);
                return conn.executeSelectQuery("sp_GetAppModules", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
