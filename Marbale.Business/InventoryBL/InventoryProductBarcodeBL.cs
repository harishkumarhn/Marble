using Marbale.BusinessObject.Inventory;
using Marbale.DataAccess.Data.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marble.Business.InventoryBL
{
    public class InventoryProductBarcodeBL
    {
        private InventoryProductBarcodeData InventoryProductBarcodeData;

        public InventoryProductBarcodeBL()
        {
            InventoryProductBarcodeData = new InventoryProductBarcodeData();
        }


        public List<InventoryProductBarcode> GetInventoryStoreist(List<KeyValuePair<InventoryProductBarcode.SearchByInventoryProductBarcodeParameters, string>> sparams)
        {
            List<InventoryProductBarcode> inventoryStoreList = InventoryProductBarcodeData.GetInventoryProductBarcodeList(sparams);
            return inventoryStoreList;
        }

        public int Save(InventoryProductBarcode inventoryProductBarcode, string userId)
        {
            try
            {
                return InventoryProductBarcodeData.InsertInventoryProductBarcode(inventoryProductBarcode, userId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
