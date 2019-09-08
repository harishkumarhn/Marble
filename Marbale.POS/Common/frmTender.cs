using Marbale.POS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Marbale.POS.Properties;

namespace Parafait_POS
{
    public partial class frmTender : Form
    {
        public double TenderedAmount = 0;
        NumberPad numPad;
        double _Amount;

        public frmTender(double Amount)
        {
            InitializeComponent();

            _Amount = Amount;
            lblChange.Text = "Rs "+ (0).ToString(); //AMOUNT_WITH_CURRENCY_SYMBOL

            string[] denoms = "100|10|5|1".Split('|'); // PAYMENT_DENOMINATIONS")

            foreach (string denomination in denoms)
            {
                if (string.IsNullOrEmpty(denomination.Trim()))
                    continue;

                Button btnPaymentMode = new Button();
                btnPaymentMode.FlatStyle = FlatStyle.Flat;
                btnPaymentMode.FlatAppearance.BorderSize = 0;
                btnPaymentMode.FlatAppearance.CheckedBackColor = Color.Transparent;
                btnPaymentMode.FlatAppearance.MouseDownBackColor = Color.Transparent;
                btnPaymentMode.FlatAppearance.MouseOverBackColor = Color.Transparent;
                btnPaymentMode.BackgroundImageLayout = ImageLayout.Zoom;
                btnPaymentMode.BackColor = Color.Transparent;
                btnPaymentMode.Tag = 0;
                btnPaymentMode.Name = "B" + denomination.Trim();
                btnPaymentMode.Text = "Rs " + denomination.Trim();
                btnPaymentMode.Click += btnPaymentMode_Click;
                btnPaymentMode.Size = btnSample.Size;
                btnPaymentMode.BackgroundImage = btnSample.BackgroundImage;
                btnPaymentMode.Font = btnSample.Font;
                btnPaymentMode.ForeColor = btnSample.ForeColor;

                btnPaymentMode.MouseDown += btnPaymentMode_MouseDown;
                btnPaymentMode.MouseUp += btnPaymentMode_MouseUp;

                flpTenders.Controls.Add(btnPaymentMode);
            }

            numPad = new NumberPad("#,##0.00", 2); //AMOUNT_FORMAT, RoundingPrecision
            numPad.handleaction(Amount.ToString());
            numPad.NewEntry = true;

            Panel NumberPadVarPanel = numPad.NumPadPanel();
            NumberPadVarPanel.Location = new System.Drawing.Point(2, 2);
            this.Controls.Add(NumberPadVarPanel);
            numPad.setReceiveAction = EventnumPadOKReceived;
            numPad.setKeyAction = EventnumPadKeyPressReceived;

            this.KeyPreview = true;

            this.KeyPress += new KeyPressEventHandler(FormNumPad_KeyPress);
            this.FormClosing += new FormClosingEventHandler(FormNumPad_FormClosing);
        }

        void btnPaymentMode_MouseUp(object sender, MouseEventArgs e)
        {
           // (sender as Button).BackgroundImage = Resources.DiplayGroupButton;
        }

        void btnPaymentMode_MouseDown(object sender, MouseEventArgs e)
        {
            //(sender as Button).BackgroundImage = Resources.ProductPressed;
        }

        void FormNumPad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
                TenderedAmount = -1;
        }

        void FormNumPad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else
                numPad.GetKey(e.KeyChar);
        }

        private void EventnumPadOKReceived()
        {
            TenderedAmount = numPad.ReturnNumber;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        void EventnumPadKeyPressReceived()
        {
            TenderedAmount = numPad.ReturnNumber;
            lblChange.Text =  "Rs " + (TenderedAmount - _Amount).ToString();

            if (TenderedAmount == 0)
            {
                foreach (Control payMode in flpTenders.Controls)
                {
                    payMode.Text = "Rs " + payMode.Name.Substring(1);
                    payMode.Tag = 0;
                }
            }
        }

        void btnPaymentMode_Click(object sender, EventArgs e)
        {
            Button payMode = (sender as Button);
            double amount = Convert.ToDouble(payMode.Name.Substring(1));
            payMode.Tag = Convert.ToInt32(payMode.Tag) + 1;
            payMode.Text = "Rs " + payMode.Name.Substring(1) + " x " + payMode.Tag.ToString();
            
            TenderedAmount += amount;
            string strAmount = TenderedAmount.ToString("#,##0.00");
            numPad.NewEntry = true;
            foreach (char c in strAmount)
                numPad.GetKey(c);
            numPad.NewEntry = true;

            lblChange.Text = "Rs " + (TenderedAmount - _Amount).ToString();
        }

        private void btnCancel_MouseDown(object sender, MouseEventArgs e)
        {
            //(sender as Button).BackgroundImage = Marbale.POS.Properties.Resources.customer_button_pressed;
        }

        private void btnCancel_MouseUp(object sender, MouseEventArgs e)
        {
            //(sender as Button).BackgroundImage = Marbale.POS.Properties.Resources.customer_button_normal;
        }
    }
}
