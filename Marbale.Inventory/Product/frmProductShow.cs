
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using Marble.Business;
using Marbale.BusinessObject.Inventory;
using Marbale.Business;
using Marbale.Inventory.Master;
using Marble.Business.InventoryBL;

namespace Marbale.Inventory.Product
{
    public partial class Frm_AddProduct : Form
    {
        //string scannedBarcode = "";
        //string filterText = "";

        frmLocation locationForm;
        frmCategory categoryform;
        frmTax frmPurchaseTax;
        frmUOM uomForm;
        frmVendor vendorForm;
        int loadProductId;
        string pmode = "";
       
        public Frm_AddProduct(int ProductId, string mode)
        {
            InitializeComponent();
            loadProductId = ProductId;
            //InitializeVariables();
            pmode = mode;
            btn_duplicate.Enabled = false;

        }

        void populateVendor()
        {
            VendorBL vendorBl = new VendorBL();
            List<KeyValuePair<Vendor.SearchByVendorParameters, string>> searchParameters = new List<KeyValuePair<Vendor.SearchByVendorParameters, string>>();
            searchParameters.Add(new KeyValuePair<Vendor.SearchByVendorParameters, string>(Vendor.SearchByVendorParameters.IS_ACTIVE, "1"));

            List<Vendor> lstVendor = vendorBl.GetVendorList(searchParameters);

            if (lstVendor == null)
                lstVendor = new List<Vendor>();
            BindingSource vendorBS = new BindingSource();

            lstVendor.Insert(0, new Vendor());
            cmb_Vendor.DataSource = lstVendor;
            cmb_Vendor.ValueMember = "VendorId";
            cmb_Vendor.DisplayMember = "VendorName";
        }

        void populateTax()
        {

            PurchaseTaxBL taxBL = new PurchaseTaxBL();
            List<KeyValuePair<PurchaseTax.SearchByTaxParameters, string>> taxSearchParams = new List<KeyValuePair<PurchaseTax.SearchByTaxParameters, string>>();
            taxSearchParams.Add(new KeyValuePair<PurchaseTax.SearchByTaxParameters, string>(PurchaseTax.SearchByTaxParameters.IS_ACTIVE, "1"));

            List<PurchaseTax> ListTax = taxBL.GetTaxList(taxSearchParams);


            if (ListTax == null)
            {
                ListTax = new List<PurchaseTax>();
            }
            BindingSource taxBS = new BindingSource();

            ListTax.Insert(0, new PurchaseTax());
            cmbTax.DataSource = ListTax;
            cmbTax.ValueMember = "TaxId";
            cmbTax.DisplayMember = "TaxName";
            cmbTax.SelectedIndex = 0;
        }

        void populateLocation()
        {
            LocationBL locationTypeBL = new LocationBL();
            List<Location> lstLocation = locationTypeBL.GetLocation();

            BindingSource locationBS = new BindingSource();
            //inBoundLocationDTOList = locationList.GetAllLocations("Store");
            if (lstLocation == null)
            {
                lstLocation = new List<Location>();
            }

            lstLocation.Insert(0, new Location());
            lstLocation[0].LocationName = "None";

            cmb_InboundLocation.DataSource = lstLocation;
            cmb_InboundLocation.ValueMember = "LocationId";
            cmb_InboundLocation.DisplayMember = "LocationName";


            cmb_OutboundLocation.DataSource = lstLocation;
            cmb_OutboundLocation.ValueMember = "LocationId";
            cmb_OutboundLocation.DisplayMember = "LocationName";
        }


        void populateCategory()
        {
            CategoryBL categoryBL = new CategoryBL();
            List<Category> lstCategory = categoryBL.GetCategory();

            if (lstCategory == null)
                lstCategory = new List<Category>();
            BindingSource lstCategoryBS = new BindingSource();

            lstCategory.Insert(0, new Category());
            cmb_category.DataSource = lstCategory;
            cmb_category.ValueMember = "categoryId";
            cmb_category.DisplayMember = "CategoryName";
        }

