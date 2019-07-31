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
    public class UnitOfMeasureData
    {
        private DBConnection conn;

        public UnitOfMeasureData()
        {
            conn = new DBConnection();
        }

        public DataTable GetUOM()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetUnitOfMeasure");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
