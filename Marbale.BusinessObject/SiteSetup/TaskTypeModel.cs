using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.SiteSetup
{
  public  class TaskTypeModel
    {
        public int TaskTypeId { get; set; }
        public string TaskType { get; set; }
        public string TaskTypeName { get; set; }
        public bool RequiresManagerApproval { get; set; }
        public bool DispalyinPOS { get; set; }
    }
}
