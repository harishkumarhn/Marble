using Marbale.Business;
using Marbale.BusinessObject.Cards;
using Marbale.POS.CardDevice;
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
        List<Card> lstConsolidateCard;
        List<DataGridView> lstConsolidatedatagridView;

        public frmTasks(int taskId, Card card)
        {
            InitializeComponent();
            currentcard = card;
            this.TaskId = taskId;
         
        }
        private void frmTasks_Load(object sender, EventArgs e)
        {
            CardReader.RequiredByOthers = true;
            CardReader.setReceiveAction = TappedCard;
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
                    {
                        lstConsolidateCard = new List<Card>();
                        lstConsolidatedatagridView = new List<DataGridView>();
                         //PopulateCardBonusGrid();
                    break;
                    }
                case (int)CommonTask.Task.REFUNDCARD:
                    PopulateRefundCardGrid();
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

        void PopulateRefundCardGrid()
        {
            if (currentcard != null && currentcard.card_id > 0)
            {
                txtCardDeposit.Text = currentcard.face_value.ToString();
                txtTotalCredits.Text = (currentcard.credits + currentcard.face_value).ToString();

                string[] row1 = new string[] { currentcard.CardNumber, currentcard.issue_date.ToString(), currentcard.credits.ToString(), currentcard.bonus.ToString(), currentcard.ticket_count.ToString() };
                dgvRefundCard.Rows.Add(row1);
            }
            else
            {
                txtCardDeposit.Text = "0".ToString();
                txtTotalCredits.Text = "0".ToString();
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

        private void TappedCard()
        {


        }


        private void PopulateConsoliDateCardGrid(Card card, ref DataGridView dataGridView, ref bool success)
        {
            bool found = false;
            if(lstConsolidateCard != null && lstConsolidateCard.Count> 0)
            {
                foreach(Card swipedcard in lstConsolidateCard)
                {
                    if (swipedcard.CardNumber == card.CardNumber)
                    {
                        found = true;
                        break;
                    }
                }

                if(found)
                {
                    MessageBox.Show("Card is already Added");
                    return;
                }
            }

            if (card != null && card.card_id > 0)
            {
                string[] row1 = new string[] { card.CardNumber, card.issue_date.ToString(), card.credits.ToString(), card.bonus.ToString(), card.ticket_count.ToString() };
                dataGridView.Rows.Add(row1);
                lstConsolidateCard.Add(card);
                lstConsolidatedatagridView.Add(dataGridView);
                success = true;
            }
            else
            {
                MessageBox.Show("Please tap the valid card");
            }
        }

        private void btnGetConsolidateCard_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validatecard(txtConsolidateCard.Text))
                {
                    Card objCard = GetCard(txtConsolidateCard.Text);
                    bool success = false;
                    DataGridView dataGrid = GetConsolidateNewGrid();
                    PopulateConsoliDateCardGrid(objCard, ref dataGrid, ref success);
                    if (success)
                    {
                        if (lstConsolidatedatagridView != null && lstConsolidatedatagridView.Count > 1)
                        {

                            lstConsolidatedatagridView[lstConsolidatedatagridView.Count-1].Location = new Point(dgvConsolidateCard.Location.X, lstConsolidatedatagridView[lstConsolidatedatagridView.Count - 2].Location.Y+60);

                            lstConsolidatedatagridView[lstConsolidatedatagridView.Count - 1].BringToFront();
                            lstConsolidatedatagridView[lstConsolidatedatagridView.Count - 1].Refresh();
                            lstConsolidatedatagridView[lstConsolidatedatagridView.Count - 1].Show();

                            tbConsilidated.Controls.Add(lstConsolidatedatagridView[lstConsolidatedatagridView.Count-1]);

                            this.Refresh(); 
                        }
                        else
                        {
                            dataGrid.Location = dgvConsolidateCard.Location;

                            dataGrid.BringToFront();
                            dataGrid.Refresh();
                            dataGrid.Show();
                            dataGrid.Visible = true;
                            tbConsilidated.Controls.Add(dataGrid);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        public DataGridView GetConsolidateNewGrid()
        {
            DataGridView grid = new DataGridView();
            grid.AllowUserToAddRows = dgvConsolidateCard.AllowUserToAddRows;
            grid.AllowUserToDeleteRows = dgvConsolidateCard.AllowUserToDeleteRows;
            grid.AllowUserToResizeColumns  = dgvConsolidateCard.AllowUserToResizeColumns;
            grid.Size = dgvConsolidateCard.Size;
            grid.MultiSelect = dgvConsolidateCard.MultiSelect;
            grid.ColumnHeadersVisible = dgvConsolidateCard.ColumnHeadersVisible;
            grid.RowHeadersVisible = dgvConsolidateCard.RowHeadersVisible;
            grid.ReadOnly = dgvConsolidateCard.ReadOnly;
            

            grid.Columns.Add("Card_Number", "Card Number");
            grid.Columns["Card_Number"].Width = 150;

            grid.Columns.Add("Issue_Date", "Issue Date");
            grid.Columns["Issue_Date"].Width = 150;

            grid.Columns.Add("Credits", "Credits");
            grid.Columns["Credits"].Width = 100;

            grid.Columns.Add("Bonus", "Bonus");
            grid.Columns["Bonus"].Width = 100;

            grid.Columns.Add("Tickets", "Tickets");
            grid.Columns["Tickets"].Width = 100;

            grid.Enabled = true;

            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            return grid;
        }

        private void btnConsolidateClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsolidateOk_Click(object sender, EventArgs e)
        {
            try
            {
                TransactionBL trxBL = new TransactionBL();
                if (lstConsolidateCard != null && lstConsolidateCard.Count > 0)
                {
                    Card[] arrayCards = lstConsolidateCard.ToArray();
                    Card updateToCard = new Card();
                    Card tocard = new Card();
                    for (int i = 0; i < arrayCards.Count(); i++)
                    {
                        updateToCard.card_id = arrayCards[i].card_id;
                        updateToCard.credits += arrayCards[i].credits;
                        updateToCard.bonus += arrayCards[i].bonus;
                        updateToCard.ticket_count += arrayCards[i].ticket_count;
                        updateToCard.courtesy += arrayCards[i].courtesy;
                        if (i == arrayCards.Count() - 1)
                        {
                            trxBL.ConsolidateCards(updateToCard, "");
                        }
                        else
                        {
                            tocard.card_id = arrayCards[i].card_id;
                            tocard.credits = 0;
                            tocard.ticket_count = 0;
                            tocard.bonus = 0;
                            tocard.courtesy = 0;
                            trxBL.ConsolidateCards(tocard, "");
                        }
                    }

                    MessageBox.Show("Card Consolidated successfully");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnRefundCardOk_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtCreditsToRefund.Text) || Convert.ToInt32(txtCreditsToRefund.Text) < 0)
                {
                    MessageBox.Show("Enter credits greater than zero to Refund");
                    return;
                }

                if (Convert.ToInt32(txtCreditsToRefund.Text) > Convert.ToInt32(txtTotalCredits.Text))
                {
                    MessageBox.Show("Enter credits less than or equal to available credits");
                    return;
                }

                //Check for partially refund face value
                //Partially face value refund is not allowed
                if(Convert.ToInt32(txtCreditsToRefund.Text) > currentcard.credits 
                    && Convert.ToInt32(txtCreditsToRefund.Text) < Convert.ToInt32(txtTotalCredits.Text))
                {
                    MessageBox.Show("Partially face value Refund is not Allowed");
                    return;
                }


                decimal creditsTorefund = Convert.ToInt32(txtCreditsToRefund.Text);
                int faceValue = Convert.ToInt32(txtCardDeposit.Text);
                decimal totalAvailableCredits = Convert.ToDecimal(txtTotalCredits.Text);

                TransactionBL trxBL = new TransactionBL();

                bool valid = true;

                if (creditsTorefund == totalAvailableCredits)
                {
                    valid = false;
                }
                else
                {
                    faceValue = 0;
                }


                trxBL.RefundCard(currentcard.card_id, creditsTorefund, creditsTorefund, faceValue, valid, string.Empty);

                MessageBox.Show("Card Refunded Successfully");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
       

        private void btnRefundCardClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectProduct_Click(object sender, EventArgs e)
        {
            frmSelectProducts frm = new frmSelectProducts();
            frm.ShowDialog();
        }

        private void txtCreditsToRefund_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
