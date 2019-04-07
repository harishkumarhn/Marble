using Marbale.BusinessObject;
using Marbale.BusinessObject.Game;
using Marbale.BusinessObject.Messages;
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
    public class GameData
    {
        private DBConnection conn;

        public GameData()
        {
            conn = new DBConnection();
        }

        public DataTable GetHubs()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetHubs");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int InsertOrUpdateHub(Hub hub)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[9];

                sqlParameters[0] = new SqlParameter("@id", hub.Id);
                sqlParameters[1] = new SqlParameter("@name", string.IsNullOrEmpty(hub.Name) ? "" : hub.Name);
                sqlParameters[2] = new SqlParameter("@note", string.IsNullOrEmpty(hub.Note) ? "" : hub.Note);
                sqlParameters[3] = new SqlParameter("@address", string.IsNullOrEmpty(hub.Address) ? "" : hub.Address);
                sqlParameters[4] = new SqlParameter("@active", hub.Active);
                sqlParameters[5] = new SqlParameter("@frequency", hub.Frequency);
                sqlParameters[6] = new SqlParameter("@macaddress", string.IsNullOrEmpty(hub.MacAddress) ? "" : hub.MacAddress);
                sqlParameters[7] = new SqlParameter("@ipaddress", string.IsNullOrEmpty(hub.IPAddress) ? "" : hub.IPAddress);
                sqlParameters[8] = new SqlParameter("@tcpport", hub.TCPPort);

                return conn.executeUpdateQuery("sp_InsertOrUpdateHub", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
