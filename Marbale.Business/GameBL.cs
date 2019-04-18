using Marbale.BusinessObject;
using Marbale.BusinessObject.SiteSetup;
using Marbale.BusinessObject.Messages;
using Marbale.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marbale.BusinessObject.Game;

namespace Marble.Business
{
    public class GameBL
    {
        private GameData gameData;

         public GameBL()
        {
            gameData = new GameData();
        }

         public List<Hub> GetHubs()
         {
             try
             {
                 var hubDataTable = gameData.GetHubs();
                 List<Hub> hubs = new List<Hub>();
                 foreach (DataRow dr in hubDataTable.Rows)
                 {
                     Hub hub = new Hub();
                     hub.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                     hub.Active = dr.IsNull("Active") ? false : bool.Parse(dr["Active"].ToString());
                     hub.Name = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                     hub.Note = dr.IsNull("Note") ? "" : dr["Note"].ToString();
                     hub.Frequency = dr.IsNull("Frequency") ? 0 : int.Parse(dr["Frequency"].ToString());
                     hub.Address = dr.IsNull("Address") ? "" : dr["Address"].ToString();
                     hub.TCPPort = dr.IsNull("TCPPort") ? 0 : Convert.ToInt32(dr["TCPPort"]);
                     hub.MacAddress = dr.IsNull("MacAddress") ? "" : dr["MacAddress"].ToString();
                     hub.IPAddress = dr.IsNull("IPAddress") ? "" : dr["IPAddress"].ToString();

                     hubs.Add(hub);
                 }
                 if (hubs.Count == 0)
                 {
                     var p = new Hub();
                     hubs.Add(p);
                 }
                 return hubs;

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
                 return gameData.InsertOrUpdateHub(hub);
             }
             catch (Exception e)
             {
                 throw e;
             }
         }

         public List<GameProfile> GetGameProfiles()
         {
             try
             {
                 var gameProfileDataTable = gameData.GetGameProfiles();
                 List<GameProfile> gameProfiles = new List<GameProfile>();
                 foreach (DataRow dr in gameProfileDataTable.Rows)
                 {
                     GameProfile gameProfile = new GameProfile();
                     gameProfile.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                     gameProfile.Name = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                     gameProfile.VIPPrice = dr.IsNull("VIPPrice") ? 0 : int.Parse(dr["VIPPrice"].ToString());
                     gameProfile.NormalPrice = dr.IsNull("NormalPrice") ? 0 : int.Parse(dr["NormalPrice"].ToString());

                     gameProfile.BonusAllowed = dr.IsNull("BonusAllowed") ? false : bool.Parse(dr["BonusAllowed"].ToString());
                     gameProfile.CreditAllowed = dr.IsNull("CreditAllowed") ? false : bool.Parse(dr["CreditAllowed"].ToString());
                     gameProfile.CourtesyAllowed = dr.IsNull("CourtesyAllowed") ? false : bool.Parse(dr["CourtesyAllowed"].ToString());
                     gameProfile.TimeAllowed = dr.IsNull("TimeAllowed") ? false : bool.Parse(dr["TimeAllowed"].ToString());
                     gameProfile.TiketAllowedOnBonus = dr.IsNull("TiketAllowedOnBonus") ? false : bool.Parse(dr["TiketAllowedOnBonus"].ToString());
                     gameProfile.TiketAllowedOnCourtesy = dr.IsNull("TiketAllowedOnCourtesy") ? false : bool.Parse(dr["TiketAllowedOnCourtesy"].ToString());
                     gameProfile.TiketAllowedOnCredit = dr.IsNull("TiketAllowedOnCredit") ? false : bool.Parse(dr["TiketAllowedOnCredit"].ToString());
                     gameProfile.TiketAllowedOnTime = dr.IsNull("TiketAllowedOnTime") ? false : bool.Parse(dr["TiketAllowedOnTime"].ToString());
                     gameProfile.LastUpdatedBy = dr.IsNull("LastUpdatedBy") ? "" : dr["LastUpdatedBy"].ToString();
                     gameProfile.LastUpdatedDate = dr.IsNull("LastUpdatedDate") ? new DateTime() : Convert.ToDateTime(dr["LastUpdatedDate"]);

                     gameProfiles.Add(gameProfile);
                 }
                 if (gameProfiles.Count == 0)
                 {
                     var p = new GameProfile();
                     gameProfiles.Add(p);
                 }
                 return gameProfiles;

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
                 return gameData.InsertOrUpdateGameProfile(gameProfile);
             }
             catch (Exception e)
             {
                 throw e;
             }
         }
       
    }
}
