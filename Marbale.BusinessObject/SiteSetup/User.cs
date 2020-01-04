using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.SiteSetup
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public string POSCounter { get; set; }
        public DateTime PaswardChangeDate { get; set; }
        public int InvalidAttempts { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Manager { get; set; }
        public DateTime EmpStartDate { get; set; }
        public DateTime EmpEndDate { get; set; }
        public string EmpEndReason { get; set; }
        public DateTime LastLoginTime { get; set; }
        public DateTime LastLogoutTime { get; set; }
        public DateTime CreationDate { get; set; }
        public bool CompanyAdmin { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public List<IdValue> Roles { get; set; }
        public List<IdValue> Statuses { get; set; }
    }
}
