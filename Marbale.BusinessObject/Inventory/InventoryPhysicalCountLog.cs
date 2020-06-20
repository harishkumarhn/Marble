using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Inventory
{
    public class InventoryPhysicalCountLog
    {

        private bool notifyingObjectIsChanged;
        private readonly object notifyingObjectIsChangedSyncRoot = new Object();
        public enum SearchByPhysicalCountLogParameters
        {
            
            PRODUCT_ID = 0,
            LOCATION_ID = 1,
            PHYSICAL_COUNT_ID=2
        }

        int id;
        int productId;
        int locationId;
        int physicalCountId;
        double quantity;
        double allocatedQuantity;
        string createdBy;
        string lastUpdatedBy;
        DateTime createdDate;
        DateTime lastUpdatedDate;


        public InventoryPhysicalCountLog()
        {
            //taxId = -1;
            //isActive = true;
        }


        
        public int Id { get { return id; } set { id = value; this.IsChanged = true; } }
        public int ProductId { get { return productId; } set { productId = value; this.IsChanged = true; } }
        public int LocationId { get { return locationId; } set { locationId = value; this.IsChanged = true; } }
        public int PhysicalCountId { get { return physicalCountId; } set { physicalCountId = value; this.IsChanged = true; } }
        public double Quantity { get { return quantity; } set { quantity = value; this.IsChanged = true; } }
        public double AllocatedQuantity { get { return allocatedQuantity; } set { allocatedQuantity = value; this.IsChanged = true; } }
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
