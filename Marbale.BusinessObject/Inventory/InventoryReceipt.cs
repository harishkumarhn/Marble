using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Inventory
{
    public class InventoryReceipt
    {
        private bool notifyingObjIsChanged;
        private readonly object notifyingObjIsChangedSyncRoot = new Object();

        public enum SearchByInventoryReceiptParameters
        {
            IS_ACTIVE = 0,
        }


        int inventoryReceiptID;
        string vendorBillNumber;
        string gatePassNumber;
        string gRN;
        int purchaseOrderId;
        string remarks;
        DateTime receiveDate;
        string receivedBy;
        bool isActive;
        string createdBy;
        DateTime createdDate;
        string lastupdatedBy;
        DateTime lastupdatedDate;


        public int InventoryReceiptID { get { return inventoryReceiptID; } set { inventoryReceiptID = value; this.IsChanged = true; } }
        public string VendorBillNumber { get { return vendorBillNumber; } set { vendorBillNumber = value; this.IsChanged = true; } }
        public string GatePassNumber { get { return gatePassNumber; } set { gatePassNumber = value; this.IsChanged = true; } }
        public string GRN { get { return gRN; } set { gRN = value; this.IsChanged = true; } }
        public int PurchaseOrderId { get { return purchaseOrderId; } set { purchaseOrderId = value; this.IsChanged = true; } }
        public string Remarks { get { return remarks; } set { remarks = value; this.IsChanged = true; } }
        public DateTime ReceiveDate { get { return receiveDate; } set { receiveDate = value; this.IsChanged = true; } }
        public string ReceivedBy { get { return receivedBy; } set { receivedBy = value; this.IsChanged = true; } }
        public bool IsActive { get { return isActive; } set { isActive = value; this.IsChanged = true; } }
        public string CreatedBy { get { return createdBy; } set { createdBy = value; this.IsChanged = true; } }
        public string LastUpdatedBy { get { return lastupdatedBy; } set { lastupdatedBy = value; this.IsChanged = true; } }
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; this.IsChanged = true; } }
        public DateTime LastUpdatedDate { get { return lastupdatedDate; } set { lastupdatedDate = value; this.IsChanged = true; } }


        public InventoryReceipt()
        {
            inventoryReceiptID = -1;

        }


        public InventoryReceipt(int inventoryReceiptID, string vendorBillNumber, string gatePassNumber, string gRN, int purchaseOrderId, string remarks, DateTime receiveDate, string receivedBy,bool isActive, string createdBy, DateTime createdDate, string lastupdatedBy, DateTime lastupdatedDate)
        {
            this.inventoryReceiptID = inventoryReceiptID;
            this.vendorBillNumber = vendorBillNumber;
            this.gatePassNumber = gatePassNumber;
            this.gRN = gRN;
            this.purchaseOrderId = purchaseOrderId;
            this.remarks = remarks;
            this.receiveDate = receiveDate;
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
