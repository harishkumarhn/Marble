using Marbale.BusinessObject.Inventory;
using Marbale.DataAccess.Data.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marble.Business.InventoryBL
{
    public class InventoryAdjustmentsActivityBL
    {
        private InventoryAdjustmentsActivityData inventoryAdjustmentsActivityData;

        public InventoryAdjustmentsActivityBL()
        {
            inventoryAdjustmentsActivityData = new InventoryAdjustmentsActivityData();
        }



        public List<InventoryAdjustmentsActivity> GetInventoryAdjustmentsList(List<KeyValuePair<Marbale.BusinessObject.Inventory.InventoryAdjustmentsActivity.SearchByInventoryAdjustmentActivityParameters, string>> searchParameters)
        {
            return inventoryAdjustmentsActivityData.GetInventoryAdjustmentsActivityList(searchParameters);


        }
    }
}
