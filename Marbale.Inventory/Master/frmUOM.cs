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
            PoupulateUOMGrid();
        }

        void PoupulateUOMGrid()
        {
            UnitOfMeasureBL uomBL = new UnitOfMeasureBL();
            List<UnitOfMeasure> lstUom = uomBL.GetUom();

            if (lstUom != null)
            {
                dgvUOM.DataSource = lstUom;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PoupulateUOMGrid();
        }
    }
}
