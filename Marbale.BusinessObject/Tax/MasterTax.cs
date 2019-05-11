using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Tax
{
   public class MasterTax
    {
       public MasterTax()
       {
           Taxset = new List<TaxSet>();
           Taxstructure = new List<TaxStructure>();
       }
        public List<TaxSet> Taxset { get; set; }
        public List<TaxStructure> Taxstructure { get; set; }
    }
}
