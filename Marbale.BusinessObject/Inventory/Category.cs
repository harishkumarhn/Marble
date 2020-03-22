using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Marbale.BusinessObject.Inventory
{
    public class Category
    {
        private bool notifyingObjIsChanged;
        private readonly object notifyingObjIsChangedSyncRoot = new Object();

        int categoryId;
        bool isActive;
        string categoryName;
        string createdBy;
        string lastUpdatedBy;
        DateTime createdDate;
        DateTime lastUpdatedDate;

        public int CategoryId { get { return categoryId; } set { categoryId = value; this.IsChanged = true; } }
        public string CategoryName { get { return categoryName; } set { categoryName = value; this.IsChanged = true; } }
        public bool IsActive { get { return isActive; } set { isActive = value; this.IsChanged = true; } }

        public string CreatedBy { get { return createdBy; } set { createdBy = value; this.IsChanged = true; } }
        public string LastUpdatedBy { get { return lastUpdatedBy; } set { lastUpdatedBy = value; this.IsChanged = true; } }
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; this.IsChanged = true; } }
        public DateTime LastUpdatedDate { get { return lastUpdatedDate; } set { lastUpdatedDate = value; this.IsChanged = true; } }


        public Category()
        {
            categoryId = -1;

        }


        public Category(int categoryId, string name,
                           bool isActive, string createdBy, string lastUpdatedBy, DateTime createdDate, DateTime lastUpdatedDate)
        {
            this.categoryId = categoryId;
            this.categoryName = name;
            this.isActive = isActive;
            this.createdBy = createdBy;
            this.lastUpdatedBy = lastUpdatedBy;
            this.createdDate = createdDate;
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
