using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Game
{
    public class Hub
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Frequency { get; set; }
        public string Note { get; set; }
        public bool Active { get; set; }
        public string MacAddress { get; set; }
        public string IPAddress { get; set; }
        public int TCPPort { get; set; }
    }
}
