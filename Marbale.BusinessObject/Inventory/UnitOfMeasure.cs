using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Inventory
{
    public class UnitOfMeasure
    {

        private bool notifyingObjIsChanged;
        private readonly object notifyingObjIsChangedSyncRoot = new Object();

        public int uomId;
        public bool isActive;
        public string uomName;
        public string notes;
        string createdBy;
        string lastUpdatedBy;
        DateTime createdDate;
        DateTime lastUpdatedDate;

        public int UOMId { get { return uomId; } set { uomId = value; this.IsChanged = true; } }
        public bool IsActive { get { return isActive; } set { isActive = value; this.IsChanged = true; } }
        public string UomName { get { return uomName; } set { uomName = value; this.IsChanged = true; } }
        public string Notes { get { return notes; } set { notes = value; this.IsChanged = true; } }
        public string CreatedBy { get { return createdBy; } set { createdBy = value; this.IsChanged = true; } }
        public string LastUpdatedBy { get { return lastUpdatedBy; } set { lastUpdatedBy = value; this.IsChanged = true; } }
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; this.IsChanged = true; } }
        public DateTime LastUpdatedDate { get { return lastUpdatedDate; } set { lastUpdatedDate = value; this.IsChanged = true; } }


        public UnitOfMeasure()
        {
            uomId = -1;
           
        }
        public UnitOfMeasure(int uOMId, string uomName, string notes,   bool isActive, string createdBy, DateTime createdDate, string lastUpdatedBy, DateTime lastUpdatedDate )
        {
            this.uomId = uOMId;
            this.uomName = uomName;
            this.notes = notes;
            this.isActive = isActive;
            this.createdBy = createdBy;
            this.createdDate = createdDate;
            this.lastUpdatedBy = lastUpdatedBy;
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
