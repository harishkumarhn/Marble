using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.SiteSetup
{
    public class AppModuleAction
    {
        public int Id { get; set; }
        public string Module { get; set; }
        public string Root { get; set; }
        public string Page { get; set; }
        public string URL { get; set; }
        public bool Active { get; set; }
        public bool Checked { get; set; }
        public int DisplayOrder { get; set; }
    }
}
