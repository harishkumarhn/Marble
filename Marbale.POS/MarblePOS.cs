using Marbale.Business;
using Marbale.BusinessObject;
using Marbale.BusinessObject.Cards;
using Marbale.BusinessObject.Discount;
using Marbale.BusinessObject.DisplayGroup;
using Marbale.BusinessObject.POSTransaction;
using Marbale.BusinessObject.SiteSetup;
using Marbale.POS.CardDevice;
using Marbale.POS.Common;
using Marble.Business;
using Parafait_POS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Windows.Forms;

namespace Marbale.POS
{
    public partial class MarblePOS : Form
    {
        POSBL posBussiness;
        double tendered_amount = 0;
        double total_amount = 0;
        double TipAmount = 0;

        Transaction Transaction;
        Card CurrentCard;
        BusinessObject.Customer.Customers Customer;
        public static User CurrentUser;
        public List<Transaction> ListTransaction;

        Color skinColor;
        public Color POSBackColor;

        ListBox cmbDisplayGroups;

        public object TranscationBL { get; private set; }

        public MarblePOS()
        {
            posBussiness = new POSBL();
            InitializeComponent();
            skinColor = Color.Gray;

            //frmLogin frmLogin = new frmLogin();
            //frmLogin.ShowDialog();
            //if (!frmLogin.isLoginSuccess)
            //    Environment.Exit(0);
            //else
            //{
            //    CurrentUser = frmLogin.loggedInUser;
            //}
        }

        private void POSHome_Load(object sender, EventArgs e)
        {
            InitializeProductDisplayGroupDropDown();
            UpdateProductsTab();
            UpdateDiscountsTab();
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

                string CardNumber = string.Empty;
                if (CardReader.CardSwiped == false)
                {
                    CardNumber = checkScannedEvent.Message; // LEFT_TRIM_CARD_NUMBER, RIGHT_TRIM_CARD_NUMBER
                    if (System.Text.RegularExpressions.Regex.Matches(CardNumber, "0").Count >= 8)
                    {
                        return;
                    }
                    CardReader.CardSwiped = true;
                    HandleCardRead(CardNumber, sender as DeviceClass);
                }
            }
        }

