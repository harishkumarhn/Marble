
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

        public Frm_ProductList()
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

            LoadCategoryCombobox();
            LoadUOMCombobox();
            LoadLocationCombobox();
            LoadVendorCombobox();
            LoadTaxCombobox();
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

            if (!string.IsNullOrEmpty(txt_searchCode.Text))
            {
                searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.PRODUCT_CODE, txt_searchCode.Text));
            }
            if (!string.IsNullOrEmpty(txt_searchProdName.Text))
            {
                searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.PRODUCT_NAME, txt_searchProdName.Text));
            }

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

            drpDataGridViewCategoryId.DataSource = lstCategory;
            drpDataGridViewCategoryId.DisplayMember = "CategoryName";
            drpDataGridViewCategoryId.ValueMember = "CategoryId";
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
            drpDataGridViewUomId.DataSource = lstUom;
            drpDataGridViewUomId.DisplayMember = "UomName";
            drpDataGridViewUomId.ValueMember = "UOMId";
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
            drpDataGridViewInnerLocationId.DataSource = lstLocation;
            drpDataGridViewInnerLocationId.DisplayMember = "LocationName";
            drpDataGridViewInnerLocationId.ValueMember = "LocationId";


            drpDataGridViewOutboundLocationId.DataSource = lstLocation;
            drpDataGridViewOutboundLocationId.DisplayMember = "LocationName";
            drpDataGridViewOutboundLocationId.ValueMember = "LocationId";



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

            drpDataGridViewVendorId.DataSource = lstVendor;
            drpDataGridViewVendorId.DisplayMember = "VendorName";
            drpDataGridViewVendorId.ValueMember = "VendorId";
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

            drpDataGridViewTaxId.DataSource = ListTax;
            drpDataGridViewTaxId.ValueMember = "TaxId";
            drpDataGridViewTaxId.DisplayMember = "TaxName";


        }

        //void LoadExpiryType()
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Type");
        //    dt.Columns.Add("ExpiryName");
        //    dt.Rows.Add("N", "None");
        //    dt.Rows.Add("D", "In Days");
        //    dt.Rows.Add("E", "Expiry Date");
        //    expiryTypeDataGridViewTextBoxColumn.DataSource = dt;
        //    expiryTypeDataGridViewTextBoxColumn.ValueMember = "Type";
        //    expiryTypeDataGridViewTextBoxColumn.DisplayMember = "ExpiryName";
        //}

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

                //MessageBox.Show("Error in Product grid data at row " + (e.RowIndex + 1).ToString() + ", Column " + dgvProducts.Columns[e.ColumnIndex].DataPropertyName +
                //": " + e.Exception.Message);
                e.Cancel = true;

            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            PopulateProductGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                InventoryProduct currentObject = (InventoryProduct)dgvProducts.CurrentRow.DataBoundItem;

                var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    currentObject.IsActive = false;
                    InventoryProductBL inventoryProductBL = new InventoryProductBL();
                    int id = inventoryProductBL.Save(currentObject, "rakshith");

                    dgvProducts.Rows.Remove(dgvProducts.CurrentRow);

                }


                //dgvProducts.CurrentRow.Cells["isActiveDataGridViewTextBoxColumn"].Value = "N";
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



        private void dgvProducts_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {


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

            Frm_AddProduct frm_AddProduct = new Frm_AddProduct(-1, "");
            frm_AddProduct.ShowDialog();
            PopulateProductGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {


            int pid = -1;
            int.TryParse(dgvProducts.CurrentRow.Cells["ProductId"].Value.ToString(), out pid);

            Frm_AddProduct frm_AddProduct = new Frm_AddProduct(pid, "");
            frm_AddProduct.ShowDialog();
            PopulateProductGrid();

        }

        private void Btn_Duplicate_Click(object sender, EventArgs e)
        {
            int pid = -1;
            int.TryParse(dgvProducts.CurrentRow.Cells["ProductId"].Value.ToString(), out pid);
            Frm_AddProduct frm_AddProduct = new Frm_AddProduct(pid, "duplicate");
            frm_AddProduct.ShowDialog();
            PopulateProductGrid();
        }

        private void btn_searchStrip_Click(object sender, EventArgs e)
        {
            PopulateProductGrid();
        }
    }
}
