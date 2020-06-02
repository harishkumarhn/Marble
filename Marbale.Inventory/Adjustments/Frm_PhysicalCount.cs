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
    public partial class Frm_PhysicalCount : Form
    {
        private string status = "";
        private string PhyscicalDescription = "";
        private int physicalCountId=0;
        public Frm_PhysicalCount()
        {
            InitializeComponent();
        }
        private void Frm_PhysicalCount_Load(object sender, EventArgs e)
        {
            loadOpenStatus();
            PopulateProductGrid();
            LoadLocationCombobox();
        }
        void LoadLocationCombobox()
        {
            LocationBL locationTypeBL = new LocationBL();
            List<Location> lstLocation = locationTypeBL.GetLocation();
            BindingSource locationBS = new BindingSource();
            if (lstLocation == null)
            {
                lstLocation = new List<Location>();
            }

            lstLocation.Insert(0, new Location());
            lstLocation[0].LocationName = "None";
            drp_Location.DataSource = lstLocation;
            drp_Location.DisplayMember = "LocationName";
            drp_Location.ValueMember = "LocationId";

            
        }

        public void loadOpenStatus()
        {
            InventoryPhysicalCountBL inventoryPhysicalCountBL = new InventoryPhysicalCountBL();
            InventoryPhysicalCount inventoryPhysicalCount = inventoryPhysicalCountBL.GetInventoryPhysicalCount("Open");

            if(inventoryPhysicalCount!=null && inventoryPhysicalCount.Id>0)
            {
                btn_initaiate.Text = "Close Count Process";
                status = "open";

                physicalCountId = inventoryPhysicalCount.Id;

            }
            else
            {
                btn_initaiate.Text = "Open Count Process";
               
                status = "closed";
            }
        }

        void PopulateProductGrid()
        {
            //lblFilter.Text = string.Empty;

            BindingSource productListBS = new BindingSource();
            InventoryProductBL productBL = new InventoryProductBL();
            List<InventoryProduct> productList;

            List<KeyValuePair<InventoryProduct.SearchByProductParameters, string>> searchParameters = new List<KeyValuePair<InventoryProduct.SearchByProductParameters, string>>();
            searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.IS_ACTIVE, "1"));

            if (!string.IsNullOrEmpty(txt_PCode.Text))
            {
                searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.PRODUCT_CODE, txt_PCode.Text));
            }
            if (!string.IsNullOrEmpty(txt_Description.Text))
            {
                searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.DESCRIPTION, txt_Description.Text));
            }
            if (drp_Location.SelectedIndex > 0)
            {
                //search location
                searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.DEFAULT_LOCATION, drp_Location.SelectedValue.ToString()));
            }
            //if (!string.IsNullOrEmpty(txt_Description.Text))
            //{
            //    searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.PRODUCT_NAME, txt_Description.Text));
            //}
            // lblFilter.Text = filter;
            productList = productBL.GetInventoryProductListWithStoreData(searchParameters);

            if (productList != null)
            {
                productListBS.DataSource = productList;
            }
            else
            {
                productListBS.DataSource = new List<InventoryProduct>();
            }

            dgv_Products.DataSource = productListBS;
        }

        private void btn_initaiate_Click(object sender, EventArgs e)
        {
            if(status=="open")
            {

                if (MessageBox.Show("Do you want to close physical count?", "Physical Count ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    InventoryPhysicalCountLogBL inventoryPhysicalCountLogBL = new InventoryPhysicalCountLogBL();

                    inventoryPhysicalCountLogBL.InsertInventoryPhysicalCountLogByID(physicalCountId, "rakshih");
                    //
                    InventoryPhysicalCountBL inventoryPhysicalCountBL = new InventoryPhysicalCountBL();
                    InventoryPhysicalCount inventoryPhysicalCount = inventoryPhysicalCountBL.GetInventoryPhysicalCount("Open");

                    if (inventoryPhysicalCount != null && inventoryPhysicalCount.Id > 0)
                    {
                        inventoryPhysicalCount.Status = "Closed";
                        inventoryPhysicalCount.ClosedBy = "rakshith";
                        inventoryPhysicalCount.ClosedDate = DateTime.Now;
                        inventoryPhysicalCountBL.Save(inventoryPhysicalCount, "rakshith");

                    }

                    loadOpenStatus();
                }
                else
                {

                }
                   


            }
            else if (status =="closed")
            {
                Frm_PhysicalCountPopup frm_PhysicalCountPopup = new Frm_PhysicalCountPopup();

                frm_PhysicalCountPopup.ShowDialog();

                loadOpenStatus();
            }
        }

        private void btnAdjust_Click(object sender, EventArgs e)
        {
            bool saved = false;
            try
            {


                InventoryStoreBL inventoryStoreBL = new InventoryStoreBL();
                for (int i = 0; i < dgv_Products.RowCount; i++)
                {
                    //if (dgv_Products["chkSelectItem", i].Value != null && Convert.ToBoolean(dgv_Products["chkSelectItem", i].Value) == true)
                    //{

                    //if (Convert.ToInt32(dgv_Products["storeLocationIdDgvColumn", i].Value) <= 0)
                    //    continue;

                    if (dgv_Products["txt_newQuantity", i].Value == null 
                        ||  string.IsNullOrEmpty (dgv_Products["txt_newQuantity", i].Value.ToString() ) )
                    {
                        continue;
                    }

                    InventoryStore inventoryStore = new InventoryStore();
                    //inventoryStore.LocationId = Convert.ToInt32(cmb_TransferLocation.SelectedValue);
                    inventoryStore.ProductId = Convert.ToInt32(dgv_Products["productIdDataGridViewTextBoxColumn", i].Value);
                    inventoryStore.Quantity = Convert.ToInt32(dgv_Products["txt_newQuantity", i].Value);
                    inventoryStore.LocationId = Convert.ToInt32(dgv_Products["defaultLocationIdDataGridViewTextBoxColumn", i].Value);
                    InventoryStore termpInventoryStore = inventoryStoreBL.GetInventoryStore(inventoryStore.ProductId, inventoryStore.LocationId);
                    if (termpInventoryStore != null && termpInventoryStore.Id > 0)
                    {
                        inventoryStoreBL.UpdateInventoryStoreOnAdjustment(inventoryStore, "Rakshith");
                    }

                    InventoryAdjustments inventoryAdjustments = new InventoryAdjustments()
                    {
                        ProductId = Convert.ToInt32(dgv_Products["productIdDataGridViewTextBoxColumn", i].Value),
                        AdjustmentQuantity = Convert.ToInt32(dgv_Products["txt_newQuantity", i].Value),
                        Remarks = dgv_Products["txt_Remarks", i].Value==null ? "": dgv_Products["txt_Remarks", i].Value.ToString(),
                        AdjustmentType = "Adjustment",
                        FromLocationId = Convert.ToInt32(dgv_Products["defaultLocationIdDataGridViewTextBoxColumn", i].Value),
                        ToLocationId = Convert.ToInt32(dgv_Products["defaultLocationIdDataGridViewTextBoxColumn", i].Value)
                    };

                    InventoryAdjustmentsBL inventoryAdjustmentsBL = new InventoryAdjustmentsBL();
                       inventoryAdjustmentsBL.Save(inventoryAdjustments, "Rakshith");
                        saved = true;
                  //  }
                }
            }
            catch (Exception ex)
            {
                saved = false;
            }
            if (saved)
            {
                MessageBox.Show("Products are adjsuted");
                 PopulateProductGrid();
            }
            else
            {
                 MessageBox.Show("Failed to save.");
            }
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            txt_PCode.Text = "";
            txt_Description.Text = "";
            txt_Barcode.Text = "";
            chk_Purchaseable.Checked = true;
            PopulateProductGrid();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            PopulateProductGrid();
        }

        private void btn_Download_Click(object sender, EventArgs e)
        {

        }

        private void btn_upload_Click(object sender, EventArgs e)
        {

        }
    }
}
