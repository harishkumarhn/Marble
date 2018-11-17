using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale
{
  public  class AdminLoginProperties
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public int FailedAttempt { get; set; }
        public bool LoginStatus { get; set; }
    }
}
