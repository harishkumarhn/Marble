using System;

namespace Marbale.BusinessObject
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string ReportGroup { get; set; }
        public bool Active { get; set; }
        public bool CardSale  { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
