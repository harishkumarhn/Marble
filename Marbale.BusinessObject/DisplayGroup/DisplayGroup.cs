using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.DisplayGroup
{
    public class DisplayGroup
    {
        public int displayGroupId { get; set; }

        public string displayGroupname { get; set; }

        public int sortOrder { get; set; }
        
        public DateTime createdDate { get; set; }

        public DateTime lastUpdatedDate { get; set; }

        public string createdBy { get; set; }

        public string lastUpdatedBy { get; set; } 
    }
}
