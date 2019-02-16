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
            List<CardDetail> cd = new List<CardDetail>();
            cd.Add(new CardDetail() {Name = "Issue Date",Value = "2001"});
            dataGrid_card.DataSource = cd;
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
             e.Handled = true;
        }
    }
}
