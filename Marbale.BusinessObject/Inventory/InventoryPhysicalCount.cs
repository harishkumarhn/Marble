using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Inventory
{
    public class InventoryPhysicalCount
    {
            private bool notifyingObjectIsChanged;
            private readonly object notifyingObjectIsChangedSyncRoot = new Object();
            public enum SearchByPhysicalCountParameters
        {
                IS_ACTIVE = 0,
                STATUS = 1,
                ID = 2
            }
         

        int id;
        string description;
        string status;
        Nullable<DateTime> initaitedDate;
        Nullable<DateTime> closedDate;
        string initiatedBy;
        string closedBy;
        bool isActive;

        public InventoryPhysicalCount()
        {
            id= -1;
            isActive = true;
            closedDate = DateTime.MinValue;
            initaitedDate = DateTime.MinValue;
        }


             

        public int Id { get { return id; } set { id = value; this.IsChanged = true; } }
        public string Description { get { return description; } set { description = value; this.IsChanged = true; } }
        public string Status { get { return status; } set { status = value; this.IsChanged = true; } }
        public Nullable<DateTime> InitaitedDate { get { return initaitedDate; } set { initaitedDate = value; this.IsChanged = true; } }
        public Nullable<DateTime> ClosedDate { get { return closedDate; } set { closedDate = value; this.IsChanged = true; } }
        public string InitiatedBy { get { return initiatedBy; } set { initiatedBy = value; this.IsChanged = true; } }
        public string ClosedBy { get { return closedBy; } set { closedBy = value; this.IsChanged = true; } }
        public bool IsActive { get { return isActive; } set { isActive = value; this.IsChanged = true; } }

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
