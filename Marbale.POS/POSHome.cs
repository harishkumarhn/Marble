using Marbale.Business;
using Marbale.BusinessObject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;

namespace Marbale.POS
{
    public partial class POSHome : Form
    {
        POSBusiness posBussiness;
        string cardNumber = "";
        string tempCardNumber = "";
             
        Color skinColor;
        public POSHome()
        {
            posBussiness = new POSBusiness();  
            InitializeComponent();
            skinColor = Color.Gray;
        }

        private void POSHome_Load(object sender, EventArgs e)
        {
            UpdateProductsTab();
           // text_CardNumber.Select();

            dataGrid_card.DataSource = GetDefaultCardInfo();
            dataGrid_card.Columns[0].DefaultCellStyle.BackColor = Color.Black;
            dataGrid_card.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            foreach (DataGridViewRow row in dataGrid_card.Rows)
            {
                row.Height = 25;
                row.DefaultCellStyle.Font = new Font("Bookshelf", 10.5F, FontStyle.Bold);
            }

            dataGrid_CardSummary.DataSource = GetDefaultCardSummary();
            dataGrid_CardSummary.Columns[0].DefaultCellStyle.BackColor = skinColor;
            dataGrid_CardSummary.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            foreach (DataGridViewRow row in dataGrid_CardSummary.Rows)
            {
                row.Height = 24;
                row.DefaultCellStyle.Font = new Font("Bookshelf", 10.5F, FontStyle.Bold);
            }
        }
        public List<KeyValue> GetDefaultCardInfo()
        {
            List<KeyValue> cardDetails = new List<KeyValue>();
            cardDetails.Add(new KeyValue() { Key = "Issue Date", Value = DateTime.Now.ToShortDateString()});
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

            if (products.Count > 0)
            {
                productsFlowLayout.Controls.Clear();
                for (int i = 0; i < products.Count; i++)
                {
                    Button button = new Button();
                    button.Tag = products[i].Id;
                    button.Name = products[i].Name + '_' + products[i].Id;
                    button.Font = new Font("Microsoft Sans Serif", 13);
                    button.Width = 150;
                    button.Height = 80;
                    button.BackColor = Color.DeepSkyBlue;
                    button.Text = products[i].Name;

                    button.Click += (obj, eArgs) =>
                    {
                        DisplayProduct(Convert.ToInt32(((Control)obj).Tag));
                    };
                    productsFlowLayout.Controls.Add(button);
                }
            }
        }

        private void pos_left_Selected(object sender, TabControlEventArgs e)
        {
            if (pos_left.TabPages[pos_left.SelectedIndex].Text == "Product")
            {
                UpdateProductsTab();
            }
        }

        private void text_CardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
           //  e.Handled = true;
        }

        private void POSHome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tempCardNumber.Length == 10)
            {
                tempCardNumber = "";
            }
            if (tempCardNumber.Length == 9)
            {
                tempCardNumber = tempCardNumber + e.KeyChar;
                if (tempCardNumber.Length == 10)
                {
                    cardNumber = tempCardNumber;
                    lab_CardNumber.Text = cardNumber;
                }
            }
            else
            {
                tempCardNumber = tempCardNumber + e.KeyChar;
            }
        }
        
    }
}
