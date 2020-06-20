using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Inventory
{
   public class PurchaseOrder
    {
        private bool notifyingObjIsChanged;
        private readonly object notifyingObjIsChangedSyncRoot = new Object();

        public enum SearchByPurchaseOrderParameters
        {
            IS_ACTIVE = 0,
        }

        int purchaseOrderId;
        string orderStatus;
        string orderNumber;
        DateTime orderDate;
        int vendorId;
        string contactName;
        string phone;
        string vendorAddress1;
        string vendorAddress2;
        string vendorCity;
        string vendorState;
        string vendorCountry;
        string vendorPostalCode;
        string shipToAddress1;
        string shipToAddress2;
        string shipToCity;
        string shipToState;
        string shipToCountry;
        string shipToPostalCode;
        string shipToAddressRemarks;
        DateTime requestShipDate;
        double orderTotal;
         
        string receiveRemarks;
        DateTime cancelledDate;
        bool isActive;
        string createdBy;
        DateTime createdDate;
        string lastupdatedBy;
        DateTime lastupdatedDate;


        public int PurchaseOrderId { get { return purchaseOrderId; } set { purchaseOrderId = value; this.IsChanged = true; } }
        public string OrderStatus { get { return orderStatus; } set { orderStatus = value; this.IsChanged = true; } }
        public string OrderNumber { get { return orderNumber; } set { orderNumber = value; this.IsChanged = true; } }
        public DateTime OrderDate { get { return orderDate; } set { orderDate = value; this.IsChanged = true; } }
        public int VendorId { get { return vendorId; } set { vendorId = value; this.IsChanged = true; } }
        public string ContactName { get { return contactName; } set { contactName = value; this.IsChanged = true; } }
        public string Phone { get { return phone; } set { phone = value; this.IsChanged = true; } }
        public string VendorAddress1 { get { return vendorAddress1; } set { vendorAddress1 = value; this.IsChanged = true; } }
        public string VendorAddress2 { get { return vendorAddress2; } set { vendorAddress2 = value; this.IsChanged = true; } }
        public string VendorCity { get { return vendorCity; } set { vendorCity = value; this.IsChanged = true; } }
        public string VendorState { get { return vendorState; } set { vendorState = value; this.IsChanged = true; } }
        public string VendorCountry { get { return vendorCountry; } set { vendorCountry = value; this.IsChanged = true; } }
        public string VendorPostalCode { get { return vendorPostalCode; } set { vendorPostalCode = value; this.IsChanged = true; } }
        public string ShipToAddress1 { get { return shipToAddress1; } set { shipToAddress1 = value; this.IsChanged = true; } }
        public string ShipToAddress2 { get { return shipToAddress2; } set { shipToAddress2 = value; this.IsChanged = true; } }
        public string ShipToCity { get { return shipToCity; } set { shipToCity = value; this.IsChanged = true; } }
        public string ShipToState { get { return shipToState; } set { shipToState = value; this.IsChanged = true; } }
        public string ShipToCountry { get { return shipToCountry; } set { shipToCountry = value; this.IsChanged = true; } }
        public string ShipToPostalCode { get { return shipToPostalCode; } set { shipToPostalCode = value; this.IsChanged = true; } }
        public string ShipToAddressRemarks { get { return shipToAddressRemarks; } set { shipToAddressRemarks = value; this.IsChanged = true; } }
        public DateTime RequestShipDate { get { return requestShipDate; } set { requestShipDate = value; this.IsChanged = true; } }
        public double OrderTotal { get { return orderTotal; } set { orderTotal = value; this.IsChanged = true; } }

        public string ReceiveRemarks { get { return receiveRemarks; } set { receiveRemarks = value; this.IsChanged = true; } }
        public DateTime CancelledDate { get { return cancelledDate; } set { cancelledDate = value; this.IsChanged = true; } }
        public bool IsActive { get { return isActive; } set { isActive = value; this.IsChanged = true; } }
        public string CreatedBy { get { return createdBy; } set { createdBy = value; this.IsChanged = true; } }
        public string LastUpdatedBy { get { return lastupdatedBy; } set { lastupdatedBy = value; this.IsChanged = true; } }
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; this.IsChanged = true; } }
        public DateTime LastUpdatedDate { get { return lastupdatedDate; } set { lastupdatedDate = value; this.IsChanged = true; } }


        public PurchaseOrder()
        {
            PurchaseOrderId = -1;

        }


        public PurchaseOrder(int purchaseOrderId,string orderStatus, string orderNumber, DateTime orderDate, int vendorId, string contactName, string phone,
        string vendorAddress1, string vendorAddress2, string vendorCity, string vendorState, string vendorCountry, string vendorPostalCode, string shipToAddress1,
        string shipToAddress2, string shipToCity, string shipToState, string shipToCountry, string shipToPostalCode, string shipToAddressRemarks,
        DateTime requestShipDate, double orderTotal,   string receiveRemarks, DateTime cancelledDate, bool isActive,
        string createdBy, DateTime createdDate, string lastupdatedBy, DateTime lastupdatedDate )
        {
            this.purchaseOrderId= purchaseOrderId;
            this.orderStatus= orderStatus;
            this.orderNumber= orderNumber;
            this.orderDate= orderDate;
            this.vendorId= vendorId;
            this.contactName= contactName;
            this.phone= phone;
            this.vendorAddress1= vendorAddress1;
            this.vendorAddress2= vendorAddress2;
            this.vendorCity= vendorCity;
            this.vendorState= vendorState;
            this.vendorCountry= vendorCountry;
            this.vendorPostalCode= vendorPostalCode;
            this.shipToAddress1= shipToAddress1;
            this.shipToAddress2= shipToAddress2;
            this.shipToCity= shipToCity;
            this.shipToState= shipToState;
            this.shipToCountry= shipToCountry;
            this.shipToPostalCode= shipToPostalCode;
            this.shipToAddressRemarks= shipToAddressRemarks;
            this.requestShipDate= requestShipDate;
            this.orderTotal= orderTotal;
            this.receiveRemarks= receiveRemarks;
            this.cancelledDate = cancelledDate;
            this.isActive = isActive;
            this.createdBy= createdBy;
            this.createdDate= createdDate;
            this.lastupdatedBy= lastupdatedBy;
            this.lastupdatedDate= lastupdatedDate;

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
