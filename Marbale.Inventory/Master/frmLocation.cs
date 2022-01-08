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
    public partial class frmLocation : Form
    {
        public frmLocation()
        {
            InitializeComponent();
            InitialiseUI initialiseUI = new InitialiseUI();
            initialiseUI.SetSubFormUI(this);
        }
        BindingSource locationListBS;
        private void lnkLocationType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLocationType frm = new frmLocationType();
            frm.ShowDialog();
            PopulateLocationType();
        }

        private void frmLocation_Load(object sender, EventArgs e)
        {
            
             PopulateLocationGrid();
           
        }

        void PopulateLocationGrid()
        {
            PopulateLocationType();
            LocationBL locationBL = new LocationBL();
          

            List<KeyValuePair< Location.SearchByLocationParameters, string>> searchParameters = new List<KeyValuePair<Location.SearchByLocationParameters, string>>();
            searchParameters.Add(new KeyValuePair<Location.SearchByLocationParameters, string>(BusinessObject.Inventory.Location.SearchByLocationParameters.IS_ACTIVE, "1"));

            List<Location> lstLocation = locationBL.GetLocationList(searchParameters);

            locationListBS = new BindingSource();
            if (lstLocation != null)
                locationListBS.DataSource = new SortableBindingList<Location>(lstLocation);
            else
            {
                lstLocation = new List<Location>();
                locationListBS.DataSource = new SortableBindingList<Location>(lstLocation);
            }


            locationListBS.AddingNew += dgvLocation_BindingSourceAddNew;
            dgv_Location.DataSource = locationListBS;
        }

        private void dgvLocation_BindingSourceAddNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                if (dgv_Location.Rows.Count == locationListBS.Count)
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
                    inventoryLocationsListDrp.Insert(0, new LocationType(0,""));
                    SortableBindingList<LocationType> inventoryDocumentTypeDTOSortList = new SortableBindingList<LocationType>(inventoryLocationsListDrp);
                    bindingSourceLocationTypes.DataSource = inventoryDocumentTypeDTOSortList;
                }
                else
                {
                    inventoryLocationsListDrp = new List<LocationType>();
                    inventoryLocationsListDrp.Insert(0, new LocationType(0, ""));
                    bindingSourceLocationTypes.DataSource = new SortableBindingList<LocationType>();
                }


                //LocationType location = new LocationType(0, "");
                locationTypeIdDataGridViewTextBoxColumn.DataSource = bindingSourceLocationTypes;
                locationTypeIdDataGridViewTextBoxColumn.ValueMember = "LocationTypeId";
                locationTypeIdDataGridViewTextBoxColumn.DisplayMember = "LocationTypeName";
                locationTypeIdDataGridViewTextBoxColumn.ValueType=typeof(int);
                //locationTypeIdDataGridViewTextBoxColumn.DisplayMember = "LocationTypeName";
                

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
            bool saved = false;
            try
            {
                LocationBL locationBL = new LocationBL();
                BindingSource locationListBS = (BindingSource)dgv_Location.DataSource;
                var locationList = (SortableBindingList<Location>)locationListBS.DataSource;
                if (locationList.Count > 0)
                {
                    foreach (Location location in locationList)
                    {
                        if (location.IsChanged)
                        {
                            location.IsActive = true;
                            locationBL.Save(location, "rakshith");
                            saved = true;
                        }
                        else
                        {
                            //MessageBox.Show("Nothing to save");
                        }
                    }
                    if(saved)
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
                if (this.dgv_Location.SelectedRows.Count <= 0 && this.dgv_Location.SelectedCells.Count <= 0)
                {
                    MessageBox.Show("No record selected");
                    return;
                }
                
                if (this.dgv_Location.SelectedCells.Count > 0)
                {
                    foreach (DataGridViewCell cell in this.dgv_Location.SelectedCells)
                    {
                        dgv_Location.Rows[cell.RowIndex].Selected = true;
                    }
                }
                foreach (DataGridViewRow row in this.dgv_Location.SelectedRows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (Convert.ToInt32(row.Cells[0].Value) < 0)
                        {
                            dgv_Location.Rows.RemoveAt(row.Index);
                        }
                        else
                        {
                            if (  (MessageBox.Show("Do you wany to Delete", "Confirm Inactivation.", MessageBoxButtons.YesNo) == DialogResult.Yes))
                            {
                                BindingSource ListBS = (BindingSource)dgv_Location.DataSource;
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
            if (dgv_Location.CurrentRow == null)
                return;
        }

        private void dgv_Location_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
