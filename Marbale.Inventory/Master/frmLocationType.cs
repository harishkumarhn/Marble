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
    public partial class frmLocationType : Form
    {
        public frmLocationType()
        {
            InitializeComponent();
        }

        private void frmLocationType_Load(object sender, EventArgs e)
        {
            PoupulateLocationTypeGrid();
        }
    

        void PoupulateLocationTypeGrid()
        {
            LocationTypeBL locationTypeBL = new LocationTypeBL();
            List<LocationType> lstLocationType = locationTypeBL.GetlocationType();

            if (lstLocationType != null)
            {
                dgvLocationType.DataSource = lstLocationType;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PoupulateLocationTypeGrid();
        }
    }
}
