
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
        //Semnox.Core.Logger log = new Semnox.Core.Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        int loadProductId;
        //string imageFolder = CommonFuncs.Utilities.getParafaitDefaults("IMAGE_DIRECTORY");
        //ProductDTO productDTO = new ProductDTO();
        //Semnox.Parafait.Context.ExecutionContext machineUserContext = Semnox.Parafait.Context.ExecutionContext.GetExecutionContext();
        public Frm_AddProduct(int ProductId)
        {
            InitializeComponent();
            loadProductId = ProductId;
            //InitializeVariables();

            //if (CommonFuncs.Utilities.ParafaitEnv.IsCorporate)
            //{
            //    machineUserContext.SetSiteId(CommonFuncs.Utilities.ParafaitEnv.SiteId);
            //}
            //else
            //{
            //    machineUserContext.SetSiteId(-1);
            //}
            //machineUserContext.SetUserId(CommonFuncs.Utilities.ParafaitEnv.LoginID);
            //if (CommonFuncs.Utilities.ParafaitEnv.IsCorporate && CommonFuncs.Utilities.ParafaitEnv.IsMasterSite)
            //{
            //    lnkPublishToSite.Visible = true;
            //}
            //else
            //{
            //    lnkPublishToSite.Visible = false;
            //}
            //CommonFuncs.Utilities.setLanguage(this);bbb
            //{
            //UnitOfMeasureBL uomBL = new UnitOfMeasureBL();
            //List<UnitOfMeasure> lstUom = uomBL.GetUom();

            //if (lstUom == null)
            //    lstUom = new List<UnitOfMeasure>();
            //BindingSource uomBS = new BindingSource();

            //lstUom.Insert(0, new UnitOfMeasure());
            //cmbUOM.DataSource = lstUom;
            //cmbUOM.ValueMember = "UOMId";
            //cmbUOM.DisplayMember = "UOM";
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
            cmb_Vendor.DisplayMember = "Name";
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

            //List<KeyValuePair<LocationDTO.SearchByLocationParameters, string>> locationDTOSearchParams;
            //locationDTOSearchParams = new List<KeyValuePair<LocationDTO.SearchByLocationParameters, string>>();

            lstLocation.Insert(0, new Location());
            lstLocation[0].LocationName = "None";


            cmb_InboundLocation.DataSource = lstLocation;
            cmb_InboundLocation.ValueMember = "LocationId";
            cmb_InboundLocation.DisplayMember = "LocationName";


            ///Check rakshith
            //inBoundLocationDTOList = locationList.GetAllLocations("Store, Department");
            //if (inBoundLocationDTOList == null)
            //{
            //    inBoundLocationDTOList = new List<LocationDTO>();
            //}
            //inBoundLocationDTOList.Insert(0, new LocationDTO());
            //inBoundLocationDTOList[0].Name = "None";
            cmb_OutboundLocation.DataSource = lstLocation;
            cmb_OutboundLocation.ValueMember = "LocationId";
            cmb_OutboundLocation.DisplayMember = "Name";
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

            //cb_category.SelectedIndex = -1;
            //cb_defaultlocation.SelectedIndex = -1;
            //cb_preferredvendor.SelectedIndex = -1;
            //cbOutboundLocation.SelectedIndex = -1;
            //cmbTax.SelectedIndex = -1;
            //cmbUOM.SelectedIndex = -1;
            ////btnSKUSegments.Tag = -1;
            ////btnCustom.Tag = -1;
            //emptyAllFields();
            //if (view_dgv.Rows.Count != 0)
            //    LoadProductFromDGV(0);
            ////transferValues(0);
            //else
            //{
            //    cmbExpiryType.Enabled = false;
            //    cmbIssueApproach.Enabled = false;
            //}
        }
        private void loadProduct(int pid)
        {
            InventoryProductBL inventoryProductBL = new InventoryProductBL();
            InventoryProduct inventoryProduct = inventoryProductBL.GetInventoryProduct(pid);

            lb_productid.Text = inventoryProduct.ProductId.ToString();

            txtCode.Text = inventoryProduct.Code;
            txtCode.ReadOnly = true;
            cmbUOM.SelectedValue = inventoryProduct.UomId;
            cmbTax.SelectedValue = inventoryProduct.TaxId;
            cmb_InboundLocation.SelectedValue = inventoryProduct.DefaultLocationId;
            cmb_OutboundLocation.SelectedValue = inventoryProduct.OutboundLocationId;
            cmb_Vendor.SelectedValue = inventoryProduct.DefaultVendorId;
            chk_active.Checked = inventoryProduct.IsActive;
            chk_IsRedeemable.Checked = inventoryProduct.IsRedeemable;
            chk_IsSellable.Checked = inventoryProduct.IsSellable;
            chkLotControlled.Checked = inventoryProduct.LotControlled;
            chkLotControlled.Enabled = !inventoryProduct.LotControlled;
            cmbIssueApproach.Enabled = inventoryProduct.LotControlled; //Added 21-Feb-2017
            chk_Purchaseable.Checked = inventoryProduct.IsPurchaseable.Equals("Y");
            chkTaxInclusiveCost.Checked = (inventoryProduct.TaxInclusiveCost.Equals("Y"));
            txtReorderpoint.Text = inventoryProduct.ReorderPoint.ToString();
            tb_reorderquantity.Text = inventoryProduct.ReorderQuantity.ToString();
            tb_cost.Text = inventoryProduct.Cost.ToString();
            tb_SalePrice.Text = inventoryProduct.SalePrice.ToString();
            txtInnerPackQty.Text = inventoryProduct.InnerPackQty.ToString();

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
            txtLowerCostLimit.Text = inventoryProduct.LowerLimitCost.ToString();
            txtUpperCostLimit.Text = inventoryProduct.UpperLimitCost.ToString();
            txtCostVariancePer.Text = inventoryProduct.CostVariancePercentage.ToString();
            tb_lastpurchaseprice.Text = inventoryProduct.LastPurchasePrice.ToString();
            tb_pit.Text = inventoryProduct.PriceInTickets.ToString();
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




        bool FireSelectionChanged = true;
        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            // cb_update.Enabled = true;
            //// filterText = "";
            // int count = 0;
            // FireSelectionChanged = false;
            // try
            // {

            //     if (productCodeToolStripTextBox.Text.Replace("%", "").Trim() != "")
            //     {
            //         filterText += "code like '%" + productCodeToolStripTextBox.Text + "%'";
            //         count++;
            //     }

            //     string condition = "";

            //     if (cmbProductType.SelectedIndex == 1)
            //     {
            //         filterText += ((count > 0) ? " And " : " ") + "isRedeemable = 'Y'";
            //         count++;
            //     }

            //     else if (cmbProductType.SelectedIndex == 2)
            //     {
            //         filterText += ((count > 0) ? " And " : " ") + "isSellable = 'Y'";
            //         count++;
            //     }
            //     if (cmbActive.SelectedIndex == 1)
            //     {
            //         filterText += ((count > 0) ? " And " : " ") + "isActive = 'Y'";
            //         count++;
            //     }
            //     else if (cmbActive.SelectedIndex == 2)
            //     {
            //         filterText += ((count > 0) ? " And " : " ") + "isActive = 'N'";
            //         count++;
            //     }

            //     if (cmbCategory.SelectedIndex > 0)
            //     {
            //         SqlCommand cmd = CommonFuncs.Utilities.getCommand();
            //         if (CommonFuncs.ParafaitEnv.IsCorporate)
            //         {
            //             condition = "  and (site_id = @siteId or @siteId = -1)";
            //             cmd.Parameters.AddWithValue("@siteId", CommonFuncs.getSiteid());
            //         }
            //         cmd.CommandText = "select top 1 categoryId from category where name = @name " + condition;
            //         cmd.Parameters.AddWithValue("@name", cmbCategory.SelectedItem);
            //         string catId = cmd.ExecuteScalar().ToString();

            //         filterText += ((count > 0) ? " And " : " ") + "categoryId = '" + catId + "'";
            //         count++;

            //     }

            //     if (DescriptiontoolStripTextBox.Text.Trim() != "")
            //     {
            //         filterText += ((count > 0) ? " And " : " ") + "description like N'%" + DescriptiontoolStripTextBox.Text + "%'";
            //         count++;
            //     }

            //     if (BarcodetoolStripTextBox.Text.Trim() != "")
            //     {
            //         SqlCommand cmd = CommonFuncs.Utilities.getCommand();
            //         if (CommonFuncs.ParafaitEnv.IsCorporate)
            //         {
            //             condition = "  and (site_id = @siteId or @siteId = -1)";
            //             cmd.Parameters.AddWithValue("@siteId", CommonFuncs.getSiteid());
            //         }
            //         //Start query update
            //         cmd.CommandText = @"SELECT ','+ cast(ProductId as varchar(10))
            //                               FROM ProductBarcode 
            //                               WHERE barcode like  '%" + BarcodetoolStripTextBox.Text + "%' and isactive = 'Y' " + condition +
            //                               " FOR XML PATH('')";
            //         //end query update

            //         string productId;
            //         object ob = cmd.ExecuteScalar();
            //         if (ob == DBNull.Value || ob == null)
            //             productId = "-1";
            //         else
            //             productId = ob.ToString().Substring(1);

            //         filterText += ((count > 0) ? " And " : " ") + " productId in (" + productId + ")";
            //         count++;

            //     }



            //     //start update 25-Apr-2016
            //     //Updated to include search by segmentcategoryid (Advanced search)
            //     if (AdvancedSearch != null)
            //     {
            //         //Start update 11-Aug-2016 
            //         if (!string.IsNullOrEmpty(AdvancedSearch.searchCriteria))
            //         {
            //             filterText += ((count > 0) ? " And " : " ") + " (" + AdvancedSearch.searchCriteria + ") ";
            //             count++;
            //         }
            //         //End update 11-Aug-2016 
            //     }

            //     filterText += ((count > 0) ? " And " : " ") + " (site_id = " + machineUserContext.GetSiteId().ToString() + " or " + machineUserContext.GetSiteId().ToString() + " = -1)";
            //     count++;
            //     //end update 25-Apr-2016

            //     FireSelectionChanged = true;
            //     ProductList productList = new ProductList();
            //     populateProducts(productList.GetProductList(filterText));

            //     if (view_dgv.Rows.Count <= 0)
            //     {
            //         emptyAllFields();
            //         cb_update.Enabled = false;
            //         tb_code.Enabled = false;
            //     }
            // }
            // catch (System.Exception ex)
            // {
            //     System.Windows.Forms.MessageBox.Show(ex.Message);
            // }
        }

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

        private void cb_delete_Click(object sender, EventArgs e)
        {
            //if (lb_productid.Text == "")
            //{
            //    try
            //    {
            //        LoadProductFromDGV(0);
            //        //transferValues(0);
            //    }
            //    catch
            //    {
            //        emptyAllFields();
            //    }
            //}
            //else if (MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(889), CommonFuncs.Utilities.MessageUtils.getMessage("Delete Product"), MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    SqlCommand cmd = CommonFuncs.Utilities.getCommand();
            //    cmd.CommandText = "delete from product where ProductId = " + Convert.ToInt64(lb_productid.Text);
            //    try
            //    {
            //        cmd.ExecuteNonQuery();
            //        populateProducts(null);
            //        //refreshDgv();
            //    }
            //    catch
            //    {
            //        MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(890), CommonFuncs.Utilities.MessageUtils.getMessage("Delete Product"));
            //    }
            //}
        }

        //private void refreshDgv()
        //{
        //    this.productTableAdapter.Fill(this.redemptionDataSet.Product);
        //    CommonFuncs.setSiteIdFilter(productBindingSource);
        //    view_dgv.Refresh();
        //}

        private void emptyAllFields()
        {
            txtCode.Text = "";
            //tb_code.Enabled = true;
            tb_cost.Text = "";
            txtLowerCostLimit.Text = txtUpperCostLimit.Text = txtCostVariancePer.Text = "";
            tb_SalePrice.Text = "";
            tb_barcode.Text = "";
            txtDescription.Text = "";
            tb_lastpurchaseprice.Text = "";
            txtInnerPackQty.Text = "1";
            tb_pit.Text = "";
            //txtTurnInPIT.Text = "";
            tb_remarks.Text = "";
            txtReorderpoint.Text = "";
            tb_reorderquantity.Text = "";
            lb_productid.Text = "";
            this.categoryBindingSource.ResetBindings(false);
            cmb_category.SelectedIndex = 0;
            cmb_InboundLocation.SelectedIndex = 0;
            cmb_Vendor.SelectedIndex = 0;
            cmb_OutboundLocation.SelectedIndex = 0;
            //cmbExpiryType.Text = cmbIssueApproach.Text = "None";

            //txtIndays.Text = "";
            txtInnerPackQty.Text = "";
            cmbTax.SelectedIndex = 0;
            cmbUOM.SelectedIndex = 0;
            chk_active.Checked = true;
            chk_IsSellable.Checked = false;
            chk_IsRedeemable.Checked = false;
            //cmbExpiryType.Text = "";
            cmbIssueApproach.Text = "";
            chk_Purchaseable.Checked = true;
            chkTaxInclusiveCost.Checked = true;
            //pbProductImage.Image = null;
            //lblImageFileName.Text = "";
            //pbProductImage.Tag = DBNull.Value;
            lb_productid.Tag = null;
            //tvBOM.Nodes.Clear();
            chkLotControlled.Enabled = true;
            chkLotControlled.Checked = false;
            //BarcodetoolStripTextBox.Focus();//added
            //AdvancedSearch = null; //
        }

        private void tb_cost_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                double val;
                if (tb_cost.Text != "")
                    val = Convert.ToDouble(tb_cost.Text);
                tb_cost.BackColor = Color.White;
            }
            catch
            {
                tb_cost.BackColor = Color.Yellow;
                //  MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(891), CommonFuncs.Utilities.MessageUtils.getMessage("Cost Validation"));
                e.Cancel = true;
            }
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
            bool return_val = true;
            //SqlCommand cmd = CommonFuncs.Utilities.getCommand();

            //if (return_val)
            //{
            //    String currentCode = tb_code.Text;
            //    String mode = "";
            //    if (lb_productid.Text != "")
            //        mode = "U";
            //    else
            //        mode = "I";
            try
            {
                if (!ProductSave())//saveProduct()
                    return;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Failed to save database");
                return;
            }

            //    if (mode == "I")
            //    {
            //        MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(892), CommonFuncs.Utilities.MessageUtils.getMessage("Save Product"));
            //    }
            //    emptyAllFields();
            //    populateProducts(null);
            //    LoadProductFromDGV(0);
            //    tb_code.Enabled = true;
            //    //refreshDgv();
            //    //for (int i = 0; i < view_dgv.Rows.Count; i++)
            //    //{
            //    //    try
            //    //    {
            //    //        if (view_dgv["codeDataGridViewTextBoxColumn", i].Value.ToString() == currentCode)
            //    //        {
            //    //            view_dgv.Rows[i].Selected = true;
            //    //            if (mode == "I")
            //    //            {
            //    //                try
            //    //                {
            //    //                    cmd.CommandText = "insert into inventory (productId, locationId, quantity, TimeStamp, Lastupdated_userid, site_id) " +
            //    //                    "values (@productId, @locationId, 0, getdate(), @user, @site_id)";
            //    //                    cmd.Parameters.Clear();
            //    //                    cmd.Parameters.AddWithValue("@productId", view_dgv["productIdDataGridViewTextBoxColumn", i].Value);
            //    //                    cmd.Parameters.AddWithValue("@locationId", view_dgv["defaultLocationIdDataGridViewTextBoxColumn", i].Value);
            //    //                    cmd.Parameters.AddWithValue("@user", CommonFuncs.ParafaitEnv.Username);
            //    //                    cmd.Parameters.AddWithValue("@site_id", CommonFuncs.getSiteid());
            //    //                    cmd.ExecuteNonQuery();
            //    //                }
            //    //                catch (Exception ex)
            //    //                {
            //    //                    MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(ex.Message), CommonFuncs.Utilities.MessageUtils.getMessage("Create product"));
            //    //                }
            //    //            }
            //    //            view_dgv.FirstDisplayedScrollingRowIndex = i;
            //    //            break;
            //    //        }
            //    //    }
            //    //    catch { }
            //    //}
            //}
        }

        private void cb_Add_Click(object sender, EventArgs e)
        {
            //tsbClear.PerformClick();
            //cb_update.Enabled = true;
            ////TransferToDGV();
            //productDTO = new ProductDTO();
            //emptyAllFields();
            //tb_code.Enabled = true;
            //tb_code.ReadOnly = false;
            //tb_code.Focus();

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


            InventoryProduct inventoryProduct = new InventoryProduct();
            if (!string.IsNullOrEmpty(lb_productid.Text))
                inventoryProduct.ProductId = Convert.ToInt32(lb_productid.Text);

            inventoryProduct.Code = txtCode.Text;
            inventoryProduct.UomId = Convert.ToInt32(cmbUOM.SelectedValue);
            inventoryProduct.TaxId = Convert.ToInt32(cmbTax.SelectedValue);
            inventoryProduct.DefaultLocationId = Convert.ToInt32(cmb_InboundLocation.SelectedValue);
            inventoryProduct.OutboundLocationId = Convert.ToInt32(cmb_OutboundLocation.SelectedValue);
            inventoryProduct.DefaultVendorId = Convert.ToInt32(cmb_Vendor.SelectedValue);

            //Issueing apporach Pending

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

            if (!string.IsNullOrEmpty(txtReorderpoint.Text))
                inventoryProduct.ReorderPoint = Convert.ToDouble(txtReorderpoint.Text);
            if (!string.IsNullOrEmpty(tb_reorderquantity.Text))
                inventoryProduct.ReorderQuantity = Convert.ToDouble(tb_reorderquantity.Text);


            //if (!string.IsNullOrEmpty(tb_cost.Text))
            //    inventoryProduct.Cost = Convert.ToDouble(tb_cost.Text);
            //if (!string.IsNullOrEmpty(tb_SalePrice.Text))
            //    inventoryProduct.SalePrice = Convert.ToDouble(tb_SalePrice.Text);
            //if (!string.IsNullOrEmpty(txtInnerPackQty.Text))
            //    inventoryProduct.InnerPackQty = Convert.ToDouble(txtInnerPackQty.Text);
            //inventoryProduct.SegmentCategoryId = Convert.ToInt32(btnSKUSegments.Tag.ToString());
            //inventoryProduct.CustomDataSetId = Convert.ToInt32(btnCustom.Tag.ToString());
            //if (chkLotControlled.Checked)
            //    inventoryProduct.LotControlled = true;
            //else
            //    inventoryProduct.LotControlled = false;

            //if (chkMarketListItem.Checked)
            //    inventoryProduct.MarketListItem = true;
            //else
            //    inventoryProduct.MarketListItem = false;
            //inventoryProduct.ExpiryDays = 0;
            //if (cmbExpiryType.Text == "None")
            //    inventoryProduct.ExpiryType = "N";
            //else if (cmbExpiryType.Text == "In Days")
            //{
            //    inventoryProduct.ExpiryType = "D";
            //    inventoryProduct.LotControlled = true;
            //    if (string.IsNullOrEmpty(txtIndays.Text))
            //    {
            //        MessageBox.Show("Please enter expiry days.");
            //    }
            //    else
            //    {
            //        inventoryProduct.ExpiryDays = Convert.ToInt32(txtIndays.Text);
            //    }
            //}
            //else if (cmbExpiryType.Text == "Expiry Date")
            //{
            //    inventoryProduct.ExpiryType = "E";
            //    inventoryProduct.LotControlled = true;
            //}

            ////Start update 21-Feb-2017
            ////Added condition 
            //if (chkLotControlled.Checked == true && cmbIssueApproach.Text == "None")
            //{
            //    if (inventoryProduct.ExpiryType == "E" || inventoryProduct.ExpiryType == "D")
            //        inventoryProduct.IssuingApproach = "FEFO";
            //    else
            //        inventoryProduct.IssuingApproach = "FIFO";
            //}
            //else
            //    inventoryProduct.IssuingApproach = cmbIssueApproach.Text;
            ////End update 21-Feb-2017
            //inventoryProduct.Description = tb_description.Text;
            //inventoryProduct.Remarks = tb_remarks.Text;
            //inventoryProduct.CategoryId = (int)cb_category.SelectedValue;
            //if (!string.IsNullOrEmpty(txtLowerCostLimit.Text))
            //{
            //    inventoryProduct.LowerLimitCost = Convert.ToDouble(txtLowerCostLimit.Text);
            //}

            //if (!string.IsNullOrEmpty(txtUpperCostLimit.Text))
            //{
            //    inventoryProduct.UpperLimitCost = Convert.ToDouble(txtUpperCostLimit.Text);
            //}
            //if (!string.IsNullOrEmpty(txtCostVariancePer.Text))
            //{
            //    inventoryProduct.CostVariancePercentage = Convert.ToDouble(txtCostVariancePer.Text);
            //}

            //if (!string.IsNullOrEmpty(tb_lastpurchaseprice.Text))
            //{
            //    inventoryProduct.LastPurchasePrice = Convert.ToDouble(tb_lastpurchaseprice.Text);
            //}
            //else
            //    inventoryProduct.LastPurchasePrice = 0;

            //if (!string.IsNullOrEmpty(tb_pit.Text))
            //{
            //    inventoryProduct.PriceInTickets = Convert.ToDouble(tb_pit.Text);
            //}
            //if (!string.IsNullOrEmpty(txtTurnInPIT.Text))
            //{
            //    inventoryProduct.TurnInPriceInTickets = Convert.ToInt32(txtTurnInPIT.Text);
            //}

            //inventoryProduct.TaxInclusiveCost = (chkTaxInclusiveCost.Checked ? "Y" : "N");
            //inventoryProduct.ImageFileName = (pbProductImage.Tag == null) ? "" : pbProductImage.Tag.ToString();
            //Product product = new Product(productDTO);
            //product.Save(null);

            //if (productDTO.ProductId < 0)
            //{
            //    SQLTrx.Rollback(); //Added 21-Feb-2016
            //    return false;
            //}

            ////Start update 21-Feb-2016
            //if (chkLotControlled.Checked)
            //{
            //    if (productDTO.LotControlled && productDTO.IssuingApproach == "FIFO")
            //    {
            //        Semnox.Parafait.InventoryLot.InventoryLotBL inventoryLot = new Semnox.Parafait.InventoryLot.InventoryLotBL();
            //        inventoryLot.UpdateNonLotableToLotable(productDTO.ProductId, SQLTrx);
            //    }
            //}
            //SQLTrx.Commit();
            ////End update 21-Feb-2016
            return true;
        }
        private void LoadProductFromDGV(int index)
        {
            //productDTO = new ProductDTO();
            //BindingSource productbs = (BindingSource)view_dgv.DataSource;
            //var productDTOListOnDisplay = (Semnox.Core.SortableBindingList.SortableBindingList<ProductDTO>)productbs.DataSource;
            //productDTO = productDTOListOnDisplay[index];
            //if (inventoryProduct != -1)
            //{
            //    productDTO = productDTOListOnDisplay.Where(x => (bool)(x.ProductId == inventoryProduct)).ToList<ProductDTO>()[0];
            //}
            //if (productDTO != null)
            //{
            //    lb_productid.Text = productDTO.ProductId.ToString();

            //    tb_code.Text = productDTO.Code;
            //    tb_code.ReadOnly = true;
            //    cmbUOM.SelectedValue = productDTO.UomId;
            //    cmbTax.SelectedValue = productDTO.TaxId;
            //    cb_defaultlocation.SelectedValue = productDTO.DefaultLocationId;
            //    cbOutboundLocation.SelectedValue = productDTO.OutboundLocationId;
            //    cb_preferredvendor.SelectedValue = productDTO.DefaultVendorId;
            //    cb_active.Checked = productDTO.IsActive.Equals("Y");
            //    cb_IsRedeemable.Checked = productDTO.IsActive.Equals("Y");
            //    cb_IsSellable.Checked = productDTO.IsSellable.Equals("Y");
            //    chkLotControlled.Checked = productDTO.LotControlled;
            //    chkLotControlled.Enabled = !productDTO.LotControlled;
            //    cmbIssueApproach.Enabled = productDTO.LotControlled; //Added 21-Feb-2017
            //    chkMarketListItem.Checked = productDTO.MarketListItem;
            //    chkPurchaseable.Checked = productDTO.IsPurchaseable.Equals("Y");
            //    chkTaxInclusiveCost.Checked = (productDTO.TaxInclusiveCost.Equals("Y"));
            //    tb_reorderpoint.Text = productDTO.ReorderPoint.ToString();
            //    tb_reorderquantity.Text = productDTO.ReorderQuantity.ToString();
            //    tb_cost.Text = productDTO.Cost.ToString();
            //    tb_SalePrice.Text = productDTO.SalePrice.ToString();
            //    txtInnerPackQty.Text = productDTO.InnerPackQty.ToString();
            //    btnSKUSegments.Tag = productDTO.SegmentCategoryId;
            //    btnCustom.Tag = productDTO.CustomDataSetId;
            //    if (productDTO.ExpiryType.Equals("N"))
            //        cmbExpiryType.Text = "None";
            //    else if (productDTO.ExpiryType.Equals("D"))
            //    {
            //        cmbExpiryType.Text = "In Days";
            //        txtIndays.Text = productDTO.ExpiryDays.ToString();
            //        txtIndays.Visible = true;
            //    }
            //    else if (productDTO.ExpiryType.Equals("E"))
            //        cmbExpiryType.Text = "Expiry Date";

            //    cmbIssueApproach.Text = productDTO.IssuingApproach;
            //    tb_description.Text = productDTO.Description;
            //    tb_remarks.Text = productDTO.Remarks;
            //    cb_category.SelectedValue = productDTO.CategoryId;
            //    txtLowerCostLimit.Text = productDTO.LowerLimitCost.ToString();
            //    txtUpperCostLimit.Text = productDTO.UpperLimitCost.ToString();
            //    txtCostVariancePer.Text = productDTO.CostVariancePercentage.ToString();
            //    tb_lastpurchaseprice.Text = productDTO.LastPurchasePrice.ToString();
            //    tb_pit.Text = productDTO.PriceInTickets.ToString();
            //    txtTurnInPIT.Text = productDTO.TurnInPriceInTickets.ToString();
            //    tb_barcode.Text = productDTO.BarCode;
            //    pbProductImage.Tag = productDTO.ImageFileName;
            //    lblImageFileName.Text = pbProductImage.Tag.ToString();
            //    if (pbProductImage.Tag != DBNull.Value && !string.IsNullOrEmpty(pbProductImage.Tag.ToString()))
            //    {
            //        //pbProductImage.Image = CommonFuncs.Utilities.ConvertToImage(DT.Rows[0]["picture"]);
            //        SqlCommand cmdImage = CommonFuncs.Utilities.getCommand();
            //        cmdImage.CommandText = "exec ReadBinaryDataFromFile @FileName";

            //        string fileName = pbProductImage.Tag.ToString();
            //        lblImageFileName.Text = fileName;
            //        cmdImage.Parameters.AddWithValue("@FileName", imageFolder + "\\" + fileName);
            //        try
            //        {
            //            object o = cmdImage.ExecuteScalar();
            //            pbProductImage.Image = CommonFuncs.Utilities.ConvertToImage(o);
            //        }
            //        catch
            //        {
            //            pbProductImage.Image = null;
            //        }
            //    }
            //    else
            //        pbProductImage.Image = null;
            //}
        }
        private bool TransferToDGV()
        {
            //this.ValidateChildren();
            //this.Validate();

            //if (tb_code.Text == "")
            //{
            //    if (tb_description.Text.Trim() != "" && cb_category.Text.Trim() != "") // some data entered for insert
            //    {
            //        MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(893), CommonFuncs.Utilities.MessageUtils.getMessage("Insert / Update Product"));
            //        tb_code.Focus();
            //        return false;
            //    }
            //    else // nothing entered
            //        return false;
            //}

            //if (tb_description.Text.Trim() == "" || cb_category.Text.Trim() == "" || cb_defaultlocation.Text.Trim() == "" || cbOutboundLocation.Text.Trim() == "")
            //{
            //    MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(894), CommonFuncs.Utilities.MessageUtils.getMessage("Insert / Update Product"));
            //    tb_description.Focus();
            //    return false;
            //}

            //String mode = "";
            //if (lb_productid.Tag != null)
            //    mode = "U";
            //else
            //    mode = "I";

            //try
            //{
            //    //Prepare variables
            //    String ProdCode = tb_code.Text;
            //    int defaultlocation;
            //    int outBoundLocation;
            //    int preferredvendor = -1;
            //    String selectedvalue = "Y";
            //    int taxId = -1;
            //    int UOMId = -1;
            //    int SegmentCategoryId = -1; //Added 22-Apr-2016
            //    bool IsLottable = false;
            //    bool IsMarketListItem = false;
            //    string ExpiryType = "N";
            //    string IssueApproach = "None";

            //    if (cmbUOM.SelectedValue == null)
            //        UOMId = -1;
            //    else
            //        UOMId = Convert.ToInt32(cmbUOM.SelectedValue);

            //    if (cmbTax.SelectedValue == DBNull.Value || cmbTax.SelectedValue == null)
            //        taxId = -1;
            //    else
            //        taxId = Convert.ToInt32(cmbTax.SelectedValue);

            //    if (cb_defaultlocation.Text == null)
            //        defaultlocation = -1;
            //    else
            //        defaultlocation = Convert.ToInt32(cb_defaultlocation.SelectedValue);

            //    outBoundLocation = Convert.ToInt32(cbOutboundLocation.SelectedValue);

            //    if (cb_preferredvendor.Text.Trim() == "")
            //        preferredvendor = -1;
            //    else
            //        preferredvendor = Convert.ToInt32(cb_preferredvendor.SelectedValue);

            //    if (cb_active.Checked)
            //        selectedvalue = "Y";
            //    else
            //        selectedvalue = "N";

            //    string IsSellable, IsRedeemable;
            //    if (cb_IsRedeemable.Checked)
            //        IsRedeemable = "Y";
            //    else
            //        IsRedeemable = "N";

            //    if (cb_IsSellable.Checked)
            //        IsSellable = "Y";
            //    else
            //        IsSellable = "N";

            //    if (tb_reorderpoint.Text.Trim() == "")
            //        tb_reorderpoint.Text = "0";
            //    if (tb_reorderquantity.Text.Trim() == "")
            //        tb_reorderquantity.Text = "0";
            //    if (tb_cost.Text.Trim() == "")
            //        tb_cost.Text = (0).ToString(CommonFuncs.ParafaitEnv.INVENTORY_COST_FORMAT);
            //    if (tb_SalePrice.Text.Trim() == "")
            //        tb_SalePrice.Text = (0).ToString(CommonFuncs.ParafaitEnv.AMOUNT_FORMAT);

            //    if (txtInnerPackQty.Text.Trim() == "")
            //        txtInnerPackQty.Text = (1).ToString(CommonFuncs.ParafaitEnv.INVENTORY_QUANTITY_FORMAT);

            //    if (Convert.ToInt32(btnSKUSegments.Tag.ToString()) == -1)
            //        SegmentCategoryId = -1;
            //    else
            //        SegmentCategoryId = Convert.ToInt32(btnSKUSegments.Tag.ToString());

            //    if (chkLotControlled.Checked)
            //        IsLottable = true;
            //    else
            //        IsLottable = false;

            //    if (chkMarketListItem.Checked)
            //        IsMarketListItem = true;
            //    else
            //        IsMarketListItem = false;

            //    if (cmbExpiryType.Text == "None")
            //        ExpiryType = "N";
            //    else if (cmbExpiryType.Text == "In Days")
            //        ExpiryType = "D";
            //    else if (cmbExpiryType.Text == "Expiry Date")
            //        ExpiryType = "E";

            //    IssueApproach = cmbIssueApproach.Text;

            //    int index = 0;
            //    if (mode == "I")
            //    {
            //        productBindingSource.AddNew();
            //        index = view_dgv.Rows.Count - 1;
            //        lb_productid.Tag = index;
            //    }
            //    else
            //        index = Convert.ToInt32(lb_productid.Tag);

            //    if (!view_dgv["codeDataGridViewTextBoxColumn", index].Value.Equals(ProdCode))
            //        view_dgv["codeDataGridViewTextBoxColumn", index].Value = ProdCode;

            //    if (!view_dgv["descriptionDataGridViewTextBoxColumn", index].Value.Equals(tb_description.Text))
            //        view_dgv["descriptionDataGridViewTextBoxColumn", index].Value = tb_description.Text;

            //    if (!view_dgv["remarksDataGridViewTextBoxColumn", index].Value.Equals(tb_remarks.Text))
            //        view_dgv["remarksDataGridViewTextBoxColumn", index].Value = tb_remarks.Text;

            //    //if (!view_dgv["barCodeDataGridViewTextBoxColumn", index].Value.Equals(tb_barcode.Text))
            //    //    view_dgv["barCodeDataGridViewTextBoxColumn", index].Value = tb_barcode.Text;

            //    if (!view_dgv["categoryIdDataGridViewTextBoxColumn", index].Value.Equals(cb_category.SelectedValue))
            //        view_dgv["categoryIdDataGridViewTextBoxColumn", index].Value = cb_category.SelectedValue;

            //    if (!view_dgv["defaultLocationIdDataGridViewTextBoxColumn", index].Value.Equals(defaultlocation))
            //        view_dgv["defaultLocationIdDataGridViewTextBoxColumn", index].Value = defaultlocation;

            //    if (view_dgv["reorderPointDataGridViewTextBoxColumn", index].Value == DBNull.Value || !Convert.ToDouble(view_dgv["reorderPointDataGridViewTextBoxColumn", index].Value).Equals(Convert.ToDouble(tb_reorderpoint.Text)))
            //        view_dgv["reorderPointDataGridViewTextBoxColumn", index].Value = Convert.ToDouble(tb_reorderpoint.Text);

            //    if (view_dgv["reorderQuantityDataGridViewTextBoxColumn", index].Value == DBNull.Value || !Convert.ToDouble(view_dgv["reorderQuantityDataGridViewTextBoxColumn", index].Value).Equals(Convert.ToDouble(tb_reorderquantity.Text)))
            //        view_dgv["reorderQuantityDataGridViewTextBoxColumn", index].Value = Convert.ToDouble(tb_reorderquantity.Text);

            //    if (preferredvendor == -1)
            //    {
            //        if (!view_dgv["defaultVendorIdDataGridViewTextBoxColumn", index].Value.Equals(DBNull.Value))
            //            view_dgv["defaultVendorIdDataGridViewTextBoxColumn", index].Value = -1;
            //    }
            //    else
            //    {
            //        if (!view_dgv["defaultVendorIdDataGridViewTextBoxColumn", index].Value.Equals(preferredvendor))
            //            view_dgv["defaultVendorIdDataGridViewTextBoxColumn", index].Value = preferredvendor;
            //    }

            //    if (view_dgv["costDataGridViewTextBoxColumn", index].Value == DBNull.Value || !Convert.ToDouble(view_dgv["costDataGridViewTextBoxColumn", index].Value).Equals(Convert.ToDouble(tb_cost.Text)))
            //        view_dgv["costDataGridViewTextBoxColumn", index].Value = Convert.ToDouble(tb_cost.Text);

            //    if (txtLowerCostLimit.Text.Trim() != "")
            //    {
            //        if (view_dgv["LowerLimitCost", index].Value.Equals(0.0))
            //        {
            //            view_dgv["LowerLimitCost", index].Value = Convert.ToDouble(txtLowerCostLimit.Text);
            //        }
            //        else if (!Convert.ToDouble(view_dgv["LowerLimitCost", index].Value).Equals(Convert.ToDouble(txtLowerCostLimit.Text)))
            //        {
            //            view_dgv["LowerLimitCost", index].Value = Convert.ToDouble(txtLowerCostLimit.Text);
            //        }
            //    }
            //    else
            //    {
            //        if (!view_dgv["LowerLimitCost", index].Value.Equals(0.0))
            //            view_dgv["LowerLimitCost", index].Value = 0.0;
            //    }

            //    if (txtUpperCostLimit.Text.Trim() != "")
            //    {
            //        if (view_dgv["UpperLimitCost", index].Value == DBNull.Value)
            //        {
            //            view_dgv["UpperLimitCost", index].Value = Convert.ToDouble(txtUpperCostLimit.Text);
            //        }
            //        else if (!Convert.ToDouble(view_dgv["UpperLimitCost", index].Value).Equals(Convert.ToDouble(txtUpperCostLimit.Text)))
            //        {
            //            view_dgv["UpperLimitCost", index].Value = Convert.ToDouble(txtUpperCostLimit.Text);
            //        }
            //    }
            //    else
            //    {
            //        if (!view_dgv["UpperLimitCost", index].Value.Equals(0.0))
            //            view_dgv["UpperLimitCost", index].Value = 0.0;
            //    }

            //    if (txtCostVariancePer.Text.Trim() != "")
            //    {
            //        if (view_dgv["CostVariancePercentage", index].Value == DBNull.Value)
            //        {
            //            view_dgv["CostVariancePercentage", index].Value = Convert.ToDouble(txtCostVariancePer.Text);
            //        }
            //        else if (!Convert.ToDouble(view_dgv["CostVariancePercentage", index].Value).Equals(Convert.ToDouble(txtCostVariancePer.Text)))
            //        {
            //            view_dgv["CostVariancePercentage", index].Value = Convert.ToDouble(txtCostVariancePer.Text);
            //        }
            //    }
            //    else
            //    {
            //        if (!view_dgv["CostVariancePercentage", index].Value.Equals(0.0))
            //            view_dgv["CostVariancePercentage", index].Value = 0.0;
            //    }

            //    //Start update 22-Apr-2016
            //    if (tb_lastpurchaseprice.Text.Trim() != "")
            //    {
            //        if (view_dgv["lastPurchasePriceDataGridViewTextBoxColumn", index].Value == DBNull.Value)
            //        {
            //            view_dgv["lastPurchasePriceDataGridViewTextBoxColumn", index].Value = Convert.ToDouble(tb_lastpurchaseprice.Text);
            //        }
            //        else if (!Convert.ToDouble(view_dgv["lastPurchasePriceDataGridViewTextBoxColumn", index].Value).Equals(Convert.ToDouble(tb_lastpurchaseprice.Text)))
            //        {
            //            view_dgv["lastPurchasePriceDataGridViewTextBoxColumn", index].Value = Convert.ToDouble(tb_lastpurchaseprice.Text);
            //        }
            //    }
            //    else
            //    {
            //        if (view_dgv["lastPurchasePriceDataGridViewTextBoxColumn", index].Value.Equals(0.0))
            //            view_dgv["lastPurchasePriceDataGridViewTextBoxColumn", index].Value = 0.0;
            //    }
            //    //End update 22-Apr-2016

            //    if (!view_dgv["isActiveDataGridViewTextBoxColumn", index].Value.Equals(selectedvalue))
            //        view_dgv["isActiveDataGridViewTextBoxColumn", index].Value = selectedvalue;

            //    if (view_dgv["priceInTicketsDataGridViewTextBoxColumn", index].Value == DBNull.Value || !Convert.ToDouble(view_dgv["priceInTicketsDataGridViewTextBoxColumn", index].Value).Equals(Convert.ToDouble(tb_pit.Text.Trim() == "" ? "0" : tb_pit.Text)))
            //        view_dgv["priceInTicketsDataGridViewTextBoxColumn", index].Value = Convert.ToDouble(tb_pit.Text.Trim() == "" ? "0" : tb_pit.Text);

            //    if (view_dgv["TurnInPriceInTickets", index].Value == DBNull.Value || !Convert.ToDouble(view_dgv["TurnInPriceInTickets", index].Value).Equals(Convert.ToDouble(txtTurnInPIT.Text.Trim() == "" ? "0" : txtTurnInPIT.Text)))
            //        view_dgv["TurnInPriceInTickets", index].Value = Convert.ToDouble(txtTurnInPIT.Text.Trim() == "" ? "0" : txtTurnInPIT.Text);

            //    //if (!view_dgv["lastModUserIdDataGridViewTextBoxColumn", index].Value.Equals(CommonFuncs.ParafaitEnv.LoginID))//Starts modification on 23-08-2016
            //    //    view_dgv["lastModUserIdDataGridViewTextBoxColumn", index].Value = CommonFuncs.ParafaitEnv.LoginID;//ends modification on 23-08-2016

            //    if (mode == "I")
            //    {
            //        view_dgv["lastModDttmDataGridViewTextBoxColumn", index].Value = DateTime.Now;
            //    }

            //    if (!view_dgv["OutboundLocationId", index].Value.Equals(outBoundLocation))
            //        view_dgv["OutboundLocationId", index].Value = outBoundLocation;

            //    if (!view_dgv["IsRedeemable", index].Value.Equals(IsRedeemable))
            //        view_dgv["IsRedeemable", index].Value = IsRedeemable;

            //    if (!view_dgv["isSellableDataGridViewTextBoxColumn", index].Value.Equals(IsSellable))
            //        view_dgv["isSellableDataGridViewTextBoxColumn", index].Value = IsSellable;

            //    if (view_dgv["SalePrice", index].Value == DBNull.Value || !Convert.ToDouble(view_dgv["SalePrice", index].Value).Equals(Convert.ToDouble(tb_SalePrice.Text)))
            //        view_dgv["SalePrice", index].Value = Convert.ToDouble(tb_SalePrice.Text);

            //    if (view_dgv["innerPackQtyDataGridViewTextBoxColumn", index].Value == DBNull.Value || !Convert.ToDouble(view_dgv["innerPackQtyDataGridViewTextBoxColumn", index].Value).Equals(Convert.ToDouble(txtInnerPackQty.Text)))
            //        view_dgv["innerPackQtyDataGridViewTextBoxColumn", index].Value = Convert.ToDouble(txtInnerPackQty.Text);

            //    if (taxId == -1)
            //    {
            //        //if (!view_dgv["TaxId", index].Value.Equals(DBNull.Value))//Starts: Modification 23-08-2016
            //        view_dgv["TaxId", index].Value = -1; //DBNull.Value;//Ends: Modification 23-08-2016
            //    }
            //    else
            //    {
            //        if (!view_dgv["TaxId", index].Value.Equals(taxId))
            //            view_dgv["TaxId", index].Value = taxId;
            //    }

            //    if (UOMId == -1)
            //    {
            //        //if (!view_dgv["uomIdDataGridViewTextBoxColumn", index].Value.Equals(DBNull.Value))//Starts modification on 23-08-2016
            //        view_dgv["uomIdDataGridViewTextBoxColumn", index].Value = -1; //DBNull.Value;//Ends modification on 23-08-2016
            //    }
            //    else
            //    {
            //        if (!view_dgv["uomIdDataGridViewTextBoxColumn", index].Value.Equals(UOMId))
            //            view_dgv["uomIdDataGridViewTextBoxColumn", index].Value = UOMId;
            //    }

            //    if (!view_dgv["TaxInclusiveCost", index].Value.Equals((chkTaxInclusiveCost.Checked ? "Y" : "N")))
            //        view_dgv["TaxInclusiveCost", index].Value = (chkTaxInclusiveCost.Checked ? "Y" : "N");

            //    if (!view_dgv["isPurchaseableDataGridViewTextBoxColumn", index].Value.Equals((chkPurchaseable.Checked ? "Y" : "N")))
            //        view_dgv["isPurchaseableDataGridViewTextBoxColumn", index].Value = (chkPurchaseable.Checked ? "Y" : "N");

            //    if (!view_dgv["ImageFileName", index].Value.Equals(pbProductImage.Tag))
            //        view_dgv["ImageFileName", index].Value = pbProductImage.Tag;

            //    //Start update 18-Aug-2016
            //    if (!view_dgv["lotControlledDataGridViewCheckBoxColumn", index].Value.Equals(DBNull.Value))
            //        view_dgv["lotControlledDataGridViewCheckBoxColumn", index].Value = IsLottable;
            //    else
            //        view_dgv["lotControlledDataGridViewCheckBoxColumn", index].Value = false;

            //    if (!view_dgv["marketListItemDataGridViewCheckBoxColumn", index].Value.Equals(DBNull.Value))
            //        view_dgv["marketListItemDataGridViewCheckBoxColumn", index].Value = IsMarketListItem;
            //    else
            //        view_dgv["marketListItemDataGridViewCheckBoxColumn", index].Value = false;

            //    if (!view_dgv["expiryTypeDataGridViewTextBoxColumn", index].Value.Equals(DBNull.Value))
            //        view_dgv["expiryTypeDataGridViewTextBoxColumn", index].Value = ExpiryType;
            //    else
            //        view_dgv["expiryTypeDataGridViewTextBoxColumn", index].Value = "N";
            //    if (view_dgv["expiryTypeDataGridViewTextBoxColumn", index].Value.Equals("D"))
            //    {
            //        view_dgv["expiryDaysDataGridViewTextBoxColumn", index].Value = txtIndays.Text;
            //    }

            //    if (!view_dgv["issuingApproachDataGridViewTextBoxColumn", index].Value.Equals(DBNull.Value))
            //        view_dgv["issuingApproachDataGridViewTextBoxColumn", index].Value = IssueApproach;
            //    else
            //        view_dgv["issuingApproachDataGridViewTextBoxColumn", index].Value = "None";
            //    //End update 18-Aug-2016

            //    //Start update 22-Apr-2016
            //    if (SegmentCategoryId == -1)
            //    {
            //        //if (!view_dgv["SegmentCategoryId", index].Value.Equals(DBNull.Value))//Starts modification on 23-08-2016
            //        view_dgv["SegmentCategoryId", index].Value = -1; //DBNull.Value;//Ends modification on 23-08-2016
            //    }
            //    else
            //    {
            //        if (!view_dgv["SegmentCategoryId", index].Value.Equals(SegmentCategoryId))
            //            view_dgv["SegmentCategoryId", index].Value = SegmentCategoryId;
            //    }
            //    //End update 22-Apr-2016

            //    if (CommonFuncs.ParafaitEnv.IsCorporate && mode == "I")
            //    {
            //        view_dgv["site_id", index].Value = CommonFuncs.ParafaitEnv.SiteId;
            //    }

            //    productBindingSource.EndEdit();
            //    view_dgv.CurrentCell = view_dgv["codeDataGridViewTextBoxColumn", index];

            //    this.ValidateChildren();
            //    this.Validate();
            //    //BarcodetoolStripTextBox.Text = "";
            //    //BarcodetoolStripTextBox.Focus();
            //    return true;
            //}
            //catch (Exception exc)
            //{
            //    MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(895) + exc.Message, CommonFuncs.Utilities.MessageUtils.getMessage("Insert / Update Product"));
            //    MessageBox.Show(exc.StackTrace);
            //    return false;
            //}

            return false;

        }

        private void cb_addcategory_Click(object sender, EventArgs e)
        {
            categoryform = new frmCategory();

            categoryform.StartPosition = FormStartPosition.CenterScreen;
            categoryform.ShowDialog();
            //populateCategory();
            cmb_category.SelectedIndex = -1;
        }

        private void cb_addlocation_Click(object sender, EventArgs e)
        {
            //LocationUI = new Semnox.Core.Location.LocationUI(CommonFuncs.Utilities);
            //CommonDisplay.setupVisuals(LocationUI);//Added for GUI Design style on 23-Aug-2016
            //LocationUI.StartPosition = FormStartPosition.CenterScreen;//Added for showing in center on 23-Aug-2016
            //LocationUI.ShowDialog();
            //populateLocation();
            //cb_defaultlocation.SelectedIndex = -1;
        }

        private void cb_addvendor_Click(object sender, EventArgs e)
        {
            ////VendorUI = new Semnox.Core.Vendor.VendorUI(CommonFuncs.Utilities);
            ////CommonDisplay.setupVisuals(VendorUI);//Added for GUI Design style on 23-Aug-2016
            ////VendorUI.StartPosition = FormStartPosition.CenterScreen;//Added for showing in center on 23-Aug-2016
            ////VendorUI.ShowDialog();
            //CommonDisplay.OpenForm(this, "Vendor", false, true);//Added for GUI Design style on 23-Aug-2016
            //populateVendor();
            //cb_preferredvendor.SelectedIndex = -1;
        }

        private void frm_MaintainProducts_FormClosing(object sender, FormClosingEventArgs e)
        {
            //TransferToDGV();
            //if (redemptionDataSet.HasChanges())
            //{
            //    if (MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(896), CommonFuncs.Utilities.MessageUtils.getMessage("Exit Products Form"), MessageBoxButtons.YesNo) == DialogResult.No)
            //        e.Cancel = true;
            //}
        }

        private void transferValues(int rowindex)
        {
            //lb_productid.Tag = rowindex;
            //tb_code.Enabled = false;
            //lb_productid.Text = view_dgv.Rows[rowindex].Cells["productIdDataGridViewTextBoxColumn"].Value.ToString();
            //tb_code.Text = view_dgv.Rows[rowindex].Cells["codeDataGridViewTextBoxColumn"].Value.ToString();//Added 28-Apr-2016
            //tb_description.Text = view_dgv.Rows[rowindex].Cells["descriptionDataGridViewTextBoxColumn"].Value.ToString();
            //cb_category.SelectedValue = view_dgv.Rows[rowindex].Cells["categoryIdDataGridViewTextBoxColumn"].Value;
            ////Starts modification on 22-Apr-2016 for adding segments.
            //btnSKUSegments.Tag = (view_dgv.Rows[rowindex].Cells["SegmentCategoryId"].Value == DBNull.Value) ? -1 : Convert.ToInt32(view_dgv.Rows[rowindex].Cells["SegmentCategoryId"].Value);
            ////Ends modification on 22-Apr-2016 for adding segments.
            //tb_barcode.Text = view_dgv.Rows[rowindex].Cells["barCodeDataGridViewTextBoxColumn"].Value.ToString();

            //if ((String)view_dgv.Rows[rowindex].Cells["isActiveDataGridViewTextBoxColumn"].Value == "Y")
            //{
            //    cb_active.Checked = true;
            //    lblActive.BackColor = this.BackColor;
            //}
            //else
            //{
            //    cb_active.Checked = false;
            //    lblActive.BackColor = Color.LightGray;
            //}

            //if ((String)view_dgv.Rows[rowindex].Cells["IsRedeemable"].Value == "Y")
            //    cb_IsRedeemable.Checked = true;
            //else
            //    cb_IsRedeemable.Checked = false;

            //if ((String)view_dgv.Rows[rowindex].Cells["isSellableDataGridViewTextBoxColumn"].Value == "Y")
            //    cb_IsSellable.Checked = true;
            //else
            //    cb_IsSellable.Checked = false;

            //if (view_dgv.Rows[rowindex].Cells["LowerLimitCost"].Value != DBNull.Value)
            //    txtLowerCostLimit.Text = Convert.ToDouble(view_dgv.Rows[rowindex].Cells["LowerLimitCost"].Value).ToString(CommonFuncs.ParafaitEnv.INVENTORY_COST_FORMAT);
            //else
            //    txtLowerCostLimit.Text = "";

            //if (view_dgv.Rows[rowindex].Cells["UpperLimitCost"].Value != DBNull.Value)
            //    txtUpperCostLimit.Text = Convert.ToDouble(view_dgv.Rows[rowindex].Cells["UpperLimitCost"].Value).ToString(CommonFuncs.ParafaitEnv.INVENTORY_COST_FORMAT);
            //else
            //    txtUpperCostLimit.Text = "";

            //if (view_dgv.Rows[rowindex].Cells["CostVariancePercentage"].Value != DBNull.Value)
            //    txtCostVariancePer.Text = Convert.ToDouble(view_dgv.Rows[rowindex].Cells["CostVariancePercentage"].Value).ToString(CommonFuncs.ParafaitEnv.AMOUNT_FORMAT);
            //else
            //    txtCostVariancePer.Text = "";

            //if (view_dgv.Rows[rowindex].Cells["lastPurchasePriceDataGridViewTextBoxColumn"].Value != DBNull.Value)
            //    tb_lastpurchaseprice.Text = Convert.ToDouble(view_dgv.Rows[rowindex].Cells["lastPurchasePriceDataGridViewTextBoxColumn"].Value).ToString(CommonFuncs.ParafaitEnv.INVENTORY_COST_FORMAT);
            //else
            //    tb_lastpurchaseprice.Text = "";
            ////in the following section conditional operator was introduced to check whether the value is dbnull (it was throwing error while trying to convert nulls)-29-04-2015
            //txtInnerPackQty.Text = Convert.ToDouble(view_dgv.Rows[rowindex].Cells["innerPackQtyDataGridViewTextBoxColumn"].Value == DBNull.Value ? "" : view_dgv.Rows[rowindex].Cells["innerPackQtyDataGridViewTextBoxColumn"].Value).ToString(CommonFuncs.ParafaitEnv.INVENTORY_QUANTITY_FORMAT);
            //tb_cost.Text = Convert.ToDouble(view_dgv.Rows[rowindex].Cells["costDataGridViewTextBoxColumn"].Value == DBNull.Value ? "" : view_dgv.Rows[rowindex].Cells["costDataGridViewTextBoxColumn"].Value).ToString(CommonFuncs.ParafaitEnv.INVENTORY_COST_FORMAT);
            //tb_SalePrice.Text = Convert.ToDouble(view_dgv.Rows[rowindex].Cells["SalePrice"].Value == DBNull.Value ? "" : view_dgv.Rows[rowindex].Cells["SalePrice"].Value).ToString(CommonFuncs.ParafaitEnv.AMOUNT_FORMAT);
            //tb_reorderpoint.Text = Convert.ToDouble(view_dgv.Rows[rowindex].Cells["reorderPointDataGridViewTextBoxColumn"].Value == DBNull.Value ? 0 : view_dgv.Rows[rowindex].Cells["reorderPointDataGridViewTextBoxColumn"].Value).ToString(CommonFuncs.ParafaitEnv.INVENTORY_QUANTITY_FORMAT);
            //tb_reorderquantity.Text = Convert.ToDouble(view_dgv.Rows[rowindex].Cells["reorderQuantityDataGridViewTextBoxColumn"].Value == DBNull.Value ? "" : view_dgv.Rows[rowindex].Cells["reorderQuantityDataGridViewTextBoxColumn"].Value).ToString(CommonFuncs.ParafaitEnv.INVENTORY_QUANTITY_FORMAT);
            //cb_defaultlocation.SelectedValue = view_dgv.Rows[rowindex].Cells["defaultLocationIdDataGridViewTextBoxColumn"].Value;
            //cbOutboundLocation.SelectedValue = view_dgv.Rows[rowindex].Cells["OutboundLocationId"].Value;
            //cb_preferredvendor.SelectedValue = view_dgv.Rows[rowindex].Cells["defaultVendorIdDataGridViewTextBoxColumn"].Value;
            //tb_remarks.Text = view_dgv.Rows[rowindex].Cells["remarksDataGridViewTextBoxColumn"].Value.ToString();
            //tb_pit.Text = string.Format("{0:n2}", view_dgv.Rows[rowindex].Cells["priceInTicketsDataGridViewTextBoxColumn"].Value);
            //txtTurnInPIT.Text = string.Format("{0:n0}", view_dgv.Rows[rowindex].Cells["TurnInPriceInTickets"].Value);

            //if (view_dgv.Rows[rowindex].Cells["taxInclusiveCost"].Value.ToString() == "Y")
            //    chkTaxInclusiveCost.Checked = true;
            //else
            //    chkTaxInclusiveCost.Checked = false;

            //if (view_dgv.Rows[rowindex].Cells["TaxId"].Value == DBNull.Value)
            //    cmbTax.SelectedIndex = -1;
            //else
            //    cmbTax.SelectedValue = Convert.ToInt32(view_dgv.Rows[rowindex].Cells["TaxId"].Value);

            //if (view_dgv.Rows[rowindex].Cells["uomIdDataGridViewTextBoxColumn"].Value == DBNull.Value)
            //    cmbUOM.SelectedIndex = -1;
            //else
            //    cmbUOM.SelectedValue = Convert.ToInt32(view_dgv.Rows[rowindex].Cells["uomIdDataGridViewTextBoxColumn"].Value);

            //if (view_dgv.Rows[rowindex].Cells["isPurchaseableDataGridViewTextBoxColumn"].Value.ToString() == "Y")
            //    chkPurchaseable.Checked = true;
            //else
            //    chkPurchaseable.Checked = false;

            //pbProductImage.Tag = view_dgv.Rows[rowindex].Cells["ImageFileName"].Value;
            //lblImageFileName.Text = pbProductImage.Tag.ToString();
            //if (pbProductImage.Tag != DBNull.Value)
            //{
            //    //pbProductImage.Image = CommonFuncs.Utilities.ConvertToImage(DT.Rows[0]["picture"]);
            //    SqlCommand cmdImage = CommonFuncs.Utilities.getCommand();
            //    cmdImage.CommandText = "exec ReadBinaryDataFromFile @FileName";

            //    string fileName = pbProductImage.Tag.ToString();
            //    lblImageFileName.Text = fileName;
            //    cmdImage.Parameters.AddWithValue("@FileName", imageFolder + "\\" + fileName);
            //    try
            //    {
            //        object o = cmdImage.ExecuteScalar();
            //        pbProductImage.Image = CommonFuncs.Utilities.ConvertToImage(o);
            //    }
            //    catch
            //    {
            //        pbProductImage.Image = null;
            //    }
            //}
            //else
            //    pbProductImage.Image = null;

            //if (view_dgv.Rows[rowindex].Cells["lotControlledDataGridViewCheckBoxColumn"].Value == DBNull.Value)
            //{
            //    chkLotControlled.Checked = false;
            //}
            //else if ((Boolean)view_dgv.Rows[rowindex].Cells["lotControlledDataGridViewCheckBoxColumn"].Value)
            //{
            //    chkLotControlled.Checked = true;
            //}
            //else
            //{
            //    chkLotControlled.Checked = false;
            //}

            //if (view_dgv.Rows[rowindex].Cells["marketListItemDataGridViewCheckBoxColumn"].Value == DBNull.Value)
            //{
            //    chkMarketListItem.Checked = false;
            //}
            //else if ((Boolean)view_dgv.Rows[rowindex].Cells["marketListItemDataGridViewCheckBoxColumn"].Value)
            //{
            //    chkMarketListItem.Checked = true;
            //}
            //else
            //{
            //    chkMarketListItem.Checked = false;
            //}

            //if (view_dgv.Rows[rowindex].Cells["expiryTypeDataGridViewTextBoxColumn"].Value == DBNull.Value)
            //{
            //    cmbExpiryType.SelectedText = "None";
            //}
            //else if ((String)view_dgv.Rows[rowindex].Cells["expiryTypeDataGridViewTextBoxColumn"].Value == "N")
            //{
            //    cmbExpiryType.SelectedText = "None";
            //}
            //else if ((String)view_dgv.Rows[rowindex].Cells["expiryTypeDataGridViewTextBoxColumn"].Value == "D")
            //{
            //    cmbExpiryType.SelectedText = "In Days";
            //}
            //else if ((String)view_dgv.Rows[rowindex].Cells["expiryTypeDataGridViewTextBoxColumn"].Value == "E")
            //{
            //    cmbExpiryType.SelectedText = "Expiry Date";
            //}

            //if (view_dgv.Rows[rowindex].Cells["issuingApproachDataGridViewTextBoxColumn"].Value == DBNull.Value)
            //{
            //    cmbIssueApproach.Text = "None";
            //}
            //else
            //{
            //    cmbIssueApproach.Text = view_dgv.Rows[rowindex].Cells["issuingApproachDataGridViewTextBoxColumn"].Value.ToString();
            //}
        }

        private void cb_duplicate_Click(object sender, EventArgs e)
        {
            ////TransferToDGV();
            //if (view_dgv.SelectedRows.Count < 1)
            //    MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(897), CommonFuncs.Utilities.MessageUtils.getMessage("Duplicate Product"));
            //else
            //{
            //    lb_productid.Text = "";
            //    lb_productid.Tag = null;
            //    if (productDTO != null)
            //    {
            //        productDTO.ProductId = -1;
            //    }
            //    //tb_barcode.Text = "";
            //    tb_code.Text = "";
            //    tvBOM.Nodes.Clear();
            //    tb_code.Enabled = true;
            //    tb_barcode.Text = "";
            //    tb_lastpurchaseprice.Text = "";
            //    tb_code.ReadOnly = false;
            //    tb_code.Focus();
            //}
        }

        private void frm_MaintainProducts_Activated(object sender, EventArgs e)
        {
            //BarcodeReader.setReceiveAction = serialbarcodeDataReceived;
            //BarcodetoolStripTextBox.Focus();
        }

        //For Barcode
        private void serialbarcodeDataReceived()
        {
            //    scannedBarcode = BarcodeReader.Barcode;
            //    //string condition = "";

            //    if (scannedBarcode != "")
            //    {
            //        //If BarcodetoolStripTextBox textbox is focused product should be populated by barcode entered
            //        if (BarcodetoolStripTextBox.Focused)
            //        {
            //            BarcodetoolStripTextBox.Text = scannedBarcode;
            //            fillByToolStripButton.PerformClick();
            //        }
            //        //else if (tb_barcode.Focused) //If barcode textbox is focused, barcode should be entered in the textbox
            //        //{
            //        //    tb_barcode.Text = scannedBarcode;

            //        //    SqlCommand cmd = CommonFuncs.Utilities.getCommand();
            //        //    if (CommonFuncs.ParafaitEnv.IsCorporate)
            //        //    {
            //        //        condition = " and (site_id = @site_id or @site_id = -1)";
            //        //        cmd.Parameters.AddWithValue("@site_id", CommonFuncs.getSiteid());
            //        //    }
            //        //    cmd.CommandText = "select Code " +
            //        //            "from Product " +
            //        //            "where BarCode = @bar " + condition;
            //        //    DataTable DT = new DataTable();
            //        //    cmd.Parameters.AddWithValue("@bar", scannedBarcode);
            //        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //        //    da.Fill(DT);
            //        //    da.Dispose();

            //        //    if (tb_barcode.Focused) //If textbox Bar Code is focused, enter the barcode in the textbox
            //        //    {
            //        //        tb_barcode.Text = scannedBarcode;
            //        //        //BarcodetoolStripTextBox.Focus();
            //        //    }
            //        //    else if (DT.Rows.Count < 1)
            //        //    {
            //        //        tb_code.Enabled = true;
            //        //        //BarcodetoolStripTextBox.Focus();
            //        //    }
            //        //    else if (DT.Rows.Count == 1)
            //        //    {
            //        //        tb_code.Enabled = false;
            //        //        tsbClear.PerformClick();
            //        //        productCodeToolStripTextBox.Text = DT.Rows[0]["Code"].ToString();
            //        //        BarcodetoolStripTextBox.Text = scannedBarcode;
            //        //        fillByToolStripButton.PerformClick();
            //        //    }
            //        //    else
            //        //    {
            //        //        MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(859), CommonFuncs.Utilities.MessageUtils.getMessage("Error"));
            //        //    }
            //        //}
            //    }
        }



        private void cb_preferredvendor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //int vendor_id;
            //if (cb_preferredvendor.SelectedValue == DBNull.Value || cb_preferredvendor.SelectedValue == null)
            //    vendor_id = -1;
            //else
            //{
            //    vendor_id = Convert.ToInt32(cb_preferredvendor.SelectedValue.ToString());
            //    DataTable DT = new DataTable();
            //    SqlCommand cmd = CommonFuncs.Utilities.getCommand();
            //    cmd.CommandText = "select  ContactName, Phone, Address1,Address2,City,State,Country,PostalCode" +
            //            " from Vendor " +
            //            "where VendorId = @vendor AND IsActive = 'Y'";
            //    if (vendor_id == -1)
            //        cmd.Parameters.AddWithValue("@vendor", DBNull.Value);
            //    else
            //        cmd.Parameters.AddWithValue("@vendor", vendor_id);
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    da.Fill(DT);
            //    da.Dispose();

            //    if (DT.Rows.Count == 0)
            //    {
            //        MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(857), CommonFuncs.Utilities.MessageUtils.getMessage("Vendor Status"));
            //        cb_preferredvendor.SelectedIndex = -1;
            //        return;
            //    }
            //}
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
            //TransferToDGV();

            //UploadProducts up = new UploadProducts();
            ////if (up.ShowDialog() == DialogResult.OK)
            //up.ShowDialog();

            //CommonDisplay.OpenForm(this, "UploadProducts", false, true);//Added for GUI Design style on 23-Aug-2016
            //populateProducts(null);
            //refreshDgv();
        }

        private void btnAddTax_Click(object sender, EventArgs e)
        {
            //PurchaseTaxUI = new Semnox.Core.PurchaseTax.PurchaseTaxUI(CommonFuncs.Utilities);
            //CommonDisplay.setupVisuals(PurchaseTaxUI);//Added for GUI Design style on 23-Aug-2016
            //PurchaseTaxUI.StartPosition = FormStartPosition.CenterScreen;//Added for showing in center on 23-Aug-2016
            //PurchaseTaxUI.ShowDialog();
            //populateTax();
            //cmbTax.SelectedIndex = -1;
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
            //UOMUI = new Semnox.Core.UOM.UOMUI(CommonFuncs.Utilities);
            //CommonDisplay.setupVisuals(UOMUI);//Added for GUI Design style on 23-Aug-2016
            //UOMUI.StartPosition = FormStartPosition.CenterScreen;//Added for showing in center on 23-Aug-2016
            //UOMUI.ShowDialog();
            //populateUOM();
            //cmbUOM.SelectedIndex = -1;
        }

        private void btnTabularView_Click(object sender, EventArgs e)
        {
            //ShowWaitScreen();
            ////TransferToDGV();
            //BindingSource productbs = (BindingSource)view_dgv.DataSource;
            //var productDTOListOnDisplay = (Semnox.Core.SortableBindingList.SortableBindingList<ProductDTO>)productbs.DataSource;
            //List<ProductDTO> productDTOList = new List<ProductDTO>();
            //foreach (ProductDTO prodDTO in productDTOListOnDisplay)
            //{
            //    productDTOList.Add(prodDTO);
            //}
            ////frm_ProductTabular frm = new frm_ProductTabular(filterText);//"Code like '" + productCodeToolStripTextBox.Text + "'" + (productBindingSource.Filter == null ? "" : " and " + productBindingSource.Filter)
            ////CommonDisplay.setupVisuals(frm);//Added for GUI Design style on 23-Aug-2016            
            ////frm.MdiParent = this.MdiParent;
            ////frm.Location = new Point(0, 0);
            ////frm.Show();

            ////Begin: Modification added on 01-Sep-2016
            //int productTabular_form_active = 0;
            //foreach (Form child_form in Application.OpenForms)
            //{
            //    if (child_form.Name == "frm_ProductTabular")
            //    {
            //        child_form.Activate();
            //        child_form.Focus();
            //        productTabular_form_active = 1;
            //        child_form.BringToFront();
            //    }
            //}
            //if (productTabular_form_active == 0)
            //{
            //    frm_ProductTabular frm = new frm_ProductTabular(filterText);
            //    CommonDisplay.setupVisuals(frm);//Setup GUI Design Style Added on 23-Aug-2016
            //    frm.MdiParent = this.MdiParent;
            //    frm.Location = new Point(0, 0);
            //    frm.Dock = DockStyle.Fill;//Added to fit in MDI Container on 25-Aug-2016
            //    frm.Show();
            //    frm.BringToFront();
            //    productTabular_form_active = 0;
            //}
            ////End: Modification added on 01-Sep-2016

            //populateProducts(null);
            ////refreshDgv();
        }

        #region BOM
        private void BOM_Load(int productId)
        {
            //if (productId != -1)
            //{
            //    populateTree(productId);
            //    if (tvBOM.Nodes.Count > 0)
            //    {
            //        tvBOM.Nodes[0].NodeFont = new System.Drawing.Font(tvBOM.Font, FontStyle.Bold);
            //        tvBOM.Nodes[0].ExpandAll();
            //        tvBOM.Nodes[0].Text = tvBOM.Nodes[0].Text; // reassign to set proper width for text
            //    }
            //}
            //else
            //    tvBOM.Nodes.Clear();
        }

        DataTable getProducts(int LocalProductId)
        {
            //SqlCommand cmd = CommonFuncs.Utilities.getCommand();
            //cmd.CommandText = "select ProductId, Code + ' (' + description + ')' " +
            //                    "from Product p " +
            //                    "where (p.ProductId = @productId or @productId = -1)";
            //cmd.Parameters.AddWithValue("@productId", LocalProductId);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            //da.Fill(dt);

            return (dt);
        }

        //TreeNode[] getChildren(int LocalProductId)
        //{
        //    SqlCommand cmd = CommonFuncs.Utilities.getCommand();
        //    cmd.CommandText = @"select ChildProductId, Code + 
        //                        ' (' + description + '-' + cast(convert(decimal(10, 3), quantity) as varchar) + ' ' + uom + 
        //                        ') Cost: ' + cast(convert(decimal(10, 3), isnull(dbo.GetBOMProductCost(ChildProductId) * quantity / case isnull(innerPackQty, 0) when 0 then 1 else innerPackQty end, 0)) as varchar) " +
        //                        "from Product p, ProductBOM bom, uom u " +
        //                        "where bom.ProductId = @productId " +
        //                        "and p.ProductId = bom.ChildProductId " +
        //                        "and u.uomId = p.uomId";
        //    cmd.Parameters.AddWithValue("@productId", LocalProductId);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);

        //    if (dt.Rows.Count == 0)
        //        return null;
        //    else
        //    {
        //        TreeNode[] tnCollection = new TreeNode[dt.Rows.Count];

        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            tnCollection[i] = new TreeNode(dt.Rows[i][1].ToString());
        //            tnCollection[i].Tag = dt.Rows[i][0];
        //        }
        //        return (tnCollection);
        //    }
        //}

        //TreeNode getNodes(TreeNode rootNode)
        //{
        //    TreeNode[] tn = getChildren(Convert.ToInt32(rootNode.Tag));
        //    if (tn == null)
        //        return null;
        //    else
        //    {
        //        foreach (TreeNode tnode in tn)
        //        {
        //            TreeNode node = getNodes(tnode);
        //            if (node == null)
        //                rootNode.Nodes.Add(tnode);
        //            else
        //                rootNode.Nodes.Add(node);
        //        }

        //        return (rootNode);
        //    }
        //}

        void populateTree(int LocalProductId)
        {
            //tvBOM.Nodes.Clear();
            //DataTable dt = getProducts(LocalProductId);
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    TreeNode node = new TreeNode(dt.Rows[i][1].ToString());
            //    node.Tag = dt.Rows[i][0];
            //    tvBOM.Nodes.Add(node);

            //    getNodes(node);
            //}
        }

        private void tvBOM_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //if (e.Button == System.Windows.Forms.MouseButtons.Right)
            //    tvBOM.SelectedNode = e.Node;
        }

        void refreshNode(TreeNode node)
        {
            node.Nodes.Clear();
            //getNodes(node);
            node.ExpandAll();
        }

        void refreshSelectedNode()
        {
            //if (tvBOM.SelectedNode != null)
            //    refreshNode(tvBOM.SelectedNode);
        }

        int selectedProductId;
        private void tvBOM_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectedProductId = Convert.ToInt32(e.Node.Tag);
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            //TreeNode tn = tvBOM.SelectedNode;
            //if (tn == null)
            //    return;
            //if (tn.Parent == null)
            //    return;
            //TreeNode tnParent = tn.Parent;

            //if (MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(898), CommonFuncs.Utilities.MessageUtils.getMessage("Remove Node"), MessageBoxButtons.YesNoCancel) == System.Windows.Forms.DialogResult.Yes)
            //{
            //    int localProductId = Convert.ToInt32(tn.Tag);
            //    int localParentProductId = Convert.ToInt32(tnParent.Tag);
            //    SqlCommand cmd = CommonFuncs.Utilities.getCommand();
            //    cmd.CommandText = "delete from ProductBOM where ChildproductId = @productId and ProductId = @parentId";
            //    cmd.Parameters.AddWithValue("@productId", localProductId);
            //    cmd.Parameters.AddWithValue("@parentId", localParentProductId);
            //    cmd.ExecuteNonQuery();

            //    tvBOM.SelectedNode = tnParent;
            //    refreshNode(tnParent);
            //}
        }

        private void BOMEditMenu_Opening(object sender, CancelEventArgs e)
        {
            //if (tvBOM.SelectedNode == null)
            //    return;
            //if (tvBOM.SelectedNode.Level == 0)
            //{
            //    EditBOM.Enabled = false;
            //    Remove.Enabled = false;
            //}
            //else
            //{
            //    EditBOM.Enabled = true;
            //    Remove.Enabled = true;
            //}
        }

        private void Add_Click(object sender, EventArgs e)
        {
            //TreeNode tn = tvBOM.SelectedNode;
            //if (tn != null)
            //{
            //    int localProductId = Convert.ToInt32(tn.Tag);
            //    frm_BOM frm = new frm_BOM(localProductId, tn.Text);
            //    frm.StartPosition = FormStartPosition.CenterScreen;
            //    try
            //    {
            //        frm.ShowDialog();
            //    }
            //    catch { }
            //    refreshNode(tn);
            //}
        }

        private void menuRefresh_Click(object sender, EventArgs e)
        {
            refreshSelectedNode();
        }

        private void tvBOM_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Delete)
                Remove.PerformClick();
        }
        #endregion

        private void tvBOM_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //EditBOM.PerformClick();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //EditBOM.PerformClick();
            //this.ActiveControl = tvBOM;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Add.PerformClick();
            //this.ActiveControl = tvBOM;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //Remove.PerformClick();
            //this.ActiveControl = tvBOM;
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            //cb_update.Enabled = true;
            //productCodeToolStripTextBox.Text = "%";
            //DescriptiontoolStripTextBox.Text = "";
            //cmbCategory.SelectedIndex =
            //cmbProductType.SelectedIndex =
            //cmbActive.SelectedIndex = 0;
            //BarcodetoolStripTextBox.Text = "";
            //AdvancedSearch = null; //Added 27-Apr-2016
            //fillByToolStripButton.PerformClick();
        }

        private void productCodeToolStripTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13)
            //    fillByToolStripButton.PerformClick();
        }

        private void DescriptiontoolStripTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13)
            //    fillByToolStripButton.PerformClick();
        }

        private void lnkProductImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //    OpenFileDialog fileDialog = new OpenFileDialog();
            //    fileDialog.Title = "Upload Product Image";
            //    fileDialog.Filter = "Image Files (*.gif, *.jpg, *.jpeg, *.wmf, *.png, *.ico, *.bmp)|*.gif; *.jpg; *.jpeg; *.wmf; *.png; *.ico; *.bmp|All Files(*.*)|*.*";
            //    if (fileDialog.ShowDialog() == DialogResult.Cancel)
            //        return;

            //    try
            //    {
            //        pbProductImage.Image = Image.FromFile(fileDialog.FileName);
            //        pbProductImage.Tag = (new System.IO.FileInfo(fileDialog.FileName)).Name;
            //        lblImageFileName.Text = pbProductImage.Tag.ToString();
            //       // SqlCommand cmd = CommonFuncs.Utilities.getCommand();
            //        cmd.CommandText = "exec SaveBinaryDataToFile @Image, @FileName";
            //        cmd.Parameters.AddWithValue("@Image", System.IO.File.ReadAllBytes(fileDialog.FileName));
            //        cmd.Parameters.AddWithValue("@FileName", imageFolder + "\\" + pbProductImage.Tag.ToString());
            //        cmd.ExecuteNonQuery();
            //    }
            //    catch
            //    {
            //       // MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(601), CommonFuncs.Utilities.MessageUtils.getMessage("Image File Error"));
            //    }
        }

        private void lnkClearImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //pbProductImage.Image = null;
            //lblImageFileName.Text = "";
            //pbProductImage.Tag = DBNull.Value;
        }

        private void lnkBuildCostfromBOM_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //SqlCommand cmd = CommonFuncs.Utilities.getCommand();
            //cmd.CommandText = "select dbo.GetBOMProductCost(@ProductId)";
            //cmd.Parameters.AddWithValue("@ProductId", Convert.ToInt32(lb_productid.Text));
            //object o = cmd.ExecuteScalar();
            //if (o != DBNull.Value)
            //    tb_cost.Text = Convert.ToDecimal(o).ToString(CommonFuncs.ParafaitEnv.INVENTORY_COST_FORMAT);
        }

        private void txtInnerPackQty_Validating(object sender, CancelEventArgs e)
        {
            //try
            //{
            //    double val;
            //    if (txtInnerPackQty.Text != "")
            //        val = Convert.ToDouble(txtInnerPackQty.Text);
            //    txtInnerPackQty.BackColor = Color.White;
            //}
            //catch
            //{
            //    txtInnerPackQty.BackColor = Color.Yellow;
            //    //MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(900), CommonFuncs.Utilities.MessageUtils.getMessage("Cost Unit Validation"));
            //    e.Cancel = true;
            //}
        }

        private void gb_view_Enter(object sender, EventArgs e)
        {
            //TransferToDGV();
        }

        private void EditBOM_Click(object sender, EventArgs e)
        {
            //TreeNode tn = tvBOM.SelectedNode;
            //if (tn != null)
            //{
            //    if (tn.Parent == null)
            //        return;
            //    int localProductId = Convert.ToInt32(tn.Tag);
            //    frm_BOM frm = new frm_BOM(localProductId, Convert.ToInt32(tn.Parent.Tag), tn.Parent.Text);
            //    frm.StartPosition = FormStartPosition.CenterScreen;
            //    frm.ShowDialog();
            //    refreshNode(tn.Parent);
            //}
            //else
            //{
            //    if (tvBOM.Nodes.Count > 0)
            //        tvBOM.SelectedNode = tvBOM.Nodes[0];
            //}
        }

        private void EditProduct_Click(object sender, EventArgs e)
        {
            ////TreeNode tn = tvBOM.SelectedNode;
            //if (tn != null)
            //{
            //    //int localProductId = Convert.ToInt32(tn.Tag);

            //    //tsbClear.PerformClick();

            //    //fillByToolStripButton.PerformClick();
            //    //for (int i = 0; i < view_dgv.Rows.Count; i++)
            //    //{
            //    //    if (Convert.ToInt32(view_dgv["productIdDataGridViewTextBoxColumn", i].Value) == localProductId)
            //    //    {
            //    //        view_dgv.CurrentCell = view_dgv["codeDataGridViewTextBoxColumn", i];
            //    //        break;
            //    //    }
            //    //}
            //}
            //else
            //{
            //    //if (tvBOM.Nodes.Count > 0)
            //    //    tvBOM.SelectedNode = tvBOM.Nodes[0];
            //}
        }

        private void txtLowerCostLimit_Validating(object sender, CancelEventArgs e)
        {
            //try
            //{
            //    double val;
            //    if (txtLowerCostLimit.Text != "")
            //        val = Convert.ToDouble(txtLowerCostLimit.Text);
            //    txtLowerCostLimit.BackColor = Color.White;
            //}
            //catch
            //{
            //    txtLowerCostLimit.BackColor = Color.Yellow;
            //    //MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(901), CommonFuncs.Utilities.MessageUtils.getMessage("Cost Validation"));
            //    e.Cancel = true;
            //}
        }

        private void txtUpperCostLimit_Validating(object sender, CancelEventArgs e)
        {
            //try
            //{
            //    double val;
            //    if (txtUpperCostLimit.Text != "")
            //        val = Convert.ToDouble(txtUpperCostLimit.Text);
            //    txtUpperCostLimit.BackColor = Color.White;
            //}
            //catch
            //{
            //    txtUpperCostLimit.BackColor = Color.Yellow;
            //    //MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(902), CommonFuncs.Utilities.MessageUtils.getMessage("Cost Validation"));
            //    e.Cancel = true;
            //}
        }

        private void txtCostVariancePer_Validating(object sender, CancelEventArgs e)
        {
            //try
            //{
            //    double val;
            //    if (txtCostVariancePer.Text != "")
            //        val = Convert.ToDouble(txtCostVariancePer.Text);
            //    txtCostVariancePer.BackColor = Color.White;
            //}
            //catch
            //{
            //    txtCostVariancePer.BackColor = Color.Yellow;
            //    //MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(903), CommonFuncs.Utilities.MessageUtils.getMessage("Cost Validation"));
            //    e.Cancel = true;
            //}
        }

        private void productCodeToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            //fillByToolStripButton_Click(null, null);
        }

        private void cb_printBOM_Click(object sender, EventArgs e)
        {
            //if (tvBOM.Nodes.Count == 0)
            //    return;
            //PrintHelper print = new PrintHelper();
            //print.PrintTree(this.tvBOM, "Product Bill of Material");
        }

        private void txtTurnInPIT_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
        }

        private void BarcodetoolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            //fillByToolStripButton_Click(null, null);
        }

        private void BarcodetoolStripTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13)
            //    fillByToolStripButton.PerformClick();
        }

        private void btnAddBarCode_Click(object sender, EventArgs e)
        {
            //if (lb_productid.Text != "")
            //{
            //    //Updated frm_addBarcode constructor call to see that product description is passed 19-Apr-2016
            //    //Updated frm_addBarcode constructor call to see that product price is passed 03-Feb-2017
            //    frm_addBarcode f = new frm_addBarcode(Convert.ToInt32(lb_productid.Text), tb_code.Text, tb_description.Text, tb_cost.Text == "" ? -1 : Convert.ToDouble(tb_cost.Text));
            //    CommonDisplay.setupVisuals(f);//Added for GUI Design style on 23-Aug-2016
            //    f.StartPosition = FormStartPosition.CenterScreen;//Added for showing in center on 23-Aug-2016
            //    f.ShowDialog();
            //    this.productBarcodeTableAdapter.Fill(this.redemptionDataSet.ProductBarcode);
            //    CommonFuncs.setSiteIdFilter(productBarcodebindingSource);
            //    btnRefresh.PerformClick();
            //}
            //else
            //{
            //    //02-Jun-2016 Updated to add Message No.
            //    MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(1018), CommonFuncs.Utilities.MessageUtils.getMessage("Add Barcode"));
            //}
            //BarcodeReader.setReceiveAction = serialbarcodeDataReceived;//Added line to fix Barcode scan related issue 31-Mar-2016
            //BarcodetoolStripTextBox.Focus();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // populateProducts(null);
            // refreshDgv();
        }

        //bool segmentsExist()
        //{
        //    try
        //    {
        //        SegmentDefinitionList segmentDefinitionList = new SegmentDefinitionList();
        //        List<SegmentDefinitionDTO> segmentDefinitionDTOList = new List<Semnox.Parafait.SegmentDefinition.SegmentDefinitionDTO>();
        //        List<KeyValuePair<SegmentDefinitionDTO.SearchBySegmentDefinitionParameters, string>> segmentDefinitionSearchParams = new List<KeyValuePair<SegmentDefinitionDTO.SearchBySegmentDefinitionParameters, string>>();
        //        segmentDefinitionSearchParams = new List<KeyValuePair<SegmentDefinitionDTO.SearchBySegmentDefinitionParameters, string>>();
        //        segmentDefinitionSearchParams.Add(new KeyValuePair<SegmentDefinitionDTO.SearchBySegmentDefinitionParameters, string>(SegmentDefinitionDTO.SearchBySegmentDefinitionParameters.IS_ACTIVE, "Y"));
        //        segmentDefinitionDTOList = segmentDefinitionList.GetAllSegmentDefinitions(segmentDefinitionSearchParams);
        //        if (segmentDefinitionDTOList == null)
        //            return false;
        //        else
        //            return true;
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}

        // AdvancedSearch AdvancedSearch;
        //private void tbsAdvancedSearched_Click(object sender, EventArgs e)
        //{
        //    if (AdvancedSearch == null)
        //    {
        //        if (segmentsExist())
        //        {
        //            AdvancedSearch = new Semnox.Core.AdvanceSearch.AdvancedSearch(CommonFuncs.Utilities, "Product", "p");
        //            CommonDisplay.setupVisuals(AdvancedSearch);
        //            AdvancedSearch.StartPosition = FormStartPosition.CenterScreen;
        //        }
        //        else
        //        {
        //            MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(1000));
        //            return;
        //        }
        //    }
        //    if (AdvancedSearch.ShowDialog() == DialogResult.OK)
        //    {
        //        try
        //        {
        //            fillByToolStripButton.PerformClick();
        //        }
        //        catch (SqlException ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}

        private void btnSKUSegments_Click(object sender, EventArgs e)//Starts modification on 22-Apr-2016 for adding segments.
        {
            //if (lb_productid.Text != "")
            //{
            //    segmentCategorizationValueUI = segmentCategorizationValueUI = new SegmentCategorizationValueUI(CommonFuncs.Utilities, CommonFuncs.ParafaitEnv, "Product", Convert.ToInt32(lb_productid.Text), (btnSKUSegments.Tag == null) ? -1 : (int)btnSKUSegments.Tag, tb_description.Text);
            //    CommonDisplay.setupVisuals(segmentCategorizationValueUI);//Added for GUI Design style on 23-Aug-2016
            //    segmentCategorizationValueUI.StartPosition = FormStartPosition.CenterScreen;//Added for showing in center on 23-Aug-2016
            //    segmentCategorizationValueUI.ShowDialog();
            //    populateProducts(null);
            //    //refreshDgv();
            //}
            //else
            //{
            //    //02-Jun-2016 Updated to add Message No.
            //    MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(1017), CommonFuncs.Utilities.MessageUtils.getMessage("Add Segment"));
            //}
        }
        //Ends modification on 22-Apr-2016 for adding segments.

        //Start update 28-Apr-2016
        //Added method to see that top 1 barcode is shown in the screen
        private void view_dgv_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //if (e.Row.Index > -1)
            //{
            //    if (e.Row.Cells["productIdDataGridViewTextBoxColumn"].Value != null && e.Row.Cells["codeDataGridViewTextBoxColumn"].Value != null)
            //    {
            //        if (e.Row.Cells["barCodeDataGridViewTextBoxColumn"].Value == null)
            //        {
            //            SqlCommand cmd = CommonFuncs.Utilities.getCommand();
            //            cmd.CommandText = @"select top 1 barcode
            //                                from (
            //                                  select *, row_number() over(partition by productid order by productid, LastUpdatedDate desc) as num 
            //                                  from productbarcode	
            //                                  where isactive = 'Y' and productid = @productid)v 
            //                                where num = 1";
            //            cmd.Parameters.AddWithValue("@productid", e.Row.Cells["productIdDataGridViewTextBoxColumn"].Value);
            //            object o = cmd.ExecuteScalar();
            //            if (o != null)
            //                e.Row.Cells["barCodeDataGridViewTextBoxColumn"].Value = o.ToString();
            //            else
            //                e.Row.Cells["barCodeDataGridViewTextBoxColumn"].Value = "";
            //        }
            //    }
            //}
        }

        //Start update 29-Apr-2016
        //Added function to enable editing custom attributes
        private void btnCustom_Click(object sender, EventArgs e)
        {
            try
            {
                //if (lb_productid.Text == "")
                //{
                //    //MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(1010), CommonFuncs.Utilities.MessageUtils.getMessage("Add Custom Attributes"));
                //}
                //else
                //{
                //   // CustomDataUI cd;
                //    try
                //    {
                //        //cd = new CustomDataUI("INVPRODUCT", Convert.ToInt32(lb_productid.Text), null);
                //    }
                //    catch
                //    {
                //        return;
                //    }
                //    cd.ShowDialog();
                //    populateProducts(null);
                //    //refreshDgv();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUPCBarcode_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (lb_productid.Text == "")
            //    {
            //        //02-Jun-2016 Updated code to add Message No.
            //       // MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(1009), CommonFuncs.Utilities.MessageUtils.getMessage("Generate UPC Barcode"));
            //    }
            //    else
            //    {
            //        string productCode = "";
            //        long preferredvendor = -1;
            //        string vendorCode = "";
            //        string typeChar = "";
            //        int checkBit = 0;
            //        string UPCCode = "";

            //        try
            //        {
            //            //typeChar = CommonFuncs.Utilities.getParafaitDefaults("UPC_TYPE");
            //            if (string.IsNullOrEmpty(typeChar))
            //            {
            //                //MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(1011), CommonFuncs.Utilities.MessageUtils.getMessage("Generate UPC Barcode"));
            //                return;
            //            }
            //            else if (typeChar.Length > 1 || !typeChar.All(char.IsDigit))
            //            {
            //                //MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(1012), CommonFuncs.Utilities.MessageUtils.getMessage("Generate UPC Barcode"));
            //                return;
            //            }

            //            if (!tb_code.Text.All(char.IsDigit) || tb_code.Text.Length > 5)
            //            {
            //                //MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(1013), CommonFuncs.Utilities.MessageUtils.getMessage("Generate UPC Barcode"));
            //                return;
            //            }

            //            productCode = tb_code.Text.PadLeft(5, '0');

            //            //SqlCommand cmd = CommonFuncs.Utilities.getCommand();
            //            string condition = "";
            //            //if (CommonFuncs.ParafaitEnv.IsCorporate)
            //            //{
            //            //    condition = " and (site_id = @site_id or @site_id = -1)";
            //            //    cmd.Parameters.AddWithValue("@site_id", CommonFuncs.getSiteid());
            //            //}
            //            object o;

            //            if (cb_preferredvendor.Text.Trim() != "")
            //            {
            //                preferredvendor = Convert.ToInt32(cb_preferredvendor.SelectedValue);
            //                //Get vendorcode
            //                //cmd.CommandText = @"select VendorCode from vendor where vendorid = @vendorid";
            //                //cmd.Parameters.AddWithValue("@vendorid", preferredvendor);
            //                //o = cmd.ExecuteScalar();
            //                if (o != null && o != DBNull.Value)
            //                {
            //                    if (!o.ToString().All(char.IsDigit) || o.ToString().Length > 5)
            //                    {
            //                        //MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(1014), CommonFuncs.Utilities.MessageUtils.getMessage("Generate UPC Barcode"));
            //                        return;
            //                    }
            //                    else
            //                    {
            //                        //Left pad vendor code with 0
            //                        vendorCode = o.ToString().PadLeft(5, '0');
            //                    }
            //                }
            //                else
            //                {
            //                    //MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(1014), CommonFuncs.Utilities.MessageUtils.getMessage("Generate UPC Barcode"));
            //                    return;
            //                }
            //            }
            //            else
            //            {
            //                //MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(1015), CommonFuncs.Utilities.MessageUtils.getMessage("Generate UPC Barcode"));
            //                return;
            //            }

            //            //Get check bit (Last digit in barcode)
            //            checkBit = getCheckBit(typeChar, vendorCode, productCode);
            //            UPCCode = typeChar + vendorCode + productCode + checkBit;

            //            //Check for duplicate barcode
            //           // cmd.CommandText = "select ID from productbarcode where BarCode = @BarCode and isactive = 'Y' " + condition; ;
            //           // cmd.Parameters.AddWithValue("@BarCode", UPCCode);

            //           // o = cmd.ExecuteScalar();
            //           // if (o != null)
            //           // {
            //           //     //MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(904), CommonFuncs.Utilities.MessageUtils.getMessage("Generate UPC Barcode"));
            //           //     return;
            //           // }
            //           // //Insert barcode into database
            //           // cmd.CommandText = "insert into productbarcode (barcode, productid, isactive, Lastupdated_userid, site_id, LastUpdatedDate) " +
            //           //                "Values(@barcode,@productid,@isactive,@Lastupdated_userid, @site_id, getdate()) ";
            //           // cmd.Parameters.Clear();
            //           // cmd.Parameters.AddWithValue("@barcode", UPCCode);
            //           // cmd.Parameters.AddWithValue("@productid", lb_productid.Text);
            //           // cmd.Parameters.AddWithValue("@isactive", "Y");
            //           // //cmd.Parameters.AddWithValue("@Lastupdated_userid", CommonFuncs.ParafaitEnv.LoginID);
            //           // //cmd.Parameters.AddWithValue("@site_id", CommonFuncs.getSiteid());
            //           // cmd.ExecuteNonQuery();
            //           //// MessageBox.Show(CommonFuncs.Utilities.MessageUtils.getMessage(1016), CommonFuncs.Utilities.MessageUtils.getMessage("Add Barcode"));
            //           // populateProducts(null);
            //            //refreshDgv(); 
            //        }
            //        catch
            //        {
            //            return;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private int getCheckBit(string typeChar, string vendorCode, string productCode)
        {
            int CheckBit = 0;
            //int sumOddDigits = 0;
            //int sumEvenDigits = 0;

            //string UPCCode = typeChar + vendorCode + productCode;
            //for (int i = 0; i < UPCCode.Length; i++)
            //{
            //    if ((i + 1) % 2 == 0)
            //    {
            //        sumEvenDigits += Convert.ToInt32(UPCCode[i].ToString());
            //    }
            //    else
            //    {
            //        sumOddDigits += Convert.ToInt32(UPCCode[i].ToString());
            //    }
            //}
            //int digitSum = (sumOddDigits * 3) + sumEvenDigits;
            //if (digitSum % 10 != 0)
            //    CheckBit = 10 - (digitSum % 10);
            //else
            //    CheckBit = digitSum % 10;
            return CheckBit;
        }

        private void chkLotControlled_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkLotControlled.Checked)
            //{
            //    cmbExpiryType.Enabled = true;
            //    cmbIssueApproach.Enabled = true;
            //}
            //else
            //{
            //    cmbExpiryType.Enabled = false;
            //    cmbExpiryType.Text = "None";
            //    cmbIssueApproach.Enabled = false;
            //    cmbIssueApproach.Text = "None";
            //}
        }

        private void chkMarketListItem_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkMarketListItem.Checked)
            //{
            //    chkLotControlled.Checked = true;
            //    cmbExpiryType.Enabled = true;
            //    cmbIssueApproach.Enabled = true;
            //}
        }


        private void frm_MaintainProducts_FormClosed(object sender, FormClosedEventArgs e)
        {
            //    foreach (Form child_form in Application.OpenForms)
            //    {
            //        if (child_form.Name == "frm_ProductTabular")
            //        {
            //            child_form.Dispose();
            //            break;
            //        }
            //    }
        }

        private void cmbExpiryType_SelectedIndexChanged(object sender, EventArgs e)

        {
            //    if (cmbExpiryType.Text == "In Days")
            //    {
            //        txtIndays.Visible = true;
            //    }
            //    else
            //    {
            //        txtIndays.Visible = false;
            //    }

            //    ComboBox cmb = (ComboBox)sender;
            //    if (cmb.Focused)
            //    {
            //        string expiryType;
            //        //if (view_dgv.SelectedRows[0] != null)
            //        //    expiryType = view_dgv.SelectedRows[0].Cells["expiryTypeDataGridViewTextBoxColumn"].Value.ToString();
            //        //else
            //        //{
            //        //    if (cmbExpiryType.SelectedItem.ToString() == "Expiry Date")
            //        //        expiryType = "E";
            //        //    else if (cmbExpiryType.SelectedItem.ToString() == "In Days")
            //        //        expiryType = "D";
            //        //    else
            //        //        expiryType = "N";
            //        //}
            //        string selectedValue = cmbExpiryType.SelectedItem.ToString();

            //        if (lb_productid.Text != "")
            //        {
            //            if ((expiryType == "E" || expiryType == "D") && selectedValue == "None")
            //            {
            //                cmbExpiryType.Text = (expiryType == "E" ? "Expiry Date" : "In Days");
            //            }
            //            else if ((expiryType == "N" && cmbIssueApproach.SelectedItem.ToString() == "FIFO") && (selectedValue == "In Days" || selectedValue == "Expiry Date"))
            //                cmbExpiryType.Text = "None";
            //        }
            //        else
            //        {
            //            if (selectedValue == "In Days" || selectedValue == "Expiry Date")
            //            {
            //                chkLotControlled.Checked = true;
            //                cmbIssueApproach.SelectedItem = "FEFO";
            //            }
            //        }
            //    }
        }


        private void lnkPublishToSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //PublishUI publishUI;
            //if (!string.IsNullOrEmpty(lb_productid.Text)&& !string.IsNullOrEmpty(tb_code.Text))
            //{
            //    publishUI = new PublishUI(CommonFuncs.Utilities, Convert.ToInt32(lb_productid.Text), "Product", tb_code.Text);
            //    publishUI.ShowDialog();
            //}
        }


    }
}

