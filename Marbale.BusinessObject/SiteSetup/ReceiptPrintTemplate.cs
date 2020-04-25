using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.SiteSetup
{
    public class ReceiptPrintTemplate
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public string FontName { get; set; }
        public decimal FontSize { get; set; }
        public string Section { get; set; }
        public int Sequence { get; set; }
        public string Col1Data { get; set; }
        public string Col1Alignment { get; set; }
        public string Col2Data { get; set; }
        public string Col2Alignment { get; set; }
        public string Col3Data { get; set; }
        public string Col3Alignment { get; set; }
        public string Col4Data { get; set; }
        public string Col4Alignment { get; set; }
        public string Col5Data { get; set; }
        public string Col5Alignment { get; set; }
        public List<IdValue> AlignmentList { get; set; }
        public List<IdValue> SectionTypes { get; set; }

    }
}
