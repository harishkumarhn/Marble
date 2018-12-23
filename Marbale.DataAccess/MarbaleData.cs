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
    public class MarbaleData
    {
        private DBConnection conn;

        public MarbaleData()
        {
            conn = new DBConnection();
        }

        public DataTable GetSettings()
        {
            return conn.executeSelectQuery("sp_GetSettings");
        }

        public DataTable GetAppSettings(string screen)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@screen", screen);
            return conn.executeSelectQuery("sp_GetAppSettings", sqlParameters);
        }

        public int UpdateSettings(int id, string name, string caption,string description, string defaultvalue,
            string type, string screenGroup,string updatedby, bool active, bool userLevel, bool posLevel)
        {
            SqlParameter[] sqlParameters = new SqlParameter[11];
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
            sqlParameters[10] = new SqlParameter("@caption", caption);



            return conn.executeUpdateQuery("sp_UpdateSettings", sqlParameters);
        }

        public int SaveAppSettings(string name, string value, string screen)
        {
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@name", name);
            sqlParameters[1] = new SqlParameter("@value", value);
            sqlParameters[2] = new SqlParameter("@screen", screen);

            return conn.executeUpdateQuery("sp_InsertOrUpdateAppSetting", sqlParameters);
        }

    }
}
