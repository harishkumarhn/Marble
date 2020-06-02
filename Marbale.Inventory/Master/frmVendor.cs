using Marbale.BusinessObject.Inventory;
using Marble.Business;
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

namespace Marbale.Inventory.Master
{
    public partial class frmVendor : Form
    {
        public frmVendor()
        {
            InitializeComponent();
        }

        private void frmVendor_Load(object sender, EventArgs e)
        {
            PopulateVendorGrid();
        }

        void PopulateVendorGrid()
        {
            VendorBL vendorBl = new VendorBL();
            List<KeyValuePair<Vendor.SearchByVendorParameters, string>> searchParameters = new List<KeyValuePair<Vendor.SearchByVendorParameters, string>>();
            searchParameters.Add(new KeyValuePair<Vendor.SearchByVendorParameters, string>(Vendor.SearchByVendorParameters.IS_ACTIVE, "1"));

            List<Vendor> lstVendor = vendorBl.GetVendorList(searchParameters);

            BindingSource vendorListBS = new BindingSource();

            if (lstVendor != null && lstVendor.Count > 0)
            {
                vendorListBS.DataSource = lstVendor;
            }
            else
            {
                vendorListBS.DataSource = new List<Vendor>();
            }
            dgvVendor.DataSource = vendorListBS;
        }


        //private void dgvVendor_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dgvVendor.DataSource != null && dgvVendor.SelectedRows.Count == 1)
        //    {
        //        txtVendorId.Text = dgvVendor.CurrentRow.Cells["VendorId"].Value.ToString();
        //        txtVendorName.Text = dgvVendor.CurrentRow.Cells["VendorName"].Value.ToString();
        //        txtAddressLine1.Text = dgvVendor.CurrentRow.Cells["AddressLine1"].Value.ToString();
        //        txtAddressLine2.Text = dgvVendor.CurrentRow.Cells["AddressLine2"].Value.ToString();
        //        txtCode.Text = dgvVendor.CurrentRow.Cells["Code"].Value.ToString();
        //        txtRemarks.Text = dgvVendor.CurrentRow.Cells["Remarks"].Value.ToString();
        //        txtCity.Text = dgvVendor.CurrentRow.Cells["City"].Value.ToString();
        //        txtState.Text = dgvVendor.CurrentRow.Cells["State"].Value.ToString();
        //        txtCountry.Text = dgvVendor.CurrentRow.Cells["Country"].Value.ToString();
        //        txtContactPerson.Text = dgvVendor.CurrentRow.Cells["ContactName"].Value.ToString();
        //        txtPhoneNo.Text = dgvVendor.CurrentRow.Cells["Phone"].Value.ToString();
        //        txtEmailId.Text = dgvVendor.CurrentRow.Cells["Email"].Value.ToString();
        //        txtWebsite.Text = dgvVendor.CurrentRow.Cells["Website"].Value.ToString();
        //        chkActive.Checked = Convert.ToBoolean(dgvVendor.CurrentRow.Cells["IsActive"].Value);
        //    }
        //}

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        void ClearControls()
        {
            txtVendorId.Text = string.Empty;
            txtVendorName.Text = string.Empty;
            txtAddressLine1.Text = string.Empty;
            txtAddressLine2.Text = string.Empty;
            txtCode.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtState.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtContactPerson.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            txtEmailId.Text = string.Empty;
            txtWebsite.Text = string.Empty;
            chkActive.Checked = true;
            txtPostalCode.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool Validate()
        {
            if (txtVendorName.Text == "")
            {
                MessageBox.Show(" Vendor name Required");
                txtVendorName.Focus();
                return false;
            }

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    Vendor vendor = new Vendor();
                    vendor.VendorName = txtVendorName.Text;
                    vendor.Code = txtCode.Text;
                    vendor.AddressLine1 = txtAddressLine1.Text;
                    vendor.AddressLine2 = txtAddressLine2.Text;
                    vendor.Remarks = txtRemarks.Text;
                    vendor.City = txtCity.Text;
                    //vendor.State = ddlState.Text;
                    //vendor.Country = ddlCountry.Text;
                    vendor.PostalCode = txtPostalCode.Text;
                    //vendor.AddressRemarks = txtRemarks.Text;
                    vendor.ContactName = txtContactPerson.Text;
                    vendor.Phone = txtPhoneNo.Text;
                    vendor.Email = txtEmailId.Text;
                    vendor.IsActive = chkActive.Checked;
                    vendor.Website = txtWebsite.Text;

                    VendorBL vendorBL = new VendorBL();
                    int vendorId = vendorBL.Save(vendor, "rakshith");
                    vendor.VendorId = vendorId;
                    MessageBox.Show("Saved successfully");
                    // ResetFields();
                    //refreshDgv();
                    PopulateVendorGrid();
                    ClearControls();
                    DataGridViewRow row = dgvVendor.Rows.Cast<DataGridViewRow>()
                                         .Where(r => r.Cells["VendorId"].Value.ToString().Equals(vendorId.ToString()))
                                          .First();
                    if (row.Index >= 0)
                    {
                        dgvVendor.Rows[row.Index].Selected = true;
                        dgvVendor.CurrentCell = dgvVendor.Rows[row.Index].Cells["vendorname"];
                        dgvVendor.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {

                
            }
       
        }

         
        //private void ResetFields()
        //{
        //    txtVendorName.Text = "";
        //    txtCode.Text = "";
        //    txtAddressLine1.Text = "";
        //    txtAddressLine2.Text = "";
        //    txtRemarks.Text = "";
        //    txtCity.Text = "";
        //    //vendor.State = ddlState.Text= "";
        //    //vendor.Country = ddlCountry.Text= "";
        //    txtPostalCode.Text = "";
        //    //vendor.AddressRemarks = txtRemarks.Text= "";
        //    txtContactPerson.Text = "";
        //    txtPhoneNo.Text = "";
        //    txtEmailId.Text = "";
        //    chkActive.Checked = false;
        //    txtWebsite.Text = "";


        //}

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<Vendor.SearchByVendorParameters, string>> searchParameters = new List<KeyValuePair<Vendor.SearchByVendorParameters, string>>();
            searchParameters.Add(new KeyValuePair<Vendor.SearchByVendorParameters, string>(Vendor.SearchByVendorParameters.IS_ACTIVE, "1"));
            VendorBL vendorBl = new VendorBL();
            if (!string.IsNullOrEmpty( txtVendorNameSearch.Text))
            {
                searchParameters.Add(new KeyValuePair<Vendor.SearchByVendorParameters, string>(Vendor.SearchByVendorParameters.VENDOR_NAME, txtVendorNameSearch.Text));
            }
            if (!string.IsNullOrEmpty(txtVendorCodeSearch.Text))
            {
                searchParameters.Add(new KeyValuePair<Vendor.SearchByVendorParameters, string>(Vendor.SearchByVendorParameters.VENDOR_CODE, txtVendorCodeSearch.Text));
            }

            List<Vendor> lstVendor = vendorBl.GetVendorList(searchParameters);

            BindingSource vendorListBS = new BindingSource();

            if (lstVendor != null && lstVendor.Count > 0)
            {
                vendorListBS.DataSource = lstVendor;
            }
            else
            {
                vendorListBS.DataSource = new List<Vendor>();
            }
            dgvVendor.DataSource = vendorListBS;
        }

        private void dgvVendor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LoadRowData(e.RowIndex);
            }
        }

