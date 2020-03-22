 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Marbale.Business;
using Marbale.BusinessObject;
using Marble.Business;
using Marbale.BusinessObject.Inventory;
using Marble.Business.InventoryBL;

namespace Marbale.Inventory.Product
{
    public partial class Frm_ProductList : Form
    {
        string filter;

        //List<Product> filterProductListDTO;

        public Frm_ProductList( )
        {
            InitializeComponent();
          
        }


        public Frm_ProductList(string filterText)
        {
            InitializeComponent();
            filter = filterText;
        }

        private void frm_ProductTabular_Load(object sender, EventArgs e)
        {
            
            dgvProducts.BackgroundColor = this.BackColor;
            
            //LoadCategoryCombobox();
            //LoadUOMCombobox();
            ////LoadInOutBoundLocationCombobox();
            //LoadVendorCombobox();
            //LoadTaxCombobox();
            //LoadExpiryType();
             PopulateProductGrid();
        }

        void PopulateProductGrid()
        {
            //lblFilter.Text = string.Empty;

            BindingSource productListBS = new BindingSource();
            InventoryProductBL productBL = new InventoryProductBL();
            List<InventoryProduct> productList;

            List<KeyValuePair<InventoryProduct.SearchByProductParameters, string>> searchParameters = new List<KeyValuePair<InventoryProduct.SearchByProductParameters, string>>();
            searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.IS_ACTIVE, "1"));
            // lblFilter.Text = filter;
            productList = productBL.GetInventoryProductList(searchParameters);

            if (productList != null)
            {
                productListBS.DataSource = productList;
            }
            else
            {
                productListBS.DataSource = new List<InventoryProduct>();
            }

