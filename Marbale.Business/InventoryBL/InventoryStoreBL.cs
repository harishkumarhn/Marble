using Marbale.BusinessObject.Inventory;
using Marbale.DataAccess.Data.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marble.Business.InventoryBL
{
    public class InventoryStoreBL
    {
        private InventoryStoreData inventoryStoreData;

        public InventoryStoreBL()
        {
            inventoryStoreData = new InventoryStoreData();
        }


        public List<InventoryStore> GetTaxList(List<KeyValuePair<InventoryStore.SearchByInventoryStoreParameters, string>> taxSearchParams)
        {
            List<InventoryStore> taxList = inventoryStoreData.GetInventoryStoreList(taxSearchParams);
            return taxList;
        }
        public InventoryStore GetPurchaseTax(int productId,int locationId)
        {
            List<KeyValuePair<InventoryStore.SearchByInventoryStoreParameters, string>> taxSearchParams = new List<KeyValuePair<InventoryStore.SearchByInventoryStoreParameters, string>>();
            taxSearchParams.Add(new KeyValuePair<InventoryStore.SearchByInventoryStoreParameters, string>(InventoryStore.SearchByInventoryStoreParameters.PRODUCT_ID, productId.ToString()));
            taxSearchParams.Add(new KeyValuePair<InventoryStore.SearchByInventoryStoreParameters, string>(InventoryStore.SearchByInventoryStoreParameters.LOCATION_ID, locationId.ToString()));


            List<InventoryStore> inventoryStoreList = inventoryStoreData.GetInventoryStoreList(taxSearchParams);

            if (inventoryStoreList == null || inventoryStoreList.Count == 0)
            {
                return new InventoryStore();
            }
            else
            {
                return inventoryStoreList.FirstOrDefault();
            }

        }

        public int Save(InventoryStore tax, string userId)
        {
            try
            {
                return inventoryStoreData.InsertOrUpdateInventoryStore(tax, userId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
