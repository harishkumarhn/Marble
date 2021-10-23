using Marbale.Business;
using Marbale.BusinessObject;
using Marbale.BusinessObject.Cards;
using Marbale.POS.CardDevice;
using Marbale.POS.Common;
using Marbale.POS.Tasks;
using Marble.Business;
using Marble.DataLoggerService;
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
        private readonly DataLogger dataLogger = new DataLogger();
        Card currentcard = new Card();
        int TaskId = 0;
        Card fromCard;
        Card toCard;
        List<Card> lstOfCards;
        List<DataGridView> lstConsolidatedatagridView;
        POSBL posBussiness = new POSBL();
        StaticData staticData = new StaticData();
        int[] LoadMultipleProducts;
        TransactionBL trxBL = new TransactionBL();
        SiteSetupBL siteSetup = new SiteSetupBL();


        const int MAXLOADMULTIPLECARDS = 500;
        //object paramData;
        public frmTasks(int taskId, Card card, StaticData MainstaticData)
        {
            InitializeComponent();
            currentcard = card;
            this.TaskId = taskId;
            lstOfCards = new List<Card>();
            staticData = MainstaticData;
        }
        private void frmTasks_Load(object sender, EventArgs e)
        {
            CardReader.RequiredByOthers = true;
            CardReader.setReceiveAction = TappedCard;
            PoplateForm();
            lstOfCards = new List<Card>();
            Common.Devices.RegisterCardReaders(new EventHandler(CardScanCompleteEventHandle));
        }
        private void CardScanCompleteEventHandle(object sender, EventArgs e)
        {
            dataLogger.Debug("Begin CardScanCompleteEventHandle()");

            if (e is DeviceScannedEventArgs)
            {
                DeviceScannedEventArgs checkScannedEvent = e as DeviceScannedEventArgs;

                string CardNumber = "";
                try
                {
                    CardNumber = checkScannedEvent.Message;
                    HandleCardRead(CardNumber, sender as DeviceClass);
                }
                catch (Exception ex)
                {

                    dataLogger.Error("Ends-CardScanCompleteEventHandle()  " + ex.Message);
                }
            }
            dataLogger.Debug("Ends CardScanCompleteEventHandle()");
        }

        private void HandleCardRead(string CardNumber, DeviceClass readerDevice)
        {
            if (CardReader.CardSwiped)
                CardReader.CardSwiped = false;

            //ClearCard();

            currentcard = null;

            TransactionBL trxBL = new TransactionBL();
            currentcard = trxBL.GetCard(0, CardNumber);

            if (currentcard == null || currentcard.card_id == 0)
                currentcard = new Card();




            TabPage page = CardTabControl.SelectedTab;

            if (page.Name == "tbLoadMultiple")
            {
                AddMultipleCardListBox(CardNumber);
            }
            else if (page.Name == "tbTransferCard")
            {
                PopulateTransferCard();
            }
            else if (page.Name == "tbConsilidated")
            {
                AddConsolidateCardLoad();
            }

        }

        private void InitialMultipleCardListBox()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Card Number", typeof(string)));

            dgvloadCardsList.DataSource = dt;
            dgvloadCardsList.Columns[0].Width = 150;
        }



        private void AddMultipleCardListBox(string cardnuber)
        {

            try
            {
                int CardCount = dgvloadCardsList.Rows.Count;
                if (CardCount == MAXLOADMULTIPLECARDS)
                {
                    MessageBox.Show(GlobalMessage.MAXLOADMULTIPLECARDS_REACHED);
                    return;
                }


                bool cardExist = false;
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn col in dgvloadCardsList.Columns)
                {
                    dt.Columns.Add(col.Name);
                }

                foreach (DataGridViewRow row in dgvloadCardsList.Rows)
                {
                    DataRow dRow = dt.NewRow();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dRow[cell.ColumnIndex] = cell.Value;
                    }
                    if (dRow[0].ToString() == cardnuber)
                    {
                        cardExist = true;
                    }
                    dt.Rows.Add(dRow);

                }


                if (currentcard != null && currentcard.CardStatus == "NEW")
                {
                    DataRow dr = dt.NewRow();

                    if (!cardExist)
                    {
                        dr[0] = cardnuber;
                        dt.Rows.Add(dr);
                    }
                }
                else
                {
                    MessageBox.Show(GlobalMessage.TAP_NEW_CARD);
                }


                dgvloadCardsList.DataSource = dt;

                Card newCard = trxBL.GetCard(0, cardnuber);

                lstOfCards.Add(newCard);
                dgvloadCardsList.Refresh();

            }
            catch (Exception ex)
            {
                dataLogger.Error("Ends-AddMultipleCardListBox() " + ex.Message);
            }



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
                    InitialMultipleCardListBox();
                    //PopulateCardBonusGrid();
                    break;
                case (int)CommonTask.Task.TRANSFERCARD:
                    PopulateTransferCard();
                    break;
                case (int)CommonTask.Task.CANSOLIDATECARD:
                    {
                        lstOfCards = new List<Card>();
                        lstConsolidatedatagridView = new List<DataGridView>();
                        //AddConsolidateCardLoad();
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

        #region TransferCard


        private void PopulateTransferCard()
        {
            if (currentcard != null && currentcard.CardNumber != "")
            {


                if (currentcard.CardNumber != "" && txtFromCardnumber.Text == "")
                {

                    PopulateRefundCardGrid();
                }
                else if (currentcard.CardNumber != "" && txtTocardNumber.Text == "")
                {
                    PopulateToTranferCard();
                }
            }
        }
        private void PopulateFromTranferCard()
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
                    if (fromCard != null && fromCard.card_id > 0)
                    {
                        string[] row1 = new string[] { fromCard.CardNumber, fromCard.issue_date.ToString(), fromCard.credits.ToString(), fromCard.bonus.ToString(), fromCard.ticket_count.ToString() };
                        dgvFromCard.Rows.Add(row1);
                    }

                }
            }
        }
        private void PopulateToTranferCard()
        {
            toCard = new Card();
            if (Validatecard(currentcard.CardNumber))
            {
                toCard = GetCard(currentcard.CardNumber.Trim());

                if (toCard == null || toCard.CardStatus != "NEW")
                {

                    txtTocardNumber.Text = "";
                    MessageBox.Show(GlobalMessage.TAP_NEW_CARD);
                }
                else
                {
                    if (toCard != null && toCard.card_id <= 0)
                    {

                        txtTocardNumber.Text = currentcard.CardNumber;
                        string[] row1 = new string[] { toCard.CardNumber, string.Empty, toCard.credits.ToString(), toCard.bonus.ToString(), toCard.ticket_count.ToString() };
                        dgvToCard.Rows.Add(row1);
                    }
                }
            }
        }



        #endregion



        void PopulateRefundCardGrid()
        {
            if (currentcard != null && currentcard.card_id > 0)
            {
                txtFromCardnumber.Text = currentcard.CardNumber;
                txtCardDeposit.Text = currentcard.face_value.ToString();
                txtTotalCredits.Text = (currentcard.credits + currentcard.face_value).ToString();

                string[] row1 = new string[] { currentcard.CardNumber, currentcard.issue_date.ToString(), currentcard.credits.ToString(), currentcard.bonus.ToString(), currentcard.ticket_count.ToString() };
                dgvRefundCard.Rows.Add(row1);
            }
            else
            {
                txtFromCardnumber.Text = "";
                txtCardDeposit.Text = "0".ToString();
                txtTotalCredits.Text = "0".ToString();
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
            if (lstOfCards != null && lstOfCards.Count > 0)
            {
                foreach (Card swipedcard in lstOfCards)
                {
                    if (swipedcard.CardNumber == card.CardNumber)
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    MessageBox.Show("Card is already Added");
                    return;
                }
            }

            if (card != null && card.card_id > 0)
            {
                string[] row1 = new string[] { card.CardNumber, card.issue_date.ToString(), card.credits.ToString(), card.bonus.ToString(), card.ticket_count.ToString() };
                dataGridView.Rows.Add(row1);
                lstOfCards.Add(card);
                lstConsolidatedatagridView.Add(dataGridView);
                success = true;
            }
            else
            {
                MessageBox.Show("Please tap the valid card");
            }
        }

        #region ConsolidateCard
        private void AddConsolidateCardLoad()
        {
            try
            {
                if (currentcard != null && currentcard.CardNumber != "")
                {
                    if (Validatecard(currentcard.CardNumber))
                    {
                        txtConsolidateCard.Text = currentcard.CardNumber;
                        Card objCard = GetCard(currentcard.CardNumber);
                        bool success = false;
                        DataGridView dataGrid = GetConsolidateNewGrid();
                        PopulateConsoliDateCardGrid(objCard, ref dataGrid, ref success);
                        if (success)
                        {
                            if (lstConsolidatedatagridView != null && lstConsolidatedatagridView.Count > 1)
                            {

                                lstConsolidatedatagridView[lstConsolidatedatagridView.Count - 1].Location = new Point(dgvConsolidateCard.Location.X, lstConsolidatedatagridView[lstConsolidatedatagridView.Count - 2].Location.Y + 60);

                                lstConsolidatedatagridView[lstConsolidatedatagridView.Count - 1].BringToFront();
                                lstConsolidatedatagridView[lstConsolidatedatagridView.Count - 1].Refresh();
                                lstConsolidatedatagridView[lstConsolidatedatagridView.Count - 1].Show();

                                tbConsilidated.Controls.Add(lstConsolidatedatagridView[lstConsolidatedatagridView.Count - 1]);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion
        private void btnGetConsolidateCard_Click(object sender, EventArgs e)
        {
            AddConsolidateCardLoad();
        }


        public DataGridView GetConsolidateNewGrid()
        {
            DataGridView grid = new DataGridView();
            grid.AllowUserToAddRows = dgvConsolidateCard.AllowUserToAddRows;
            grid.AllowUserToDeleteRows = dgvConsolidateCard.AllowUserToDeleteRows;
            grid.AllowUserToResizeColumns = dgvConsolidateCard.AllowUserToResizeColumns;
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
                if (lstOfCards != null && lstOfCards.Count > 0)
                {
                    Card[] arrayCards = lstOfCards.ToArray();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnRefundCardOk_Click(object sender, EventArgs e)
        {
            try
            {
                dataLogger.Debug("Begin tasks btnRefundCardOk_Click");
                List<AppSetting> appCards = new List<AppSetting>();
                appCards = siteSetup.GetAppSettings("POS");


                decimal creditsToRefund = 0;
                decimal.TryParse(txtCreditsToRefund.Text, out creditsToRefund);

                decimal faceValue = 0;
                decimal.TryParse(txtCardDeposit.Text, out faceValue);
                 
                decimal totalAvailCredits = 0;
                decimal.TryParse(txtTotalCredits.Text, out totalAvailCredits);

                

                if (string.IsNullOrEmpty(txtCreditsToRefund.Text) || Convert.ToInt32(txtCreditsToRefund.Text) < 0)
                {
                    MessageBox.Show(GlobalMessage.ENTER_CREDITS_GREATER_THAN_ZERO_TO_REFUND);
                    return;
                }


                //allowing partial refund
                AppSetting partialRefundEnable = appCards.Where(x => x.Name == GlobalConstant.ALLOW_PARTIAL_REFUND).FirstOrDefault();
                if (partialRefundEnable != null && partialRefundEnable.Value.ToLower() == "false")
                {
                    if ( creditsToRefund > Convert.ToInt32(txtTotalCredits.Text))
                    {
                        MessageBox.Show(GlobalMessage.ENTER_CREDITS_LESS_THAN_OR_EQUAL_TO_AVAILABLE_CREDITS);
                        return;
                    }
                }


                //Allow  Refund of Card Deposit
                AppSetting partialRefundDepositEnable = appCards.Where(x => x.Name == GlobalConstant.ALLOW_REFUND_OF_CARD_DEPOSIT).FirstOrDefault();
                if (partialRefundEnable != null && partialRefundEnable.Value.ToLower() == "false")
                {
                    
                }




                //Check for partially refund face value
                //Partially face value refund is not allowed
                if (Convert.ToInt32(txtCreditsToRefund.Text) > currentcard.credits
                    && Convert.ToInt32(txtCreditsToRefund.Text) < Convert.ToInt32(txtTotalCredits.Text))
                {
                    MessageBox.Show("Partially face value Refund is not Allowed");
                    return;
                }


      

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
                dataLogger.Debug("Ends tasks btnRefundCardOk_Click");
                this.Close();
            }
            catch (Exception ex)
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
            Form frmProductList = new Form();


            frmProductList.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frmProductList.Size = new Size(500, 600);
            frmProductList.StartPosition = FormStartPosition.CenterScreen;
            frmProductList.Text = "Load Multiple Card Products";
            frmProductList.BackColor = Color.Gray;
            frmProductList.BringToFront();
            frmProductList.TopMost = true;

            FlowLayoutPanel flpProducts = new FlowLayoutPanel();


            flpProducts.FlowDirection = FlowDirection.LeftToRight;
            flpProducts.WrapContents = true;
            flpProducts.Size = new Size(frmProductList.Width - 7, frmProductList.Height - 80);
            flpProducts.BorderStyle = BorderStyle.FixedSingle;
            flpProducts.BackColor = Color.Gray;
            flpProducts.AutoScroll = true;

            frmProductList.Controls.Add(flpProducts);



            List<Product> lstProducts = posBussiness.GetProductsByScreenGroup(0);

            int i = 0;
            if (lstProducts != null && lstProducts.Count > 0)
            {
                //flpProducts.Controls.Clear();
                foreach (Product product in lstProducts)
                {

                    Button ProductButton = new Button();
                    ProductButton.Click += new EventHandler(ProductSelectButton_Click);
                    ProductButton.Name = "ProductButton" + i.ToString();
                    ProductButton.Text = product.Name.ToString();
                    ProductButton.Tag = product.Id;
                    ProductButton.Font = new Font("arial", 10);
                    ProductButton.ForeColor = Color.White;
                    ProductButton.Size = new Size(150, 80);
                    ProductButton.FlatStyle = FlatStyle.Flat;
                    ProductButton.FlatAppearance.BorderColor = Color.White;
                    //ProductButton.BringToFront();
                    if (product.Type == "CARDSALE")
                        ProductButton.BackColor = Color.MidnightBlue;
                    else if (product.Type == "RECHARGE")
                        ProductButton.BackColor = Color.Olive;
                    else if (product.Type == "GAMETIME")
                        ProductButton.BackColor = Color.Tan;
                    else if (product.Type == GlobalEnum.ProductType.NEW_CARD.DescriptionAttr())
                    {
                        //ProductButton.BackColor = Color.SteelBlue;

                    }

                    flpProducts.Controls.Add(ProductButton);

                    i++;
                }


                Button CancelButton = new Button();
                CancelButton.Click += new EventHandler(CancelButton_Click);
                CancelButton.Name = "CancelButton";
                CancelButton.Text = "Cancel";
                CancelButton.Font = new Font("arial", 10, FontStyle.Bold);
                CancelButton.ForeColor = Color.Black;
                CancelButton.Size = new Size(100, 36);
                CancelButton.Location = new Point(frmProductList.Width / 2 - CancelButton.Width / 2, flpProducts.Bottom + 2);
                CancelButton.BackColor = Color.White;
                frmProductList.Controls.Add(CancelButton);

                frmProductList.CancelButton = CancelButton;

                //dgvSelectedProducts.Rows.Add(new object[] { productId,
                //                                         DT.Rows[0]["product_name"],
                //                                         DT.Rows[0]["price"],
                //                                         DT.Rows[0]["credits"],
                //                                         DT.Rows[0]["Bonus"],
                //                                         DT.Rows[0]["courtesy"],
                //                                         DT.Rows[0]["time"],
                //                                         DT.Rows[0]["product_type"] });
            }
            if (frmProductList.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show("selected");
                int pid = staticData.LoadMultipleProductSelected;
                Product product = posBussiness.GetProductsById(pid);

                dgvSelectedProducts.Rows.Add(new object[] { product.Id,
                                                         product.Name,
                                                        product.Price,
                                                        product.Credits,
                                                        product.Bonus,
                                                         product.Courtesy,
                                                        product.Time,
                                                        product.Type });
            }
            frmProductList.ShowDialog();
        }

        void ProductSelectButton_Click(object sender, EventArgs e)
        {
            dataLogger.Debug("Begin ProductSelectButton_Click   ");
            Form f = ((Button)sender).FindForm();
            f.DialogResult = DialogResult.OK;
            staticData.LoadMultipleProductSelected = Convert.ToInt32(((Button)sender).Tag);
            f.Close();
            dataLogger.Debug("Ends-ProductButton_Click() ");
        }
        void CancelButton_Click(object sender, EventArgs e)
        {
            dataLogger.Debug("Begin CancelButton_Click ");
            ((Button)sender).FindForm().DialogResult = DialogResult.Cancel;
            dataLogger.Debug("Ends CancelButton_Click ");
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

        private void btnTransferCardReset_Click(object sender, EventArgs e)
        {
            ///dgvFromCard
            dgvFromCard.Rows.Clear();
            dgvToCard.Rows.Clear();
            txtFromCardnumber.Text = "";
            txtTocardNumber.Text = "";
        }

        private void tbRefundCard_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = dgvSelectedProducts.CurrentCell.RowIndex;
                if (selectedIndex > -1)
                {
                    dgvSelectedProducts.Rows.RemoveAt(selectedIndex);
                    dgvSelectedProducts.Refresh(); // if needed
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnLoadMultipleOk_Click(object sender, EventArgs e)
        {

            try
            {



                if (lstOfCards.Count == 0)
                {
                    MessageBox.Show(GlobalMessage.NO_CARD_NOT_PRESENT);
                    return;
                }

                //if (lstConsolidateCard.Count < Convert.ToInt32(parameters[1]))
                //{
                //    MessageBox.Show(GlobalMessage.ATLEAST_ONE_CARD_PRESENT);
                //    return;
                //}



                //if (paramData != null)
                //{
                //    object[] parameters = paramData as object[];

                //    
                //}

                //bool newProductFound = false;
                //int newProductIndex = -1;
                //for (int i = 0; i < dgvloadCardsList.Rows.Count; i++)
                //{
                //    string prodType = dgvloadCardsList.Rows[i].Cells["ProductType"].Value.ToString();
                //    if (prodType == "NEW" || prodType == "GAMETIME" || prodType == "CARDSALE")
                //    {
                //        //newProductFound = true;
                //        //newProductIndex = i;
                //        break;
                //    }
                //}
                //if (!newProductFound)
                //{
                //    MessageBox.Show(GlobalMessage.CHOOSE_NEW_CARD);
                //    return;
                //}

                // new product should be the first product 
                //lstConsolidateCard[0] = Convert.ToInt32(dgvloadCardsList.Rows[newProductIndex].Cells["ProductID"].Value);

                int index = 0;
                LoadMultipleProducts = new int[dgvSelectedProducts.Rows.Count];
                for (int i = 0; i < dgvSelectedProducts.Rows.Count; i++)
                {

                    LoadMultipleProducts[index++] = Convert.ToInt32(dgvSelectedProducts.Rows[i].Cells["Id"].Value);

                }


                staticData.LoadMultipleCards = lstOfCards.ToArray();
                staticData.LoadMultipleProducts = LoadMultipleProducts;

            }
            catch (Exception ex)
            {
                dataLogger.Error("Error on btnLoadMultipleOk_Click()", ex);
                MessageBox.Show("Error");
            }
            //ReturnMessage = MessageUtils.getMessage(42);
            //log.Info("Ends-buttonOK_Click() -LOADMULTIPLE- Multiple Card Issue");//Added for logger function on 08-Mar-2016
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
