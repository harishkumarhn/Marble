using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject
{
    public class Settings
    {
        public int Id {get;set;}
        public string Name { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string DefaultValue { get; set; }
        public string Type { get; set; }
        public string ScreenGroup { get; set; }
        public bool Active { get; set; }
        public bool UserLevel { get; set; }
        public bool PosLevel { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }

    }
}
