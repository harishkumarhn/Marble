using Marbale.BusinessObject.Inventory;
using Marbale.DataAccess;
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
    public partial class frmTax : Form
    {
        public frmTax()
        {
            InitializeComponent();
        }

         
        void PopulateTaxGrid()
        {
            PurchaseTaxBL taxBL = new PurchaseTaxBL();

          
            List<KeyValuePair<PurchaseTax.SearchByTaxParameters, string>> taxSearchParams = new List<KeyValuePair<PurchaseTax.SearchByTaxParameters, string>>();
            taxSearchParams.Add(new KeyValuePair<PurchaseTax.SearchByTaxParameters, string>(PurchaseTax.SearchByTaxParameters.IS_ACTIVE, "1"));

            List<PurchaseTax> ListTax = taxBL.GetTaxList(taxSearchParams);

            
            BindingSource BSobj = new BindingSource();
            if (ListTax != null)
                BSobj.DataSource = new SortableBindingList<PurchaseTax>(ListTax);
            else
            {
                BSobj.DataSource = new SortableBindingList<PurchaseTax>();
            }
            dgvTax.DataSource = BSobj;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                PurchaseTaxBL taxBL = new PurchaseTaxBL();
                BindingSource taxListBS = (BindingSource)dgvTax.DataSource;
                var taxList = (SortableBindingList<PurchaseTax>)taxListBS.DataSource;
                if (taxList.Count > 0)
                {
                    foreach (PurchaseTax tax in taxList)
                    {
                        if (tax.IsChanged)
                        {

                            if (string.IsNullOrEmpty(tax.TaxName))
                            {
                                MessageBox.Show("Please enter the Tax Name");
                                return;
                            }
                            taxBL.Save(tax, "rakshith");
                        }
                        //else
                        //{
                        //    MessageBox.Show("nothing to Save");
                        //}
                    }
                    PopulateTaxGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmTax_Load(object sender, EventArgs e)
        {
            PopulateTaxGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvTax.SelectedRows.Count <= 0 && this.dgvTax.SelectedCells.Count <= 0)
                {
                    MessageBox.Show("No record selected");
                    return;
                }

                if (this.dgvTax.SelectedCells.Count > 0)
                {
                    foreach (DataGridViewCell cell in this.dgvTax.SelectedCells)
                    {
                        dgvTax.Rows[cell.RowIndex].Selected = true;
                    }
                }
                foreach (DataGridViewRow row in this.dgvTax.SelectedRows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (Convert.ToInt32(row.Cells[0].Value) < 0)
                        {
                            dgvTax.Rows.RemoveAt(row.Index);
                        }
                        else
                        {
                            if ((MessageBox.Show("Do you wany to Delete", "Confirm Inactivation.", MessageBoxButtons.YesNo) == DialogResult.Yes))
                            {
                                BindingSource ListBS = (BindingSource)dgvTax.DataSource;
                                var datalist = (SortableBindingList<PurchaseTax>)ListBS.DataSource;
                                PurchaseTax objitem = datalist[row.Index];
                                objitem.IsActive = false;
                                PurchaseTaxBL blObj = new PurchaseTaxBL();
                                blObj.Save(objitem, "rakshith");
                            }
                        }
                    }
                }
                PopulateTaxGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateTaxGrid();
        }
    }
}
