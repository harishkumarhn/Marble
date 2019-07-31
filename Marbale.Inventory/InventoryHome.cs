using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Marbale.Inventory.MenuPopups;

namespace Marbale.Inventory
{
    /// <summary>
    /// Home page for inventory
    /// </summary>
    public partial class InventoryHome : Form// MaterialSkin.Controls.MaterialForm
    {
        public InventoryHome()
        {
            InitializeComponent();
        }

        MasterPopup frmMasterPopup;
        private void btnMaster_Click(object sender, EventArgs e)
        {
            frmMasterPopup = new MasterPopup();
            frmMasterPopup.LostFocus += FrmMasterPopup_LostFocus;
            frmMasterPopup.Location = FormPosition(btnMaster.PointToScreen(new Point(0, 0)), frmMasterPopup.Size, btnMaster.Size);
            frmMasterPopup.Show();
        }

        private void FrmMasterPopup_LostFocus(object sender, EventArgs e)
        {
            if (frmMasterPopup != null)
                frmMasterPopup.Close();
        }

        public Point FormPosition(Point screenPosition, Size fromSize, Size controlSize)
        {
            Point _retVal = new Point();

            if (screenPosition.Y + controlSize.Height + fromSize.Height + 1 < Screen.PrimaryScreen.Bounds.Height)
                _retVal.Y = screenPosition.Y + controlSize.Height + 1;
            else
                _retVal.Y = screenPosition.Y - fromSize.Height - 1;

            if (screenPosition.X + fromSize.Width < Screen.PrimaryScreen.Bounds.Width)
                _retVal.X = screenPosition.X;
            else
                _retVal.X = screenPosition.X - fromSize.Width + controlSize.Width;

            return _retVal;
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            frmProduct frm = new frmProduct();
            frm.MdiParent = this;
            //frm.Width = this.Width;
            //frm.Height = 623; //this.Height - pnlHomeControls.Height - statusStrip1.Height - 63;
            //frm.Location = new Point(0,122);
            //frm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
