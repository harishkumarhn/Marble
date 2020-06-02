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


        public List<InventoryStore> GetInventoryStoreist(List<KeyValuePair<InventoryStore.SearchByInventoryStoreParameters, string>> sparams)
        {
            List<InventoryStore> inventoryStoreList = inventoryStoreData.GetInventoryStoreList(sparams);
            return inventoryStoreList;
        }
        public InventoryStore GetInventoryStore(int productId,int locationId)
        {
            List<KeyValuePair<InventoryStore.SearchByInventoryStoreParameters, string>> searchParams = new List<KeyValuePair<InventoryStore.SearchByInventoryStoreParameters, string>>();
            searchParams.Add(new KeyValuePair<InventoryStore.SearchByInventoryStoreParameters, string>(InventoryStore.SearchByInventoryStoreParameters.PRODUCT_ID, productId.ToString()));
            searchParams.Add(new KeyValuePair<InventoryStore.SearchByInventoryStoreParameters, string>(InventoryStore.SearchByInventoryStoreParameters.LOCATION_ID, locationId.ToString()));


            List<InventoryStore> inventoryStoreList = inventoryStoreData.GetInventoryStoreList(searchParams);

            if (inventoryStoreList == null || inventoryStoreList.Count <= 0)
            {
                return new InventoryStore();
            }
            else
            {
                return inventoryStoreList.FirstOrDefault();
            }

        }

        public int Save(InventoryStore inventoryStore, string userId)
        {
            try
            {
                return inventoryStoreData.InsertOrUpdateInventoryStore(inventoryStore, userId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int UpdateInventoryStoreOnAdjustment(InventoryStore inventoryStore, string userId)
        {
            try
            {
                return inventoryStoreData.UpdateInventoryStoreOnAdjustment(inventoryStore, userId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
