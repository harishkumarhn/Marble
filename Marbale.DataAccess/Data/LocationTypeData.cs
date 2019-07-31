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

namespace Marbale.DataAccess.Data
{
    public class LocationTypeData
    {
        private DBConnection conn;

        public LocationTypeData()
        {
            conn = new DBConnection();
        }

        public DataTable GetLocationType()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetLocationType");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
