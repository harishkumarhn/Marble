using Marbale.BusinessObject.Inventory;
using Marbale.DataAccess;
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

namespace Marbale.Inventory.Master
{
    public partial class frmLocation : Form
    {
        public frmLocation()
        {
            InitializeComponent();
        }
        BindingSource locationListBS;
        private void lnkLocationType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLocationType frm = new frmLocationType();
            frm.ShowDialog();
        }

        private void frmLocation_Load(object sender, EventArgs e)
        {
            PopulateLocationGrid();
        }

        void PopulateLocationGrid()
        {
            PopulateLocationType();
            LocationBL locationTypeBL = new LocationBL();
            List<Location> lstLocation = locationTypeBL.GetLocation();

            locationListBS = new BindingSource();
            if (locationListBS != null)
                locationListBS.DataSource = new SortableBindingList<Location>(lstLocation);
            else
            {
                locationListBS.DataSource = new SortableBindingList<Location>();
            }


            locationListBS.AddingNew += dgvLocation_BindingSourceAddNew;
            dgvLocation.DataSource = locationListBS;
        }

        private void dgvLocation_BindingSourceAddNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                if (dgvLocation.Rows.Count == locationListBS.Count)
                {
                    locationListBS.RemoveAt(locationListBS.Count - 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PopulateLocationType()
        {
            try
            {
                LocationTypeBL locationTypeBL = new LocationTypeBL();

                List<KeyValuePair<LocationType.SearchByLocationTypeParameters, string>> inventoryLocationTypeSearchParams = new List<KeyValuePair<LocationType.SearchByLocationTypeParameters, string>>();
                inventoryLocationTypeSearchParams.Add(new KeyValuePair<LocationType.SearchByLocationTypeParameters, string>(LocationType.SearchByLocationTypeParameters.IS_ACTIVE, "1"));



                List<LocationType> inventoryLocationsListDrp = locationTypeBL.GetLocationTypeList(inventoryLocationTypeSearchParams);

                BindingSource bindingSourceLocationTypes = new BindingSource();
                if (inventoryLocationsListDrp != null)
                {
                    inventoryLocationsListDrp.Insert(0, new LocationType());
                    SortableBindingList<LocationType> inventoryDocumentTypeDTOSortList = new SortableBindingList<LocationType>(inventoryLocationsListDrp);
                    bindingSourceLocationTypes.DataSource = inventoryDocumentTypeDTOSortList;
                }
                else
                {
                    inventoryLocationsListDrp = new List<LocationType>();
                    inventoryLocationsListDrp.Insert(0, new LocationType());
                    bindingSourceLocationTypes.DataSource = new SortableBindingList<LocationType>();
                }
                locationTypeIdDataGridViewTextBoxColumn.DataSource = bindingSourceLocationTypes;
                locationTypeIdDataGridViewTextBoxColumn.ValueMember = "LocationTypeId";
                locationTypeIdDataGridViewTextBoxColumn.DisplayMember = "LocationTypeId";
            }
            catch
            {
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateLocationGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                LocationBL locationBL = new LocationBL();
                BindingSource locationListBS = (BindingSource)dgvLocation.DataSource;
                var locationList = (SortableBindingList<Location>)locationListBS.DataSource;
                if (locationList.Count > 0)
                {
                    foreach (Location location in locationList)
                    {
                        if (location.IsChanged)
                        {
                            locationBL.Save(location, "rakshith");
                        }
                        else
                        {
                            MessageBox.Show("nothing to delete");
                        }
                    }
                    PopulateLocationGrid();
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
                if (this.dgvLocation.SelectedRows.Count <= 0 && this.dgvLocation.SelectedCells.Count <= 0)
                {
                    MessageBox.Show("No record selected");
                    return;
                }
                
                if (this.dgvLocation.SelectedCells.Count > 0)
                {
                    foreach (DataGridViewCell cell in this.dgvLocation.SelectedCells)
                    {
                        dgvLocation.Rows[cell.RowIndex].Selected = true;
                    }
                }
                foreach (DataGridViewRow row in this.dgvLocation.SelectedRows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (Convert.ToInt32(row.Cells[0].Value) < 0)
                        {
                            dgvLocation.Rows.RemoveAt(row.Index);
                        }
                        else
                        {
                            if (  (MessageBox.Show("Do you wany to Delete", "Confirm Inactivation.", MessageBoxButtons.YesNo) == DialogResult.Yes))
                            {
                                BindingSource ListBS = (BindingSource)dgvLocation.DataSource;
                                var datalist = (SortableBindingList<Location>)ListBS.DataSource;
                                Location location = datalist[row.Index];
                                location.IsActive = false;
                                LocationBL locationBL = new LocationBL();
                                locationBL.Save(location, "rakshith");
                            }
                        }
                    }
                }
                PopulateLocationGrid();
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

        private void dgvLocation_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLocation.CurrentRow == null)
                return;
        }
    }
}
