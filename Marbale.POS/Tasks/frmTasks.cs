using Marbale.Business;
using Marbale.BusinessObject.Cards;
using Marbale.POS.Tasks;
using Marble.Business;
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
        Card fromCard;
        Card toCard;

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

            ProductBL productBL = new ProductBL();
            productBL.LoadTicketBonusToCards(currentcard.card_id, Convert.ToInt32(txtTickets.Text), 0, "");

            MessageBox.Show("Tickets loaded to card successfully.");
            this.Close();
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
            while (CardTabControl.TabPages.Count > 1)
            {
                for (int i = 0; i < CardTabControl.TabPages.Count; i++)
                {
                    if (CardTabControl.TabPages[i].Tag != null && Convert.ToInt32(CardTabControl.TabPages[i].Tag) != TaskId)
                    {
                        CardTabControl.TabPages.RemoveAt(i);
                    }
                }
            }

            switch (TaskId)
            {
                case (int)CommonTask.Task.LOADTICKETS:
                    PopulateCardTicketGrid();
                    break;
                case (int)CommonTask.Task.LOADBONUS:
                    PopulateCardBonusGrid();
                    break;
                case (int)CommonTask.Task.LOADMULTIPLE:
                    //PopulateCardBonusGrid();
                    break;
                case (int)CommonTask.Task.TRANSFERCARD:
                    //PopulateCardBonusGrid();
                    break;
                case (int)CommonTask.Task.CANSOLIDATECARD:
                    //PopulateCardBonusGrid();
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

        void PopulateTransferFromCard(Card card)
        {
            if (card != null && card.card_id > 0)
            {
                string[] row1 = new string[] { card.CardNumber, card.issue_date.ToString(), card.credits.ToString(), card.bonus.ToString(), card.ticket_count.ToString() };
                dgvFromCard.Rows.Add(row1);
            }
            else if (card != null && card.card_id <= 0)
            {
                string[] row1 = new string[] { card.CardNumber, string.Empty, card.credits.ToString(), card.bonus.ToString(), card.ticket_count.ToString() };
                dgvToCard.Rows.Add(row1);
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

            ProductBL productBL = new ProductBL();
            productBL.LoadTicketBonusToCards(currentcard.card_id, 0, Convert.ToInt32(txtBonus.Text), "");

            MessageBox.Show("Bonus loaded to card successfully.");
            this.Close();
        }

        private void btnBonusClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGetFromcard_Click(object sender, EventArgs e)
        {
            fromCard = new Card();
            if (Validatecard(txtFromCardnumber.Text))
            {
                fromCard = GetCard(txtFromCardnumber.Text.Trim());

                if (fromCard != null && fromCard.CardStatus != "ISSUED")
                {
                    MessageBox.Show("Please Tap the issued card");
                }
                else
                {
                    PopulateTransferFromCard(fromCard);
                }
            }
        }


        private Card GetCard(string cardNumber)
        {
            TransactionBL trxBL = new TransactionBL();
            return trxBL.GetCard(0, cardNumber);
        }

        bool Validatecard(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber))
            {
                MessageBox.Show("Please enter card number");
                return false;
            }
            if (cardNumber.Length != 10)
            {
                MessageBox.Show("Card number length should be 10");
                return false;
            }

            return true;
        }

        private void btnGetTocard_Click(object sender, EventArgs e)
        {
            toCard = new Card();
            if (Validatecard(txtTocardNumber.Text))
            {
                toCard = GetCard(txtTocardNumber.Text.Trim());

                if (toCard == null || toCard.CardStatus != "NEW")
                {
                    MessageBox.Show("Please Tap the NEW card");
                }
                else
                {
                    PopulateTransferFromCard(toCard);
                }
            }
        }

        public void TransferCard(Card fromCard, Card toCard, string remarks)
        {
            try
            {
                toCard.card_id = 0;
                toCard.issue_date = fromCard.issue_date;
                toCard.face_value = fromCard.face_value;
                toCard.refund_date = fromCard.refund_date;
                toCard.refund_flag = fromCard.refund_flag;
                toCard.refund_amount = fromCard.refund_amount;
                toCard.ticket_count = fromCard.ticket_count;
                toCard.credits = fromCard.credits;
                toCard.bonus = fromCard.bonus;
                toCard.courtesy = fromCard.courtesy;
                toCard.valid_flag = fromCard.valid_flag;
                toCard.customer_id = fromCard.customer_id;
                toCard.credits_played = fromCard.credits_played;
                toCard.ticket_allowed = fromCard.ticket_allowed;
                toCard.real_ticket_mode = fromCard.real_ticket_mode;
                toCard.vip_customer = fromCard.vip_customer;
                toCard.notes = fromCard.notes;
                toCard.start_time = fromCard.start_time;
                toCard.last_played_time = fromCard.last_played_time;
                toCard.technician_card = fromCard.technician_card;
                toCard.TimerResetCard = fromCard.TimerResetCard;
                toCard.loyalty_points = fromCard.loyalty_points;
                toCard.CardTypeId = fromCard.CardTypeId;
                toCard.ExpiryDate = fromCard.ExpiryDate;
                toCard.notes = fromCard.notes;
                toCard.addTime = fromCard.time;

                TransactionBL trxBL = new TransactionBL();
                int toCardId = trxBL.SaveCard(toCard);

                if (toCardId > 0)
                {
                    trxBL.TransferCard(fromCard.card_id, toCardId, "");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnTransferCardOk_Click(object sender, EventArgs e)
        {
            if (fromCard == null || fromCard.card_id == 0)
            {
                MessageBox.Show("Please enter From card details");
                return;
            }

            if (toCard == null || string.IsNullOrEmpty(toCard.CardNumber))
            {
                MessageBox.Show("Please enter To card details");
                return;
            }

            TransferCard(fromCard, toCard, "");


            MessageBox.Show("Card transferred successfully.");
            this.Close();
        }
    }
}