            dgvProducts.DataSource = productListBS;
        }

        void LoadCategoryCombobox()
        {
            CategoryBL categoryBL = new CategoryBL();
            List<Category> lstCategory = categoryBL.GetCategory();

            if (lstCategory == null)
                lstCategory = new List<Category>();

            lstCategory.Insert(0, new Category());
            lstCategory[0].CategoryName = "None";
            lstCategory[0].CategoryId = -1;

            categoryIdDataGridViewTextBoxColumn.DataSource = lstCategory;
            categoryIdDataGridViewTextBoxColumn.DisplayMember = "CategoryName";
            categoryIdDataGridViewTextBoxColumn.ValueMember = "CategoryId";
        }

        void LoadUOMCombobox()
        {
            UnitOfMeasureBL uomBL = new UnitOfMeasureBL();
            List<UnitOfMeasure> lstUom = uomBL.GetUom();

            if (lstUom == null)
                lstUom = new List<UnitOfMeasure>();

            lstUom.Insert(0, new UnitOfMeasure());
            lstUom[0].UomName = "None";
            lstUom[0].UOMId = -1;
            uomIdDataGridViewTextBoxColumn.DataSource = lstUom;
            uomIdDataGridViewTextBoxColumn.DisplayMember = "UomName";
            uomIdDataGridViewTextBoxColumn.ValueMember = "UOMId";
        }

        void LoadLocationCombobox()
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
            defaultLocationIdDataGridViewTextBoxColumn.DataSource = lstLocation;
            defaultLocationIdDataGridViewTextBoxColumn.DisplayMember = "LocationName";
            defaultLocationIdDataGridViewTextBoxColumn.ValueMember = "LocationId";

            //outBoundLocationDTOList = locationList.GetAllLocations(locationDTOSearchParams);
            //if (outBoundLocationDTOList == null)
            //{
            //    outBoundLocationDTOList = new List<LocationDTO>();
            //}
            //outBoundLocationDTOList.Insert(0, new LocationDTO());
            //outBoundLocationDTOList[0].Name = "None";
            outboundLocationIdDataGridViewTextBoxColumn.DataSource = locationBS;
            outboundLocationIdDataGridViewTextBoxColumn.DisplayMember = "Name";
            outboundLocationIdDataGridViewTextBoxColumn.ValueMember = "LocationId";


            
        }

        void LoadVendorCombobox()
        {
            VendorBL vendorBl = new VendorBL();
            List<KeyValuePair<Vendor.SearchByVendorParameters, string>> searchParameters = new List<KeyValuePair<Vendor.SearchByVendorParameters, string>>();
            searchParameters.Add(new KeyValuePair<Vendor.SearchByVendorParameters, string>(Vendor.SearchByVendorParameters.IS_ACTIVE, "1"));

            List<Vendor> lstVendor = vendorBl.GetVendorList(searchParameters);

            if (lstVendor == null)
                lstVendor = new List<Vendor>();

            lstVendor.Insert(0, new Vendor());
            lstVendor[0].VendorName = "None";
            lstVendor[0].VendorId = -1;

            defaultVendorIdDataGridViewTextBoxColumn.DataSource = lstVendor;
            defaultVendorIdDataGridViewTextBoxColumn.DisplayMember = "VendorName";
            defaultVendorIdDataGridViewTextBoxColumn.ValueMember = "VendorId";
        }

        void LoadTaxCombobox()
        {
            PurchaseTaxBL taxBL = new PurchaseTaxBL();
            List<KeyValuePair<PurchaseTax.SearchByTaxParameters, string>> taxSearchParams = new List<KeyValuePair<PurchaseTax.SearchByTaxParameters, string>>();
            taxSearchParams.Add(new KeyValuePair<PurchaseTax.SearchByTaxParameters, string>(PurchaseTax.SearchByTaxParameters.IS_ACTIVE, "1"));

            List<PurchaseTax> ListTax = taxBL.GetTaxList(taxSearchParams);


            if (ListTax == null)
            {
                ListTax = new List<PurchaseTax>();
            }

            ListTax.Insert(0, new PurchaseTax());
            ListTax[0].TaxName = "None";

            taxIdDataGridViewTextBoxColumn.DataSource = ListTax;
            taxIdDataGridViewTextBoxColumn.ValueMember = "TaxId";
            taxIdDataGridViewTextBoxColumn.DisplayMember = "TaxName";

            //List<KeyValuePair<TaxDTO.SearchByTaxParameters, string>> taxListSearchParams = new List<KeyValuePair<TaxDTO.SearchByTaxParameters, string>>();

            //TaxList taxlist = new TaxList();
            //List<TaxDTO> taxListOnDisplay = taxlist.GetAllTaxes();

            //if (taxListOnDisplay == null)
            //    taxListOnDisplay = new List<TaxDTO>();

            //taxListOnDisplay.Insert(0, new TaxDTO());
            //taxListOnDisplay[0].TaxId = -1;
            //taxListOnDisplay[0].TaxName = "None";
            //taxIdDataGridViewTextBoxColumn.DataSource = taxListOnDisplay;
            //taxIdDataGridViewTextBoxColumn.DisplayMember = "TaxName";
            //taxIdDataGridViewTextBoxColumn.ValueMember = "TaxId";
        }

        void LoadExpiryType()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Type");
            dt.Columns.Add("ExpiryName");
            dt.Rows.Add("N", "None");
            dt.Rows.Add("D", "In Days");
            dt.Rows.Add("E", "Expiry Date");
            expiryTypeDataGridViewTextBoxColumn.DataSource = dt;
            expiryTypeDataGridViewTextBoxColumn.ValueMember = "Type";
            expiryTypeDataGridViewTextBoxColumn.DisplayMember = "ExpiryName";
        }

        private void dgvProducts_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            //e.Row.Cells["isSellableDataGridViewTextBoxColumn"].Value = "Y";
            //e.Row.Cells["isRedeemableDataGridViewTextBoxColumn"].Value = "Y";
            //e.Row.Cells["isActiveDataGridViewTextBoxColumn"].Value = "Y";
            //e.Row.Cells["isPurchaseableDataGridViewTextBoxColumn"].Value = "Y";
            //e.Row.Cells["innerPackQtyDataGridViewTextBoxColumn"].Value = 1;
            //e.Row.Cells["costDataGridViewTextBoxColumn"].Value = 0;
            //e.Row.Cells["salePriceDataGridViewTextBoxColumn"].Value = 0;
            //e.Row.Cells["reorderPointDataGridViewTextBoxColumn"].Value = 0;
            //e.Row.Cells["reorderQuantityDataGridViewTextBoxColumn"].Value = 1;

            //e.Row.Cells["expiryTypeDataGridViewTextBoxColumn"].Value = "N";
            //e.Row.Cells["issuingApproachDataGridViewTextBoxColumn"].Value = "None";
            //e.Row.Cells["taxInclusiveCostDataGridViewTextBoxColumn"].Value = "N";

        }

        private void dgvProducts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                
                MessageBox.Show("Error in Product grid data at row " + (e.RowIndex + 1).ToString() + ", Column " + dgvProducts.Columns[e.ColumnIndex].DataPropertyName +
                ": " + e.Exception.Message);
                e.Cancel = true;

            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Product productBL;
            //try
            //{
            //    BindingSource productBS = (BindingSource)dgvProducts.DataSource;
            //    var productList= (List<Product>)productBS.DataSource;

            //    foreach (Product d in productList)
            //    {
            //        if (d.IsChanged)
            //        {
            //            //Start update 23-Feb-2017
            //            if (d.LotControlled && d.IssuingApproach == "None")
            //            {
            //                if (d.ExpiryType == "E" || d.ExpiryType == "D")
            //                    d.IssuingApproach = "FEFO";
            //                else
            //                    d.IssuingApproach = "FIFO";
            //            }
            //            //End update 23-Feb-2017
            //            productBL = new Product(d);
            //            productBL.Save();
            //            //Start update 23-Feb-2017
            //            if (d.LotControlled && d.IssuingApproach == "FIFO")
            //            {
            //                Semnox.Parafait.InventoryLot.InventoryLotBL inventoryLot = new Semnox.Parafait.InventoryLot.InventoryLotBL();
            //                inventoryLot.UpdateNonLotableToLotable(d.ProductId, null);
            //            }
            //            //End update 23-Feb-2017
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            PopulateProductGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                dgvProducts.CurrentRow.Cells["isActiveDataGridViewTextBoxColumn"].Value = "N";
                //dgvProducts.Rows.Remove(dgvProducts.CurrentRow);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            bool saverequired = false;
            bool isChanged = false;

            try
            {
                BindingSource productBS = (BindingSource)dgvProducts.DataSource;
                var productListOnDisplay = (List<InventoryProduct>)productBS.DataSource;

                foreach (InventoryProduct d in productListOnDisplay)
                {
                    if (d.IsChanged == true)
                    {
                        isChanged = true;
                        break;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (isChanged)
            {
                DialogResult DR = MessageBox.Show("Do you want save", "Save", MessageBoxButtons.YesNoCancel);
                switch (DR)
                {
                    case DialogResult.Yes: saverequired = true; break;
                    case DialogResult.No: break;
                    case DialogResult.Cancel: return;
                    default: break;
                }
            }

            if (saverequired)
            {
                if (!ValidateChildren())
                    return;
                btnSave.PerformClick();
            }

            PopulateProductGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            bool saverequired = false;
            bool isChanged = false;
            try
            {
                BindingSource productBS = (BindingSource)dgvProducts.DataSource;
                var productListOnDisplay = (List<InventoryProduct>)productBS.DataSource;

                foreach (InventoryProduct d in productListOnDisplay)
                {
                    if (d.IsChanged == true)
                    {
                        isChanged = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (isChanged)
            {
                DialogResult DR = MessageBox.Show("Do you want save", "Save", MessageBoxButtons.YesNoCancel);
                switch (DR)
                {
                    case DialogResult.Yes: saverequired = true; break;
                    case DialogResult.No: break;
                    case DialogResult.Cancel: return;
                    default: break;
                }
            }

            if (saverequired)
            {
                if (!ValidateChildren())
                    return;
                btnSave.PerformClick();
            }

            this.Close();
        }

        //private void dgvProducts_CellEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (dgvProducts.Columns[e.ColumnIndex].DataPropertyName == "Code")
        //    {
        //        CurrencyManager xCM = (CurrencyManager)dgvProducts.BindingContext[dgvProducts.DataSource, dgvProducts.DataMember];
        //        if (xCM.Count <= 0) return;

        //        try
        //        {
        //            if (dgvProducts["codeDataGridViewTextBoxColumn", e.RowIndex].Value == null ||
        //                Convert.ToInt32(dgvProducts["codeDataGridViewTextBoxColumn", e.RowIndex].Value) == -1)
        //            {
        //                dgvProducts["codeDataGridViewTextBoxColumn", e.RowIndex].ReadOnly = false;
        //            }
        //            else
        //            {
        //                dgvProducts["codeDataGridViewTextBoxColumn", e.RowIndex].ReadOnly = true;
        //            }
        //        }

        //        catch { }
        //    }
        //}

        private void dgvProducts_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //if ((!dgvProducts.Rows[e.RowIndex].IsNewRow && dgvProducts["uomIdDataGridViewTextBoxColumn", e.RowIndex].Value.ToString() == "-1"))
            //{
            //    MessageBox.Show("Error", "Validation");
            //    e.Cancel = true;
            //}

            //else if (!dgvProducts.Rows[e.RowIndex].IsNewRow && dgvProducts["codeDataGridViewTextBoxColumn", e.RowIndex].Value == null || dgvProducts["codeDataGridViewTextBoxColumn", e.RowIndex].Value == DBNull.Value)
            //{
            //    MessageBox.Show("Error", "Validation");
            //    e.Cancel = true;
            //}

            //else if (!dgvProducts.Rows[e.RowIndex].IsNewRow && dgvProducts["categoryIdDataGridViewTextBoxColumn", e.RowIndex].Value.ToString() == "-1")
            //{
            //    MessageBox.Show("Error", "Validation");
            //    e.Cancel = true;
            //}

            //else if (!dgvProducts.Rows[e.RowIndex].IsNewRow && dgvProducts["defaultLocationIdDataGridViewTextBoxColumn", e.RowIndex].Value.ToString() == "-1")
            //{
            //    MessageBox.Show("Error", "Validation");
            //    e.Cancel = true;
            //}

            //else if (!dgvProducts.Rows[e.RowIndex].IsNewRow && dgvProducts["outboundLocationIdDataGridViewTextBoxColumn", e.RowIndex].Value.ToString() == "-1")
            //{
            //    MessageBox.Show("Error", "Validation");
            //    e.Cancel = true;
            //}

        }

        private void chkShowall_CheckedChanged(object sender, EventArgs e)
        {
            PopulateProductGrid();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProducts.Columns[e.ColumnIndex].Name == "ProductBarCode")
                {
                    if (dgvProducts["productIdDataGridViewTextBoxColumn", e.RowIndex].Value != null && dgvProducts["codeDataGridViewTextBoxColumn", e.RowIndex].Value != null)
                    {
                    }
                    
                }
                
               // btnRefresh.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvProducts_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //if (e.Row.Index > -1)
            //{
            //    if (e.Row.Cells["productIdDataGridViewTextBoxColumn"].Value != null && e.Row.Cells["codeDataGridViewTextBoxColumn"].Value != null)
            //    {
            //        if (e.Row.Cells["BarCode"].Value == null)
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
            //                e.Row.Cells["BarCode"].Value = o.ToString();
            //            else
            //                e.Row.Cells["BarCode"].Value = "";
            //        }
            //    }
            //}
        }

        private void frm_ProductTabular_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void productCodeToolStripTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void DescriptiontoolStripTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void BarcodetoolStripTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void tbsAdvancedSearched_Click(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            Frm_AddProduct frm_AddProduct = new Frm_AddProduct(-1);
            frm_AddProduct.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            
            int pid = -1;
            int.TryParse( dgvProducts.CurrentRow.Cells["ProductId"].Value.ToString(),  out pid);

            Frm_AddProduct frm_AddProduct = new Frm_AddProduct(pid);
            frm_AddProduct.ShowDialog();

        }
    }
}
