using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.SiteSetup
{
    public class Printer
    {
        public int PrinterId { get; set; }
        public string PrinterName { get; set; }
        public string PrinterLocation { get; set; }
        public string IPAddress { get; set; }
        public bool KDSTerminal { get; set; }
        public string Remarks { get; set; }
    }
}
