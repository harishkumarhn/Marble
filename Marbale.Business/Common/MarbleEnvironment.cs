using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marble.Business
{
    public class MarbleEnvironment
    {
        public string DATETIME_FORMAT;
        public string AMOUNT_FORMAT;
        public string NUMBER_FORMAT;

        public void InitEnvironment()
        {
            try
            {
                DATETIME_FORMAT = "dd-MMM-yyyy h:mm tt";
            }
            catch
            {
              
            }

            try
            {
                NUMBER_FORMAT = "N0";
            }
            catch
            {
               
            }

            try
            {
                 AMOUNT_FORMAT = "N2";
            }
            catch
            {
               
            }
        }
    }
}
