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
    public partial class CardTask : Form
    {
        POSOperations pos = new POSOperations();
        public CardTask()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            carddetailgridview.Show();
            DataTable grid = new DataTable();
            string CardNum = txtCardNumber.Text;
            grid = pos.GetCardDetails(CardNum);
            carddetailgridview.DataSource = grid;
            getColor();
        }

        private void getColor()
        {
          //  carddetailgridview.Columns["CardNumber"].DefaultCellStyle.ForeColor = Color.Red;
            for (int i = 0; i < carddetailgridview.Rows.Count; i++)
            {
                carddetailgridview.Rows[i].DefaultCellStyle.BackColor = Color.LawnGreen;
            }
        }

        private void CardTask_Load(object sender, EventArgs e)
        {
            carddetailgridview.Hide();
        }
    }
}
