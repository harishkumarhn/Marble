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
            PoupulateVendorGrid();
        }

        void PoupulateVendorGrid()
        {
            VendorBL vendorBl = new VendorBL();
            List<Vendor> lstVendor = vendorBl.GetVendor();

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


        private void dgvVendor_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVendor.DataSource != null && dgvVendor.SelectedRows.Count == 1)
            {
                txtVendorId.Text = dgvVendor.CurrentRow.Cells["VendorId"].Value.ToString();
                txtVendorName.Text = dgvVendor.CurrentRow.Cells["VendorName"].Value.ToString();
                txtAddressLine1.Text = dgvVendor.CurrentRow.Cells["AddressLine1"].Value.ToString();
                txtAddressLine2.Text = dgvVendor.CurrentRow.Cells["AddressLine2"].Value.ToString();
                txtCode.Text = dgvVendor.CurrentRow.Cells["Code"].Value.ToString();
                txtRemarks.Text = dgvVendor.CurrentRow.Cells["Remarks"].Value.ToString();
                txtCity.Text = dgvVendor.CurrentRow.Cells["City"].Value.ToString();
                txtState.Text = dgvVendor.CurrentRow.Cells["State"].Value.ToString();
                txtCountry.Text = dgvVendor.CurrentRow.Cells["Country"].Value.ToString();
                txtContactPerson.Text = dgvVendor.CurrentRow.Cells["ContactName"].Value.ToString();
                txtPhoneNo.Text = dgvVendor.CurrentRow.Cells["Phone"].Value.ToString();
                txtEmailId.Text = dgvVendor.CurrentRow.Cells["Email"].Value.ToString();
                txtWebsite.Text = dgvVendor.CurrentRow.Cells["Website"].Value.ToString();
                chkActive.Checked = Convert.ToBoolean(dgvVendor.CurrentRow.Cells["IsActive"].Value);
            }
        }

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

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
