using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marbale.POS
{
    public partial class frmManualCard : Form
    {
        public string cardNumber = string.Empty;
        public frmManualCard()
        {
            InitializeComponent();
            cardNumber = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            cardNumber = txtCardNumber.Text;
            this.Close();
        }
    }
}
