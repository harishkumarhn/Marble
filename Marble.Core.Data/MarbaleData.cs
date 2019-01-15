using Marbale.Core.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marble.Core.Data
{
    public class MarbaleData
    {
        private DBConnection conn;
        public MarbaleData()
        {
            conn = new DBConnection();
        }

        public DataTable getSettings()
        {
            string query = string.Format("select * from appsettings");
            return conn.executeSelectQuery(query);
        }

        public DataTable searchByName(string _username)
        {
            string query = string.Format("select * from appsettings");
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@t01_firstname", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_username);
            sqlParameters[1] = new SqlParameter("@t01_lastname", SqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(_username);
            return conn.executeSelectQuery(query, sqlParameters);
        }

        /// <method>
        /// Get User Email By Id and return DalaTable
        /// </method>
        public DataTable searchById(string _id)
        {
            string query = "select * from [t01_id] where t01_id = @t01_id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@t01_id", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_id);
            return conn.executeSelectQuery(query, sqlParameters);
        }

    }
}
