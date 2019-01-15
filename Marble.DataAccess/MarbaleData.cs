using Marbale.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marble.DataAccess
{
    public class MarbaleData
    {
        private DBConnection conn;
        public MarbaleData()
        {
            conn = new DBConnection();
        }

        public DataTable GetSettings()
        {
            return conn.executeSelectQuery("GetSettings");
        }

        public int UpdateSettings(int id, string name, string description, string defaultvalue,
            string type, string screenGroup,string updatedby, bool active, bool userLevel, bool posLevel)
        {
            SqlParameter[] sqlParameters = new SqlParameter[10];
            sqlParameters[0] = new SqlParameter("@id", id);
            sqlParameters[1] = new SqlParameter("@name", name);
            sqlParameters[2] = new SqlParameter("@description", description);
            sqlParameters[3] = new SqlParameter("@defaultvalue", defaultvalue);
            sqlParameters[4] = new SqlParameter("@type", type);
            sqlParameters[5] = new SqlParameter("@screengroup", screenGroup);
            sqlParameters[6] = new SqlParameter("@active", active);
            sqlParameters[7] = new SqlParameter("@userlevel", userLevel);
            sqlParameters[8] = new SqlParameter("@poslevel", posLevel);
            sqlParameters[9] = new SqlParameter("@updatedby", updatedby);

            return conn.executeUpdate("UpdateAppSettings", sqlParameters);
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
