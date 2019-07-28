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
    public partial class frmGenericDataEntry : Form
    {
        public frmGenericDataEntry()
        {
            InitializeComponent();
        }

        public string cardNumber;

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtCardNumber.Text))
            {
                MessageBox.Show("Please Enter CardNumber");
                return;
            }
            else if(txtCardNumber.Text.Length < 10 || txtCardNumber.Text.Length > 10)
            {
                MessageBox.Show("CardNumber Length should be 10");
                return;
            }

            cardNumber = txtCardNumber.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cardNumber = txtCardNumber.Text;
            this.Close();
        }
    }
}
