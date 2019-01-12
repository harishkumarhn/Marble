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
        private MarbaleData marbaleData;

        public POSBusiness()
        {
            marbaleData = new MarbaleData();
        }


        public DataTable GetDefaultPaymentDropdown()
        {
            DataTable dataTable = marbaleData.GetDefalutCashMode();
           // List<POSModel> listSettings = new List<POSModel>();
            return dataTable;
        }

        public int UpdatePOSUserCredential(string Password)
        {
            int updatestatus = marbaleData.UpdatePOSUserCredential(Password);
            return updatestatus;
        }
    }
}
