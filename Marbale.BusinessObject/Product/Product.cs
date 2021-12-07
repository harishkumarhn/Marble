using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Marbale.BusinessObject.Tax;

namespace Marbale.BusinessObject
{
    public class Product
    {
        public Product()
        {
            TypeList = new List<IdValue>();
        }
        public int Id { get; set; }
        public string DisplayGroup { get; set; }
        [Required(ErrorMessage = "Enter Product name.")]
        //[Remote("IsAlreadySigned", "Product", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessage = "Product Exist Already")]
        public string Name { get; set; }

        [Display(Name = "Product Type")]
        [Required(ErrorMessage = "Enter Product Type.")]
        public string Type { get; set; }

        public string POSCounter { get; set; }

        public bool Active { get; set; }
        public bool DisplayInPOS { get; set; }
        public int? DisplayGroupId { get; set; }
        public string Category { get; set; }
        public bool AutoGenerateCardNumber { get; set; }
        public bool OnlyVIP { get; set; }
        public decimal? Price { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Please enter  Number")]
        public decimal? FaceValue { get; set; }
        [DataType(DataType.Currency)]
        public bool TaxInclusive { get; set; }
        [DataType(DataType.Currency)]
        public decimal TaxPercentage { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Please enter  Number")]
        public decimal? FinalPrice { get; set; }
        [DataType(DataType.Currency)]
        public decimal? EffectivePrice { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Credits { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Courtesy { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Bonus { get; set; }
        public decimal Games { get; set; }
        [DataType(DataType.Currency)]
        public int? CreditsPlus { get; set; }
        public string StartDate { get; set; }
        public string ExpiryDate { get; set; }
        public string TaxName { get; set; }
        public string TypeName { get; set; }
        public decimal Taxpercent { get; set; }
        public int CardValidFor { get; set; }
        public DateTime? Time { get; set; }
        public int Tickets { get; set; }
        public bool TicketAllowed { get; set; }
        public bool ManagerApprovalRequired { get; set; }
        public bool TrxHeaderRemarksMandatory { get; set; }
        public bool TrxLineRemarksMandatory { get; set; }
        public bool AllowPriceOverride { get; set; }
        public bool QuantityPrompt { get; set; }
        public int MinimumQuantity { get; set; }

        public List<IdValue> TypeList { get; set; }
        public List<IdValue> CategoryList { get; set; }
        public List<TaxSet> TaxList { get; set; }
        public List<IdValue> DisplayGroupList { get; set; }
        public int? TaxId { get; set; }

        [Display(Name = "Display Order")]
        public int? DisplayOrder { get; set; }
        public DateTime? CardExpiryDate { get; set; }
        public int MaximumQuantity { get; set; }
        public string HSNSACCode { get; set; }
        public bool vipCard { get; set; }
        public bool LineRemarksMandatory { get; set; }
        public bool InvokeCustomerRegistration { get; set; }
        public int Discount { get;set;}
        public int InventoryProductCode { get; set; }
        public string Description { get; set; }
    }
}
