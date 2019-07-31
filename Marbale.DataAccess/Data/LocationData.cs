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
    public class LocationData
    {
        private DBConnection conn;

        public LocationData()
        {
            conn = new DBConnection();
        }

        public DataTable GetLocation()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetLocation");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
