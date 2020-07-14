using Marbale.BusinessObject.Inventory;
using Marbale.DataAccess.Data.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marble.Business.InventoryBL
{
    public class InventoryReceiptBL
    {
            private InventoryReceiptData inventoryReceiptData;

            public InventoryReceiptBL()
            {
                inventoryReceiptData = new InventoryReceiptData();
            }


          

            public List<InventoryReceipt> GetInventoryReceiptList(List<KeyValuePair<InventoryReceipt.SearchByInventoryReceiptParameters, string>> searchParameters)
            {
                return inventoryReceiptData.GetInventoryReceiptList(searchParameters);


            }
            public int Save(InventoryReceipt inventoryReceipt, string userId)
            {
                try
                {
                    return inventoryReceiptData.InsertOrUpdateInventoryReceipt(inventoryReceipt, userId);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }
    }
