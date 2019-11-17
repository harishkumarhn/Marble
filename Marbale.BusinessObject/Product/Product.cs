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
        [Remote("IsAlreadySigned", "Product", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessage = "Product Exsist Already")]
        public string Name { get; set; }
        public string Type { get; set; }
        public string POSCounter { get; set; }
        public bool Active { get; set; }
        public bool DisplayInPOS { get; set; }
        public int ? DisplayGroupId { get; set; }
        [Required(ErrorMessage = "Select Category")]
        public string Category { get; set; }
        public bool AutoGenerateCardNumber { get; set; }
        public bool OnlyVIP { get; set; }
        [Required(ErrorMessage = "Enter Price.")]
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
        public DateTime LastUpdatedDate { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Credits { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Courtesy { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Bonus { get; set; }
        public decimal Games { get; set; }
        [DataType(DataType.Currency)]
        public int? CreditsPlus { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string TaxName { get; set; }
        public string TypeName { get; set; }
        public decimal Taxpercent { get; set; }
        public string LastUpdatedUser { get; set; }
        public int CardValidFor { get; set; }

        public List<IdValue> TypeList { get; set; }
        public List<IdValue> CategoryList { get; set; }
        public List<TaxSet> TaxList { get; set; }
        public List<IdValue> DisplayGroupList { get; set; }
        public int TaxId { get; set; }
    }
}
