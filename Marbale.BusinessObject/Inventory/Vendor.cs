using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Inventory
{
    public class Vendor
    {
        private bool notifyingObjIsChanged;
        private readonly object notifyingObjIsChangedSyncRoot = new Object();
        public enum SearchByVendorParameters
        {
            IS_ACTIVE = 1,
            VENDOR_NAME = 2,
            VENDOR_CODE = 3,
            VENDOR_ID=4
        }
        int vendorId;
         bool isActive;
         string vendorName;
         string remarks;
         string code;
         string addressLine1;
         string addressLine2;
         string city;
         string state;
         string country;
         string postalCode;
         string addressRemarks;
         string contactName;
         string phone;
         string email;
         string website;
        string createdBy;
        string lastUpdatedBy;
        DateTime createdDate;
        DateTime lastUpdatedDate;


        public Vendor()
        {
            vendorId = -1;
        }

        public Vendor(int vendorId,bool isActive,string vendorName,string remarks,string code,string addressLine1,string addressLine2,
        string city,string state,string country,string postalCode,string addressRemarks,string contactName,string phone,string email,string website,string createdBy,string lastUpdatedBy,DateTime createdDate,DateTime lastUpdatedDate)
        {
            this.vendorId = vendorId;
            this.isActive = isActive;
            this.vendorName = vendorName;
            this.remarks = remarks;
            this.code = code;
            this.addressLine1 = addressLine1;
            this.addressLine2 = addressLine2;
            this.state = state;
            this.city = city;
            this.country = country;
            this.postalCode = postalCode;
            this.addressRemarks = addressRemarks;
            this.contactName = contactName;
            this.phone = phone;
            this.email = email;
            this.website = website;
            this.createdBy = createdBy;
            this.createdDate = createdDate;
            this.lastUpdatedBy = lastUpdatedBy;
            this.lastUpdatedDate = lastUpdatedDate;
        }

        public int VendorId { get { return vendorId; } set { vendorId = value; this.IsChanged = true; } }
        public bool IsActive { get { return isActive; } set { isActive = value; this.IsChanged = true; } }
        public string VendorName { get { return vendorName; } set { vendorName = value; this.IsChanged = true; } }
        public string Remarks { get { return remarks; } set { remarks = value; this.IsChanged = true; } }
        public string Code { get { return code; } set { code = value; this.IsChanged = true; } }
        public string AddressLine1 { get { return addressLine1; } set { addressLine1 = value; this.IsChanged = true; } }
        public string AddressLine2 { get { return addressLine2; } set { addressLine2 = value; this.IsChanged = true; } }
        public string City { get { return city; } set { city = value; this.IsChanged = true; } }
        public string State { get { return state; } set { state = value; this.IsChanged = true; } }
        public string Country { get { return country; } set { country = value; this.IsChanged = true; } }
        public string PostalCode { get { return postalCode; } set { postalCode = value; this.IsChanged = true; } }
        public string AddressRemarks { get { return addressRemarks; } set { addressRemarks = value; this.IsChanged = true; } }
        public string ContactName { get { return contactName; } set { contactName = value; this.IsChanged = true; } }
        public string Phone { get { return phone; } set { phone = value; this.IsChanged = true; } }
        public string Email { get { return email; } set { email = value; this.IsChanged = true; } }
        public string Website { get { return website; } set { website = value; this.IsChanged = true; } }
        public string CreatedBy { get { return createdBy; } set { createdBy = value; this.IsChanged = true; } }
        public string LastUpdatedBy { get { return lastUpdatedBy; } set { lastUpdatedBy = value; this.IsChanged = true; } }
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; this.IsChanged = true; } }
        public DateTime LastUpdatedDate { get { return lastUpdatedDate; } set { lastUpdatedDate = value; this.IsChanged = true; } }


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
