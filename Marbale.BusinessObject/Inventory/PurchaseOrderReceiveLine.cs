using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Inventory
{
   public class PurchaseOrderReceiveLine
    {
        private bool notifyingObjIsChanged;
        private readonly object notifyingObjIsChangedSyncRoot = new Object();

        public enum SearchByPurchaseOrderRecieveLineParameters
        {
            IS_ACTIVE = 0,
        }

        int purchaseOrderReceiveLineId;
        int purchaseOrderId;
        int productId;
        string description;
        string vendorItemCode;
        double quantity;
        int locationId;
        bool isReceived;
        int purchaseOrderLineId;
        double price;
        double taxPercentage;
        double amount;
        bool taxInclusive;
        int taxId;
        int receiptId;
        string vendorBillNumber;
        string receivedBy;
        bool isActive;
        string createdBy;
        DateTime createdDate;
        string lastupdatedBy;
        DateTime lastupdatedDate;

        public int PurchaseOrderReceiveLineId   { get { return purchaseOrderReceiveLineId; } set { purchaseOrderReceiveLineId = value; this.IsChanged = true; } }
        public int PurchaseOrderId { get { return purchaseOrderId; } set { purchaseOrderId = value; this.IsChanged = true; } }
        public int ProductId { get { return productId; } set { productId = value; this.IsChanged = true; } }
        public string Description { get { return description; } set { description = value; this.IsChanged = true; } }
         public string VendorItemCode { get { return vendorItemCode; } set { vendorItemCode = value; this.IsChanged = true; } }
        public double Quantity { get { return quantity; } set { quantity = value; this.IsChanged = true; } }
        public int LocationId { get { return locationId; } set { locationId = value; this.IsChanged = true; } }
        public bool IsReceived { get { return isReceived; } set { isReceived = value; this.IsChanged = true; } }
        public int PurchaseOrderLineId { get { return purchaseOrderLineId; } set { purchaseOrderLineId = value; this.IsChanged = true; } }
        public double Price { get { return price; } set { price = value; this.IsChanged = true; } }
        public double TaxPercentage { get { return taxPercentage; } set { taxPercentage = value; this.IsChanged = true; } }
        public double Amount { get { return amount; } set { amount = value; this.IsChanged = true; } }
        public bool TaxInclusive { get { return taxInclusive; } set { taxInclusive = value; this.IsChanged = true; } }
        public int TaxId { get { return taxId; } set { taxId = value; this.IsChanged = true; } }
        public int ReceiptId { get { return receiptId; } set { receiptId = value; this.IsChanged = true; } }
        public string VendorBillNumber { get { return vendorBillNumber; } set { vendorBillNumber = value; this.IsChanged = true; } }
        public string ReceivedBy { get { return receivedBy; } set { receivedBy = value; this.IsChanged = true; } }
        public bool IsActive { get { return isActive; } set { isActive = value; this.IsChanged = true; } }
        public string CreatedBy { get { return createdBy; } set { createdBy = value; this.IsChanged = true; } }
        public string LastUpdatedBy { get { return lastupdatedBy; } set { lastupdatedBy = value; this.IsChanged = true; } }
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; this.IsChanged = true; } }
        public DateTime LastUpdatedDate { get { return lastupdatedDate; } set { lastupdatedDate = value; this.IsChanged = true; } }


        public PurchaseOrderReceiveLine()
        {
            purchaseOrderReceiveLineId = -1;

        }


        public PurchaseOrderReceiveLine(int purchaseOrderReceiveLineId,int purchaseOrderId,int productId,string description,string vendorItemCode,double quantity,int locationId,bool isReceived,int purchaseOrderLineId,double price,double taxPercentage,double amount,bool taxInclusive,int taxId,int receiptId,string vendorBillNumber,string receivedBy, bool isActive, string createdBy,DateTime createdDate,string lastupdatedBy,DateTime lastupdatedDate)
        {
            this.purchaseOrderReceiveLineId = purchaseOrderReceiveLineId;
            this.purchaseOrderId = purchaseOrderId;
            this.productId = productId;
            this.description = description;
            this.vendorItemCode = vendorItemCode;
            this.quantity = quantity;
            this.locationId = locationId;
            this.isReceived = isReceived;
            this.purchaseOrderLineId = purchaseOrderLineId;
            this.price = price;
            this.taxPercentage = taxPercentage;
            this.amount = amount;
            this.taxInclusive = taxInclusive;
            this.taxId = taxId;
            this.receiptId = receiptId;
            this.vendorBillNumber = vendorBillNumber;
            this.receivedBy = receivedBy;
            this.isActive = isActive;
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
    
    