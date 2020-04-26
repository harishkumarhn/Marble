using Marbale.BusinessObject.Inventory;
using Marbale.DataAccess.Data;
using Marbale.DataAccess.Data.Inventory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marble.Business.InventoryBL
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
        public  PurchaseTax  GetPurchaseTax(int taxid)
        {
            List<KeyValuePair<PurchaseTax.SearchByTaxParameters, string>> taxSearchParams = new List<KeyValuePair<PurchaseTax.SearchByTaxParameters, string>>();
            taxSearchParams.Add(new KeyValuePair<PurchaseTax.SearchByTaxParameters, string>(PurchaseTax.SearchByTaxParameters.PURCHASE_TAX_ID, taxid.ToString()));
            List<PurchaseTax> taxList = taxData.GetTaxList(taxSearchParams);

            if(taxList==null || taxList.Count==0)
            {
                return new PurchaseTax();
            }
            else
            {
                return taxList.FirstOrDefault();
            }
          
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
