using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Inventory
{
    public class InventoryStore
    {

        private bool notifyingObjectIsChanged;
        private readonly object notifyingObjectIsChangedSyncRoot = new Object();
        public enum SearchByInventoryStoreParameters
        {
            IS_ACTIVE = 0,
            PRODUCT_ID = 1,
            LOCATION_ID = 1
        }


        int id;
        int productId;
        int locationId;
        double quantity;
        double allocatedQuantity;
        string remarks;
        bool isActive;
        string createdBy;
        string lastUpdatedBy;
        DateTime createdDate;
        DateTime lastUpdatedDate;

        public InventoryStore()
        {
            //taxId = -1;
            //isActive = true;
        }

         
        public InventoryStore(int i,int productId,int locationId,double quantity,double allocatedQuantity,string remarks,bool isActive,
        string createdBy,string lastUpdatedBy,DateTime createdDate,DateTime lastUpdatedDate )
        {
            this.id=id;
       this.productId=productId;
        this.locationId=locationId;
        this.quantity=quantity;
       this.allocatedQuantity=allocatedQuantity;
        this.remarks=remarks;
       this.isActive=isActive;
        this.createdBy=createdBy;
        this.lastUpdatedBy=lastUpdatedBy;
       this.createdDate=createdDate;
        this.lastUpdatedDate=lastUpdatedDate;
    }

        public int Id { get { return id; } set { id = value; this.IsChanged = true; } }
        public int ProductId { get { return productId; } set { productId = value; this.IsChanged = true; } }
        public int LocationId { get { return locationId; } set { locationId = value; this.IsChanged = true; } }
        public double Quantity { get { return quantity; } set { quantity = value; this.IsChanged = true; } }
        public double AllocatedQuantity { get { return allocatedQuantity; } set { allocatedQuantity = value; this.IsChanged = true; } }
        public string Remarks { get { return remarks; } set { createdBy = value; this.IsChanged = true; } }
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
