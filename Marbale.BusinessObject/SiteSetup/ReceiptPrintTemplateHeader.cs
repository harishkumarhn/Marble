using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.SiteSetup
{
    public class ReceiptPrintTemplateHeader
    {
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public string FontName { get; set; }
        public int FontSize { get; set; }
    }
}
