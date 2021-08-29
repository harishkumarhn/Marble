using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marble.Business
{
    public static class Extention
    {

        public static int ToINT(this string o)
        {
            if (o == null)
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(o);
            }
        }

    }
}
