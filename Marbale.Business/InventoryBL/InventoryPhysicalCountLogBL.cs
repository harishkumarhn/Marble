using Marbale.BusinessObject.Inventory;
using Marbale.DataAccess.Data.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marble.Business.InventoryBL
{
    public  class InventoryPhysicalCountLogBL
    {
        private InventoryPhysicalCountLogData inventoryPhysicalCountLogData;

        public InventoryPhysicalCountLogBL()
        {
            inventoryPhysicalCountLogData = new InventoryPhysicalCountLogData();
        }


        public List<InventoryPhysicalCountLog> GetInventoryStoreist(List<KeyValuePair<InventoryPhysicalCountLog.SearchByPhysicalCountLogParameters, string>> sparams)
        {
            List<InventoryPhysicalCountLog> inventoryStoreList = inventoryPhysicalCountLogData.GetInventoryPhysicalCountLogList(sparams);
            return inventoryStoreList;
        }
        //public InventoryPhysicalCountLog GetInventoryStore(int productId, int locationId)
        //{
        //    List<KeyValuePair<InventoryPhysicalCountLog.SearchByInventoryStoreParameters, string>> searchParams = new List<KeyValuePair<InventoryPhysicalCountLog.SearchByInventoryStoreParameters, string>>();
        //    searchParams.Add(new KeyValuePair<InventoryPhysicalCountLog.SearchByInventoryStoreParameters, string>(InventoryPhysicalCountLog.SearchByInventoryStoreParameters.PRODUCT_ID, productId.ToString()));
        //    searchParams.Add(new KeyValuePair<InventoryPhysicalCountLog.SearchByInventoryStoreParameters, string>(InventoryPhysicalCountLog.SearchByInventoryStoreParameters.LOCATION_ID, locationId.ToString()));


        //    List<InventoryPhysicalCountLog> inventoryStoreList = inventoryStoreData.GetInventoryStoreList(searchParams);

        //    if (inventoryStoreList == null || inventoryStoreList.Count <= 0)
        //    {
        //        return new InventoryPhysicalCountLog();
        //    }
        //    else
        //    {
        //        return inventoryStoreList.FirstOrDefault();
        //    }

        //}

        public int Save(InventoryPhysicalCountLog inventoryPhysicalCountLog, string userId)
        {
            try
            {
                return inventoryPhysicalCountLogData.InsertOrUpdateInventoryPhysicalCountLog(inventoryPhysicalCountLog, userId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public int InsertInventoryPhysicalCountLogByID(int physicalCountId, string userId)
        {
            try
            {
                return inventoryPhysicalCountLogData.InsertInventoryPhysicalCountLogByID(physicalCountId, userId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
