using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject
{
   public class MasterDiscounts
    {
       public MasterDiscounts()
       {
           transactiondiscount = new List<TransactionDiscount>();
           gaamediscount = new List<GameDiscount>();
       }

       public List<GameDiscount> gaamediscount { get; set; }
       public List<TransactionDiscount> transactiondiscount { get; set; }
    }
}
