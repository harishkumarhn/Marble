using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.DataAccess.Data
{
    public class VendorData
    {
        private DBConnection conn;

        public VendorData()
        {
            conn = new DBConnection();
        }

        public DataTable GetVendorData()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetVendor");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
