using Marbale.BusinessObject.Inventory;
using Marbale.DataAccess.Data.Inventory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marble.Business.InventoryBL
{
    public class PurchaseOrderBL
    {
            private PurchaseOrderData purchaseOrderData;

            public PurchaseOrderBL()
            {
                purchaseOrderData = new PurchaseOrderData();
            }


            //public PurchaseOrder GetInventoryProduct(int productId)
            //{
            //    List<KeyValuePair<PurchaseOrder.SearchByPurchaseOrderParameters, string>> searchParameters = new List<KeyValuePair<PurchaseOrder.SearchByPurchaseOrderParameters, string>>();
            //    searchParameters.Add(new KeyValuePair<PurchaseOrder.SearchByPurchaseOrderParameters, string>(PurchaseOrder.SearchByPurchaseOrderParameters.IS_ACTIVE, "1"));
                

            //    PurchaseOrder purchaseOrder = purchaseOrderData.GetInventoryProductList(searchParameters).FirstOrDefault(); ;
            //    if (purchaseOrder == null)
            //    {
            //        purchaseOrder = new PurchaseOrder();
            //    }
            //    return purchaseOrder;
            //}

            public List<PurchaseOrder> GetPurchaseOrderList(List<KeyValuePair<PurchaseOrder.SearchByPurchaseOrderParameters, string>> searchParameters)
            {
                return purchaseOrderData.GetPurchaseOrderList(searchParameters);


            }
            public int Save(PurchaseOrder purchaseOrder, string userId)
            {
                try
                {
                    return purchaseOrderData.InsertOrUpdatePurchaseOrder(purchaseOrder, userId);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }
    }
