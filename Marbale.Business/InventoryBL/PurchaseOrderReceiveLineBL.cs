using Marbale.BusinessObject.Inventory;
using Marbale.DataAccess.Data.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marble.Business.InventoryBL
{
    public class PurchaseOrderReceiveLineBL
     {
            private PurchaseOrderReceiveLineData purchaseOrderReceiveLineData;

            public PurchaseOrderReceiveLineBL()
            {
                purchaseOrderReceiveLineData = new PurchaseOrderReceiveLineData();
            }




            public List<PurchaseOrderReceiveLine> GetPurchaseOrderReceiveLineList(List<KeyValuePair<PurchaseOrderReceiveLine.SearchByPurchaseOrderRecieveLineParameters, string>> searchParameters)
            {
                return purchaseOrderReceiveLineData.GetPurchaseOrderReceiveLineList(searchParameters);


            }
            public int Save(PurchaseOrderReceiveLine purchaseOrderReceiveLine, string userId)
            {
                try
                {
                    return purchaseOrderReceiveLineData.InsertOrUpdatePurchaseOrderReceiveLine(purchaseOrderReceiveLine, userId);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }
    }