        private void HandleCardRead(string CardNumber, DeviceClass readerDevice)
        {
            if(CardReader.CardSwiped)
               CardReader.CardSwiped = false;

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
            cmbDisplayGroups.Items.Clear();
            List<Product> lstProducts = posBussiness.GetProductsByScreenGroup(0);
            TabPage ProductTab = null;
            tabControlProducts.TabPages.Clear();
            FlowLayoutPanel flpProducts = new FlowLayoutPanel();
            if (lstProducts.Count > 0)
            {
                string prev_display_group = "@!@##$#";
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

                    string dispGroup = lstProducts[i].DisplayGroup;
                    if (dispGroup != prev_display_group)
                    {
                        prev_display_group = dispGroup;
                        ProductTab = new TabPage(prev_display_group);
                        ProductTab.Name = prev_display_group;
                        ProductTab.Text = prev_display_group;
                        ProductTab.BackColor = Color.Gray;
                        ProductTab.Text = prev_display_group.Replace("&", "&&");
                        tabControlProducts.TabPages.Add(ProductTab);
                        flpProducts = new FlowLayoutPanel();
                        flpProducts.Dock = DockStyle.Fill;
                        flpProducts.AutoScroll = true;
                        flpProducts.BackColor = Color.Transparent;
                        ProductTab.Controls.Add(flpProducts);

                        cmbDisplayGroups.Items.Add(prev_display_group);
                        int width = (int)(cmbDisplayGroups.CreateGraphics().MeasureString(prev_display_group, cmbDisplayGroups.Font).Width) + 20;
                        if (width > cmbDisplayGroups.Width)
                            cmbDisplayGroups.Width = width;
                    }

                    flpProducts.Controls.Add(btnProduct);
                    //flowLayoutPanelProducts.Controls.Add(btnProduct);
                }

                lblTabText.Text = tabControlProducts.SelectedTab.Text;
            }
        }

        private void UpdateDiscountsTab()
        {
            ProductBL productBL = new ProductBL();
            MasterDiscounts masterDiscounts = productBL.GetAllDiscounts();

            List<TransactionDiscount> lstDiscounts = masterDiscounts.transactiondiscount;

            if (lstDiscounts.Count > 0)
            {
                flowLayoutPanelDiscounts.Controls.Clear();
                for (int i = 0; i < lstDiscounts.Count; i++)
                {
                    Button btnDiscount = new Button();
                    btnDiscount.Click += new EventHandler(DiscountButton_Click);
                    btnDiscount.MouseDown += DiscountButton_MouseDown;
                    btnDiscount.MouseUp += DiscountButton_MouseUp;
                    btnDiscount.Name = lstDiscounts[i].DiscountName + '_' + lstDiscounts[i].DiscountID;
                    btnDiscount.Text = lstDiscounts[i].DiscountName;
                    btnDiscount.Tag = lstDiscounts[i].DiscountID;
                    btnDiscount.Font = btnSampleProduct.Font;
                    btnDiscount.ForeColor = btnSampleProduct.ForeColor;
                    btnDiscount.Size = btnSampleProduct.Size;
                    btnDiscount.BackgroundImage = btnSampleProduct.BackgroundImage;
                    btnDiscount.FlatStyle = btnSampleProduct.FlatStyle;
                    btnDiscount.FlatAppearance.BorderColor = btnSampleProduct.FlatAppearance.BorderColor;
                    btnDiscount.FlatAppearance.BorderSize = btnSampleProduct.FlatAppearance.BorderSize;
                    btnDiscount.FlatAppearance.MouseDownBackColor = btnSampleProduct.FlatAppearance.MouseOverBackColor = Color.Transparent;
                    btnDiscount.BackgroundImageLayout = ImageLayout.Zoom;
                    btnDiscount.BackColor = Color.Transparent;
                    flowLayoutPanelDiscounts.Controls.Add(btnDiscount);
                }
            }
        }

        private void DiscountButton_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int discountId = Convert.ToInt32(b.Tag);

            ProductBL productBL = new ProductBL();
            TransactionDiscount discount = productBL.GetDiscountById(discountId);

            createDiscountLine(discount);
            ApplyDiscountToLines();
            RefreshTransactionGrid();
        }

        bool createDiscountLine(TransactionDiscount discount)
        {
            if (Transaction == null)
                return false;

            string couponNumber = string.Empty;
            Discounts.DiscountLine dl = new Discounts.DiscountLine();

            if (Transaction.discounts == null)
                Transaction.discounts = new Discounts();
            if (Transaction.discounts.DiscountLines == null)
                Transaction.discounts.DiscountLines = new List<Discounts.DiscountLine>();

            bool found = false;
            foreach (Discounts.DiscountLine d in Transaction.discounts.DiscountLines)
            {
                if (d.DiscountId == discount.DiscountID)
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Transaction.discounts.DiscountLines.Add(dl);
                dl.DiscountId = discount.DiscountID;

                dl.DiscountName = discount.DiscountName;
                dl.DiscountPercentage = discount.DiscountPercentage;

                dl.DiscountCouponNumber = string.Empty;
                dl.DiscountCouponSetId = 0;

                if (!couponNumber.Equals(string.Empty))
                {
                    dl.DiscountName += " (Coupon:" + couponNumber + ")";
                }

                switch (Transaction.discounts.DiscountLines.Count % 5)
                {
                    case 1: dl.DisplayChar = "*"; break;
                    case 2: dl.DisplayChar = "^"; break;
                    case 3: dl.DisplayChar = "#"; break;
                    case 4: dl.DisplayChar = "@"; break;
                    case 0: dl.DisplayChar = "$"; break;
                }
            }
            return true;
        }

        public void ApplyDiscountToLines()
        {
            if (Transaction == null)
                return;

            for (int i = 0; i < Transaction.TransactionLines.Count; i++)
            {
                if (Transaction.TransactionLines[i].DBLineId <= 0)
                    Transaction.TransactionLines[i].discountLines.Clear();
            }

            foreach (Discounts.DiscountLine dl in Transaction.discounts.DiscountLines)
            {
                if (dl.LineValid)
                {
                    for (int i = 0; i < Transaction.TransactionLines.Count; i++)
                    {
                        if (Transaction.TransactionLines[i].LineValid)
                        {
                            if (!Transaction.TransactionLines[i].discountLines.Contains(dl)) //Add discounts to line if not added already
                                Transaction.TransactionLines[i].discountLines.Add(dl);
                        }
                    }
                }
            }
            updateAmounts();
        }

        public void updateAmounts()
        {
            decimal Transaction_Amount = 0;
            decimal Pre_TaxAmount = 0;
            decimal Tax_Amount = 0;
            decimal Discount_Amount = 0;
            if (Transaction == null)
            {
                ClearTransaction();
                return;
            }
            if (Transaction.discounts == null)
            {
                Transaction.discounts = new Discounts();
            }

            foreach (Discounts.DiscountLine dl in Transaction.discounts.DiscountLines)
            {
                dl.DiscountAmount = 0;
            }

            for (int i = 0; i < Transaction.TransactionLines.Count; i++)
            {
                if (Transaction.TransactionLines[i].LineValid && Transaction.TransactionLines[i].CancelledLine == false)
                {
                    decimal preTaxLineAmount = 0;
                    if (Transaction.TransactionLines[i].quantity > 1)
                    {
                        preTaxLineAmount = Transaction.TransactionLines[i].LineAmount = Transaction.TransactionLines[i].Price;
                    }
                    else
                    {
                        preTaxLineAmount = Transaction.TransactionLines[i].LineAmount = Transaction.TransactionLines[i].Price * Transaction.TransactionLines[i].quantity;
                    }

                    Pre_TaxAmount += preTaxLineAmount;
                    if (Transaction.TransactionLines[i].quantity == 1)
                        Transaction.TransactionLines[i].tax_amount = preTaxLineAmount * Transaction.TransactionLines[i].tax_percentage / 100;
                    
                   

                    Tax_Amount += Transaction.TransactionLines[i].tax_amount;
                    Transaction.TransactionLines[i].LineAmount += Transaction.TransactionLines[i].tax_amount;
                    Transaction.TransactionLines[i].Discount_Percentage = 0;

                    foreach (Discounts.DiscountLine dl in Transaction.TransactionLines[i].discountLines)
                    {
                        if (dl.LineValid)
                        {
                            Transaction.TransactionLines[i].Discount_Percentage += dl.DiscountPercentage;
                            dl.DiscountAmount += (preTaxLineAmount + Transaction.TransactionLines[i].tax_amount) * dl.DiscountPercentage / 100;
                        }
                    }
                    Discount_Amount += (preTaxLineAmount + Transaction.TransactionLines[i].tax_amount) * Transaction.TransactionLines[i].Discount_Percentage / 100;
                }
            }
            Transaction_Amount = Pre_TaxAmount + Tax_Amount;
            Transaction.Discount_Percentage = GetTransactionDiscountPercentage();
            Transaction.Net_Transaction_Amount =  Math.Round(Transaction_Amount - Discount_Amount, 2, MidpointRounding.AwayFromZero);
        }

        private decimal GetTransactionDiscountPercentage()
        {
            List<Discounts.DiscountLine> distinctDiscountLines = new List<Discounts.DiscountLine>();

            if (Transaction != null && Transaction.discounts != null)
            {
                foreach(Discounts.DiscountLine d in Transaction.discounts.DiscountLines)
                {
                    if (d.LineValid && !distinctDiscountLines.Any(x => x.DiscountId == d.DiscountId && x.LineValid))
                        distinctDiscountLines.Add(d);
                }
            }

           return distinctDiscountLines.Sum(x => x.DiscountPercentage);
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
            trxLine.tax_amount = (decimal) ((product.Price - product.FaceValue) * product.TaxPercentage) / 100;
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

            if (Transaction.discounts != null && Transaction.discounts.DiscountLines != null)
            {
                ApplyDiscountToLines();
            }

            updateAmounts();
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
            dgvTransaction.Rows[rowcount].Cells["Line_Amount"].Value = Transaction.Net_Transaction_Amount;// = Transaction.Transaction_Amount;

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


        private void DiscountButton_MouseDown(object sender, EventArgs e)
        {

        }
        private void DiscountButton_MouseUp(object sender, EventArgs e)
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
            dgvCardDetails.Rows[5].Cells[0].Value = "Tickets"; //Time

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
            posContextMenu.Show(btnTask, new Point(0, 0), ToolStripDropDownDirection.AboveLeft);
            //ChangeLayout();
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

                    if (dgvTransaction.SelectedRows[i].Cells["Line_Type"].Value != null && 
                        dgvTransaction.SelectedRows[i].Cells["Line_Type"].Value.ToString() == "Discount")
                    {
                        int discountId = Convert.ToInt32(dgvTransaction.SelectedRows[i].Cells["LineId"].Value);
                        List<Discounts.DiscountLine> dscLines = Transaction.discounts.DiscountLines.FindAll(x => x.DiscountId == discountId);
                        if (dscLines != null)
                        {
                            foreach (Discounts.DiscountLine ln in dscLines)
                            {
                                ln.LineValid = false;
                            }
                        }
                    }
                }

                List<TransactionLine> activeTrxLns = Transaction.TransactionLines.FindAll(x => x.LineValid == true && x.CancelledLine == false);

                if (activeTrxLns != null && activeTrxLns.Count == 0)
                    ClearTransaction();

                updateAmounts();
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
                dgvCardDetails.Rows[5].Cells[1].Value = CurrentCard.ticket_count; // CurrentCard.time;

                //Games
                dgvCardDetails.Rows[6].Cells[1].Value = CurrentCard.CardGames;

                //Credit Plus
                dgvCard.Rows[0].Cells[1].Value = CurrentCard.CreditPlusCredits;

                //Loyalty Points
                dgvCard.Rows[1].Cells[1].Value = CurrentCard.loyalty_points;

                //Recharged / Spent
                dgvCard.Rows[2].Cells[1].Value = "0/0"; // CurrentCard.TotalRechargeAmount;

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
                        MessageBox.Show("Please enter amount equal or greater than total transaction amount", "Message");
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
            lblCustomerMessage.Text = string.Empty;
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

            lblCustomerMessage.Text = "Customer will be saved after saving Transcation";
        }

        private void tabControlCardAction_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControlCardAction.SelectedTab.Name == "tabPageCustomer")
            {
                lblCustomerMessage.Text = "";
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

                dgvTrxHeader.Columns["POSMachineId"].Visible = false;
                dgvTrxHeader.Columns["POSTypeId"].Visible = false;
                dgvTrxHeader.Columns["Pre_TaxAmount"].Visible = false;
                dgvTrxHeader.Columns["Status"].Visible = false;
                dgvTrxHeader.Columns["Tax_Amount"].Visible = false;
                dgvTrxHeader.Columns["Tip_Amount"].Visible = false;
                dgvTrxHeader.Columns["TokenNumber"].Visible = false;
                dgvTrxHeader.Columns["TotalPaidAmount"].Visible = false;
                //dgvTrxHeader.Columns["DateTimeTransactionDate"].Visible = false;
                dgvTrxHeader.Columns["Transaction_Amount"].Visible = false;
                //dgvTrxHeader.Columns["DateTimeTrxDate"].Visible = false;
                dgvTrxHeader.Columns["TrxProfileId"].Visible = false;
                dgvTrxHeader.Columns["Username"].Visible = false;
                dgvTrxHeader.Columns["UserId"].Visible = false;
                dgvTrxHeader.Columns["CustomerId"].Visible = false;
                dgvTrxHeader.Columns["CreditCardAmount"].Visible = false;
                dgvTrxHeader.Columns["GameCardAmount"].Visible = false;
                dgvTrxHeader.Columns["PrimaryCardId"].Visible = false;
                dgvTrxHeader.Columns["OrderId"].Visible = false;
                dgvTrxHeader.Columns["Remarks"].Visible = false;
                dgvTrxHeader.Columns["ExternalSystemReference"].Visible = false;
                //dgvTrxHeader.Columns["DateTimeLastUpdatedTime"].Visible = false;
                dgvTrxHeader.Columns["Customer"].Visible = false;
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
                {
                    dgvTrxLines.DataSource = trx.TransactionLines;

                    dgvTrxLines.Columns["AllowCancel"].Visible = false;
                    dgvTrxLines.Columns["AllowEdit"].Visible = false;
                    dgvTrxLines.Columns["AllowPriceOverride"].Visible = false;
                    dgvTrxLines.Columns["AttractionDetails"].Visible = false;
                    dgvTrxLines.Columns["CancelledLine"].Visible = false;
                    dgvTrxLines.Columns["CardTypeId"].Visible = false;
                    dgvTrxLines.Columns["CategoryId"].Visible = false;
                    dgvTrxLines.Columns["ComboChildLine"].Visible = false;
                    dgvTrxLines.Columns["CreditPlusConsumptionApplied"].Visible = false;
                    dgvTrxLines.Columns["CreditPlusConsumptionId"].Visible = false;
                    dgvTrxLines.Columns["DBLineId"].Visible = false;
                    dgvTrxLines.Columns["LineProcessed"].Visible = false;
                    dgvTrxLines.Columns["LineValid"].Visible = false;
                    dgvTrxLines.Columns["LockerAllocationId"].Visible = false;
                    dgvTrxLines.Columns["LockerName"].Visible = false;
                    dgvTrxLines.Columns["LockerNumber"].Visible = false;
                    dgvTrxLines.Columns["ModifierLine"].Visible = false;
                    dgvTrxLines.Columns["OriginalLineID"].Visible = false;
                   // dgvTrxLines.Columns["doubleOriginalPrice"].Visible = false;
                
                  
                    dgvTrxLines.Columns["productSplitTaxExists"].Visible = false;
                    dgvTrxLines.Columns["TaxInclusivePrice"].Visible = false;
                    dgvTrxLines.Columns["tax_structer_id"].Visible = false;
                    dgvTrxLines.Columns["LineAmount"].Visible = false;
                    dgvTrxLines.Columns["cardId"].Visible = false;
                    dgvTrxLines.Columns["time"].Visible = false;
                    dgvTrxLines.Columns["Customer"].Visible = false;
                    dgvTrxLines.Columns["ModifierSetId"].Visible = false;
                    //dgvTrxLines.Columns["TransactionLineParentLine"].Visible = false;
                    dgvTrxLines.Columns["PrintKOT"].Visible = false;
                    dgvTrxLines.Columns["ParentLine"].Visible = false;
                }
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (Transaction == null)
            {
                RefreshTabs();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to cancel unsaved Transaction and continue ?", "Confirmation Messages", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    RefreshTabs();
                }
            }
        }

        public void RefreshTabs()
        {
            ClearTransaction();
            updateScreenAmounts();
            UpdateProductsTab();
            UpdateDiscountsTab();
            updateCardDetailsGrid();
            registerAdditionalCardReaders();
            updateScreenAmounts();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to logout ?", "Confirmation Messages", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void posContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
             if (e.ClickedItem.Equals(changeLayoutToolStripMenuItem))
             {
                ChangeLayout();
             }
        }

        void trxButtonMouseUp(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            if (b.Equals(btnSave))
            {
                b.BackgroundImage = Properties.Resources.Save_Transaction;
            }
            else if (b.Equals(btnPayment))
            {
                b.BackgroundImage = Properties.Resources.Payment;
            }
            else if (b.Equals(btnClearTrxn))
            {
                b.BackgroundImage = Properties.Resources.Clear_Transaction;
            }
            else if (b.Equals(btnCancelTrxnLine))
            {
                b.BackgroundImage = Properties.Resources.Cancel_Transaction;
            }
            else if (b.Equals(btnSuspendOrder))
            {
                b.BackgroundImage = Properties.Resources.Payment;
            }
            else if (b.Equals(btnPrint))
            {
                b.BackgroundImage = Properties.Resources.Print;
            }
            else if (b.Equals(btnLoadTickets))
            {
                b.BackgroundImage = Properties.Resources.Load_Tickets;
            }
            else if (b.Equals(btnLoadBonus))
            {
                b.BackgroundImage = Properties.Resources.Load_Bonus;
            }
            else if (b.Equals(btnLoadMultiple))
            {
                b.BackgroundImage = Properties.Resources.Load_Multiple;
            }
            else if (b.Equals(btnTransferCard))
            {
                b.BackgroundImage = Properties.Resources.Transfer_Card;
            }
            else if (b.Equals(btnCansolidateCard))
            {
                b.BackgroundImage = Properties.Resources.Consolidate_Cards;
            }
        }

        private void trxButtonMouseDown(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            if (b.Equals(btnSave))
            {
                b.BackgroundImage = Properties.Resources.Save_Transaction_Pressed;
            }
            else if (b.Equals(btnPayment))
            {
                b.BackgroundImage = Properties.Resources.Payment_Pressed;
            }
            else if (b.Equals(btnClearTrxn))
            {
                b.BackgroundImage = Properties.Resources.Clear_Transaction_Pressed;
            }
            else if (b.Equals(btnCancelTrxnLine))
            {
                b.BackgroundImage = Properties.Resources.Cancel_Trx_Line_Pressed;
            }
            else if (b.Equals(btnSuspendOrder))
            {
                b.BackgroundImage = Properties.Resources.Payment_Pressed;
            }
            else if (b.Equals(btnPrint))
            {
                b.BackgroundImage = Properties.Resources.Print_Pressed;
            }
            else if (b.Equals(btnLoadTickets))
            {
                b.BackgroundImage = Properties.Resources.Load_Tickets_Pressed;
            }
            else if (b.Equals(btnLoadBonus))
            {
                b.BackgroundImage = Properties.Resources.Load_Bonus_Pressed;
            }
            else if (b.Equals(btnLoadMultiple))
            {
                b.BackgroundImage = Properties.Resources.Load_Multiple_Pressed;
            }
            else if (b.Equals(btnTransferCard))
            {
                b.BackgroundImage = Properties.Resources.Transfer_Card_Pressed;
            }
            else if (b.Equals(btnCansolidateCard))
            {
                b.BackgroundImage = Properties.Resources.Consolidate_Cards_Pressed;
            }
        }

        private void btnDisplayGroupDropDown_Click(object sender, EventArgs e)
        {
            if (cmbDisplayGroups.Visible)
            {
                cmbDisplayGroups.Visible = false;
            }
            else
            {
                cmbDisplayGroups.Location = new Point(btnDisplayGroupDropDown.Location.X + btnDisplayGroupDropDown.Width - cmbDisplayGroups.Width - 2, btnDisplayGroupDropDown.Location.Y + btnDisplayGroupDropDown.Height);
                cmbDisplayGroups.BringToFront();

             
                cmbDisplayGroups.Height = (int)(cmbDisplayGroups.Items.Count * cmbDisplayGroups.ItemHeight * 1.1);

                if (cmbDisplayGroups.Height > tbPageProducts.Height - 40)
                {
                    cmbDisplayGroups.Height = tbPageProducts.Height - 40;
                    cmbDisplayGroups.ScrollAlwaysVisible = true;
                }
                else
                    cmbDisplayGroups.ScrollAlwaysVisible = false;

                cmbDisplayGroups.Visible = true;
                this.ActiveControl = cmbDisplayGroups;
                cmbDisplayGroups.Focus();
            }
        }

        void InitializeProductDisplayGroupDropDown()
        {   
            cmbDisplayGroups = new ListBox();
            cmbDisplayGroups.Font = new Font("Arial", 14.0F);
            cmbDisplayGroups.SelectionMode = SelectionMode.One;
            cmbDisplayGroups.Visible = false;
            cmbDisplayGroups.SelectedIndexChanged += new EventHandler(cmbDisplayGroups_SelectedIndexChanged);
            cmbDisplayGroups.LostFocus += new EventHandler(cmbDisplayGroups_LostFocus);
            cmbDisplayGroups.HorizontalScrollbar = false;
            cmbDisplayGroups.ScrollAlwaysVisible = false;

            //POSBL posBL = new POSBL();
            //List<DisplayGroup> listDisplayGroup = posBL.GetDisplayGroup(0);

            //cmbDisplayGroups.DataSource = listDisplayGroup;
            //cmbDisplayGroups.ValueMember = "displayGroupId";
            //cmbDisplayGroups.DisplayMember = "displayGroupname";

            tbPageProducts.Controls.Add(cmbDisplayGroups);
        }

        void cmbDisplayGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            //tbPageProducts.select = cmbDisplayGroups.SelectedIndex;
            cmbDisplayGroups.Visible = false;
            tabControlProducts.SelectedIndex = cmbDisplayGroups.SelectedIndex;
            lblTabText.Text = tabControlProducts.SelectedTab.Text;
        }

        void cmbDisplayGroups_LostFocus(object sender, EventArgs e)
        {
            if (!btnDisplayGroupDropDown.Focused)
                cmbDisplayGroups.Visible = false;
        }

        private void btnPrevProductGroup_Click(object sender, EventArgs e)
        {
            try
            {
                int i = tabControlProducts.SelectedIndex - 1;
                if (i < 0)
                    i = tabControlProducts.TabPages.Count - 1;

                tabControlProducts.SelectedIndex = i;
                lblTabText.Text = tabControlProducts.SelectedTab.Text;
            }
            catch{ }
        }

        private void btnNextProductGroup_Click(object sender, EventArgs e)
        {
          
            try
            {
                int i = tabControlProducts.SelectedIndex + 1;
                if (i >= tabControlProducts.TabPages.Count)
                    i = 0;

                tabControlProducts.SelectedIndex = i;
                lblTabText.Text = tabControlProducts.SelectedTab.Text;
            }
            catch
            {
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string ReEnteredPassword = txtReEnterNewPassword.Text;


            if (string.IsNullOrEmpty(currentPassword))
            {
                MessageBox.Show("Please Enter Current Password");
                return;
            }

            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Please Enter New Password");
                return;
            }

            if (string.IsNullOrEmpty(ReEnteredPassword))
            {
                MessageBox.Show("Please Re Enter Password");
                return;
            }

            if (newPassword != ReEnteredPassword)
            {
                MessageBox.Show("New Password and Re Entered Password not Matching");
                return;
            }

            if(CurrentUser != null && CurrentUser.Password != currentPassword)
            {
                MessageBox.Show("Current Password is Incorrect");
                return;
            }

            posBussiness.ChangeUserPassword(CurrentUser.Id, currentPassword, newPassword);
            MessageBox.Show("Password is Changed Successfully");
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtReEnterNewPassword.Text = "";
        }

        private void btnChangeSkinColor_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ColorDialog colorDialogBox = new ColorDialog();
            colorDialogBox.FullOpen = true;

            DialogResult CDR = colorDialogBox.ShowDialog();

            if (CDR == DialogResult.OK)
            {
                btnChangeSkinColor.ForeColor = colorDialogBox.Color;
                POSBackColor = colorDialogBox.Color;
                SetPOSBackgroundColor();
            }
        }

        private void SetPOSBackgroundColor()
        {
            this.BackColor = POSBackColor;

            foreach (TabPage tp in tabControlProducts.TabPages)
                tp.BackColor = POSBackColor;
            flowLayoutPanelDiscounts.BackColor = POSBackColor;
            flowLayoutPanelFunctions.BackColor = POSBackColor;

            panelButtons.BackColor = POSBackColor;

            foreach (TabPage tp in tbHomeControls.TabPages)
                tp.BackColor = POSBackColor;

            dgvTransaction.BackgroundColor = POSBackColor;
        }

        private void buttonSkinColorReset_Click(object sender, EventArgs e)
        {
            POSBackColor = Color.Gray;
            SetPOSBackgroundColor();
            dgvTransaction.BackgroundColor = Color.LightBlue;
        }

        private void btnLoadTickets_Click(object sender, EventArgs e)
        {
            if (CurrentCard == null)
            {
                MessageBox.Show("Please tap the card");
                return;
            }

            if(CurrentCard.card_id <= 0)
            {
                MessageBox.Show("Can't Load tickets to the New card");
                return;
            }

            frmTasks frm = new frmTasks((int)Tasks.CommonTask.Task.LOADTICKETS, CurrentCard);
            frm.ShowDialog();
            HandleCardRead(CurrentCard.CardNumber, null);

            //if (frm.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            //{
            //    HandleCardRead(CurrentCard.CardNumber, null);
            //}
        }

        private void btnLoadBonus_Click(object sender, EventArgs e)
        {
            if (CurrentCard == null)
            {
                MessageBox.Show("Please tap the card");
                return;
            }

            if (CurrentCard.card_id <= 0)
            {
                MessageBox.Show("Can't Load Bonus to the New card");
                return;
            }

            frmTasks frm = new frmTasks((int)Tasks.CommonTask.Task.LOADBONUS, CurrentCard);
            frm.ShowDialog();
            HandleCardRead(CurrentCard.CardNumber, null);

            //if (frm.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            //{
            //    HandleCardRead(CurrentCard.CardNumber, null);
            //}
        }

        private void btnTransferCard_Click(object sender, EventArgs e)
        {
            frmTasks frm = new frmTasks((int)Tasks.CommonTask.Task.TRANSFERCARD, CurrentCard);
            frm.ShowDialog();
        }

        private void btnLoadMultiple_Click(object sender, EventArgs e)
        {
            frmTasks frm = new frmTasks((int)Tasks.CommonTask.Task.LOADMULTIPLE, CurrentCard);
            frm.ShowDialog();
        }

        private void btnCansolidateCard_Click(object sender, EventArgs e)
        {
            frmTasks frm = new frmTasks((int)Tasks.CommonTask.Task.CANSOLIDATECARD, CurrentCard);
            frm.ShowDialog();
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            if(CurrentCard == null)
            {
                MessageBox.Show("Please tap the card");
                return;
            }

            if (CurrentCard.card_id == -1 || CurrentCard.CardStatus == "NEW")
            {
                MessageBox.Show("Can't Refund New Card");
                return;
            }

            frmTasks frm = new frmTasks((int)Tasks.CommonTask.Task.REFUNDCARD, CurrentCard);
            frm.ShowDialog();

            HandleCardRead(CurrentCard.CardNumber, null);
        }
    }
}
