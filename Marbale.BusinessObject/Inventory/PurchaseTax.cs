using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Inventory
{
    public class PurchaseTax
    {

        private bool notifyingObjectIsChanged;
        private readonly object notifyingObjectIsChangedSyncRoot = new Object();
        public enum SearchByTaxParameters
        {
            IS_ACTIVE = 0,
            PURCHASE_TAX_ID=1
        }


        int taxId;
        string taxName;
        double taxPercentage;
        bool isActive;
        string createdBy;
        string lastUpdatedBy;
        DateTime createdDate;
        DateTime lastUpdatedDate;

        public PurchaseTax()
        {
            taxId = -1;
            isActive = true;
        }
 
        public PurchaseTax(int taxId, string taxName, double taxPercentage, bool activeFlag , string createdBy, string lastUpdatedBy, DateTime createdDate, DateTime lastUpdatedDate)
        {
            this.taxId = taxId;
            this.taxName = taxName;
            this.taxPercentage = taxPercentage;
            this.isActive = activeFlag;
            this.createdBy = createdBy;
            this.createdDate = createdDate;
            this.lastUpdatedBy = lastUpdatedBy;
            this.lastUpdatedDate = lastUpdatedDate;
        }

        public int TaxId { get { return taxId; } set { taxId = value; this.IsChanged = true; } }
        public string TaxName { get { return taxName; } set { taxName = value; this.IsChanged = true; } }
        public double TaxPercentage { get { return taxPercentage; } set { taxPercentage = value; this.IsChanged = true; } }
       
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
