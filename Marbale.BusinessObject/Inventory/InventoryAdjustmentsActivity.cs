using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Inventory
{
     public class InventoryAdjustmentsActivity
    {

        private bool notifyingObjIsChanged;
        private readonly object notifyingObjIsChangedSyncRoot = new Object();
        public enum SearchByInventoryAdjustmentActivityParameters
        {
            IS_ACTIVE = 0,
            PRODUCT_ID=1,
            LOCATION_ID=2
        }
        
        public InventoryAdjustmentsActivity()
        {

        }

        

        string trxType;
        int productId;
        string productName;
        int locationId;
        int transferLocationId;
        int quantity;
        DateTime lastUpdatedDate;

        string lastUpdatedBy;
        string fromLocation;
        string transferLocation;

        public string TrxType { get { return trxType; } set { trxType = value; this.IsChanged = true; } }
        public int ProductId { get { return productId; } set { productId = value; this.IsChanged = true; } }
        public string ProductName { get { return productName; } set { productName = value; this.IsChanged = true; } }
        public int LocationId { get { return locationId; } set { locationId = value; this.IsChanged = true; } }
        public int TransferLocationId { get { return transferLocationId; } set { transferLocationId = value; this.IsChanged = true; } }
        public int Quantity { get { return quantity; } set { quantity = value; this.IsChanged = true; } }
        public DateTime LastUpdatedDate { get { return lastUpdatedDate; } set { lastUpdatedDate = value; this.IsChanged = true; } }



        public string LastUpdatedBy { get { return lastUpdatedBy; } set { lastUpdatedBy = value; this.IsChanged = true; } }
        public string FromLocation { get { return fromLocation; } set { fromLocation = value; this.IsChanged = true; } }
        public string TransferLocation { get { return transferLocation; } set { transferLocation = value; this.IsChanged = true; } }


        public bool IsChanged
        {
            get
            {
                lock (notifyingObjIsChangedSyncRoot)
                {
                    return notifyingObjIsChanged;
                }
            }

            set
            {
                lock (notifyingObjIsChangedSyncRoot)
                {
                    if (!Boolean.Equals(notifyingObjIsChanged, value))
                    {
                        notifyingObjIsChanged = value;
                    }
                }
            }
        }

        public void AcceptChanges()
        {
            this.IsChanged = false;
        }
    }
}
