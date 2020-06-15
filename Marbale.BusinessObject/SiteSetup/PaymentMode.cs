using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.SiteSetup
{
    public class PaymentMode
    {
        public string PaymentModeName { get; set; }
        public int PaymentModeId { get; set; }
        public bool IsCreditCard { get; set; }
        public int CreditCardSurchargePercentage { get; set; }
        public string SynchStatus { get; set; }
        public Guid? Guid { get; set; }
        public int SiteId { get; set; }
        public bool IsCash { get; set; }
        public bool IsDebitCard { get; set; }
        public bool ManagerApprovalRequired { get; set; }
        public bool IsRoundOff { get; set; }
        public bool POSAvailable { get; set; }
        public int DisplayOrder { get; set; }
    }
}
