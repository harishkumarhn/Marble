using System;

namespace Marbale.BusinessObject.SiteSetup
{
    public class UserRole
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
        public bool ManagerFlag { get; set; }
        public bool AllowPOSAccess { get; set; }
        public bool POSClockInOut { get; set; }
        public bool AllowShiftOpenClose { get; set; }
        public string AvailableModuleActions { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }

    }
}
