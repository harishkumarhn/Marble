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
       
    }
}
