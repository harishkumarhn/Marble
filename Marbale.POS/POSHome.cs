using Marbale.Business;
using Marbale.BusinessObject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Marbale.POS
{
    public partial class POSHome : Form
    {
        POSBusiness posBussiness;
        public POSHome()
        {
            posBussiness = new POSBusiness();  
            InitializeComponent();
        }

        private void POSHome_Load(object sender, EventArgs e)
        {
            UpdateProductsTab();
            text_CardNumber.Select();

            dataGrid_card.DataSource = GetDefaultCardInfo();
            dataGrid_card.Columns[0].DefaultCellStyle.BackColor = Color.Black;
            dataGrid_card.Columns[0].DefaultCellStyle.BackColor = Color.Black;
            dataGrid_card.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            foreach (DataGridViewRow row in dataGrid_card.Rows)
            {
                row.Height = 25;
                row.DefaultCellStyle.Font = new Font("Bookshelf", 10.5F, FontStyle.Bold);
            }
        }
        public List<CardDetail> GetDefaultCardInfo()
        {
            List<CardDetail> cardDetails = new List<CardDetail>();
            cardDetails.Add(new CardDetail() { Name = "Issue Date", Value = DateTime.Now.ToShortDateString()});
            cardDetails.Add(new CardDetail() { Name = "Card Deposit", Value = "0.00" });
            cardDetails.Add(new CardDetail() { Name = "Card Credit", Value = "0.00" });
            cardDetails.Add(new CardDetail() { Name = "Courtesy", Value = "0.00" });
            cardDetails.Add(new CardDetail() { Name = "Card Deposit", Value = "0.00" });
            cardDetails.Add(new CardDetail() { Name = "Bonus", Value = "0.00" });
            cardDetails.Add(new CardDetail() { Name = "Time", Value = "0.00" });
            cardDetails.Add(new CardDetail() { Name = "Games", Value = "" });
            cardDetails.Add(new CardDetail() { Name = "Credit Plus", Value = "0.00" });
            cardDetails.Add(new CardDetail() { Name = "Tickets", Value = "0.00" });
            cardDetails.Add(new CardDetail() { Name = "Loyality Points", Value = "0.00" });
            cardDetails.Add(new CardDetail() { Name = "Recharged/Spent", Value = "0.0000" });

            return cardDetails;

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

        private void dataGrid_card_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
