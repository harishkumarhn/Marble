using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject
{
    public class POSModel
    {
        public string DefalutCashMode { get; set; }
        public List<KeyValue> Card { get; set; }
    }
}
