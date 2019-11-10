using Marbale.BusinessObject.Cards;
using Marbale.POS.Tasks;
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
    public partial class frmTasks : Form
    {
        Card currentcard = new Card();
        int TaskId = 0;
        public frmTasks(int taskId, Card card)
        {
            InitializeComponent();
            currentcard = card;
            this.TaskId = taskId;
            PoplateForm();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTickets.Text.Trim()))
            {
                MessageBox.Show("Please enter the tickets to load to card");
                return;
            }
        }

        private void txtTickets_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void PoplateForm()
        {
            for (int i = 0; i < CardTabControl.TabPages.Count; i++)
            {
                if (CardTabControl.TabPages[i].Tag != null && Convert.ToInt32(CardTabControl.TabPages[i].Tag) != TaskId)
                {
                    CardTabControl.TabPages.RemoveAt(i);
                }
            }

            switch(TaskId)
            {
                case (int)CommonTask.Task.LOADTICKETS:
                                                       PopulateCardTicketGrid();
                                                       break;
                case (int)CommonTask.Task.LOADBONUS  :
                                                       PopulateCardBonusGrid();
                                                       break;
            }
        }

        void PopulateCardTicketGrid()
        {
            if (currentcard != null && currentcard.card_id > 0)
            {
                string[] row1 = new string[] { currentcard.CardNumber, currentcard.issue_date.ToString(), currentcard.ticket_count.ToString() };
                dgvCardTickets.Rows.Add(row1);
            }
        }

        void PopulateCardBonusGrid()
        {
            if (currentcard != null && currentcard.card_id > 0)
            {
                string[] row1 = new string[] { currentcard.CardNumber, currentcard.issue_date.ToString(), currentcard.bonus.ToString() };
                dgvBonusCard.Rows.Add(row1);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBonusOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBonus.Text.Trim()))
            {
                MessageBox.Show("Please enter the Bonus to load to card");
                return;
            }
        }
    }
}
