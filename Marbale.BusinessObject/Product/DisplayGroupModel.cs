using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject
{
  public  class DisplayGroupModel
    {
        public int Id { get; set; }
        public string DisplayGroup { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public string LastUpdatedBy { get; set; }
        public string LastUpdatedDate { get; set; }
    }
}
