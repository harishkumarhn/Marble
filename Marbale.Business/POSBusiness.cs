using Marbale.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.Business
{
   public class POSBusiness
    {
        private ProductData marbaleData;

        public POSBusiness()
        {
            marbaleData = new ProductData();
        }

        public DataTable GetDefaultPaymentDropdown()
        {
            DataTable dataTable = marbaleData.GetDefalutCashMode();
            return dataTable;
        }

        public int UpdatePOSUserCredential(string Password)
        {
            int updatestatus = marbaleData.UpdatePOSUserCredential(Password);
            return updatestatus;
        }
    }
}
