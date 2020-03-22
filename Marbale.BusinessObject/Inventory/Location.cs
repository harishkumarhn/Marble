using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Inventory
{
    public class Location
    {

        private bool notifyingObjectIsChanged;
        private readonly object notifyingObjectIsChangedSyncRoot = new Object();

       

        int locationId;
        string name;
        bool isActive;
        bool isAvailableToSell;
        string barcode;
        bool isTurnInLocation;
        bool isStore;
        bool allowForMassUpdate;
        int locationTypeId;
        string createdBy;
        string lastUpdatedBy;
        DateTime createdDate;
        DateTime lastUpdatedDate;

        public Location()
        {
            locationId = -1;
            locationTypeId = 0;
        }
        public Location(int locationId,   string name, bool isActive, bool isAvailableToSell, string barcode, bool isTurnInLocation,
        bool isStore, bool allowForMassUpdate, int locationTypeId, string createdBy, string lastUpdatedBy, DateTime createdDate, DateTime lastUpdatedDate)
        {
            this.locationId = locationId;
            this.name = name;
            this.isActive = isActive;
            this.isAvailableToSell = isAvailableToSell;
            this.barcode = barcode;
            this.isTurnInLocation = isTurnInLocation;
            this.isStore = isStore;
            this.allowForMassUpdate = allowForMassUpdate;
            this.locationTypeId = locationTypeId;
            this.createdBy = createdBy;
            this.lastUpdatedBy = lastUpdatedBy;
            this.createdDate = createdDate;
            this.lastUpdatedDate = lastUpdatedDate;

        }

        public int LocationId { get { return locationId; } set { locationId = value; this.IsChanged = true; } }
        public string LocationName { get { return name; } set { name = value; this.IsChanged = true; } }
        public bool IsActive { get { return isActive; } set { isActive = value; this.IsChanged = true; } }
        public bool IsAvailableToSell { get { return isAvailableToSell; } set { isAvailableToSell = value; this.IsChanged = true; } }
        public string BarCode { get { return barcode; } set { barcode = value; this.IsChanged = true; } }
        public bool IsTurnInLocation { get { return isTurnInLocation; } set { isTurnInLocation = value; this.IsChanged = true; } }
        public bool IsStore { get { return isStore; } set { isStore = value; this.IsChanged = true; } }
        public bool AllowForMassUpdate { get { return allowForMassUpdate; } set { allowForMassUpdate = value; this.IsChanged = true; } }
        public int LocationTypeId { get { return locationTypeId; } set { locationTypeId = value; this.IsChanged = true; } }
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
