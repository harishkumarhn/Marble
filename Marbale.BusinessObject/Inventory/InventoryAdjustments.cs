using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Inventory
{
    public class InventoryAdjustments
    {
        private bool notifyingObjIsChanged;
        private readonly object notifyingObjIsChangedSyncRoot = new Object();
        public enum SearchByInventoryAdjustmentParameters
        {
            IS_ACTIVE = 0,
        }

        int id ;
        string adjustmentType  ;
        int productId;
        double adjustmentQuantity;
        int fromLocationId;
        int toLocationId;
        string remarks;
        bool isActive;
        string createdBy;
        string lastUpdatedBy;
        DateTime createdDate;
        DateTime lastUpdatedDate;

        public int Id { get { return id; } set { id = value; this.IsChanged = true; } }
        public string AdjustmentType { get { return adjustmentType; } set { adjustmentType = value; this.IsChanged = true; } }
        public int ProductId { get { return productId; } set { productId = value; this.IsChanged = true; } }
        public double AdjustmentQuantity { get { return adjustmentQuantity; } set { adjustmentQuantity = value; this.IsChanged = true; } }
        public int FromLocationId { get { return fromLocationId; } set { fromLocationId = value; this.IsChanged = true; } }
        public int ToLocationId { get { return toLocationId; } set { toLocationId = value; this.IsChanged = true; } }
        public string Remarks { get { return remarks; } set { remarks = value; this.IsChanged = true; } }
        public bool IsActive { get { return isActive; } set { isActive = value; this.IsChanged = true; } }
        public string CreatedBy { get { return createdBy; } set { createdBy = value; this.IsChanged = true; } }
        public string LastUpdatedBy { get { return lastUpdatedBy; } set { lastUpdatedBy = value; this.IsChanged = true; } }
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; this.IsChanged = true; } }
        public DateTime LastUpdatedDate { get { return lastUpdatedDate; } set { lastUpdatedDate = value; this.IsChanged = true; } }


        public InventoryAdjustments()
        {
            Id = -1;
            isActive = true;
        }


        public InventoryAdjustments(int id ,string adjustmentType,int productId,double adjustmentQuantity,int fromLocationId,int toLocationId,string remarks,bool isActive, string createdBy, DateTime createdDate,  string lastUpdatedBy,  DateTime lastUpdatedDate)
        {
            this.id= id;
            this.adjustmentType= adjustmentType;
            this.productId= productId;
            this.adjustmentQuantity= adjustmentQuantity;
            this.fromLocationId= fromLocationId;
            this.toLocationId= toLocationId;
            this.remarks= remarks;
            this.isActive = isActive;
            this.createdBy = createdBy;
            this.lastUpdatedBy = lastUpdatedBy;
            this.createdDate = createdDate;
            this.lastUpdatedDate = lastUpdatedDate;
        }

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
