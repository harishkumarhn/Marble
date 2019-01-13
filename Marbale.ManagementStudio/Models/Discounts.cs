using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarbaleManagementStudio.Models
{
    public class Discounts1
    {
        public int DiscountID { get; set; }
        public string DiscountName { get; set; }
        public int DiscountPercentage { get; set; }
        public bool AutomaticApply { get; set; }
        public float MinimumSaleAmount { get; set; }
        public float MinimumUsedCredits { get; set; }
        public bool DisplayInPOS { get; set; }
        public bool ActiveFlag { get; set; }
        public int SortOrder { get; set; }
        public bool ManagerApproval { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedUser { get; set; }
        public string DiscountType { get; set; }
        public bool CouponMendatory { get; set; }
        public float DiscountAmount { get; set; }
        public bool RemarkMendatory { get; set; }
        public int DisplayOrder { get; set; }

        public bool RemarksMandatory { get; set; }
    }
}