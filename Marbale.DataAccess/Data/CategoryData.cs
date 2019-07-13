using Marbale.BusinessObject;
using Marbale.BusinessObject.Inventory;
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
    public class CategoryData
    {
        private DBConnection conn;

        public CategoryData()
        {
            conn = new DBConnection();
        }

        public DataTable GetCategory()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetCategory");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int InsertOrUpdateCategroy(Category category)
        {
            try
            {
                return 1;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
