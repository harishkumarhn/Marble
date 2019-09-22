using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Discount
{
    public class Discounts
    {
        public DataTable AutomaticCreditDiscountTable;
        public DataTable AutomaticSaleDiscountTable;
        public DataTable GenericDiscountTable;

        public class DiscountLine
        {
            public int DiscountId;
            public decimal DiscountPercentage;
            public string DiscountName = "";
            public bool LineValid = true;
            public string DiscountCouponNumber = "";
            public int DiscountCouponSetId = -1;
            public decimal DiscountAmount;
            public string DisplayChar = "*";
        }
        public List<DiscountLine> DiscountLines = new List<DiscountLine>();
    }
}
