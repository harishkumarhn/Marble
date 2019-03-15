using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Tax
{
   public class TaxStructure
    {
        public int TaxId { get; set; }
        public int TaxStructureId { get; set; }
        public string TaxStructureName { get; set; }
        public decimal TaxStructurePercentage { get; set; }
     
    }
}