        void populateUOM()
        {
            UnitOfMeasureBL uomBL = new UnitOfMeasureBL();
            List<UnitOfMeasure> lstUom = uomBL.GetUom();

            BindingSource BSobj = new BindingSource();

            lstUom.Insert(0, new UnitOfMeasure());
            cmbUOM.DataSource = lstUom;
            cmbUOM.ValueMember = "uomId";
            cmbUOM.DisplayMember = "uomName";
        }
        private void frm_MaintainProducts_Load(object sender, EventArgs e)
        {
            populateCategory();
            populateUOM();
            populateVendor();
            populateTax();
            populateLocation();

            loadProduct(loadProductId);


            if (pmode == "duplicate")
            {
                btn_duplicate.Enabled = true;
                loadProductId = -1;
                lb_productid.Text = "";

                txtCode.ReadOnly = false;
            }



        }
        private void loadProduct(int pid)
        {
            InventoryProductBL inventoryProductBL = new InventoryProductBL();
            InventoryProduct inventoryProduct = new InventoryProduct();
            if (pid > 0)
            {
                inventoryProduct = inventoryProductBL.GetInventoryProduct(pid);
                txtCode.ReadOnly = true;
            }
            
            lb_productid.Text = inventoryProduct.ProductId.ToString();

            txtCode.Text = inventoryProduct.Code;

            cmbUOM.SelectedValue = inventoryProduct.UomId;
            cmbTax.SelectedValue = inventoryProduct.TaxId;
            cmb_InboundLocation.SelectedValue = inventoryProduct.DefaultLocationId;
            cmb_OutboundLocation.SelectedValue = inventoryProduct.OutboundLocationId;
            cmb_Vendor.SelectedValue = inventoryProduct.DefaultVendorId;
            chk_active.Checked = inventoryProduct.IsActive;
            chk_IsRedeemable.Checked = inventoryProduct.IsRedeemable;
            chk_IsSellable.Checked = inventoryProduct.IsSellable;
            //chkLotControlled.Checked = inventoryProduct.LotControlled;
            //chkLotControlled.Enabled = !inventoryProduct.LotControlled;
            cmbIssueApproach.Enabled = inventoryProduct.LotControlled;
            chk_Purchaseable.Checked = inventoryProduct.IsPurchaseable.Equals("Y");
            chkTaxInclusiveCost.Checked = (inventoryProduct.TaxInclusiveCost.Equals("Y"));
            txtReorderpoint.Text = inventoryProduct.ReorderPoint.ToString();
            tb_reorderquantity.Text = inventoryProduct.ReorderQuantity.ToString();
            txt_cost.Text = inventoryProduct.Cost.ToString();
            txt_SalePrice.Text = inventoryProduct.SalePrice.ToString();
            txt_InnerCostUnit.Text = inventoryProduct.InnerPackQty.ToString();

            //if (inventoryProduct.ExpiryType.Equals("N"))
            //    cmbExpiryType.Text = "None";
            //else if (inventoryProduct.ExpiryType.Equals("D"))
            //{
            //    cmbExpiryType.Text = "In Days";
            //    txtIndays.Text = inventoryProduct.ExpiryDays.ToString();
            //    txtIndays.Visible = true;
            //}
            //else if (inventoryProduct.ExpiryType.Equals("E"))
            //    cmbExpiryType.Text = "Expiry Date";

            cmbIssueApproach.Text = inventoryProduct.IssuingApproach;
            txtDescription.Text = inventoryProduct.Description;
            tb_remarks.Text = inventoryProduct.Remarks;
            cmb_category.SelectedValue = inventoryProduct.CategoryId;
            txt_LowerCostLimit.Text = inventoryProduct.LowerLimitCost.ToString();
            txt_UpperCostLimit.Text = inventoryProduct.UpperLimitCost.ToString();
            txt_Variance.Text = inventoryProduct.CostVariancePercentage.ToString();
            tb_lastpurchaseprice.Text = inventoryProduct.LastPurchasePrice.ToString();
            txt_pTicket.Text = inventoryProduct.PriceInTickets.ToString();
            tb_barcode.Text = inventoryProduct.BarCode;


        }
        //void populateProducts(List<Product> prodDTOList)
        //{
        //    ProductBL productBL = new ProductBL();
        //    List<Marbale.BusinessObject.Product> productList;

