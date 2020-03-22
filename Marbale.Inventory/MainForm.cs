using Marbale.Inventory.Master;
using Marbale.Inventory.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Marbale.Inventory
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategory frm = new frmCategory();
            //frm.MdiParent = this;
            frm.ShowDialog();
        }

        private void uOMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUOM frm = new frmUOM();
            //frm.MdiParent = this;
            frm.ShowDialog();
        }

        private void taxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTax frm = new frmTax();
            //frm.MdiParent = this;
            frm.ShowDialog();
        }

        private void vendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVendor frm = new frmVendor();
            //frm.MdiParent = this;
            frm.ShowDialog();
        }

        private void locationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocation frm = new frmLocation();
            frm.ShowDialog();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ProductList frm_ProductList = new Frm_ProductList();
            frm_ProductList.ShowDialog();
        }
    }
}
