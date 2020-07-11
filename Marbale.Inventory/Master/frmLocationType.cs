using Marbale.BusinessObject.Inventory;
using Marbale.BusinessObject.SiteSetup;
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
    public partial class frmLocationType : Form
    {
        BindingSource  locationListBS ;
        public frmLocationType()
        {
            InitializeComponent();
        }

        private void frmLocationType_Load(object sender, EventArgs e)
        {
            PopulateLocationTypeGrid();
        }


        void PopulateLocationTypeGrid()
        {
            LocationTypeBL locationTypeBL = new LocationTypeBL();
            List<LocationType> lstLocationType = locationTypeBL.GetlocationType();

            locationListBS = new BindingSource();

            if (lstLocationType != null)
                locationListBS.DataSource = new SortableBindingList<LocationType>(lstLocationType);
            else
            {
                locationListBS.DataSource = new SortableBindingList<LocationType>();
            }

            dgvLocationType.DataSource = locationListBS;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateLocationTypeGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                LocationTypeBL locationTypeBL = new LocationTypeBL();
                BindingSource locationTypeListBS = (BindingSource)dgvLocationType.DataSource;
                var locationTypeList = (SortableBindingList<LocationType>)locationTypeListBS.DataSource;
                if (locationTypeList.Count > 0)
                {
                    foreach (LocationType locationType in locationTypeList)
                    {
                        locationType.IsActive = true;
                        if (locationType.IsChanged)
                        {
                            locationTypeBL.Save(locationType, LogedInUser.LoginId);
                        }
                        else
                        {
                            MessageBox.Show("nothing to delete");
                        }
                    }
                    PopulateLocationTypeGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvLocationType.SelectedRows.Count <= 0 && this.dgvLocationType.SelectedCells.Count <= 0)
                {
                    MessageBox.Show("No record selected");
                    return;
                }

                if (this.dgvLocationType.SelectedCells.Count > 0)
                {
                    foreach (DataGridViewCell cell in this.dgvLocationType.SelectedCells)
                    {
                        dgvLocationType.Rows[cell.RowIndex].Selected = true;
                    }
                }
                foreach (DataGridViewRow row in this.dgvLocationType.SelectedRows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (Convert.ToInt32(row.Cells[0].Value) < 0)
                        {
                            dgvLocationType.Rows.RemoveAt(row.Index);
                        }
                        else
                        {
                            if ((MessageBox.Show("Do you wany to Delete", "Confirm Inactivation.", MessageBoxButtons.YesNo) == DialogResult.Yes))
                            {
                                BindingSource ListBS = (BindingSource)dgvLocationType.DataSource;
                                var datalist = (SortableBindingList<LocationType>)ListBS.DataSource;
                                LocationType objitem = datalist[row.Index];
                                objitem.IsActive = false;
                                LocationTypeBL blObj = new LocationTypeBL();
                                blObj.Save(objitem, LogedInUser.LoginId);
                            }
                        }
                    }
                }
                PopulateLocationTypeGrid();
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
    }
}
