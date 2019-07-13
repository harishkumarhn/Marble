using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Inventory
{
    public class Location
    {
        public int LocationId { get; set; }

        public string LocationName { get; set; }

        public string BarCode { get; set; }

        public int LocationTypeId { get; set; }

        public bool IsActive { get; set; }

        public bool IsStore { get; set; }

        public bool AllowForMassUpdate { get; set; }

        public bool IsTurnInLocation { get; set; }

        public bool IsAvailableToSell { get; set; }

        public string CreatedBy { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }
    }
}
