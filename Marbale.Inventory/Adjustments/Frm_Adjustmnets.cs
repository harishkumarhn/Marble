using Marbale.BusinessObject.Inventory;
using Marbale.BusinessObject.SiteSetup;
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
    public partial class Frm_Adjustmnets : Form
    {
        public Frm_Adjustmnets()
        {
            InitializeComponent();
        }
        private void Frm_Adjustmnets_Load(object sender, EventArgs e)
        {
            PopulateProductGrid();
            LoadLocationCombobox();
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
                searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.PRODUCT_NAME, txt_Description.Text));
            }
            if (drp_Location.SelectedIndex > 0)
            {
                //search location
                //searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.PRODUCT_NAME, txt_Description.Text));
            }
            if (!string.IsNullOrEmpty(txt_Description.Text))
            {
                searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.PRODUCT_NAME, txt_Description.Text));
            }
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


        void LoadLocationCombobox()
        {
            LocationBL locationTypeBL = new LocationBL();
            List<Location> lstLocation = locationTypeBL.GetLocation();
            BindingSource locationBS = new BindingSource();
            BindingSource locationBS1 = new BindingSource();
            BindingSource locationBS2= new BindingSource();
            if (lstLocation == null)
            {
                lstLocation = new List<Location>();
            }

            lstLocation.Insert(0, new Location());
            lstLocation[0].LocationName = "None";
            locationBS.DataSource = lstLocation;
            locationBS1.DataSource = lstLocation;
            locationBS2.DataSource = lstLocation;

            drp_Location.DataSource = locationBS1;
            drp_Location.DisplayMember = "LocationName";
            drp_Location.ValueMember = "LocationId";

            storeLocationIdDgvColumn.DataSource = locationBS1;
            storeLocationIdDgvColumn.DisplayMember = "LocationName";
            storeLocationIdDgvColumn.ValueMember = "LocationId";

            cmb_TransferLocation.DataSource = locationBS2;
            cmb_TransferLocation.DisplayMember = "LocationName";
            cmb_TransferLocation.ValueMember = "LocationId";
        }

        private void ResetTransfer()
        {
            rb_FromLocation.Checked = false;
            rb_ToLocation.Checked = false;
            txtTransferRemarks.Text = "";
            cmb_TransferLocation.SelectedIndex = 0;
        }
        private void ResetAdjustments()
        {
            txt_AdjQty.Value=0;
            txtAdjRemarks.Text = "";
        }
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            //Update inventory


            if (cmb_TransferLocation.SelectedIndex < 0 || (int)cmb_TransferLocation.SelectedValue < 0)
            {
                MessageBox.Show("Please select Location");
                cmb_TransferLocation.Focus();
                return;
            }

            double userTransferQty = 0;
            int TransferLocationId = Convert.ToInt32(cmb_TransferLocation.SelectedValue);

            bool saved = false;
            try
            {
                InventoryStoreBL inventoryStoreBL = new InventoryStoreBL();
                for (int i = 0; i < dgv_Products.RowCount; i++)
                {
                    if (dgv_Products["chkSelectItem", i].Value != null && Convert.ToBoolean(dgv_Products["chkSelectItem", i].Value) == true)
                    {

                        if (TransferLocationId == Convert.ToInt32(dgv_Products["storeLocationIdDgvColumn", i].Value))
                            continue;


                        InventoryStore inventoryStore = new InventoryStore();
                        InventoryStore inventoryStore1 = new InventoryStore();


                        //{
                        //    Quantity = Convert.ToUInt32(dgv_Products["txt_TQuantity", i].Value)
                        //};

                        //InventoryStore inventoryStore1 = new InventoryStore()
                        //{
                        //    Quantity = Convert.ToUInt32(dgv_Products["txt_TQuantity", i].Value) * (-1)
                        //};

                        InventoryAdjustments inventoryAdjustments = new InventoryAdjustments()
                        {
                            ProductId = Convert.ToInt32(dgv_Products["productIdColumn", i].Value),
                            AdjustmentQuantity = Convert.ToInt32(dgv_Products["txt_TQuantity", i].Value),
                            Remarks = txtTransferRemarks.Text,
                            AdjustmentType = "Transfer"

                        };
                        inventoryStore.ProductId = Convert.ToInt32(dgv_Products["productIdColumn", i].Value);
                        inventoryStore1.ProductId = Convert.ToInt32(dgv_Products["productIdColumn", i].Value);

                        if (rb_FromLocation.Checked)
                        {

                            //group box to grid
                            //check 1 ob
                            inventoryStore.LocationId = Convert.ToInt32(cmb_TransferLocation.SelectedValue);
                            inventoryStore.Quantity = Convert.ToInt32(dgv_Products["txt_TQuantity", i].Value);

                            inventoryStore1.LocationId = Convert.ToInt32(dgv_Products["storeLocationIdDgvColumn", i].Value);
                            inventoryStore1.Quantity = Convert.ToInt32(dgv_Products["txt_TQuantity", i].Value) * -1;

                            inventoryAdjustments.FromLocationId = Convert.ToInt32(cmb_TransferLocation.SelectedValue);
                            inventoryAdjustments.ToLocationId = Convert.ToInt32(dgv_Products["storeLocationIdDgvColumn", i].Value);


                            InventoryStore termpInventoryStore = inventoryStoreBL.GetInventoryStore(inventoryStore.ProductId, inventoryStore.LocationId);
                            if (termpInventoryStore != null && termpInventoryStore.Id > 0)
                            {

                                inventoryStoreBL.UpdateInventoryStoreOnAdjustment(inventoryStore, LogedInUser.LoginId);

                            }
                            else
                            {
                                inventoryStoreBL.Save(inventoryStore, LogedInUser.LoginId);
                            }
                            inventoryStoreBL.UpdateInventoryStoreOnAdjustment(inventoryStore1, LogedInUser.LoginId);


                        }
                        else if (rb_ToLocation.Checked)
                        {

                            //grid to group box
                            //check 1 ob
                            inventoryStore.LocationId = Convert.ToInt32(dgv_Products["storeLocationIdDgvColumn", i].Value);
                            inventoryStore.Quantity = Convert.ToInt32(dgv_Products["txt_TQuantity", i].Value) * -1;

                            inventoryStore1.LocationId = Convert.ToInt32(cmb_TransferLocation.SelectedValue);
                            inventoryStore1.Quantity = Convert.ToInt32(dgv_Products["txt_TQuantity", i].Value);


                            inventoryAdjustments.ToLocationId = Convert.ToInt32(cmb_TransferLocation.SelectedValue);
                            inventoryAdjustments.FromLocationId = Convert.ToInt32(dgv_Products["storeLocationIdDgvColumn", i].Value);



                            InventoryStore termpInventoryStore = inventoryStoreBL.GetInventoryStore(inventoryStore1.ProductId, inventoryStore1.LocationId);
                            if (termpInventoryStore != null && termpInventoryStore.Id > 0)
                            {

                                inventoryStoreBL.UpdateInventoryStoreOnAdjustment(inventoryStore1, LogedInUser.LoginId);

                            }
                            else
                            {
                                inventoryStoreBL.Save(inventoryStore1, LogedInUser.LoginId);
                            }
                            inventoryStoreBL.UpdateInventoryStoreOnAdjustment(inventoryStore, LogedInUser.LoginId);

                        }




                        InventoryAdjustmentsBL inventoryAdjustmentsBL = new InventoryAdjustmentsBL();
                        inventoryAdjustmentsBL.Save(inventoryAdjustments, LogedInUser.LoginId);
                        saved = true;
                    }


                }
            }
            catch (Exception ex)
            {
                saved = false;

            }

            if (saved)
            {
                MessageBox.Show("Saved successfully");
                ResetTransfer();
                PopulateProductGrid();
            }
            else
            {
                MessageBox.Show("Failed to save.");
            }

            //insert adjustments

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            PopulateProductGrid();
        }

        private void dgv_Products_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgv_Products.Columns[e.ColumnIndex].Name == "lnkAvail_Quantity")
            {
                try
                {
                    Form_InventoryStoreActivity frmAct = new Form_InventoryStoreActivity((int)dgv_Products["productIdColumn", e.RowIndex].Value, (int)dgv_Products["storeLocationIdDgvColumn", e.RowIndex].Value);
                    //f.Text = "Activities for Product: " + dgvProducts["Code", e.RowIndex].FormattedValue.ToString() +
                    //        " and Location: " + dgvProducts["location_name", e.RowIndex].FormattedValue.ToString();
                    //CommonDisplay.setupVisuals(f); 
                    frmAct.StartPosition = FormStartPosition.CenterScreen;
                    frmAct.ShowDialog();
                }
                catch { }
            }

            //if (dgv_Products.Columns[e.ColumnIndex].Name == "TransferQuantity")
            //{
            //    if (dgv_Products["txt_TQuantity", e.RowIndex].Value == null || dgv_Products["txt_TQuantity", e.RowIndex].Value == DBNull.Value  )
            //    {
            //    }
            //}
        }

        private void dgv_Products_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_Products_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                if (dgv_Products.Columns[e.ColumnIndex].Name == "txt_TQuantity")
                {
                    if (dgv_Products["txt_TQuantity", e.RowIndex].Value == null || dgv_Products["txt_TQuantity", e.RowIndex].Value == DBNull.Value)
                    {
                        dgv_Products["chkSelectItem", e.RowIndex].Value = false;
                        return;
                    }

                    try
                    {
                        double userTransferQty = Convert.ToDouble(dgv_Products["txt_TQuantity", e.RowIndex].Value);
                        if (userTransferQty > 0)
                        {
                            dgv_Products["chkSelectItem", e.RowIndex].Value = true;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch { }
        }

        private void btnAdjust_Click(object sender, EventArgs e)
        {

            bool saved = false;
            try
            {


                InventoryStoreBL inventoryStoreBL = new InventoryStoreBL();
                for (int i = 0; i < dgv_Products.RowCount; i++)
                {
                    if (dgv_Products["chkSelectItem", i].Value != null && Convert.ToBoolean(dgv_Products["chkSelectItem", i].Value) == true)
                    {

                        if (Convert.ToInt32(dgv_Products["storeLocationIdDgvColumn", i].Value) <= 0)
                            continue;


                        InventoryStore inventoryStore = new InventoryStore();
                        //inventoryStore.LocationId = Convert.ToInt32(cmb_TransferLocation.SelectedValue);
                        inventoryStore.ProductId = Convert.ToInt32(dgv_Products["productIdColumn", i].Value);
                        inventoryStore.Quantity = Convert.ToInt32(txt_AdjQty.Value);
                        inventoryStore.LocationId = Convert.ToInt32(dgv_Products["storeLocationIdDgvColumn", i].Value);
                        InventoryStore termpInventoryStore = inventoryStoreBL.GetInventoryStore(inventoryStore.ProductId, inventoryStore.LocationId);
                        if (termpInventoryStore != null && termpInventoryStore.Id > 0)
                        {
                            inventoryStoreBL.UpdateInventoryStoreOnAdjustment(inventoryStore, LogedInUser.LoginId);
                        }

                        InventoryAdjustments inventoryAdjustments = new InventoryAdjustments()
                        {
                            ProductId = Convert.ToInt32(dgv_Products["productIdColumn", i].Value),
                            AdjustmentQuantity = Convert.ToInt32(dgv_Products["txt_TQuantity", i].Value),
                            Remarks = txtAdjRemarks.Text,
                            AdjustmentType = "Adjustment",
                            FromLocationId = Convert.ToInt32(dgv_Products["storeLocationIdDgvColumn", i].Value),
                            ToLocationId = Convert.ToInt32(dgv_Products["storeLocationIdDgvColumn", i].Value)
                        };

                        InventoryAdjustmentsBL inventoryAdjustmentsBL = new InventoryAdjustmentsBL();
                        inventoryAdjustmentsBL.Save(inventoryAdjustments, LogedInUser.LoginId);
                        saved = true;
                    }
                }
            }
            catch (Exception ex)
            {
                saved = false;
            }
            if (saved)
            {
                MessageBox.Show("Saved successfully");
                ResetAdjustments();
                PopulateProductGrid();
            }
            else
            {
                MessageBox.Show("Failed to save.");
            }
        }

    }
}
