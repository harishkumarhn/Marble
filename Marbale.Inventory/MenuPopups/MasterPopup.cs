using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marbale.Inventory.MenuPopups
{
    /// <summary>
    /// POP up window
    /// </summary>
    public partial class MasterPopup : Form
    {
        public MasterPopup()
        {
            InitializeComponent();
        }

        private void MasterPopup_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            this.Close();



        }

        private void MasterPopup_Leave(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
