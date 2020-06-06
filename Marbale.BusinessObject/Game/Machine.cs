using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Game
{
    public class Machine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GameName { get; set; }
        public string HubName { get; set; }
        public List<Hub> AvalibleHubs { get; set; }
        public string HubAddress { get; set; }
        public string MachineAddress { get; set; }
        public string EffectiveMachineAddress { get; set; }
        public bool Active { get; set; }
        public string ReaderType { get; set; }
        public List<IdValue> AvalibleReaders { get; set; }
        public string SoftwareVersion { get; set; }
        public string TicketMode { get; set; }
        public int VIPPrice { get; set; }
        public bool TicketAllowed { get; set; }
        public int PurchasePrice { get; set; }
        public string Notes { get; set; }
        public string Theme { get; set; }
        public List<IdValue> AvalibleThemes { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public List<IdValue> AvailableTicketModes { get; set; }
        public List<Game> AvailableGames { get; set; }
    }
}
