using Marbale.BusinessObject.SiteSetup;
using Marbale.Inventory.Adjustments;
using Marbale.Inventory.Master;
using Marbale.Inventory.Product;
using Marbale.Inventory.Recieve;
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
        public static User loggedInUser;
        public MainForm()
        {
            InitializeComponent();

            InitialiseUI initialiseUI = new InitialiseUI();
            initialiseUI.SetUI(this);
             

            loggedInUser = new User()
            {
                Id = 1,
                LoginId = "rakshith",
                Name = "rakshith"
            };


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
            frm_ProductList.MdiParent = this;
            frm_ProductList.StartPosition = FormStartPosition.CenterScreen;
            frm_ProductList.Show();

            //frm_ProductList.Show(this);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_AddProduct frm_AddProduct = new Frm_AddProduct(-1, "");
            frm_AddProduct.ShowDialog();
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ProductList frm_ProductList = new Frm_ProductList();
            frm_ProductList.ShowDialog();
        }

        private void receiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ReciewInventory frm_Reciew = new Frm_ReciewInventory();
            frm_Reciew.ShowDialog();
        }

        private void adjustmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Adjustmnets frm_Adjustmnets = new Frm_Adjustmnets();
            frm_Adjustmnets.ShowDialog();
        }

        private void physicalCountingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_PhysicalCount frm_PhysicalCount = new Frm_PhysicalCount();
            frm_PhysicalCount.ShowDialog();
        }
    }
}
