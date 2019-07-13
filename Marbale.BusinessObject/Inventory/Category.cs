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

        public int categoryId;
        public bool isActive;
        public string categoryName;


        public int CategoryId { get { return categoryId; } set { categoryId = value; this.IsChanged = true; } }

        public bool IsActive { get { return isActive; } set { isActive = value; this.IsChanged = true; } }

        public string CategoryName { get { return categoryName; } set { categoryName = value; this.IsChanged = true; } }

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
