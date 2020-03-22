using Marbale.BusinessObject.Inventory;
using Marbale.DataAccess.Data;
 
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marble.Business
{
   public  class PurchaseTaxBL
    {
        private PurchaseTaxData taxData;

        public PurchaseTaxBL()
        {
            taxData = new PurchaseTaxData();
        }


        public List<PurchaseTax> GetTaxList(List<KeyValuePair<PurchaseTax.SearchByTaxParameters, string>> taxSearchParams)
        {
            List < PurchaseTax > taxList = taxData.GetTaxList(taxSearchParams);
            return taxList;
        }


        public int Save(PurchaseTax tax, string userId)
        {
            try
            {
                return taxData.InsertOrUpdateTax(tax, userId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
