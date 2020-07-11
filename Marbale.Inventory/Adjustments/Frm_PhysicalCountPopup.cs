using Marbale.BusinessObject.Inventory;
using Marbale.BusinessObject.SiteSetup;
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

namespace Marbale.Inventory.Adjustments
{
    public partial class Frm_PhysicalCountPopup : Form
    {
        public Frm_PhysicalCountPopup()
        {
            InitializeComponent();
        }

        private void Frm_PhysicalCountPopup_Load(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            InventoryPhysicalCountBL inventoryPhysicalCountBL = new InventoryPhysicalCountBL();
            InventoryPhysicalCount inventoryPhysicalCount = new InventoryPhysicalCount()
            {
                InitiatedBy = LogedInUser.LoginId,
                InitaitedDate = DateTime.Now,
                Description = txt_Desc.Text,
                IsActive = true,
                Status = "Open",

            };
            inventoryPhysicalCountBL.Save(inventoryPhysicalCount, LogedInUser.LoginId);

            this.Close();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
