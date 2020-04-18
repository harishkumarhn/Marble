using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Inventory
{
    public class LocationType
    {
        private bool notifyingObjIsChanged;
        private readonly object notifyingObjIsChangedSyncRoot = new Object();

        public enum SearchByLocationTypeParameters
        {
            IS_ACTIVE = 1,
        }

        int locationTypeId;
        string locationTypeName;
        string notes;
        bool isActive;
        string createdBy;
        DateTime createdDate;
        String lastUpdatedBy;
        DateTime lastUpdatedDate;


        public int LocationTypeId { get { return locationTypeId; } set { locationTypeId = value; this.IsChanged = true; } }
        public string LocationTypeName { get { return locationTypeName; } set { locationTypeName = value; this.IsChanged = true; } }
        public string Notes { get { return notes; } set { notes = value; this.IsChanged = true; } }
        public bool IsActive { get { return isActive; } set { isActive = value; this.IsChanged = true; } }
        public string CreatedBy { get { return createdBy; } set { createdBy = value; this.IsChanged = true; } }
        public string LastUpdatedBy { get { return lastUpdatedBy; } set { lastUpdatedBy = value; this.IsChanged = true; } }
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; this.IsChanged = true; } }
        public DateTime LastUpdatedDate { get { return lastUpdatedDate; } set { lastUpdatedDate = value; this.IsChanged = true; } }


        public LocationType()
        {
            locationTypeId = 0;
            locationTypeName = "";
        }
        public LocationType(int locationTypeId, string locationTypeName)
        {
            this.locationTypeId = locationTypeId;
            this.locationTypeName = locationTypeName;
        }
        /// <summary>

        public LocationType(int locationTypeId, string locationTypeName, string notes, string createdBy, DateTime createdDate, string lastUpdatedBy, DateTime lastUpdatedDate, bool isActive)
        {
            this.locationTypeId = locationTypeId;
            this.locationTypeName = locationTypeName;
            this.notes = notes;
            this.createdBy = createdBy;
            this.createdDate = createdDate;
            this.lastUpdatedBy = lastUpdatedBy;
            this.lastUpdatedDate = lastUpdatedDate;
            this.isActive = isActive;
            
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