        private void LoadRowData(int rowindex)
        {
            txtVendorId.Text = dgvVendor.Rows[rowindex].Cells["VendorID"].Value.ToString();
            txtVendorName.Text = dgvVendor.Rows[rowindex].Cells["vendorname"].Value.ToString();
            txtRemarks.Text = dgvVendor.Rows[rowindex].Cells["Remarks"].Value.ToString();
            txtAddressLine1.Text = dgvVendor.Rows[rowindex].Cells["AddressLine1"].Value.ToString();
            txtAddressLine2.Text = dgvVendor.Rows[rowindex].Cells["AddressLine2"].Value.ToString();
            txtCity.Text = dgvVendor.Rows[rowindex].Cells["City"].Value.ToString();
            txtState.Text = dgvVendor.Rows[rowindex].Cells["State"].Value.ToString();
            txtCountry.Text = dgvVendor.Rows[rowindex].Cells["Country"].Value.ToString();
            txtPostalCode.Text = dgvVendor.Rows[rowindex].Cells["PostalCode"].Value.ToString();
            txtContactPerson.Text = dgvVendor.Rows[rowindex].Cells["ContactName"].Value.ToString();
            txtPhoneNo.Text = dgvVendor.Rows[rowindex].Cells["Phone"].Value.ToString();
            txtEmailId.Text = dgvVendor.Rows[rowindex].Cells["Email"].Value.ToString();
            chkActive.Text = dgvVendor.Rows[rowindex].Cells["IsActive"].Value.ToString();
            txtWebsite.Text = dgvVendor.Rows[rowindex].Cells["Website"].Value.ToString();
            txtCode.Text = dgvVendor.Rows[rowindex].Cells["Code"].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvVendor.CurrentRow!=null && dgvVendor.CurrentRow.Cells["VendorID"].Value.ToString()!="")
            {

                try
                {
                    int Vendorid = Convert.ToInt32(dgvVendor.CurrentRow.Cells["VendorID"].Value.ToString());
                    if (Vendorid > 0)
                    {
                        List<KeyValuePair<Vendor.SearchByVendorParameters, string>> searchParameters = new List<KeyValuePair<Vendor.SearchByVendorParameters, string>>();
                        searchParameters.Add(new KeyValuePair<Vendor.SearchByVendorParameters, string>(Vendor.SearchByVendorParameters.VENDOR_ID, Vendorid.ToString()));
                        VendorBL vendorBl = new VendorBL();
                        List<Vendor> lstVendor = vendorBl.GetVendorList(searchParameters);
                        if (lstVendor != null && lstVendor.Count == 1)
                        {
                            Vendor vendor = lstVendor.FirstOrDefault();
                            vendor.IsActive = false;
                            vendorBl.Save(vendor, "rakshith");
                            MessageBox.Show("Delete successfully");
                            PopulateVendorGrid();
                        }
                        else
                        {
                            MessageBox.Show("Unable delete");
                        }

                    }
                }
                catch (Exception ex )
                {
                    MessageBox.Show(" Error Occured");
                }
               
            }
             
        }
    }
}
