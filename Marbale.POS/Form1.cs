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
    public partial class ShiftForm : Form
    {
        public static ShiftForm ShowShiftForm()
        {
            ShiftForm form = new ShiftForm();
            form.Show();
            return form;
        }

        public ShiftForm()
        {
            InitializeComponent();
        }

        private void btnOpenShift_Click(object sender, EventArgs e)
        {

            ValidationPopUp v = new ValidationPopUp();
            v.StartPosition = FormStartPosition.CenterParent;
            string CashBalance = (txtcashblalance.Text).ToString();
            string CardCount = (txtCardCount.Text).ToString();
            if (CashBalance == "")
            {
                v.ValidationText = "Please Enter Cash Balance";
                v.ShowDialog();
            }
            else if (CardCount == "")
            {
                v.ValidationText = "Please Enter Card Count";
                v.ShowDialog();
            }
            else
            {

            }


        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtcashblalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtCardCount_TextChanged(object sender, EventArgs e)
        {
           // e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtCreditCard_TextChanged(object sender, EventArgs e)
        {
         //   e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtCreditCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtCardCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }
        

        private void ShiftForm_Load(object sender, EventArgs e)
        {
            ShiftForm shift = new ShiftForm();
            shift.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ShiftForm_Load_1(object sender, EventArgs e)
        {
            ShiftForm shift = new ShiftForm();
            btnClosedShift.Enabled = false;
            shift.StartPosition = FormStartPosition.CenterScreen;
        }       
    }
}
