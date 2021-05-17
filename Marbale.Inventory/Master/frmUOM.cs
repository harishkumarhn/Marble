using Marbale.BusinessObject.Inventory;
using Marble.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Marbale.DataAccess;
using Marble.Business.InventoryBL;

namespace Marbale.Inventory.Master
{
    public partial class frmUOM : Form
    {
        public frmUOM()
        {
            InitializeComponent();
        }


        private void frmUOM_Load(object sender, EventArgs e)
        {
            PopulateUOMGrid();
        }

        void PopulateUOMGrid()
        {
            UnitOfMeasureBL uomBL = new UnitOfMeasureBL();
            List<UnitOfMeasure> lstUom = uomBL.GetUom();

            BindingSource  BSobj = new BindingSource();
            if (BSobj != null)
                BSobj.DataSource = new SortableBindingList<UnitOfMeasure>(lstUom);
            else
            {
                BSobj.DataSource = new SortableBindingList<UnitOfMeasure>();
            }
            dgvUOM.DataSource = BSobj;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateUOMGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvUOM.SelectedRows.Count <= 0 && this.dgvUOM.SelectedCells.Count <= 0)
                {
                    MessageBox.Show("No record selected");
                    return;
                }

                if (this.dgvUOM.SelectedCells.Count > 0)
                {
                    foreach (DataGridViewCell cell in this.dgvUOM.SelectedCells)
                    {
                        dgvUOM.Rows[cell.RowIndex].Selected = true;
                    }
                }
                foreach (DataGridViewRow row in this.dgvUOM.SelectedRows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (Convert.ToInt32(row.Cells[0].Value) < 0)
                        {
                            dgvUOM.Rows.RemoveAt(row.Index);
                        }
                        else
                        {
                            if ((MessageBox.Show("Do you wany to Delete", "Confirm Inactivation.", MessageBoxButtons.YesNo) == DialogResult.Yes))
                            {
                                BindingSource ListBS = (BindingSource)dgvUOM.DataSource;
                                var datalist = (SortableBindingList<UnitOfMeasure>)ListBS.DataSource;
                                UnitOfMeasure objitem = datalist[row.Index];
                                objitem.IsActive = false;
                                UnitOfMeasureBL blObj = new UnitOfMeasureBL();
                                blObj.Save(objitem, "rakshith");
                            }
                        }
                    }
                }
                PopulateUOMGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UnitOfMeasureBL uomBL = new UnitOfMeasureBL();
                BindingSource locationTypeListBS = (BindingSource)dgvUOM.DataSource;
                var  uomList = (SortableBindingList<UnitOfMeasure>)locationTypeListBS.DataSource;
                if (uomList.Count > 0)
                {
                    foreach (UnitOfMeasure  unitOfMeasure in uomList)
                    {
                        unitOfMeasure.isActive = true;
                        if (unitOfMeasure.IsChanged)
                        {

                            if(string.IsNullOrEmpty( unitOfMeasure.UomName))
                            {
                                MessageBox.Show("Please enter the UOM Name");
                                return;
                            }
                            if (string.IsNullOrEmpty(unitOfMeasure.Notes))
                            {
                                MessageBox.Show("Please enter the Notes");
                                return;
                            }
                            uomBL.Save(unitOfMeasure, "rakshith");
                        }
                        else
                        {
                            MessageBox.Show("nothing to delete");
                        }
                    }
                    PopulateUOMGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
