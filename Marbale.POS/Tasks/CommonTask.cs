using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.POS.Tasks
{
    public static class CommonTask
    {
        public enum Task
        {
            LOADTICKETS = 0,
            LOADBONUS =  1,
            LOADMULTIPLE = 2,
            TRANSFERCARD = 3,
            CANSOLIDATECARD = 4,
            REFUNDCARD = 5,
        }
    }
}
