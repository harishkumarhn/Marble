using Marbale.BusinessObject.Inventory;
using Marbale.DataAccess.Data.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marble.Business.InventoryBL
{
    public class InventoryAdjustmentsBL
    {
            private InventoryAdjustmentsData inventoryAdjustmentsData;

            public InventoryAdjustmentsBL()
            {
            inventoryAdjustmentsData = new InventoryAdjustmentsData();
            }


          
            public List<InventoryAdjustments> GetInventoryAdjustmentsList(List<KeyValuePair<InventoryAdjustments.SearchByInventoryAdjustmentParameters, string>> searchParameters)
            {
                return inventoryAdjustmentsData.GetInventoryAdjustmentsList(searchParameters);


            }
            public int Save(InventoryAdjustments inventoryProduct, string userId)
            {
                try
                {
                    return inventoryAdjustmentsData.InsertOrUpdateInventoryAdjustment(inventoryProduct, userId);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }
    }
