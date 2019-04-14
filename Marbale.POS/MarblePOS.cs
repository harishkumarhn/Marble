using Marbale.Business;
using Marbale.BusinessObject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;
using Marbale.POS.UserControls;

namespace Marbale.POS
{
    public partial class MarblePOS : Form
    {
        POSBL posBussiness;
        string cardNumber = "";
        string tempCardNumber = "";

        Color skinColor;
        public MarblePOS()
        {
            posBussiness = new POSBL();
            InitializeComponent();
            skinColor = Color.Gray;
        }

        private void POSHome_Load(object sender, EventArgs e)
        {

            ShowProductsDetails();

        }
        public List<KeyValue> GetDefaultCardInfo()
        {
            List<KeyValue> cardDetails = new List<KeyValue>();
            cardDetails.Add(new KeyValue() { Key = "Issue Date", Value = DateTime.Now.ToShortDateString() });
            cardDetails.Add(new KeyValue() { Key = "Card Deposit", Value = "0.00" });
            cardDetails.Add(new KeyValue() { Key = "Card Credit", Value = "0.00" });
            cardDetails.Add(new KeyValue() { Key = "Courtesy", Value = "0.00" });
            cardDetails.Add(new KeyValue() { Key = "Card Deposit", Value = "0.00" });
            cardDetails.Add(new KeyValue() { Key = "Bonus", Value = "0.00" });
            cardDetails.Add(new KeyValue() { Key = "Time", Value = "0.00" });
            cardDetails.Add(new KeyValue() { Key = "Games", Value = "" });
            cardDetails.Add(new KeyValue() { Key = "Credit Plus", Value = "0.00" });
            cardDetails.Add(new KeyValue() { Key = "Tickets", Value = "0.00" });
            cardDetails.Add(new KeyValue() { Key = "Loyality Points", Value = "0.00" });
            cardDetails.Add(new KeyValue() { Key = "Recharged/Spent", Value = "0.0000" });

            return cardDetails;

        }

        public List<KeyValue> GetDefaultCardSummary()
        {
            List<KeyValue> cardSummary = new List<KeyValue>();
            cardSummary.Add(new KeyValue() { Key = "Total", Value = DateTime.Now.ToShortDateString() });
            cardSummary.Add(new KeyValue() { Key = "Balance", Value = "0.00" });
            cardSummary.Add(new KeyValue() { Key = "Tendered", Value = "0.00" });
            cardSummary.Add(new KeyValue() { Key = "Change", Value = "0.00" });
            cardSummary.Add(new KeyValue() { Key = "Tip Amount", Value = "0.00" });

            return cardSummary;

        }

        public void DisplayProduct(int productId)
        {

        }

        private void UpdateProductsTab()
        {
            var products = posBussiness.GetProductsByScreenGroup("POS");


        }

        private void pos_left_Selected(object sender, TabControlEventArgs e)
        {

        }

        private void text_CardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  e.Handled = true;
        }

        private void POSHome_new_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ShowProductsDetails();
        }

        private void btnDiscounts_Click(object sender, EventArgs e)
        {
            ShowDiscountDetails();
        }

        private void btnTask_Click(object sender, EventArgs e)
        {
            ShowTasksDetails();
        }

        private void btnRedeem_Click(object sender, EventArgs e)
        {
            ShowRedeemDetails();
        }

        private void btntools_Click(object sender, EventArgs e)
        {
            ShowToolsDetails();
        }

        void ShowProductsDetails()
        {
            ClearAllControls();
            if (!pnlUserControls.Controls.Contains(Products.Instance))
            {
                pnlUserControls.Controls.Add(Products.Instance);
                //Products.Instance.Dock = DockStyle.Fill;
                Products.Instance.BringToFront();
            }
            else
            {
                Products.Instance.BringToFront();
            }
        }

        void ShowDiscountDetails()
        {
            ClearAllControls();
            if (!pnlUserControls.Controls.Contains(Discounts.Instance))
            {
                pnlUserControls.Controls.Add(Discounts.Instance);
                //Products.Instance.Dock = DockStyle.Fill;
                Discounts.Instance.BringToFront();
            }
            else
            {
                Discounts.Instance.BringToFront();
            }
        }

        void ShowRedeemDetails()
        {
            ClearAllControls();
            if (!pnlUserControls.Controls.Contains(Redeem.Instance))
            {
                pnlUserControls.Controls.Add(Redeem.Instance);
                //Products.Instance.Dock = DockStyle.Fill;
                Discounts.Instance.BringToFront();
            }
            else
            {
                Redeem.Instance.BringToFront();
            }
        }
        void ShowToolsDetails()
        {
            ClearAllControls();
            if (!pnlUserControls.Controls.Contains(Tools.Instance))
            {
                pnlUserControls.Controls.Add(Tools.Instance);
                //Products.Instance.Dock = DockStyle.Fill;
                Tools.Instance.BringToFront();
            }
            else
            {
                Tools.Instance.BringToFront();
            }
        }

        void ShowTasksDetails()
        {
            ClearAllControls();
            if (!pnlUserControls.Controls.Contains(Tasks.Instance))
            {
                pnlUserControls.Controls.Add(Tasks.Instance);
                //Products.Instance.Dock = DockStyle.Fill;
                Tasks.Instance.BringToFront();
            }
            else
            {
                Tasks.Instance.BringToFront();
            }
        }

        void ClearAllControls()
        {
            foreach (Control c in pnlUserControls.Controls)
            {
                pnlUserControls.Controls.Remove(c);
            }
        }

    }
}
