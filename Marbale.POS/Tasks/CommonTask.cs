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
            LOADTICKETS = 1,
            LOADBONUS =  2,
            LOADMULTIPLE = 3,
            TRANSFERCARD = 4,
            CANSOLIDATECARD = 5
        }
    }
}
