using Marbale.BusinessObject.Inventory;
using Marbale.DataAccess.Data.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marble.Business.InventoryBL
{
    public class PurchaseOrderLineBL
    {
            private PurchaseOrderLineData purchaseOrderLineData;

            public PurchaseOrderLineBL()
            {
                purchaseOrderLineData = new PurchaseOrderLineData();
            }




            public List<PurchaseOrderLine> GetPurchaseOrderList(List<KeyValuePair<PurchaseOrderLine.SearchByPurchaseOrderLineParameters, string>> searchParameters)
            {
                return purchaseOrderLineData.GetPurchaseOrderLineList(searchParameters);


            }
            public int Save(PurchaseOrderLine purchaseOrderLine, string userId)
            {
                try
                {
                    return purchaseOrderLineData.InsertOrUpdatePurchaseOrderLine(purchaseOrderLine, userId);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }
    }
