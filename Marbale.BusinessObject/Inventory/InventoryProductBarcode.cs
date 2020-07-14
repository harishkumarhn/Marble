using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Inventory
{
    public class InventoryProductBarcode
    {

        private bool notifyingObjectIsChanged;
        private readonly object notifyingObjectIsChangedSyncRoot = new Object();

        public enum SearchByInventoryProductBarcodeParameters
        {
            IS_ACTIVE = 0,
            PRODUCT_ID=1
        }

        int id;
        string barCode;
        int productId;
        bool isActive;
        string createdBy;
        string lastUpdatedBy;
        DateTime createdDate;
        DateTime lastUpdatedDate;


        public InventoryProductBarcode()
        {
            isActive = true;
            id = -1; productId = -1;
        }

        public int Id { get { return id; } set { id = value; this.IsChanged = true; } }
        public string BarCode { get { return barCode; } set { barCode = value; this.IsChanged = true; } }
        public int ProductId { get { return productId; } set { productId = value; this.IsChanged = true; } }
        public bool IsActive { get { return isActive; } set { isActive = value; this.IsChanged = true; } }
        public string CreatedBy { get { return createdBy; } set { createdBy = value; this.IsChanged = true; } }
        public string LastUpdatedBy { get { return lastUpdatedBy; } set { lastUpdatedBy = value; this.IsChanged = true; } }
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; this.IsChanged = true; } }
        public DateTime LastUpdatedDate { get { return lastUpdatedDate; } set { lastUpdatedDate = value; this.IsChanged = true; } }


        public bool IsChanged
        {
            get
            {
                lock (notifyingObjectIsChangedSyncRoot)
                {
                    return notifyingObjectIsChanged;
                }
            }

            set
            {
                lock (notifyingObjectIsChangedSyncRoot)
                {
                    if (!Boolean.Equals(notifyingObjectIsChanged, value))
                    {
                        notifyingObjectIsChanged = value;
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
