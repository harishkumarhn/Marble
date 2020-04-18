using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Inventory
{
    public class PurchaseOrderLine
    {
        private bool notifyingObjIsChanged;
        private readonly object notifyingObjIsChangedSyncRoot = new Object();

        public enum SearchByPurchaseOrderLineParameters
        {
            IS_ACTIVE = 0,
        }

        int purchaseOrderLineId;
        int purchaseOrderId;
        string itemCode;
        string description;
        double quantity;
        double unitPrice;
        double subTotal;
        double taxAmount;
        double discountPercentage;
        DateTime requiredByDate;
        int productId;
        bool isActive;
        DateTime cancelledDate;
        string createdBy;
        DateTime createdDate;
        string lastupdatedBy;
        DateTime lastupdatedDate;


        public int PurchaseOrderLineId { get { return purchaseOrderLineId; } set { purchaseOrderLineId = value; this.IsChanged = true; } }
        public int PurchaseOrderId { get { return purchaseOrderId; } set { purchaseOrderId = value; this.IsChanged = true; } }
        public string ItemCode { get { return itemCode; } set { itemCode = value; this.IsChanged = true; } }
        public string Description { get { return description; } set { description = value; this.IsChanged = true; } }
        public double Quantity { get { return quantity; } set { quantity = value; this.IsChanged = true; } }
        public double UnitPrice { get { return unitPrice; } set { unitPrice = value; this.IsChanged = true; } }
        public double SubTotal { get { return subTotal; } set { subTotal = value; this.IsChanged = true; } }
        public double TaxAmount { get { return taxAmount; } set { taxAmount = value; this.IsChanged = true; } }
        public double DiscountPercentage { get { return discountPercentage; } set { discountPercentage = value; this.IsChanged = true; } }
        public DateTime RequiredByDate { get { return requiredByDate; } set { requiredByDate = value; this.IsChanged = true; } }
        public int ProductId { get { return productId; } set { productId = value; this.IsChanged = true; } }
        public DateTime CancelledDate { get { return cancelledDate; } set { cancelledDate = value; this.IsChanged = true; } }
        public bool IsActive { get { return isActive; } set { isActive = value; this.IsChanged = true; } }
        public string CreatedBy { get { return createdBy; } set { createdBy = value; this.IsChanged = true; } }
        public string LastUpdatedBy { get { return lastupdatedBy; } set { lastupdatedBy = value; this.IsChanged = true; } }
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; this.IsChanged = true; } }
        public DateTime LastUpdatedDate { get { return lastupdatedDate; } set { lastupdatedDate = value; this.IsChanged = true; } }


        public PurchaseOrderLine()
        {
            purchaseOrderLineId = -1;

        }


        public PurchaseOrderLine(int purchaseOrderLineId,int purchaseOrderId,string itemCode,string description,double quantity,double unitPrice,double subTotal,double taxAmount,double discountPercentage,DateTime requiredByDate,int productId , bool isActive ,DateTime    cancelledDate,string createdBy,DateTime createdDate,string lastupdatedBy,DateTime lastupdatedDate)
        {
            this.purchaseOrderLineId = purchaseOrderLineId;
            this.purchaseOrderId = purchaseOrderId;
            this.itemCode = itemCode;
            this.description = description;
            this.quantity = quantity;
            this.unitPrice = unitPrice;
            this.subTotal = subTotal;
            this.taxAmount = taxAmount;
            this.discountPercentage = discountPercentage;
            this.requiredByDate = requiredByDate;
            this.productId = productId;
            this.isActive = isActive;
            this.cancelledDate = cancelledDate;
            this.createdBy = createdBy;
            this.createdDate = createdDate;
            this.lastupdatedBy = lastupdatedBy;
            this.lastupdatedDate = lastupdatedDate;
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
