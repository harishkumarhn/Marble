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

        public int vendorId;
        public bool isActive;
        public string vendorName;
        public string remarks;
        public string code;
        public string addressLine1;
        public string addressLine2;
        public string city;
        public string state;
        public string country;
        public string postalCode;
        public string addressRemarks;
        public string contactName;
        public string phone;
        public string email;
        public string website;


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

        public string CreatedBy { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }

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
