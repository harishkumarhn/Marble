using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Tax
{
   public class TaxSet:IdValue
    {
       public int TaxId { get; set; }
       public string TaxName { get; set; }
       public decimal TaxPercent { get; set; }
       public bool ActiveFlag { get; set; }
    }
}
