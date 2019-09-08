using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Game
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int GameProfile { get; set; }
        public string GPNormalPrice { get; set; }
        public string GPVipPrice { get; set; }
        public List<GameProfile> GameProfiles { get; set; }
        public int NormalPrice { get; set; }
        public int VIPPrice { get; set; }
        public int RepeatPlayDiscountPercentage { get; set; }
        public string GameCompanyName { get; set; }
        public string Notes { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
