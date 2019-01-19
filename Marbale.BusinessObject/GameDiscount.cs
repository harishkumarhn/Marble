using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject
{
  public  class GameDiscount
    {
        public int DiscountID { get; set; }
        public string DiscountName { get; set; }
        public int DiscountPercentage { get; set; }
        public float MinimumUsedCredits { get; set; }
        public bool ActiveFlag { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedUser { get; set; }
    }
}
