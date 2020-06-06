using Marbale.BusinessObject.Inventory;
using Marbale.DataAccess.Data.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marble.Business.InventoryBL
{
    public class InventoryPhysicalCountBL
    {
            private InventoryPhysicalCountData inventoryPhysicalCountData;

            public InventoryPhysicalCountBL()
            {
                inventoryPhysicalCountData = new InventoryPhysicalCountData();
            }


            //public List<InventoryPhysicalCount> GetInventoryPhysicalCount(List<KeyValuePair<InventoryPhysicalCount.SearchByPhysicalCountParameters, string>> searchParams)
            //{
            //    List<InventoryPhysicalCount> inventoryPhysicalCountList = inventoryPhysicalCountData.GetInventoryStoreList(searchParams);
            //    return inventoryPhysicalCountList;
            //}
            public InventoryPhysicalCount GetInventoryPhysicalCount(string status)
            {
                List<KeyValuePair<InventoryPhysicalCount.SearchByPhysicalCountParameters, string>> taxSearchParams = new List<KeyValuePair<InventoryPhysicalCount.SearchByPhysicalCountParameters, string>>();
                taxSearchParams.Add(new KeyValuePair<InventoryPhysicalCount.SearchByPhysicalCountParameters, string>(InventoryPhysicalCount.SearchByPhysicalCountParameters.IS_ACTIVE, "1"));
                taxSearchParams.Add(new KeyValuePair<InventoryPhysicalCount.SearchByPhysicalCountParameters, string>(InventoryPhysicalCount.SearchByPhysicalCountParameters.STATUS, status.ToString()));


                List<InventoryPhysicalCount> inventoryStoreList = inventoryPhysicalCountData.GetInventoryStoreList(taxSearchParams);

                if (inventoryStoreList == null || inventoryStoreList.Count == 0)
                {
                    return new InventoryPhysicalCount();
                }
                else
                {
                    return inventoryStoreList.FirstOrDefault();
                }

            }

            public int Save(InventoryPhysicalCount tax, string userId)
            {
                try
                {
                    return inventoryPhysicalCountData.InsertOrUpdateInventoryStore(tax, userId);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

           
        }
    }