        //    productList = productBL.GetProducts();
        //    BindingSource productBS = new BindingSource();
        //    //if (prodDTOList == null)
        //    //    productListOnDisplay = productList.GetAllProducts(null);
        //    //else
        //    //{
        //    //    productListOnDisplay = prodDTOList;
        //    //}
        //    productBS.AddingNew += productBindingSource_AddingNew;

        //    //Semnox.Core.SortableBindingList.SortableBindingList<Product> sortProductDTOList;
        //    //if (productListOnDisplay == null)
        //    //{
        //    //    sortProductDTOList = new Semnox.Core.SortableBindingList.SortableBindingList<ProductDTO>();
        //    //}
        //    //else
        //    //{
        //    //    sortProductDTOList = new Semnox.Core.SortableBindingList.SortableBindingList<ProductDTO>(productListOnDisplay);
        //    //}
        //    productBS = new BindingSource();
        //    productBS.DataSource = productList;
        //    view_dgv.DataSource = productBS;
        //}




      
    
        private void cb_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb_pit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // This is to accept only numbers. 
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tb_reorderpoint_KeyPress(object sender, KeyPressEventArgs e)
        {
            // This is to accept only numbers. 
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tb_reorderquantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // This to accept only numbers. 
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

         

      

        private void ResetControls()
        {
            txtCode.Text = "";
            //tb_code.Enabled = true;
            txtDescription.Text = "";
            txtCode.Text = "";
            txt_cost.Text = "";
            txt_LowerCostLimit.Text = txt_UpperCostLimit.Text = txt_Variance.Text = "";
            txt_SalePrice.Text = "";
            tb_barcode.Text = "";
            tb_lastpurchaseprice.Text = "";
            txt_InnerCostUnit.Text = "1";
            txt_pTicket.Text = "";
            tb_remarks.Text = "";
            txtReorderpoint.Text = "";
            tb_reorderquantity.Text = "";
            lb_productid.Text = "";
            this.categoryBindingSource.ResetBindings(false);
            cmb_category.SelectedIndex = 0;
            cmb_InboundLocation.SelectedIndex = 0;
            cmb_Vendor.SelectedIndex = 0;
            cmb_OutboundLocation.SelectedIndex = 0;
            txt_InnerCostUnit.Text = "";
            cmbTax.SelectedIndex = 0;
            cmbUOM.SelectedIndex = 0;
            chk_active.Checked = false;
            chk_IsSellable.Checked = false;
            chk_IsRedeemable.Checked = false;
            //cmbExpiryType.Text = "";
            cmbIssueApproach.Text = "";
            chk_Purchaseable.Checked = false;
            chkTaxInclusiveCost.Checked = false;

            lb_productid.Tag = null;

        }

        

        bool saveProduct()
        {
            //for (int i = 0; i < redemptionDataSet.Product.Rows.Count; i++)
            //{
            //    if (redemptionDataSet.Product.Rows[i].RowState == DataRowState.Modified)
            //    {
            //        redemptionDataSet.Product.Rows[i]["lastModDttm"] = DateTime.Now;
            //        redemptionDataSet.Product.Rows[i]["lastModUserId"] = CommonFuncs.ParafaitEnv.LoginID;
            //    }
            //}

            //try
            //{
            //    this.productTableAdapter.Update(this.redemptionDataSet.Product);
            //    CommonFuncs.setSiteIdFilter(productBindingSource);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    return false;
            //}
            //CommonFuncs.displayInfo("Product Saved Successfully");
            return true;
        }

        private void cb_update_Click(object sender, EventArgs e)
        {
            

 
            try
            {
                
                if (ProductSave())
                {


                    ResetControls();
                    MessageBox.Show("Product Saved Successfully");
                }
                else
                {
                    return;
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Failed to save database");
                return;
            }

           
        }
        private bool SaveInventoryStore(InventoryProduct inventoryProduct)
        {
            InventoryStoreBL inventoryProductBL = new InventoryStoreBL();
            InventoryStore inventoryStore = new InventoryStore()
            {
                ProductId = inventoryProduct.ProductId,
                LocationId = inventoryProduct.DefaultLocationId,
                IsActive = true,
                Quantity = 1
            };
            inventoryProductBL.Save(inventoryStore, "rakshith");
            return true;
        }
        
        private bool ProductSave()
        {

            if (txtCode.Text == "")
            {
                MessageBox.Show("Please enter the Code");
                txtCode.Focus();
                return false;

            }

            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Please enter the Description");
                txtDescription.Focus();
                return false;
            }


            if (cmb_category.SelectedValue == null || (int)cmb_category.SelectedValue == -1)
            {
                MessageBox.Show("Please select the Category");
                cmb_category.Focus();
                return false;
            }

            if (cmbUOM.SelectedValue == null || (int)cmbUOM.SelectedValue == -1)
            {
                MessageBox.Show("Please select the UOM");
                cmbUOM.Focus();
                return false;
            }

            if (cmb_InboundLocation.SelectedValue == null || (int)cmb_InboundLocation.SelectedValue == -1)
            {
                MessageBox.Show("Please select the Inbound Location");
                cmb_InboundLocation.Focus();
                return false;
            }
            if (cmb_OutboundLocation.SelectedValue == null || (int)cmb_OutboundLocation.SelectedValue == -1)
            {
                MessageBox.Show("Please select the Outbound Location");
                cmb_OutboundLocation.Focus();
                return false;
            }


            try
            {

                bool isNewProduct = string.IsNullOrEmpty(lb_productid.Text) ? true : false;
                InventoryProduct inventoryProduct = new InventoryProduct();
                if (!string.IsNullOrEmpty(lb_productid.Text))
                    inventoryProduct.ProductId = Convert.ToInt32(lb_productid.Text);

                inventoryProduct.Code = txtCode.Text;
                inventoryProduct.Description = txtDescription.Text;
                inventoryProduct.ProductName = txtDescription.Text;

                inventoryProduct.CategoryId = Convert.ToInt32(cmb_category.SelectedValue);
                //barcode
                inventoryProduct.UomId = Convert.ToInt32(cmbUOM.SelectedValue);

                inventoryProduct.DefaultLocationId = Convert.ToInt32(cmb_InboundLocation.SelectedValue);
                inventoryProduct.OutboundLocationId = Convert.ToInt32(cmb_OutboundLocation.SelectedValue);


                if (!string.IsNullOrEmpty(txtReorderpoint.Text))
                    inventoryProduct.ReorderPoint = Convert.ToDouble(txtReorderpoint.Text);
                inventoryProduct.TaxId = Convert.ToInt32(cmbTax.SelectedValue);
                if (!string.IsNullOrEmpty(tb_reorderquantity.Text))
                    inventoryProduct.ReorderQuantity = Convert.ToDouble(tb_reorderquantity.Text);
                if (!string.IsNullOrEmpty(txt_pTicket.Text))
                    inventoryProduct.PriceInTickets = Convert.ToDouble(txt_pTicket.Text);

                //Issueing apporach Pending
                inventoryProduct.DefaultVendorId = Convert.ToInt32(cmb_Vendor.SelectedValue);

                if (chk_active.Checked)
                    inventoryProduct.IsActive = true;
                else
                    inventoryProduct.IsActive = false;

                if (chk_IsRedeemable.Checked)
                    inventoryProduct.IsRedeemable = true;
                else
                    inventoryProduct.IsRedeemable = false;

                if (chk_IsSellable.Checked)
                    inventoryProduct.IsSellable = true;
                else
                    inventoryProduct.IsSellable = true;

                if (chk_Purchaseable.Checked)
                    inventoryProduct.IsPurchaseable = true;
                else
                    inventoryProduct.IsPurchaseable = true;

                if (!string.IsNullOrEmpty(txt_InnerCostUnit.Text))
                    inventoryProduct.InnerPackQty = Convert.ToDouble(txt_InnerCostUnit.Text);
                if (!string.IsNullOrEmpty(txt_LowerCostLimit.Text))
                    inventoryProduct.LowerLimitCost = Convert.ToDouble(txt_LowerCostLimit.Text);

                if (!string.IsNullOrEmpty(txt_Variance.Text))
                    inventoryProduct.CostVariancePercentage = Convert.ToDouble(txt_Variance.Text);
                if (!string.IsNullOrEmpty(txt_SalePrice.Text))
                    inventoryProduct.SalePrice = Convert.ToDouble(txt_SalePrice.Text);

                if (!string.IsNullOrEmpty(txt_cost.Text))
                    inventoryProduct.Cost = Convert.ToDouble(txt_cost.Text);

                if (!string.IsNullOrEmpty(txt_UpperCostLimit.Text))
                    inventoryProduct.UpperLimitCost = Convert.ToDouble(txt_UpperCostLimit.Text);

                InventoryProductBL inventoryProductBL = new InventoryProductBL();
                int id = inventoryProductBL.Save(inventoryProduct, "rakshith");
                inventoryProduct.ProductId = id;
                if (isNewProduct)
                {
                    SaveInventoryStore(inventoryProduct);
                }
                if (id > 0)
                {


                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return false;
            }
        }
      
        
        private void cb_addcategory_Click(object sender, EventArgs e)
        {
            categoryform = new frmCategory();
            categoryform.StartPosition = FormStartPosition.CenterScreen;
            categoryform.ShowDialog();
            populateCategory();
            cmb_category.SelectedIndex = -1;
        }

        private void cb_addlocation_Click(object sender, EventArgs e)
        {
            frmLocation frmlocation = new frmLocation();

            frmlocation.StartPosition = FormStartPosition.CenterScreen;//Added for showing in center on 23-Aug-2016
            frmlocation.ShowDialog();
            populateLocation();
            cmb_InboundLocation.SelectedIndex = -1;
        }

        private void cb_addvendor_Click(object sender, EventArgs e)
        {
            frmVendor fVendor = new frmVendor();

            fVendor.StartPosition = FormStartPosition.CenterScreen;//Added for showing in center on 23-Aug-2016
            fVendor.ShowDialog();
            populateVendor();
            cmb_Vendor.SelectedIndex = -1;
        }

       

        

        private void cb_duplicate_Click(object sender, EventArgs e)
        {
            loadProductId = -1;
            lb_productid.Text = "";
        }

        private void frm_MaintainProducts_Activated(object sender, EventArgs e)
        {
             
        }

        


        private void cb_preferredvendor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void tb_SalePrice_Validating(object sender, CancelEventArgs e)
        {
            //try
            //{
            //    double val = 0;
            //    if (tb_SalePrice.Text.Trim() != "")
            //        val = Convert.ToDouble(tb_SalePrice.Text);
            //    if (val < 0)
            //    {
            //        tb_SalePrice.BackColor = Color.Yellow;
            //        lbl_error_sale_price.Visible = true;
            //        e.Cancel = true;
            //    }
            //    else
            //    {
            //        tb_SalePrice.BackColor = Color.White;
            //        lbl_error_sale_price.Visible = false;
            //    }
            //}
            //catch
            //{
            //    tb_SalePrice.BackColor = Color.Yellow;
            //    lbl_error_sale_price.Visible = true;
            //    e.Cancel = true;
            //}
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAddTax_Click(object sender, EventArgs e)
        {
            frmTax fTax = new frmTax();
            fTax.StartPosition = FormStartPosition.CenterScreen;
            fTax.ShowDialog();
            populateTax();
            cmbTax.SelectedIndex = -1;
        }

        private void view_dgv_SelectionChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (FireSelectionChanged)
            //    {
            //        if (view_dgv.SelectedRows.Count > 0)
            //        {
            //            if (view_dgv.SelectedRows[0].Cells["codeDataGridViewTextBoxColumn"].Value != DBNull.Value)
            //            {

            //                LoadProductFromDGV(view_dgv.SelectedRows[0].Index);
            //                //transferValues(view_dgv.SelectedRows[0].Index);
            //                BOM_Load(Convert.ToInt32(view_dgv.SelectedRows[0].Cells["productIdDataGridViewTextBoxColumn"].Value));
            //            }
            //        }
            //        else
            //        {
            //            emptyAllFields();
            //            BOM_Load(-1);
            //        }
            //    }
            //}
            //catch
            //{

            //}
        }

        private void btnAddUOM_Click(object sender, EventArgs e)
        {
            frmUOM frmUOM = new frmUOM();
            frmUOM.StartPosition = FormStartPosition.CenterScreen;
            frmUOM.ShowDialog();
            populateUOM();
            cmbUOM.SelectedIndex = -1;
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            if (loadProductId <= 0)
            {
                ResetControls();
            }
            else
            {
                //loadProduct(loadProductId);
            }
        }


        
    }
}

