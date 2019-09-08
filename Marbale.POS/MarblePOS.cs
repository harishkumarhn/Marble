using Marbale.Business;
using Marbale.BusinessObject;
using Marbale.BusinessObject.Cards;
using Marbale.BusinessObject.Discount;
using Marbale.BusinessObject.POSTransaction;
using Marbale.BusinessObject.SiteSetup;
using Marbale.POS.CardDevice;
using Marbale.POS.Common;
using Marble.Business;
using Parafait_POS;
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

        double tendered_amount = 0;
        double total_amount = 0;
        double TipAmount = 0;
        double balance_amount = 0;

        Transaction Transaction;
        Card CurrentCard;
        BusinessObject.Customer.Customers Customer;
        public static User CurrentUser;
        public List<Transaction> ListTransaction;

        Color skinColor;

        public object TranscationBL { get; private set; }

        public MarblePOS()
        {
            posBussiness = new POSBL();
            InitializeComponent();
            skinColor = Color.Gray;

            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
            if (!frmLogin.isLoginSuccess)
                Environment.Exit(0);
            else
            {
                CurrentUser = frmLogin.loggedInUser;
            }
        }

        private void POSHome_Load(object sender, EventArgs e)
        {
            UpdateProductsTab();
            updateCardDetailsGrid();
            registerAdditionalCardReaders();
            updateScreenAmounts();
        }

        class Device
        {
            internal string DeviceName;
            internal string DeviceType;
            internal string DeviceSubType;
            internal string VID, PID, OptString;
        }

        void registerAdditionalCardReaders()
        {
            string USBReaderVID = "VID_FFFF";
            string USBReaderPID = "PID_0035";
            string USBReaderOptionalString = "0000";

            SiteSetupBL siteSetupBussiness = new SiteSetupBL();
            List<AppSetting> ListAppSettings = siteSetupBussiness.GetAppSettings("SiteSetup");

            if (ListAppSettings != null && ListAppSettings.Count > 0)
            {
                AppSetting ReaderVID = ListAppSettings.Find(x => x.Name == "USB_READER_VID");
                if (ReaderVID != null)
                    USBReaderVID = ReaderVID.Value;

                AppSetting ReaderPID = ListAppSettings.Find(x => x.Name == "USB_READER_PID");
                if (ReaderPID != null)
                    USBReaderPID = ReaderPID.Value;

                AppSetting UsbReaderString = ListAppSettings.Find(x => x.Name == "USB_READER_OPT_STRING");
                if (UsbReaderString != null)
                    USBReaderOptionalString = UsbReaderString.Value;
            }

            List<Device> deviceList = new List<Device>();

            if (Devices.PrimaryCardReader == null)
            {
                if (USBReaderVID.Trim() != string.Empty)
                {
                    Device device = new Device();
                    device.DeviceName = "Default";
                    device.DeviceType = "CardReader";
                    device.DeviceSubType = "KeyboardWedge";
                    device.VID = USBReaderVID;
                    device.PID = USBReaderPID;
                    device.OptString = USBReaderOptionalString;

                    deviceList.Add(device);
                }
            }

            EventHandler currEventHandler = new EventHandler(CardScanCompleteEventHandle);
            foreach (Device device in deviceList)
            {
                if (device.DeviceSubType == "KeyboardWedge")
                {
                    USBDevice listener;
                    if (IntPtr.Size == 4) //32 bit
                        listener = new KeyboardWedge32();
                    else
                        listener = new KeyboardWedge64();


                    foreach (string optString in device.OptString.Split('|'))
                    {
                        if (string.IsNullOrEmpty(optString.Trim()))
                            continue;
                        bool flag = listener.InitializeUSBReader(this, device.VID, device.PID, optString.Trim());
                        if (listener.isOpen)
                        {
                            listener.Register(currEventHandler);
                            Devices.AddCardReader(listener);
                            if (Devices.PrimaryCardReader == null)
                            {
                                Devices.PrimaryCardReader = listener;
                            }
                        }
                    }
                }
            }
        }

        private void CardScanCompleteEventHandle(object sender, EventArgs e)
        {
            if (e is DeviceScannedEventArgs)
            {
                DeviceScannedEventArgs checkScannedEvent = e as DeviceScannedEventArgs;

                string CardNumber = checkScannedEvent.Message; // LEFT_TRIM_CARD_NUMBER, RIGHT_TRIM_CARD_NUMBER

                if (System.Text.RegularExpressions.Regex.Matches(CardNumber, "0").Count >= 8)
                {
                    return;
                }
                HandleCardRead(CardNumber, sender as DeviceClass);
            }
        }

        private void HandleCardRead(string CardNumber, DeviceClass readerDevice)
        {
            ClearCard();

            CurrentCard = null;

            TransactionBL trxBL = new TransactionBL();
            CurrentCard = trxBL.GetCard(0, CardNumber);

            if (CurrentCard == null || CurrentCard.card_id == 0)
                CurrentCard = new Card();

            DisplayCardDetails();
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
            Button b = (Button)sender;
            int product_id = Convert.ToInt32(b.Tag);

            ProductBL productBL = new ProductBL();
            Product product = productBL.GetProductById(product_id);

            CreateTransactionLine(product);
        }

        public void CreateTransactionLine(Product product)
        {
            if (Transaction == null)
            {
                Transaction = new Transaction();
                if (CurrentUser != null)
                {
                    Transaction.Username = CurrentUser.LoginId;
                    Transaction.LoginID = CurrentUser.LoginId;
                    Transaction.UserId = CurrentUser.Id;
                }
            }

            if (Transaction.TransactionLines == null)
                Transaction.TransactionLines = new List<TransactionLine>();

            Transaction.TransactionDate = DateTime.Now;


            if (product.Type == "NEW")
            {
                if (CurrentCard == null)
                {
                    MessageBox.Show("Please tap the card");
                    return;
                }

                if (CurrentCard.card_id > 0)
                {
                    MessageBox.Show("Cannot have New Card products for existing card");
                    return;
                }

                bool newProductExists = false;
                for (int i = 0; i < Transaction.TransactionLines.Count; i++)
                {
                    if (Transaction.TransactionLines[i].ProductType == "NEW" && Transaction.TransactionLines[i].CancelledLine == false)
                    {
                        newProductExists = true;
                        break;
                    }
                }
                if (newProductExists)
                {
                    MessageBox.Show("Cannot have multiple New Card products on same card");
                    return;
                }

                if (product.FaceValue > 0)
                    CreateDepositLine(product);
            }
            else if (product.Type == "RECHARGE")
            {
                if (CurrentCard == null)
                {
                    MessageBox.Show("Please tap the card");
                    return;
                }
            }
            else if (product.Type == "RECHARGE")
            {
                if (CurrentCard == null)
                {
                    MessageBox.Show("Please tap the card");
                    return;
                }
            }



            TransactionLine trxLine = new TransactionLine();
            trxLine.ProductID = product.Id;
            trxLine.ProductName = product.Name;
            trxLine.Price = Convert.ToDecimal(product.Price) - Convert.ToDecimal(product.FaceValue);
            trxLine.quantity = 1;

            trxLine.tax_percentage = product.TaxPercentage;
            trxLine.tax_id = product.TaxId;
            trxLine.tax_amount = (double)((product.Price - product.FaceValue) * product.TaxPercentage) / 100;
            trxLine.LineValid = true;
            trxLine.cardId = CurrentCard != null ? CurrentCard.card_id : 0;
            trxLine.amount = Convert.ToDecimal(product.Price) - Convert.ToDecimal(product.FaceValue);
            trxLine.ProductTypeCode = product.Type;
            trxLine.LineAmount = (Convert.ToDecimal(product.Price) - Convert.ToDecimal(product.FaceValue)) + Convert.ToDecimal(trxLine.tax_amount);
            trxLine.Credits = Convert.ToDecimal(product.Credits);
            trxLine.Bonus = Convert.ToDecimal(product.Bonus);
            trxLine.Courtesy = Convert.ToDecimal(product.Courtesy);

            //Transaction.Tax_Amount = 0;
            bool found = false;
            for (int i = 0; i < Transaction.TransactionLines.Count; i++)
            {
                if (Transaction.TransactionLines[i].ProductID == product.Id && Transaction.TransactionLines[i].CancelledLine == false)
                {
                    trxLine.LineValid = false;
                    Transaction.TransactionLines.Add(trxLine);
                    UpdateTrxLine(trxLine, Transaction.TransactionLines[i]);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Transaction.TransactionLines.Add(trxLine);
                //Transaction.Tax_Amount += trxLine.tax_amount;
                trxLine.LineValid = true;
            }


            RefreshTransactionGrid();
            updateScreenAmounts();
        }


        void CreateDepositLine(Product product)
        {
            TransactionLine trxLine = new TransactionLine();
            trxLine.ProductID = 0;
            trxLine.ProductName = "Card Deposit";
            trxLine.Price = Convert.ToDecimal(product.FaceValue);
            trxLine.quantity = 1;
            trxLine.tax_percentage = 0;
            trxLine.tax_amount = 0;
            trxLine.LineValid = true;
            trxLine.cardId = CurrentCard != null ? CurrentCard.card_id : 0;
            trxLine.amount = Convert.ToDecimal(product.FaceValue);
            trxLine.ProductTypeCode = product.Type;
            trxLine.LineAmount = Convert.ToDecimal(product.FaceValue);
            trxLine.ProductType = product.Type;

            if (CurrentCard != null)
            {
                CurrentCard.credits = Convert.ToDecimal(product.Credits);
                CurrentCard.bonus = Convert.ToDecimal(product.Bonus);
                CurrentCard.courtesy = Convert.ToDecimal(product.Courtesy);
                CurrentCard.face_value = Convert.ToDecimal(product.FaceValue);
            }


            Transaction.TransactionLines.Add(trxLine);

        }

        void UpdateTransactionAmount()
        {
            Transaction.Tax_Amount = 0;
            Transaction.Transaction_Amount = 0;
            for (int i = 0; i < Transaction.TransactionLines.Count; i++)
            {
                if (Transaction.TransactionLines[i].LineValid && Transaction.TransactionLines[i].CancelledLine == false)
                {
                    Transaction.Tax_Amount += Transaction.TransactionLines[i].tax_amount;

                    Transaction.Transaction_Amount += Transaction.TransactionLines[i].LineAmount;
                }
            }
        }

        public void UpdateTrxLine(TransactionLine newTrxline, TransactionLine validTrxLine)
        {
            //List<TransactionLine> TrxLines = Transaction.TransactionLines;
            validTrxLine.quantity += newTrxline.quantity;
            validTrxLine.Price += newTrxline.Price;
            validTrxLine.tax_amount += newTrxline.tax_amount;
            validTrxLine.amount += newTrxline.amount;
            validTrxLine.LineAmount += newTrxline.LineAmount;


        }

        public void RefreshTransactionGrid()
        {
            dgvTransaction.Rows.Clear();

            if (Transaction == null)
                return;

            UpdateTransactionAmount();

            for (int i = 0; i < Transaction.TransactionLines.Count; i++)
            {
                if (Transaction.TransactionLines[i].ProductTypeCode == "LOYALTY")
                    Transaction.TransactionLines[i].LineProcessed = true;
                else
                    Transaction.TransactionLines[i].LineProcessed = false;
            }

            dgvTransaction.Columns["Price"].DefaultCellStyle.Format =
            dgvTransaction.Columns["Line_Amount"].DefaultCellStyle.Format =
            dgvTransaction.Columns["Price"].DefaultCellStyle.Format = "#,##0.00";

            int rowcount = 0;
            for (int i = 0; i < Transaction.TransactionLines.Count; i++) // display card lines
            {
                if (Transaction.TransactionLines[i].LineValid && !Transaction.TransactionLines[i].LineProcessed
                    && Transaction.TransactionLines[i].CardNumber != null)
                {
                    dgvTransaction.Rows.Add();

                    string cardnumber = Transaction.TransactionLines[i].CardNumber;
                    if (cardnumber != null)
                    {
                        dgvTransaction.Rows[rowcount].Cells["Card_Number"].Value = cardnumber;
                        dgvTransaction.Rows[rowcount].Cells["Product_Type"].Value = "Card Sale";
                        dgvTransaction.Rows[rowcount].Cells["Product_Name"].Value = cardnumber;
                        dgvTransaction.Rows[rowcount].Cells["LineId"].Value = i;
                        dgvTransaction.Rows[rowcount].Cells["Line_Type"].Value = "Card";

                        dgvTransaction.Rows[rowcount].DefaultCellStyle = getSpecialGridRowFormat(dgvTransaction.DefaultCellStyle);

                        dgvTransaction.Rows[rowcount].MinimumHeight = dgvTransaction.Rows[rowcount].MinimumHeight + 25;

                        rowcount++;

                        for (int j = i; j < Transaction.TransactionLines.Count; j++)
                        {
                            if (cardnumber == Transaction.TransactionLines[j].CardNumber && Transaction.TransactionLines[j].LineValid && Transaction.TransactionLines[j].LineProcessed == false)
                            {
                                dgvTransaction.Rows.Add();
                                dgvTransaction.Rows[rowcount].Cells["Product_Name"].Value = Transaction.TransactionLines[j].ProductName + (string.IsNullOrEmpty(Transaction.TransactionLines[j].AttractionDetails) ? "" : "-" + Transaction.TransactionLines[j].AttractionDetails) + (string.IsNullOrEmpty(Transaction.TransactionLines[j].Remarks) ? "" : "-" + Transaction.TransactionLines[j].Remarks);
                                dgvTransaction.Rows[rowcount].Cells["Quantity"].Value = Transaction.TransactionLines[j].quantity;
                                dgvTransaction.Rows[rowcount].Cells["Price"].Value = Transaction.TransactionLines[j].Price;
                                dgvTransaction.Rows[rowcount].Cells["Remarks"].Value = Transaction.TransactionLines[j].Remarks;
                                dgvTransaction.Rows[rowcount].Cells["AttractionDetails"].Value = Transaction.TransactionLines[j].AttractionDetails;

                                dgvTransaction.Rows[rowcount].Cells["Tax"].Value = Transaction.TransactionLines[j].tax_amount;
                                dgvTransaction.Rows[rowcount].Cells["TaxName"].Value = Transaction.TransactionLines[j].taxName;
                                dgvTransaction.Rows[rowcount].Cells["Line_Amount"].Value = Transaction.TransactionLines[j].LineAmount;
                                dgvTransaction.Rows[rowcount].Cells["LineId"].Value = j;
                                dgvTransaction.Rows[rowcount].Cells["Line_Type"].Value = Transaction.TransactionLines[j].ProductTypeCode;
                                dgvTransaction.Rows[rowcount].Cells["Card_Number"].Value = cardnumber;
                                rowcount++;
                                Transaction.TransactionLines[j].LineProcessed = true;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < Transaction.TransactionLines.Count; i++) // display non-card Transaction lines
            {
                if (Transaction.TransactionLines[i].LineValid && !Transaction.TransactionLines[i].LineProcessed
                    && Transaction.TransactionLines[i].CardNumber == null && !Transaction.TransactionLines[i].CancelledLine)
                {
                    dgvTransaction.Rows.Add();
                    dgvTransaction.Rows[rowcount].Cells["Product_Type"].Value = "Item Sale";
                    dgvTransaction.Rows[rowcount].Cells["LineId"].Value = Transaction.TransactionLines[i].LineId = i;
                    dgvTransaction.Rows[rowcount].Cells["Line_Type"].Value = Transaction.TransactionLines[i].ProductTypeCode;
                    dgvTransaction.Rows[rowcount].Cells["ProductId"].Value = Transaction.TransactionLines[i].ProductID;


                    dgvTransaction.Rows[rowcount].DefaultCellStyle = getSpecialGridRowFormat(dgvTransaction.DefaultCellStyle);
                    dgvTransaction.Rows[rowcount].MinimumHeight = dgvTransaction.Rows[rowcount].MinimumHeight + 25;

                    rowcount++;

                    for (int j = i; j < Transaction.TransactionLines.Count; j++)
                    {
                        if (Transaction.TransactionLines[j].CardNumber == null && Transaction.TransactionLines[j].LineValid
                            && !Transaction.TransactionLines[j].LineProcessed && !Transaction.TransactionLines[j].CancelledLine)
                        {
                            displayNonCardLine(dgvTransaction, Transaction, j, ref rowcount);
                        }
                    }
                }
            }

            int selectedRowIndex = rowcount - 1;
            if (selectedRowIndex < 0)
                selectedRowIndex = 0;

            // display Transaction total
            dgvTransaction.Rows.Add();
            dgvTransaction.Rows[rowcount].Cells["Product_Name"].Value = "Transaction Total";
            dgvTransaction.Rows[rowcount].Cells["Line_Type"].Value = "Transaction Total";
            dgvTransaction.Rows[rowcount].Cells["Tax"].Value = Transaction.Tax_Amount;
            dgvTransaction.Rows[rowcount].Cells["Line_Amount"].Value = Transaction.Transaction_Amount;

            DataGridViewCellStyle dgvtot = getSpecialGridRowFormat(dgvTransaction.DefaultCellStyle, 0);// new DataGridViewCellStyle();
            dgvtot.BackColor =
            dgvtot.SelectionBackColor = Color.LightGray;
            dgvtot.ForeColor =
            dgvtot.SelectionForeColor = Color.Black;
            dgvtot.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTransaction.Rows[rowcount].DefaultCellStyle = dgvtot;
            dgvTransaction.Rows[rowcount].MinimumHeight = dgvTransaction.Rows[rowcount].MinimumHeight + 25;

            rowcount++;

            bool discFound = false;
            if (Transaction.discounts != null && Transaction.discounts.DiscountLines != null)
            {
                foreach (Discounts.DiscountLine dl in Transaction.discounts.DiscountLines)
                {
                    if (dl.LineValid && dl.DiscountAmount != 0)
                    {
                        discFound = true;
                        break;
                    }
                }
            }
            if (discFound)
            {
                bool headerDone = false;
                for (int i = 0; i < Transaction.discounts.DiscountLines.Count; i++) // display discount lines
                {
                    if (Transaction.discounts.DiscountLines[i].LineValid && Transaction.discounts.DiscountLines[i].DiscountAmount > 0)
                    {
                        if (!headerDone)
                        {
                            dgvTransaction.Rows.Add();

                            dgvTransaction.Rows[rowcount].Cells["Product_Type"].Value = "Discount";
                            dgvTransaction.Rows[rowcount].Cells["LineId"].Value = Transaction.discounts.DiscountLines[i].DiscountId;
                            dgvTransaction.Rows[rowcount].Cells["Line_Type"].Value = "Discount";

                            dgvTransaction.Rows[rowcount].DefaultCellStyle = getSpecialGridRowFormat(dgvTransaction.DefaultCellStyle);
                            dgvTransaction.Rows[rowcount].MinimumHeight = dgvTransaction.Rows[rowcount].MinimumHeight + 25;

                            rowcount++;
                            headerDone = true;
                        }

                        dgvTransaction.Rows.Add();
                        dgvTransaction.Rows[rowcount].Cells["Product_Name"].Value = Transaction.discounts.DiscountLines[i].DisplayChar + " " + Transaction.discounts.DiscountLines[i].DiscountName;
                        dgvTransaction.Rows[rowcount].Cells["Quantity"].Value = 1;
                        dgvTransaction.Rows[rowcount].Cells["Price"].Value = Transaction.discounts.DiscountLines[i].DiscountPercentage.ToString("#,##0.00") + "%";
                        dgvTransaction.Rows[rowcount].Cells["Line_Amount"].Value = Transaction.discounts.DiscountLines[i].DiscountAmount;//.ToString(ParafaitUtils.ParafaitEnv.AMOUNT_WITH_CURRENCY_SYMBOL);
                        dgvTransaction.Rows[rowcount].Cells["LineId"].Value = Transaction.discounts.DiscountLines[i].DiscountId;
                        dgvTransaction.Rows[rowcount].Cells["Line_Type"].Value = "Discount";
                        rowcount++;
                    }
                }
            }

            // display grand total
            dgvTransaction.Rows.Add();
            dgvTransaction.Rows[rowcount].Cells["Product_Name"].Value = "Grand Total";
            dgvTransaction.Rows[rowcount].Cells["Line_Amount"].Value = Transaction.Net_Transaction_Amount = Transaction.Transaction_Amount;

            DataGridViewCellStyle dgvgrandtot = getSpecialGridRowFormat(dgvTransaction.DefaultCellStyle, 2);// new DataGridViewCellStyle();
            dgvgrandtot.BackColor =
            dgvgrandtot.SelectionBackColor = Color.Black;
            dgvgrandtot.ForeColor =
            dgvgrandtot.SelectionForeColor = Color.White;
            dgvgrandtot.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTransaction.Rows[rowcount].DefaultCellStyle = dgvgrandtot;
            dgvTransaction.Rows[rowcount].MinimumHeight = dgvTransaction.Rows[rowcount].MinimumHeight + 25;

            rowcount++;

            if (dgvTransaction.Rows.Count > 1)
            {
                dgvTransaction.Rows[selectedRowIndex].Selected = true;
                dgvTransaction.Rows[0].Selected = false;
                dgvTransaction.FirstDisplayedScrollingRowIndex = selectedRowIndex;
            }

            dgvTransaction.Refresh();

            UpdateTransactionAmount();
        }

        static void displayNonCardLine(DataGridView dgvTransaction, Transaction Trx, int j, ref int rowcount)
        {

            dgvTransaction.Rows.Add();
            dgvTransaction.Rows[rowcount].Cells["Product_Name"].Value = Trx.TransactionLines[j].ProductName; // (string.IsNullOrEmpty(Trx.TransactionLines[j].AttractionDetails) ? "" : "-" + Trx.TransactionLines[j].AttractionDetails) + (string.IsNullOrEmpty(Trx.TransactionLines[j].Remarks) ? "" : "-" + Trx.TransactionLines[j].Remarks);
            if (Trx.TransactionLines[j].ParentLine != null)
            {
                int offset = 1;
                TransactionLine tl = Trx.TransactionLines[j].ParentLine;

                while (tl.ParentLine != null)
                {
                    tl = tl.ParentLine;
                    offset++;
                }
                string sOffset = "└";
                sOffset = sOffset.PadLeft(offset * 3 + 1, ' ') + " ";
                dgvTransaction.Rows[rowcount].Cells["Product_Name"].Value = sOffset + dgvTransaction.Rows[rowcount].Cells["Product_Name"].Value;
            }
            else
            {
                string highlight = "";
                foreach (Discounts.DiscountLine dl in Trx.TransactionLines[j].discountLines)
                    highlight += dl.DisplayChar;
                dgvTransaction.Rows[rowcount].Cells["Product_Name"].Value
                                    = highlight + " " + dgvTransaction.Rows[rowcount].Cells["Product_Name"].Value.ToString();
            }

            dgvTransaction.Rows[rowcount].Cells["Quantity"].Value = Trx.TransactionLines[j].quantity;
            dgvTransaction.Rows[rowcount].Cells["Price"].Value = Trx.TransactionLines[j].Price;

            dgvTransaction.Rows[rowcount].Cells["Remarks"].Value = Trx.TransactionLines[j].Remarks;
            //dgvTransaction.Rows[rowcount].Cells["AttractionDetails"].Value = Trx.TransactionLines[j].AttractionDetails;


            dgvTransaction.Rows[rowcount].Cells["Tax"].Value = Trx.TransactionLines[j].tax_amount;
            dgvTransaction.Rows[rowcount].Cells["TaxName"].Value = Trx.TransactionLines[j].taxName;
            dgvTransaction.Rows[rowcount].Cells["Line_Amount"].Value = Trx.TransactionLines[j].LineAmount;
            dgvTransaction.Rows[rowcount].Cells["LineId"].Value = Trx.TransactionLines[j].LineId = j;
            dgvTransaction.Rows[rowcount].Cells["Line_Type"].Value = Trx.TransactionLines[j].ProductTypeCode;

            if (Trx.TransactionLines[j].ProductTypeCode == "MANUAL" && Trx.TransactionLines[j].AllowEdit && Trx.TransactionLines[j].DBLineId == 0)
            {
                dgvTransaction.Rows[rowcount].Cells["Quantity"].Style.BackColor =
                dgvTransaction.Rows[rowcount].Cells["Quantity"].Style.SelectionBackColor = Color.LightBlue;
                dgvTransaction.Rows[rowcount].Cells["Quantity"].Style.ForeColor =
                dgvTransaction.Rows[rowcount].Cells["Quantity"].Style.SelectionForeColor = Color.Blue;
            }

            if (Trx.TransactionLines[j].discountLines.Count > 0 && Trx.TransactionLines[j].AllowEdit)
            {
                dgvTransaction.Rows[rowcount].Cells["Product_Name"].Style.SelectionForeColor =
                    dgvTransaction.Rows[rowcount].Cells["Product_Name"].Style.ForeColor = Color.Green;
            }

            rowcount++;
            Trx.TransactionLines[j].LineProcessed = true;

            for (int k = j + 1; k < Trx.TransactionLines.Count; k++)
            {
                if (Trx.TransactionLines[j].Equals(Trx.TransactionLines[k].ParentLine) && Trx.TransactionLines[k].LineValid && !Trx.TransactionLines[k].LineProcessed)
                    displayNonCardLine(dgvTransaction, Trx, k, ref rowcount);
            }
        }

        static DataGridViewCellStyle getSpecialGridRowFormat(DataGridViewCellStyle refDGV, float FontIncrement = 1.0f)
        {
            DataGridViewCellStyle dgv;
            if (refDGV != null)
                dgv = new DataGridViewCellStyle(refDGV);
            else
                dgv = new DataGridViewCellStyle();
            dgv.BackColor =
            dgv.SelectionBackColor = Color.Gray;
            dgv.ForeColor =
            dgv.SelectionForeColor = Color.White;
            dgv.Font = new Font(refDGV.Font.FontFamily, refDGV.Font.Size + FontIncrement, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)(0));

            return dgv;
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


        private void updateCardDetailsGrid()
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

        private void CreateCardGrid()
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

        private void ChangeLayout()
        {
            //int panelWidth1 = MarbleSplitContainer.Panel1.Width;
            //int panelWidth2 = MarbleSplitContainer.Panel2.Width;

            //MarbleSplitContainer.SplitterDistance = MarbleSplitContainer.Width - MarbleSplitContainer.SplitterWidth-1000;

            if (tbHomeControls.Parent == MarbleSplitContainer.Panel1)
            {
                //MarbleSplitContainer.Panel1.Width = panelWidth2;
                //MarbleSplitContainer.Panel2.Width = panelWidth1;
                MarbleSplitContainer.SplitterDistance = MarbleSplitContainer.Panel2.Width;

                MarbleSplitContainer.Panel1.Controls.Remove(tbHomeControls);
                MarbleSplitContainer.Panel1.Controls.Remove(panelButtons);
                MarbleSplitContainer.Panel2.Controls.Add(tbHomeControls);
                MarbleSplitContainer.Panel2.Controls.Add(panelButtons);

                tbHomeControls.Width = MarbleSplitContainer.Panel2.Width;
                //tbHomeControls.Height = 603; //MarbleSplitContainer.Panel2.Height - panelButtons.Height;

                MarbleSplitContainer.Panel2.Controls.Remove(pnlCardDetails);
                MarbleSplitContainer.Panel1.Controls.Add(pnlCardDetails);

                pnlCardDetails.Size = MarbleSplitContainer.Panel1.ClientSize;
            }
            else
            {
                MarbleSplitContainer.SplitterDistance = MarbleSplitContainer.Panel2.Width;
                MarbleSplitContainer.Panel1.Controls.Add(tbHomeControls);
                MarbleSplitContainer.Panel1.Controls.Add(panelButtons);
                MarbleSplitContainer.Panel2.Controls.Remove(tbHomeControls);
                MarbleSplitContainer.Panel2.Controls.Remove(panelButtons);

                tbHomeControls.Width = MarbleSplitContainer.Panel1.Width;
                //tbHomeControls.Height = 603; // MarbleSplitContainer.Panel1.Height - panelButtons.Height ;

                MarbleSplitContainer.Panel2.Controls.Add(pnlCardDetails);
                MarbleSplitContainer.Panel1.Controls.Remove(pnlCardDetails);

                pnlCardDetails.Size = MarbleSplitContainer.Panel2.ClientSize;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnTask_Click(object sender, EventArgs e)
        {
            ChangeLayout();
        }

        private void btnCancelTrxnLine_Click(object sender, EventArgs e)
        {
            if (Transaction != null && Transaction.TransactionLines != null)
            {
                if (dgvTransaction.SelectedRows.Count == 0)
                {
                    return;
                }

                for (int i = 0; i < dgvTransaction.SelectedRows.Count; i++)
                {
                    int lineId = 0;
                    if (dgvTransaction.SelectedRows[i].Cells["LineId"].Value != null)
                    {
                        lineId = Convert.ToInt32(dgvTransaction.SelectedRows[i].Cells["LineId"].Value);
                        TransactionLine trxLine = Transaction.TransactionLines.Find(x => x.LineId == lineId && x.LineValid == true &&
                        x.CancelledLine == false);

                        if (trxLine != null)
                            trxLine.CancelledLine = true;

                    }
                }

                RefreshTransactionGrid();
                updateScreenAmounts();
            }
        }

        private void btnClearTrxn_Click(object sender, EventArgs e)
        {
            ClearTransaction();
            updateScreenAmounts();
        }

        private void DisplayCardDetails()
        {
            if (CurrentCard == null)
                ClearCard();
            else
            {
                lblCardNotext.Text = CurrentCard.CardNumber;
                lblCardStatustext.Text = CurrentCard.CardStatus;
                txtCardStatus.Text = CurrentCard.CardStatus;

                //Issue date population
                if (CurrentCard.issue_date == DateTime.MinValue)
                {
                    dgvCardDetails.Rows[0].Cells[1].Value = DateTime.Now;
                    CurrentCard.issue_date = DateTime.Now;
                }
                else
                {
                    dgvCardDetails.Rows[0].Cells[1].Value = CurrentCard.issue_date;
                }

                //Card Deposit
                dgvCardDetails.Rows[1].Cells[1].Value = CurrentCard.face_value;

                //Credits
                dgvCardDetails.Rows[2].Cells[1].Value = CurrentCard.credits;

                //Courtesy
                dgvCardDetails.Rows[3].Cells[1].Value = CurrentCard.courtesy;

                //Bonus
                dgvCardDetails.Rows[4].Cells[1].Value = CurrentCard.bonus;

                //Time
                dgvCardDetails.Rows[5].Cells[1].Value = CurrentCard.time;

                //Games
                dgvCardDetails.Rows[6].Cells[1].Value = CurrentCard.CardGames;

                //Credit Plus
                dgvCard.Rows[0].Cells[1].Value = CurrentCard.CreditPlusCredits;

                //Loyalty Points
                dgvCard.Rows[1].Cells[1].Value = CurrentCard.loyalty_points;

                //Recharged / Spent
                dgvCard.Rows[2].Cells[1].Value = CurrentCard.TotalRechargeAmount;

                if (CurrentCard.customer != null)
                {
                    Customer = CurrentCard.customer;
                }

                PopulateCustomer();
            }
        }

        private void ClearTransaction()
        {
            dgvTransaction.Rows.Clear();
            Transaction = null;
            CurrentCard = null;
            ClearCustomer();
            ClearCard();
            updateScreenAmounts();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Transaction == null)
                return;

            if (Customer != null)
                Transaction.customer = Customer;

            if (CurrentCard != null)
                Transaction.Card = CurrentCard;

            while (true)
            {
                frmTender ft = new frmTender((double)Transaction.Net_Transaction_Amount);
                ft.ShowDialog();
                double varAmount = ft.TenderedAmount;

                if (varAmount >= 0)
                {
                    if (varAmount >= (double)Transaction.Net_Transaction_Amount)
                    {
                        tendered_amount = varAmount;
                        updateScreenAmounts();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Please enter equal or greter than total transaction amount");
                    }
                }
                else
                {
                    return;
                }
            }

            TransactionBL trxBL = new TransactionBL();
            int trxId = trxBL.SaveTransaction(Transaction);

            if (trxId > 0)
                MessageBox.Show("Transaction Saved Successfully");

            ClearTransaction();
        }


        private void ClearCustomer()
        {
            Customer = null;
            txtFirstname.Text = string.Empty;
            txtLastname.Text = string.Empty;
            txtPhoneno.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtState.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cmbGender.SelectedIndex = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearCustomer();
        }

        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            if (Customer == null)
                Customer = new BusinessObject.Customer.Customers();

            Customer.first_name = txtFirstname.Text;
            Customer.last_name = txtLastname.Text;
            Customer.contact_phone1 = txtPhoneno.Text;
            Customer.address1 = txtAddress.Text;
            Customer.city = txtCity.Text;
            Customer.state = txtState.Text;
            Customer.country = txtCountry.Text;
            Customer.email = txtEmail.Text;

            if (cmbGender.Text == "Male")
                Customer.gender = 'M';
            else if (cmbGender.Text == "Female")
                Customer.gender = 'F';
            else
                Customer.gender = 'N';

            Customer.birth_date = dtpDOB.Value;
        }

        private void tabControlCardAction_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControlCardAction.SelectedTab.Name == "tabPageCustomer")
            {
                if (cmbGender.Text == string.Empty)
                    cmbGender.SelectedIndex = 0;
            }
            else if (tabControlCardAction.SelectedTab.Name == "tabPageMyTrx")
            {
                UpdateTransactionTab(0);
            }
        }

        private void UpdateTransactionTab(int userId)
        {
            TransactionBL trxBL = new TransactionBL();
            ListTransaction = trxBL.GetTransactionList(userId);

            dgvTrxHeader.DataSource = new List<Transaction>();
            if (ListTransaction != null)
            {
                dgvTrxHeader.DataSource = ListTransaction;
            }
        }

        private void txtPhoneno_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPhoneno.Text))
            {
                TransactionBL trxBL = new TransactionBL();
                Customer = trxBL.GetCustomer(0, txtPhoneno.Text.Trim());

                if (Customer != null && Customer.customer_id > 0)
                    PopulateCustomer();
            }
        }

        void PopulateCustomer()
        {
            if (Customer != null)
            {
                txtFirstname.Text = Customer.first_name;
                txtLastname.Text = Customer.last_name;
                txtPhoneno.Text = Customer.contact_phone1;
                txtAddress.Text = Customer.address1;
                txtCity.Text = Customer.city;
                txtState.Text = Customer.state;
                txtCountry.Text = Customer.country;
                txtEmail.Text = Customer.email;

                if (Customer.gender == 'M')
                    cmbGender.SelectedIndex = 1;
                else if (Customer.gender == 'F')
                    cmbGender.SelectedIndex = 2;
                else
                    cmbGender.SelectedIndex = 0;

                //dtpDOB.Value = Customer.birth_date;
            }
        }

        void ClearCard()
        {
            lblCardNotext.Text = string.Empty;
            lblCardStatustext.Text = string.Empty;
            txtCardStatus.Text = string.Empty;

            //Issue date population
            dgvCardDetails.Rows[0].Cells[1].Value = string.Empty;

            //Card Deposit
            dgvCardDetails.Rows[1].Cells[1].Value = string.Empty;

            //Credits
            dgvCardDetails.Rows[2].Cells[1].Value = string.Empty;

            //Courtesy
            dgvCardDetails.Rows[3].Cells[1].Value = string.Empty;

            //Bonus
            dgvCardDetails.Rows[4].Cells[1].Value = string.Empty;

            //Time
            dgvCardDetails.Rows[5].Cells[1].Value = string.Empty;

            //Games
            dgvCardDetails.Rows[6].Cells[1].Value = string.Empty;

            //Credit Plus
            dgvCard.Rows[0].Cells[1].Value = string.Empty;

            //Loyalty Points
            dgvCard.Rows[1].Cells[1].Value = string.Empty;

            //Recharged / Spent
            dgvCard.Rows[2].Cells[1].Value = string.Empty;
        }

        private void lblCardNumber_Click(object sender, EventArgs e)
        {
            frmGenericDataEntry frm = new frmGenericDataEntry();
            frm.ShowDialog();

            if (!string.IsNullOrEmpty(frm.cardNumber) && frm.cardNumber.Length == 10)
            {
                HandleCardRead(frm.cardNumber, null);
            }
        }

        private void dgvTrxHeader_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvTrxLines.DataSource = new List<TransactionLine>();
            if (dgvTrxHeader["Trx_id", e.RowIndex].Value != null)
            {
                int TrxId = Convert.ToInt32(dgvTrxHeader["Trx_id", e.RowIndex].Value);
                Transaction trx = ListTransaction.Find(x => x.Trx_id == TrxId);
                if (trx != null)
                    dgvTrxLines.DataSource = trx.TransactionLines;
            }
        }

        private void btnReConnectCardReader_Click(object sender, EventArgs e)
        {
            registerAdditionalCardReaders();
        }

        private void btnKeypad_Click(object sender, EventArgs e)
        {
            (sender as Button).FlatAppearance.BorderSize = 0;
            showNumberPadForm('-');
        }

        void showNumberPadForm(char firstKey)
        {
            double varAmount = NumberPadForm.ShowNumberPadForm("Enter Amount", firstKey);
            if (varAmount >= 0)
            {
                tendered_amount = varAmount;
                updateScreenAmounts();
            }
        }


        private void updateScreenAmounts()
        {
            double balanceAmount = 0;
            double changeAmount = 0;
            if (Transaction == null)
            {
                total_amount = 0;
                tendered_amount = 0;
                TipAmount = 0;//Modification on 09-Nov-2015:Tip Amount Feature
            }
            else
            {
                //Begin Modification on 09-Nov-2015:Tip Amount Feature
                total_amount = (double)Transaction.Net_Transaction_Amount + TipAmount;

                if (Transaction.TotalPaidAmount == 0)
                    balanceAmount = total_amount - Transaction.TotalPaidAmount;
                else
                    balanceAmount = total_amount - (Transaction.TotalPaidAmount + Transaction.Tip_Amount);
                changeAmount = Math.Max(tendered_amount - balanceAmount, 0);

                TipAmount = Transaction.Tip_Amount;
            }

            textBoxTransactionTotal.Text = "Rs " + total_amount.ToString(); //.ToString("$"); //AMOUNT_WITH_CURRENCY_SYMBOL
            textBoxBalance.Text = "Rs " + balanceAmount.ToString(); //.ToString("Rs");
            textBoxTendered.Text = "Rs " + tendered_amount.ToString(); //.ToString("$"); //AMOUNT_WITH_CURRENCY_SYMBOL

            txtChangeAmount.Text = "Rs " + changeAmount.ToString(); //.ToString(ParafaitEnv.AMOUNT_WITH_CURRENCY_SYMBOL);
            txtTipAmount.Text = "Rs " + TipAmount.ToString(); //(ParafaitEnv.AMOUNT_WITH_CURRENCY_SYMBOL);
        }
    }
}
