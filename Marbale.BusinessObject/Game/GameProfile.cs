using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Game
{
    public class GameProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NormalPrice { get; set; }
        public int VIPPrice { get; set; }
        public bool CreditAllowed { get; set; }
        public bool BonusAllowed { get; set; }
        public bool CourtesyAllowed { get; set; }
        public bool TimeAllowed { get; set; }
        public bool TiketAllowedOnCredit { get; set; }
        public bool TiketAllowedOnBonus { get; set; }
        public bool TiketAllowedOnCourtesy { get; set; }
        public bool TiketAllowedOnTime { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
