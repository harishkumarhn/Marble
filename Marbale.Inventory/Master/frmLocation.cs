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
    public partial class frmLocation : Form
    {
        public frmLocation()
        {
            InitializeComponent();
        }

        private void lnkLocationType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLocationType frm = new frmLocationType();
            frm.ShowDialog();
        }

        private void frmLocation_Load(object sender, EventArgs e)
        {
            PoupulateLocationGrid();
        }

        void PoupulateLocationGrid()
        {
            LocationBL locationTypeBL = new LocationBL();
            List<Location> lstLocation = locationTypeBL.GetLocation();

            if (lstLocation != null)
            {
                dgvLocation.DataSource = lstLocation;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PoupulateLocationGrid();
        }
    }
}
