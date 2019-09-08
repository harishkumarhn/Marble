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
using Marble.Business.Enum;

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
         public List<Game> GetGames()
         {
             try
             {
                 var gameDataTable = gameData.GetGames();
                 List<Game> games = new List<Game>();
                 List<GameProfile> profiles = new List<GameProfile>();
                 profiles.Add(new GameProfile() { Id = 0, Name = "Select" });
                 profiles.AddRange(GetGameProfiles());
                 foreach (DataRow dr in gameDataTable.Rows)
                 {
                     Game game = new Game();
                     game.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                     game.Name = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                     game.Description = dr.IsNull("Description") ? "" : dr["Description"].ToString();
                     game.GameProfile = dr.IsNull("GameProfile") ? 0 : int.Parse(dr["GameProfile"].ToString());
                     game.GPNormalPrice = game.GameProfile > 0 ? profiles.Find(x => x.Id == game.GameProfile).NormalPrice.ToString() : "";
                     game.GPVipPrice = game.GameProfile > 0 ? profiles.Find(x => x.Id == game.GameProfile).VIPPrice.ToString() : "";
                     game.Notes = dr.IsNull("Notes") ? "" : dr["Notes"].ToString();
                     game.GameCompanyName = dr.IsNull("GameCompanyName") ? "" : dr["GameCompanyName"].ToString();
                     game.VIPPrice = dr.IsNull("VIPPrice") ? 0 : int.Parse(dr["VIPPrice"].ToString());
                     game.NormalPrice = dr.IsNull("NormalPrice") ? 0 : int.Parse(dr["NormalPrice"].ToString());
                     game.RepeatPlayDiscountPercentage = dr.IsNull("RepeatPlayDiscountPercentage") ? 0 : int.Parse(dr["RepeatPlayDiscountPercentage"].ToString());
                     game.GameProfiles = profiles;
                     game.LastUpdatedBy = dr.IsNull("LastUpdatedBy") ? "" : dr["LastUpdatedBy"].ToString();
                     game.LastUpdatedDate = dr.IsNull("LastUpdatedDate") ? new DateTime() : Convert.ToDateTime(dr["LastUpdatedDate"]);

                     games.Add(game);
                 }
                 if (games.Count == 0)
                 {
                     var obj = new Game();
                     obj.GameProfiles = profiles;
                     games.Add(obj);
                 }
                 return games;

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
                 return gameData.InsertOrUpdateGame(game);
             }
             catch (Exception e)
             {
                 throw e;
             }
         }
         public List<Machine> GetMachines()
         {
             try
             {
                 var gameDataTable = gameData.GetMachines();
                 List<Machine> machines = new List<Machine>();

                 List<Hub> hubs = new List<Hub>();
                 hubs.Add(new Hub() { Id = 0, Name = "Select" });
                 hubs.AddRange(GetHubs());

                 List<IdValue> readers = new List<IdValue>();
                 readers.Add(new IdValue() { Id = 0, Value = "Select" });
                 readers.Add(new IdValue() { Id = 0, Value = "Reader1" });
                 readers.Add(new IdValue() { Id = 0, Value = "Reader2" });                

                 List<IdValue> themes = new List<IdValue>();
                 themes.Add(new IdValue() { Id = 0, Value = "Select" });
                 themes.Add(new IdValue() { Id = 0, Value = "Theme1" });
                 themes.Add(new IdValue() { Id = 0, Value = "Theme2" });

                 foreach (DataRow dr in gameDataTable.Rows)
                 {
                     Machine machine = new Machine();
                     machine.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                     machine.Name = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                     machine.GameName = dr.IsNull("GameName") ? "" : dr["GameName"].ToString();
                     machine.HubName = dr.IsNull("HubName") ? "" : dr["HubName"].ToString();
                     machine.MachineAddress = dr.IsNull("MachineAddress") ? "" : dr["MachineAddress"].ToString();
                     machine.HubAddress = dr.IsNull("HubAddress") ? "" : dr["HubAddress"].ToString();
                     machine.EffectiveMachineAddress = dr.IsNull("EffectiveMachineAddress") ? "" : dr["EffectiveMachineAddress"].ToString();
                     machine.Active = dr.IsNull("Active") ? false : bool.Parse(dr["Active"].ToString());
                     machine.VIPPrice = dr.IsNull("VIPPrice") ? 0 : int.Parse(dr["VIPPrice"].ToString());
                     machine.PurchasePrice = dr.IsNull("PurchasePrice") ? 0 : int.Parse(dr["PurchasePrice"].ToString());
                     machine.ReaderType = dr.IsNull("ReaderType") ? "" : dr["ReaderType"].ToString();
                     machine.SoftwareVersion = dr.IsNull("SoftwareVersion") ? "" : dr["SoftwareVersion"].ToString();
                     machine.Theme = dr.IsNull("Theme") ? "" : dr["Theme"].ToString();
                     machine.TicketMode = dr.IsNull("TicketMode") ? "" : dr["TicketMode"].ToString();
                     machine.TicketAllowed = dr.IsNull("TicketAllowed") ? false : bool.Parse(dr["TicketAllowed"].ToString());
                     machine.Notes = dr.IsNull("Notes") ? "" : dr["Notes"].ToString();
                     machine.LastUpdatedBy = dr.IsNull("LastUpdatedBy") ? "" : dr["LastUpdatedBy"].ToString();
                     machine.LastUpdatedDate = dr.IsNull("LastUpdatedDate") ? new DateTime() : Convert.ToDateTime(dr["LastUpdatedDate"]);

                     machine.AvalibleHubs = hubs;
                     machine.AvalibleReaders = readers;
                     machine.AvalibleThemes = themes;

                     machines.Add(machine);
                 }
                 if (machines.Count == 0)
                 {
                     var obj = new Machine();
                     obj.AvalibleHubs = hubs;
                     obj.AvalibleReaders = readers;
                     obj.AvalibleThemes = themes;
                     machines.Add(obj);
                 }
                 return machines;

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
                 return gameData.InsertOrUpdateMachine(machine);
             }
             catch (Exception e)
             {
                 throw e;
             }
         }
         public List<ActiveHubMachine> GetActiveHubMachines(int hubId)
         {
             List<ActiveHubMachine> activeHubMachines = new List<ActiveHubMachine>();
             try
             {
                 var hubDataTable = gameData.GetActiveHubMachines(hubId);
                 foreach (DataRow dr in hubDataTable.Rows)
                 {
                     ActiveHubMachine aHM = new ActiveHubMachine();
                     aHM.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                     aHM.Machine = dr.IsNull("Machine") ? "" : dr["Machine"].ToString();
                     aHM.HubName = dr.IsNull("HubName") ? "" : dr["HubName"].ToString();
                     activeHubMachines.Add(aHM);
                 }
             }
             catch (Exception ex)
             {
                 return null;
             }
             return activeHubMachines;

         }
    }
}
