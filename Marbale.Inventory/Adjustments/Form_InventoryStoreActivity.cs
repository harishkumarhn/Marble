using Marbale.BusinessObject.Inventory;
using Marble.Business.InventoryBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marbale.Inventory.Adjustments
{
    public partial class Form_InventoryStoreActivity : Form
    {
        int productId = 0;
        int locationId = 0;
        public Form_InventoryStoreActivity()
        {
            InitializeComponent();
            PopulateGrid();
        }
        private void Form_InventoryStoreActivity_Load(object sender, EventArgs e)
        {

        }
        public Form_InventoryStoreActivity(int productId,int locationId)
        {
            this.productId = productId;
            this.locationId = locationId;
            InitializeComponent();
            PopulateGrid();

        }


        private void PopulateGrid()
        {
            BindingSource bindingSource = new BindingSource();
            InventoryAdjustmentsActivityBL inventoryAdjustmentsActivityBL = new InventoryAdjustmentsActivityBL();
            List<InventoryAdjustmentsActivity> inventoryAdjustmentsActivityList = new List<InventoryAdjustmentsActivity>();
            try
            {
                List<KeyValuePair<InventoryAdjustmentsActivity.SearchByInventoryAdjustmentActivityParameters, string>> searchParameters = new List<KeyValuePair<InventoryAdjustmentsActivity.SearchByInventoryAdjustmentActivityParameters, string>>();
                searchParameters.Add(new KeyValuePair<InventoryAdjustmentsActivity.SearchByInventoryAdjustmentActivityParameters, string>(InventoryAdjustmentsActivity.SearchByInventoryAdjustmentActivityParameters.IS_ACTIVE, "1"));
                searchParameters.Add(new KeyValuePair<InventoryAdjustmentsActivity.SearchByInventoryAdjustmentActivityParameters, string>(InventoryAdjustmentsActivity.SearchByInventoryAdjustmentActivityParameters.PRODUCT_ID, productId.ToString())); searchParameters.Add(new KeyValuePair<InventoryAdjustmentsActivity.SearchByInventoryAdjustmentActivityParameters, string>(InventoryAdjustmentsActivity.SearchByInventoryAdjustmentActivityParameters.LOCATION_ID, locationId.ToString()));

                // lblFilter.Text = filter;
                inventoryAdjustmentsActivityList = inventoryAdjustmentsActivityBL.GetInventoryAdjustmentsList(searchParameters);

                if (inventoryAdjustmentsActivityList != null)
                {
                    bindingSource.DataSource = inventoryAdjustmentsActivityList;
                }
                else
                {
                    bindingSource.DataSource = new List<InventoryProduct>();
                }

                dgv_activity.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
            }
        }

      
    }
}
