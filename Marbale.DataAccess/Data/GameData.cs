using Marbale.BusinessObject.Game;
using System;
using System.Data;
using System.Data.SqlClient;

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

        public DataTable GetGameProfiles()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetGameProfiles");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int InsertOrUpdateGameProfile(GameProfile gameProfile)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[14];

                sqlParameters[0] = new SqlParameter("@id", gameProfile.Id);
                sqlParameters[1] = new SqlParameter("@name", string.IsNullOrEmpty(gameProfile.Name) ? "" : gameProfile.Name);
                sqlParameters[2] = new SqlParameter("@normalPrice", gameProfile.NormalPrice);
                sqlParameters[3] = new SqlParameter("@vipPrice", gameProfile.VIPPrice);
                sqlParameters[4] = new SqlParameter("@creditAllowed", gameProfile.CreditAllowed);
                sqlParameters[5] = new SqlParameter("@bonusAllowed", gameProfile.BonusAllowed);
                sqlParameters[6] = new SqlParameter("@courtesyAllowed", gameProfile.CourtesyAllowed);
                sqlParameters[7] = new SqlParameter("@timeAllowed", gameProfile.TimeAllowed);
                sqlParameters[8] = new SqlParameter("@tiketAllowedOnCredit", gameProfile.TiketAllowedOnCredit);
                sqlParameters[9] = new SqlParameter("@tiketAllowedOnBonus", gameProfile.TiketAllowedOnBonus);
                sqlParameters[10] = new SqlParameter("@tiketAllowedOnCourtesy", gameProfile.TiketAllowedOnCourtesy);
                sqlParameters[11] = new SqlParameter("@tiketAllowedOnTime", gameProfile.TiketAllowedOnTime);
                sqlParameters[12] = new SqlParameter("@lastUpdatedDate", DateTime.Now);
                sqlParameters[13] = new SqlParameter("@lastUpdatedBy", string.IsNullOrEmpty(gameProfile.LastUpdatedBy) ? "" : gameProfile.LastUpdatedBy);

                return conn.executeUpdateQuery("sp_InsertOrUpdateGameProfile", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public DataTable GetGames()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetGames");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int InsertOrUpdateGame(Game game)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[11];

                sqlParameters[0] = new SqlParameter("@id", game.Id);
                sqlParameters[1] = new SqlParameter("@name", string.IsNullOrEmpty(game.Name) ? "" : game.Name);
                sqlParameters[2] = new SqlParameter("@description", string.IsNullOrEmpty(game.Description) ? "" : game.Description);
                sqlParameters[3] = new SqlParameter("@notes", string.IsNullOrEmpty(game.Notes) ? "" : game.Notes);
                sqlParameters[4] = new SqlParameter("@gameCompanyName", string.IsNullOrEmpty(game.GameCompanyName) ? "" : game.GameCompanyName);
                sqlParameters[5] = new SqlParameter("@repeatPlayDiscountPercentage", game.RepeatPlayDiscountPercentage);
                sqlParameters[6] = new SqlParameter("@gameProfile", game.GameProfile);                
                sqlParameters[7] = new SqlParameter("@normalPrice", game.NormalPrice);
                sqlParameters[8] = new SqlParameter("@vipPrice", game.VIPPrice);
                sqlParameters[9] = new SqlParameter("@lastUpdatedBy", string.IsNullOrEmpty(game.LastUpdatedBy) ? "" : game.LastUpdatedBy);
                sqlParameters[10] = new SqlParameter("@lastUpdatedDate", DateTime.Now);


                return conn.executeUpdateQuery("sp_InsertOrUpdateGame", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public DataTable GetMachines()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetMachines");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int InsertOrUpdateMachine(Machine machine)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[11];

                sqlParameters[0] = new SqlParameter("@id", machine.Id);
                sqlParameters[1] = new SqlParameter("@name", string.IsNullOrEmpty(machine.Name) ? "" : machine.Name);
                sqlParameters[3] = new SqlParameter("@notes", string.IsNullOrEmpty(machine.Notes) ? "" : machine.Notes);
                sqlParameters[8] = new SqlParameter("@vipPrice", machine.VIPPrice);
                sqlParameters[9] = new SqlParameter("@lastUpdatedBy", string.IsNullOrEmpty(machine.LastUpdatedBy) ? "" : machine.LastUpdatedBy);
                sqlParameters[10] = new SqlParameter("@lastUpdatedDate", DateTime.Now);


                return conn.executeUpdateQuery("sp_InsertOrUpdateMachine", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
