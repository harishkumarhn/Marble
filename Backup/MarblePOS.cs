using Marbale.Business;
using Marbale.BusinessObject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;

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
            UpdateProductsTab();
            updateCardDetailsGrid();
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


        private void UpdateProductsTab()
        {
            List<Product> lstProducts = posBussiness.GetProductsByScreenGroup("POS");

            if (lstProducts.Count > 0)
            {
                flowLayoutPanelProducts.Controls.Clear();
                for (int i = 0; i < lstProducts.Count; i++)
                {
                    Button btnProduct = new Button();
                    btnProduct.Click += new EventHandler(ProductButton_Click);
                    btnProduct.MouseDown += ProductButton_MouseDown;
                    btnProduct.MouseUp += ProductButton_MouseUp;
                    btnProduct.Name = lstProducts[i].Name + '_' + lstProducts[i].Id;
                    btnProduct.Text = lstProducts[i].Name;
                    btnProduct.Tag = lstProducts[i].Id;
                    btnProduct.Font = btnSampleProduct.Font;
                    btnProduct.ForeColor = btnSampleProduct.ForeColor;
                    btnProduct.Size = btnSampleProduct.Size;
                    btnProduct.BackgroundImage = btnSampleProduct.BackgroundImage;
                    btnProduct.FlatStyle = btnSampleProduct.FlatStyle;
                    btnProduct.FlatAppearance.BorderColor = btnSampleProduct.FlatAppearance.BorderColor;
                    btnProduct.FlatAppearance.BorderSize = btnSampleProduct.FlatAppearance.BorderSize;
                    btnProduct.FlatAppearance.MouseDownBackColor = btnSampleProduct.FlatAppearance.MouseOverBackColor = Color.Transparent;
                    btnProduct.BackgroundImageLayout = ImageLayout.Zoom;
                    btnProduct.BackColor = Color.Transparent;
                    flowLayoutPanelProducts.Controls.Add(btnProduct);
                }
            }
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {

        }

        private void ProductButton_MouseDown(object sender, EventArgs e)
        {

        }
        private void ProductButton_MouseUp(object sender, EventArgs e)
        {

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


        void updateCardDetailsGrid()
        {
            //dgvCardDetails.Columns[1].DefaultCellStyle = Utilities.gridViewNumericCellStyle();
            dgvCardDetails.RowsDefaultCellStyle = null;
            dgvCardDetails.Columns[1].DefaultCellStyle.SelectionBackColor = Color.White;
            dgvCardDetails.Columns[1].DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvCardDetails.AlternatingRowsDefaultCellStyle = dgvCardDetails.RowsDefaultCellStyle;
            dgvCardDetails.Columns[1].DefaultCellStyle.Font = new Font("arial", 12, FontStyle.Bold);
            dgvCardDetails.GridColor = Color.LightSteelBlue;
            dgvCardDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCardDetails.BorderStyle = BorderStyle.None;

            dgvCardDetails.Rows.Clear();
            dgvCardDetails.Rows.Add();
            dgvCardDetails.Rows[0].Cells[0].Value = "Issue Date";
            dgvCardDetails.Rows[0].Cells[1].Style.Font = new Font("arial", 11, FontStyle.Bold);

            dgvCardDetails.Rows.Add();
            dgvCardDetails.Rows[1].Cells[0].Value = "Card Deposit"; 

            dgvCardDetails.Rows.Add();
            dgvCardDetails.Rows[2].Cells[0].Value = "Credits";

            dgvCardDetails.Rows.Add();
            dgvCardDetails.Rows[3].Cells[0].Value = "Courtesy";  

            dgvCardDetails.Rows.Add();
            dgvCardDetails.Rows[4].Cells[0].Value = "Bonus";

            dgvCardDetails.Rows.Add();
            dgvCardDetails.Rows[5].Cells[0].Value = "Time";

            dgvCardDetails.Rows.Add();
            dgvCardDetails.Rows[6].Cells[0].Value = "Games";

            dgvCardDetails.Rows[6].Cells[1].Style = new DataGridViewCellStyle(dgvCardDetails.Columns[1].DefaultCellStyle);
            dgvCardDetails.Rows[6].Cells[1].Style.Font = new System.Drawing.Font(dgvCardDetails.Columns[1].DefaultCellStyle.Font, FontStyle.Bold | FontStyle.Underline);
            dgvCardDetails.Rows[6].Cells[1].Style.ForeColor =
                dgvCardDetails.Rows[6].Cells[1].Style.SelectionForeColor = Color.Navy;


            CreateCardGrid();


            //dgvCardDetails.Location = new Point(0, panelCardSwipe.Height - dgvCardDetails.Rows.GetRowsHeight(DataGridViewElementStates.Displayed) - 3);
        }

        void CreateCardGrid()
        {
            dgvCard.RowsDefaultCellStyle = null;
            dgvCard.Columns[1].DefaultCellStyle.SelectionBackColor = Color.White;
            dgvCard.Columns[1].DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvCard.AlternatingRowsDefaultCellStyle = dgvCard.RowsDefaultCellStyle;
            dgvCard.Columns[1].DefaultCellStyle.Font = new Font("arial", 12, FontStyle.Bold);
            dgvCard.GridColor = Color.LightSteelBlue;
            dgvCard.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCard.BorderStyle = BorderStyle.None;

            dgvCard.Rows.Clear();
            dgvCard.Rows.Add();
            dgvCard.Rows[0].Cells[0].Value = "Credit Plus";
            dgvCard.Rows[0].Cells[1].Style.Font = new Font("arial", 11, FontStyle.Bold);


            dgvCard.Rows.Add();
            dgvCard.Rows[1].Cells[0].Value = "Loyalty Points";

            dgvCard.Rows.Add();
            dgvCard.Rows[2].Cells[0].Value = "Recharged / Spent";
            dgvCard.Rows[2].Cells[1].Style.Font = new Font("arial", 11, FontStyle.Bold);
        }
    }
}
