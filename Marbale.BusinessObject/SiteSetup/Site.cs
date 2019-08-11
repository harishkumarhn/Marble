using System;
namespace Marbale.BusinessObject.SiteSetup
{
    public class Site
    {
        public string SiteName { get; set; }
        public int SiteId { get; set; }
        public string SiteAddress { get; set; }
        public string Notes { get; set; }
        public Guid SiteGUID { get; set; }
        public Guid Guid { get; set; }
        public byte[] Logo { get; set; }
        public string CustomerKey { get; set; }
        public string SiteCode { get; set; }
        public string Version { get; set; }
        public int CompanyId { get; set; }
    }
}
