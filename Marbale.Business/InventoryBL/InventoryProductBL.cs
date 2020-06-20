using Marbale.BusinessObject;
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
    public class InventoryProductBL
    {
        private InventoryProductData inventoryProductData;

        public InventoryProductBL()
        {
            inventoryProductData = new InventoryProductData();
        }


        public  InventoryProduct  GetInventoryProduct(int productId)
        {
            List<KeyValuePair<InventoryProduct.SearchByProductParameters, string>> searchParameters = new List<KeyValuePair<InventoryProduct.SearchByProductParameters, string>>();
            searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.IS_ACTIVE, "1"));
            searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.PRODUCT_ID, productId.ToString()));

            InventoryProduct inventoryProduct= inventoryProductData.GetInventoryProductList(searchParameters).FirstOrDefault(); ;
            if(inventoryProduct==null)
            {
                inventoryProduct = new InventoryProduct();
            }
            return inventoryProduct;
        }

        public List<InventoryProduct> GetInventoryProductList(List<KeyValuePair<InventoryProduct.SearchByProductParameters, string>> searchParameters)
        {
            return inventoryProductData.GetInventoryProductList(searchParameters);

        }
        public List<InventoryProduct> GetInventoryProductListWithStoreData(List<KeyValuePair<InventoryProduct.SearchByProductParameters, string>> searchParameters)
        {
            return inventoryProductData.GetInventoryProductListWithStoreData(searchParameters);

        }
        public DataTable GetInventoryDataExport()
        {
            return inventoryProductData.GetInventoryDataExport();

        }

        public int Save(InventoryProduct inventoryProduct, string userId)
        {
            try
            {
                return inventoryProductData.InsertOrUpdateInventoryProduct(inventoryProduct, userId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}

