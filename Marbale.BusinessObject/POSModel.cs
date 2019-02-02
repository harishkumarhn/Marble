using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject
{
  public  class POSModel
    {
        public int id { get; set; }
        public string DefalutCashMode { get; set; }
        public string POSSkinColor { get; set; }
        public bool EnableProductInPOS { get; set; }
        public bool EnableRefundInPOS { get; set; }
        public bool EnableDiscountInPOS { get; set; }
        public bool EnableTransactionInPOS { get; set; }
        public bool AllowPrint { get; set; }
        public bool PreferedNonCashPayment { get; set; }
        public string UserReaderpid { get; set; }
        public string UserReadervid { get; set; }
        public int ReturnWithinDays { get; set; }
        public string POSInactiveTimeOut { get; set; }
        public bool EnableTaskInPOS { get; set; }
        public bool EnableCardDetailskInPOS { get; set; }
        public bool ShowDisplayGroupInPOS { get; set; }
        public bool FullScreenInPOS { get; set; }
        public bool TransactionREprintRequiresManagerAproval { get; set; }
        public bool CancelTransactionRequiresManagerAproval { get; set; }
    }
}
