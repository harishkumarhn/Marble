using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Inventory
{
    public class LocationType
    {
        public int LocationTypeId { get; set; }

        public bool isActive { get; set; }

        public string locationTypeName { get; set; }

        public string Notes { get; set; }

        public string CreatedBy { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }
    }
}
