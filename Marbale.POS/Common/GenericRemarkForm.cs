using Marbale.BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Marbale.BusinessObject.GlobalEnum;

namespace Marbale.POS.Common
{
    public partial class GenericRemarkForm : Form
    {

        public string Remarks = "";

        RemarksMode mode;

        public GenericRemarkForm(RemarksMode mode)
        {
            this.mode = mode;

            InitializeComponent();
            if(this.mode == RemarksMode.TransactionHeader)
            {
                this.Text = "Transaction Header Remarks";
                lblRemark.Text = "Enter the Transation Header Remarks";
            }
            if (this.mode == RemarksMode.TransactionLine)
            {
                this.Text = "Transaction Line Remarks";
                lblRemark.Text = "Enter the Transation Line Remarks";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace( txtRemarks.Text))
            {
                if (this.mode == RemarksMode.TransactionHeader)
                {
                    MessageBox.Show(GlobalMessage.REQUIRED_TRANSACTION_HEADER_REMARKS);
                }
                if (this.mode == RemarksMode.TransactionHeader)
                {
                    MessageBox.Show(GlobalMessage.REQUIRED_TRANSACTION_LINE_REMARKS);
                }
            }
            else
            {
                Remarks = txtRemarks.Text;
                this.Close(); 
               DialogResult = DialogResult.OK;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtRemarks.Text = "";
        }
    }
}
