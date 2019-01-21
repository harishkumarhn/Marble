using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject
{
  public  class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string ParentCategory { get; set; }
    }
}
