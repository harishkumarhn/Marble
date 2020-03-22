using Marbale.BusinessObject;
using Marbale.BusinessObject.Inventory;
using Marbale.DataAccess.Data;
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
        private InventoryProductData locationTypeData;

        public InventoryProductBL()
        {
            locationTypeData = new InventoryProductData();
        }


        public  InventoryProduct  GetInventoryProduct(int productId)
        {
            List<KeyValuePair<InventoryProduct.SearchByProductParameters, string>> searchParameters = new List<KeyValuePair<InventoryProduct.SearchByProductParameters, string>>();
            searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.IS_ACTIVE, "1"));
            searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.PRODUCT_ID, "productId"));

            InventoryProduct inventoryProduct= locationTypeData.GetInventoryProductList(searchParameters).FirstOrDefault(); ;
            if(inventoryProduct==null)
            {
                inventoryProduct = new InventoryProduct();
            }
            return inventoryProduct;
        }

        public List<InventoryProduct> GetInventoryProductList(List<KeyValuePair<InventoryProduct.SearchByProductParameters, string>> searchParameters)
        {
            return locationTypeData.GetInventoryProductList(searchParameters);


        }
        public int Save(InventoryProduct locationType, string userId)
        {
            try
            {
                return locationTypeData.InsertOrUpdateInventoryProduct(locationType, userId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}

