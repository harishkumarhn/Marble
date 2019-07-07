using Marbale.BusinessObject.Cards;
using Marbale.BusinessObject.POSTransaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.POS.Common
{
    public class staticData
    {
        public int LoadMultipleProductPicked;
        public int[] LoadMultipleProducts;
        public Card[] LoadMultipleCards;

        public DateTime LoginTime;
        public int SystemTicketNumber = 0;

        public double PaymentCashAmount = 0;
        public double PaymentCreditCardAmount = 0;
        public double PaymentGameCardAmount = 0;
        public double PaymentOtherModeAmount = 0;
        public double PaymentRoundOffAmount = 0;

        public double PaymentCreditCardSurchargeAmount = 0;

        public string PaymentCardNumber;
        public string PaymentReference;

        public double PaymentUsedCredits;
        public double PaymentCreditPlus;

        public int GameCardId;
        public DateTime GameCardReadTime;

        public object PaymentModeId;
        public lastTransactionInfo LastTransactionInfo;


        public staticData()
        {

        }

        public class PaymentModeDetail
        {
            public int PaymentId = -1;
            public string PaymentMode;
            public string CreditCardNumber;
            public string CreditCardExpiry;
            public string NameOnCard;
            public string CreditCardName;
            public string CreditCardAuthorization;
            public string Reference;
            public double Amount;
            public bool isCreditCard = false;
            public bool isDebitCard = false;
            public bool isCash = false;
            public bool isRoundOff = false;
            public object PaymentModeId;
            //public CreditCardPaymentGateway.Gateways Gateway = CreditCardPaymentGateway.Gateways.None;
            public bool GatewayPaymentProcessed = false;
            public string Memo = "";
            public DateTime PaymentDate;
            public int TrxId;
            public object CCResponseId = DBNull.Value;
            public object GatewayObject;
        }
        public List<PaymentModeDetail> PaymentModeDetails = new List<PaymentModeDetail>();

        public string LoginId;
        public int UserId;
        public string Username;
        public string POSMachine;
        public int POSMachineId;
        public int POSTypeId;
        public int ManagerId = -1;
        public string Manager_Flag;
        public string POS_LEGAL_ENTITY;
        public int DEFAULT_PAY_MODE;

        public string ShowPrintDialog;
        public string PRINT_TICKET_FOR_PRODUCT_TYPES;
        public string PRINT_TICKET_FOR_EACH_QUANTITY;
        public string ALLOW_ONLY_GAMECARD_PAYMENT_IN_POS;
        public string TRANSACTION_ITEM_SLIPS_GAP;
        public string TRX_AUTO_PRINT_AFTER_SAVE;
        public string ALLOW_TRX_PRINT_BEFORE_SAVING;
        public string CLEAR_TRX_AFTER_PRINT;
        public string PRINT_TRANSACTION_ITEM_SLIPS;
        public string PRINT_TRANSACTION_ITEM_TICKETS;
        public string PRINT_RECEIPT_ON_BILL_PRINTER;
        public string PRINT_TICKET_BORDER;
        public string OPEN_CASH_DRAWER;
        public string CASH_DRAWER_INTERFACE;
        public byte[] CASH_DRAWER_PRINT_STRING;
        public int CASH_DRAWER_SERIAL_PORT;
        public int CASH_DRAWER_SERIAL_PORT_BAUD;
        public byte[] CASH_DRAWER_SERIALPORT_STRING;

        public bool CUT_RECEIPT_PAPER;
        public bool CUT_TICKET_PAPER;
        public byte[] CUT_PAPER_PRINTER_COMMAND;

        public int specialPricingId = -1;
        public string specialPricingRemarks = "";

        public string CheckInPhotoDirectory;
        public string ImageDirectory;
        public string CARD_ISSUE_MANDATORY_FOR_CHECKIN;
        public string CARD_ISSUE_MANDATORY_FOR_CHECKOUT;
        public string CARD_ISSUE_MANDATORY_FOR_CHECKIN_DETAILS;
        public string PHOTO_MANDATORY_FOR_CHECKIN;
        public string REFUND_REMARKS_MANDATORY;
        public string WRIST_BAND_FACE_VALUE;
        public string CHECKIN_DETAILS_RFID_TAG;
        public double DAYS_TO_KEEP_PHOTOS_FOR;

        public int TodaysFirstTrxId;
        public int LastTrxNoForPOS;
        public int MaxTokenNumber;
        public string TaxIdentificationNumber;

        public int RECEIPT_PRINT_TEMPLATE_ID;

        public int RefundCardTaxId = -1;
        public double RefundCardTaxPercent = 0;
        public int CardDepositProductId = -1;
        public int CreditCardSurchargeProductId;
        public string CreditCardSurchargeProductName;
        public int VariableRechargeProductId = -1;
        public int ExternalPOSUserId = -1;

        public int TICKETS_TO_REDEEM_PER_BONUS;

        public string AUTO_POPUP_CARD_PROMOTIONS_IN_POS;
        public string RESET_TRXNO_AT_POS_LEVEL;
        public string LOAD_FULL_VAR_AMOUNT_AS_CREDITS;

        public int RoundOffPaymentModeId;
        public int RoundOffAmountTo;

        public string RoundingType = "ROUND";

        public bool POSTTransactionProcessingExists = false;


        public void ClearPaymentData()
        {
            PaymentCashAmount = 0;
            PaymentCreditCardAmount = 0;
            PaymentGameCardAmount = 0;
            PaymentOtherModeAmount = 0;
            PaymentRoundOffAmount = 0;

            PaymentCreditCardSurchargeAmount = 0;

            PaymentCardNumber = "";
            PaymentUsedCredits = 0;
            PaymentCreditPlus = 0;

            PaymentModeDetails.Clear();

            PaymentModeId = -1;
            GameCardId = -1;
            PaymentReference = "";
        }

        public void ClearSpecialPricing()
        {
            specialPricingId = -1;
            specialPricingRemarks = "";
        }

        public class lastTransactionInfo
        {
            public Transaction LastTrx;
            public int TrxId;
            public string TrxNo;
            public string PrimaryPaymentCardNumber;
            public int PrimaryPaymentCardId;
            public Card PrimaryCard;
            public double PrimaryCardBalance, PrimaryCardCreditBalance, PrimaryCardBonusBalance;
            public double ExpiringCPCredits, ExpiringCPBonus, ExpiringCPLoyalty;
            public int ExpiringCPTickets;
            public DateTime CPCreditsExpiryDate, CPBonusExpiryDate, CPLoyaltyExpiryDate, CPTicketsExpiryDate;
            public string PrimaryCustomerName;
            public string Address;
            public string City;
            public string State;
            public string Pin;
            public string Phone;
            public int OrderId = -1;
            public string TableNumber, WaiterName, OrderCustomerName;
            public string Remarks;
            public double TaxableAmount, NonTaxableAmount, DiscountedTaxAmount;
            public double PaymentCashAmount, PaymentGameCardAmount, PaymentCreditCardAmount, PaymentOtherModeAmount, PaymentRoundOffAmount;
            public double TenderedAmount, ChangeAmount;
            public double LoyaltyPoints;
            public int Tickets;
            public string PaymentCreditCardNumber, OtherPaymentMode, PaymentReference;
            public string TrxProfile;

            public class CardInfo
            {
                public string CardNumber;
                public decimal FaceValue;
                public string CustomerName;
                public decimal TaxAmount;
                public decimal Amount;
                public decimal RedeemableValue;
                public decimal BonusValue;
                public decimal TimeValue;
            }
            public List<CardInfo> TrxCards = new List<CardInfo>();

            public class TaxInfo
            {
                public string TaxName;
                public decimal Percentage;
                public decimal TaxAmount;
            }
            public List<TaxInfo> TrxTax = new List<TaxInfo>();

            public List<PaymentModeDetail> PaymentModes = new List<PaymentModeDetail>();

            public void clearLastTransactionInfo()
            {
                TrxId = -1;
                TrxNo = "-1";
                OrderId = -1;
                OrderCustomerName = TableNumber = WaiterName = PrimaryCustomerName = Address = City = State = Pin = Phone = "";
                PrimaryCardBalance = TaxableAmount = NonTaxableAmount = DiscountedTaxAmount = PrimaryCardCreditBalance = PrimaryCardBonusBalance = 0;
                PaymentCashAmount = PaymentCreditCardAmount = PaymentGameCardAmount = PaymentOtherModeAmount = PaymentRoundOffAmount = 0;
                PrimaryCard = null;
                TenderedAmount = ChangeAmount = 0;
                LoyaltyPoints = Tickets = 0;
                PrimaryPaymentCardId = -1;
                PaymentCreditCardNumber = OtherPaymentMode = "";
                Remarks = PrimaryPaymentCardNumber = "";
                ExpiringCPCredits = ExpiringCPBonus = ExpiringCPLoyalty = ExpiringCPTickets = 0;
                CPCreditsExpiryDate = CPBonusExpiryDate = CPLoyaltyExpiryDate = CPTicketsExpiryDate = DateTime.MinValue;
                TrxProfile = "";

                TrxCards.Clear();
                TrxTax.Clear();
                PaymentModes.Clear();
            }

        }

      

        public bool InitializeVariables()
        {
            string message = "";
            return InitializeVariables(ref message);
        }

        public bool InitializeVariables(ref string message)
        {
            //Username = Utilities.ParafaitEnv.Username;
            //LoginId = Utilities.ParafaitEnv.LoginID;
            //POSMachine = Utilities.ParafaitEnv.POSMachine;
            //POSTypeId = Utilities.ParafaitEnv.POSTypeId;
            //POSMachineId = Utilities.ParafaitEnv.POSMachineId;
            //Manager_Flag = Utilities.ParafaitEnv.Manager_Flag;
            //POS_LEGAL_ENTITY = Utilities.ParafaitEnv.POS_LEGAL_ENTITY;

            //using (SqlConnection cnn = Utilities.createConnection())
            //{
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.Connection = cnn;

            //    cmd.CommandText = "select top 1 tax_id " +
            //                      "from Products p, product_type pt " +
            //                      "where product_type = 'REFUND' " +
            //                      "and p.product_type_id = pt.product_type_id";
            //    object o = cmd.ExecuteScalar();
            //    if (o == null)
            //    {
            //        message = Utilities.MessageUtils.getMessage(351);
            //        return false;
            //    }
            //    else if (o != DBNull.Value)
            //    {
            //        RefundCardTaxId = Convert.ToInt32(o);

            //        cmd.CommandText = "select isnull(tax_percentage, 0) " +
            //                      "from tax where tax_id = @taxid";
            //        cmd.Parameters.AddWithValue("@taxid", RefundCardTaxId);

            //        RefundCardTaxPercent = Convert.ToDouble(cmd.ExecuteScalar());
            //    }

            //    cmd.CommandText = "select top 1 product_id " +
            //                      "from Products p, product_type pt " +
            //                      "where product_type = 'CARDDEPOSIT' " +
            //                      "and p.product_type_id = pt.product_type_id";
            //    o = cmd.ExecuteScalar();
            //    if (o == null)
            //    {
            //        message = Utilities.MessageUtils.getMessage(352);
            //        return false;
            //    }
            //    else
            //    {
            //        CardDepositProductId = Convert.ToInt32(o);
            //    }

            //    cmd.CommandText = "select top 1 product_id, product_name " +
            //                      "from Products p, product_type pt " +
            //                      "where product_type = 'CREDITCARDSURCHARGE' " +
            //                      "and p.product_type_id = pt.product_type_id";
            //    SqlDataAdapter dacc = new SqlDataAdapter(cmd);
            //    DataTable dtcc = new DataTable();
            //    dacc.Fill(dtcc);
            //    if (dtcc.Rows.Count == 0)
            //    {
            //        message = Utilities.MessageUtils.getMessage(353);
            //        return false;
            //    }
            //    else
            //    {
            //        CreditCardSurchargeProductId = Convert.ToInt32(dtcc.Rows[0][0]);
            //        CreditCardSurchargeProductName = dtcc.Rows[0][1].ToString();
            //    }

            //    cmd.CommandText = "select top 1 1 from PostTransactionProcesses where Active = 1";
            //    POSTTransactionProcessingExists = (cmd.ExecuteScalar() != null);

            //    try
            //    {
            //        try
            //        {
            //            RECEIPT_PRINT_TEMPLATE_ID = (int)Convert.ToDouble(Utilities.getParafaitDefaults("RECEIPT_PRINT_TEMPLATE"));
            //        }
            //        catch
            //        {
            //            RECEIPT_PRINT_TEMPLATE_ID = -1;
            //        }

            //        try
            //        {
            //            populatePrinters();
            //        }
            //        catch (Exception ex)
            //        {
            //            message = "Populate Printers: " + ex.Message;
            //            return false;
            //        }

            //        DEFAULT_PAY_MODE = Utilities.ParafaitEnv.DEFAULT_PAY_MODE;

            //        ShowPrintDialog = Utilities.getParafaitDefaults("SHOW_PRINT_DIALOG_IN_POS");
            //        PRINT_TICKET_FOR_PRODUCT_TYPES = Utilities.getParafaitDefaults("PRINT_TICKET_FOR_PRODUCT_TYPES");
            //        PRINT_TICKET_BORDER = Utilities.getParafaitDefaults("PRINT_TICKET_BORDER");
            //        PRINT_TICKET_FOR_EACH_QUANTITY = Utilities.getParafaitDefaults("PRINT_TICKET_FOR_EACH_QUANTITY");
            //        ALLOW_ONLY_GAMECARD_PAYMENT_IN_POS = Utilities.getParafaitDefaults("ALLOW_ONLY_GAMECARD_PAYMENT_IN_POS");
            //        TRX_AUTO_PRINT_AFTER_SAVE = Utilities.getParafaitDefaults("TRX_AUTO_PRINT_AFTER_SAVE");
            //        ALLOW_TRX_PRINT_BEFORE_SAVING = Utilities.getParafaitDefaults("ALLOW_TRX_PRINT_BEFORE_SAVING");
            //        CLEAR_TRX_AFTER_PRINT = Utilities.getParafaitDefaults("CLEAR_TRX_AFTER_PRINT");
            //        PRINT_TRANSACTION_ITEM_SLIPS = Utilities.getParafaitDefaults("PRINT_TRANSACTION_ITEM_SLIPS");
            //        PRINT_TRANSACTION_ITEM_TICKETS = Utilities.getParafaitDefaults("PRINT_TRANSACTION_ITEM_TICKETS");
            //        PRINT_RECEIPT_ON_BILL_PRINTER = Utilities.getParafaitDefaults("PRINT_RECEIPT_ON_BILL_PRINTER");
            //        OPEN_CASH_DRAWER = Utilities.getParafaitDefaults("OPEN_CASH_DRAWER");
            //        CASH_DRAWER_INTERFACE = Utilities.getParafaitDefaults("CASH_DRAWER_INTERFACE");
            //        CUT_RECEIPT_PAPER = Utilities.getParafaitDefaults("CUT_RECEIPT_PAPER") == "Y" ? true : false;
            //        CUT_TICKET_PAPER = Utilities.getParafaitDefaults("CUT_TICKET_PAPER") == "Y" ? true : false;

            //        RESET_TRXNO_AT_POS_LEVEL = Utilities.getParafaitDefaults("RESET_TRXNO_AT_POS_LEVEL");
            //        LOAD_FULL_VAR_AMOUNT_AS_CREDITS = Utilities.getParafaitDefaults("LOAD_FULL_VAR_AMOUNT_AS_CREDITS");

            //        try
            //        {
            //            string[] strCASH_DRAWER_PRINT_STRING = Utilities.getParafaitDefaults("CASH_DRAWER_PRINT_STRING").Split(',');
            //            CASH_DRAWER_PRINT_STRING = new byte[strCASH_DRAWER_PRINT_STRING.Length];
            //            int i = 0;
            //            foreach (string str in strCASH_DRAWER_PRINT_STRING)
            //                CASH_DRAWER_PRINT_STRING[i++] = Convert.ToByte(Convert.ToInt32(str.Trim()));
            //        }
            //        catch
            //        {
            //            CASH_DRAWER_PRINT_STRING = new byte[] { 27, 112, 0, 100, 250 };
            //        }

            //        try
            //        {
            //            string[] strCASH_DRAWER_SERIALPORT_STRING = Utilities.getParafaitDefaults("CASH_DRAWER_SERIALPORT_STRING").Split(',');
            //            CASH_DRAWER_SERIALPORT_STRING = new byte[strCASH_DRAWER_SERIALPORT_STRING.Length];
            //            int i = 0;
            //            foreach (string str in strCASH_DRAWER_SERIALPORT_STRING)
            //                CASH_DRAWER_SERIALPORT_STRING[i++] = Convert.ToByte(Convert.ToInt32(str.Trim()));
            //        }
            //        catch
            //        {
            //            CASH_DRAWER_SERIALPORT_STRING = new byte[] { 27, 112, 0, 100, 250 };
            //        }

            //        try
            //        {
            //            string[] strCUT_PAPER_PRINTER_COMMAND = Utilities.getParafaitDefaults("CUT_PAPER_PRINTER_COMMAND").Split(',');
            //            CUT_PAPER_PRINTER_COMMAND = new byte[strCUT_PAPER_PRINTER_COMMAND.Length];
            //            int i = 0;
            //            foreach (string str in strCUT_PAPER_PRINTER_COMMAND)
            //                CUT_PAPER_PRINTER_COMMAND[i++] = Convert.ToByte(Convert.ToInt32(str.Trim()));
            //        }
            //        catch
            //        {
            //            CUT_PAPER_PRINTER_COMMAND = new byte[] { 29, 86, 1 };
            //        }

            //        try
            //        {
            //            CASH_DRAWER_SERIAL_PORT = Convert.ToInt32(double.Parse(Utilities.getParafaitDefaults("CASH_DRAWER_SERIAL_PORT")));
            //        }
            //        catch
            //        {
            //            CASH_DRAWER_SERIAL_PORT = 0;
            //        }

            //        try
            //        {
            //            CASH_DRAWER_SERIAL_PORT_BAUD = Convert.ToInt32(double.Parse(Utilities.getParafaitDefaults("CASH_DRAWER_SERIAL_PORT_BAUD")));
            //        }
            //        catch
            //        {
            //            CASH_DRAWER_SERIAL_PORT_BAUD = 1200;
            //        }

            //        if (CASH_DRAWER_INTERFACE == "Serial Port")
            //        {
            //            try
            //            {
            //                CashDrawerSerialPort = new ParafaitCOMPort.COMPort(CASH_DRAWER_SERIAL_PORT, CASH_DRAWER_SERIAL_PORT_BAUD);
            //            }
            //            catch { }
            //        }

            //        AUTO_POPUP_CARD_PROMOTIONS_IN_POS = Utilities.getParafaitDefaults("AUTO_POPUP_CARD_PROMOTIONS_IN_POS");

            //        specialPricingId = -1;
            //        specialPricingRemarks = "";

            //        CheckInPhotoDirectory = Utilities.getParafaitDefaults("CHECKIN_PHOTO_DIRECTORY") + "\\";
            //        ImageDirectory = Utilities.getParafaitDefaults("IMAGE_DIRECTORY") + "\\";
            //        CARD_ISSUE_MANDATORY_FOR_CHECKIN = Utilities.getParafaitDefaults("CARD_ISSUE_MANDATORY_FOR_CHECKIN");
            //        CARD_ISSUE_MANDATORY_FOR_CHECKOUT = Utilities.getParafaitDefaults("CARD_ISSUE_MANDATORY_FOR_CHECKOUT");
            //        CARD_ISSUE_MANDATORY_FOR_CHECKIN_DETAILS = Utilities.getParafaitDefaults("CARD_ISSUE_MANDATORY_FOR_CHECKIN_DETAILS");
            //        PHOTO_MANDATORY_FOR_CHECKIN = Utilities.getParafaitDefaults("PHOTO_MANDATORY_FOR_CHECKIN");
            //        REFUND_REMARKS_MANDATORY = Utilities.getParafaitDefaults("REFUND_REMARKS_MANDATORY");
            //        WRIST_BAND_FACE_VALUE = Utilities.getParafaitDefaults("WRIST_BAND_FACE_VALUE");
            //        CHECKIN_DETAILS_RFID_TAG = Utilities.getParafaitDefaults("CHECKIN_DETAILS_RFID_TAG");

            //        try
            //        {
            //            DAYS_TO_KEEP_PHOTOS_FOR = Convert.ToDouble(Utilities.getParafaitDefaults("DAYS_TO_KEEP_PHOTOS_FOR"));
            //        }
            //        catch
            //        {
            //            DAYS_TO_KEEP_PHOTOS_FOR = 7;
            //        }

            //        TodaysFirstTrxId = CommonFuncs.getTodaysFirstTrxId();
            //        LastTrxNoForPOS = CommonFuncs.getLastTrxNoForPOS(Utilities.ParafaitEnv.POSMachineId);

            //        try
            //        {
            //            MaxTokenNumber = Convert.ToInt32(double.Parse(Utilities.getParafaitDefaults("MAX_TOKEN_NUMBER")));
            //        }
            //        catch
            //        {
            //            MaxTokenNumber = 1000;
            //        }

            //        TaxIdentificationNumber = Utilities.getParafaitDefaults("TAX_IDENTIFICATION_NUMBER");

            //        TRANSACTION_ITEM_SLIPS_GAP = Utilities.getParafaitDefaults("TRANSACTION_ITEM_SLIPS_GAP");

            //        try
            //        {
            //            TICKETS_TO_REDEEM_PER_BONUS = Convert.ToInt32(Utilities.getParafaitDefaults("TICKETS_TO_REDEEM_PER_BONUS"));
            //        }
            //        catch
            //        {
            //            TICKETS_TO_REDEEM_PER_BONUS = 100;
            //        }

            //        try
            //        {
            //            RoundOffAmountTo = (int)(Math.Pow(10, Utilities.ParafaitEnv.RoundingPrecision) * double.Parse(Utilities.getParafaitDefaults("ROUND_OFF_AMOUNT_TO")));
            //            if (RoundOffAmountTo <= 0)
            //                RoundOffAmountTo = 100;
            //        }
            //        catch
            //        {
            //            RoundOffAmountTo = 100;
            //        }

            //        cmd.CommandText = "select top 1 user_id " +
            //                            "from users p where username = 'External POS'";
            //        o = cmd.ExecuteScalar();
            //        if (o != null)
            //        {
            //            ExternalPOSUserId = Convert.ToInt32(o);
            //        }

            //        if (Utilities.ParafaitEnv.User_Id > 0)
            //            UserId = Utilities.ParafaitEnv.User_Id;
            //        else
            //            UserId = ExternalPOSUserId;

            //        cmd.CommandText = "select top 1 product_id from products p, product_type pt where pt.product_type_id = p.product_type_id and pt.product_type = 'VARIABLECARD'";
            //        o = cmd.ExecuteScalar();
            //        if (o != null)
            //        {
            //            VariableRechargeProductId = Convert.ToInt32(o);
            //        }

            //        object oRoundOffId = Utilities.executeScalar("select PaymentModeId from PaymentModes where isRoundOff = 'Y'");
            //        if (oRoundOffId != null)
            //            RoundOffPaymentModeId = Convert.ToInt32(oRoundOffId);
            //        else
            //            RoundOffPaymentModeId = -1;

            //        RoundingType = Utilities.getParafaitDefaults("ROUNDING_TYPE");
            //    }
            //    catch (Exception ex)
            //    {
            //        message = ex.Message;
            //        return false;
            //    }

                return true;
            //}
        }


        public void CreateRoundOffPayment()
        {
            if (PaymentCashAmount > 0)
            {
                double savPaymentCashAmount = PaymentCashAmount;
                //PaymentCashAmount = CommonFuncs.RoundOff(PaymentCashAmount, RoundOffAmountTo, Utilities.ParafaitEnv.RoundingPrecision, RoundingType);
                PaymentRoundOffAmount = savPaymentCashAmount - PaymentCashAmount;
                PaymentOtherModeAmount += PaymentRoundOffAmount;
            }

            if (PaymentRoundOffAmount != 0)
            {
                bool found = false;
                foreach (staticData.PaymentModeDetail pd in PaymentModeDetails)
                {
                    if (Convert.ToInt32(pd.PaymentModeId) == RoundOffPaymentModeId)
                    {
                        pd.Amount = PaymentRoundOffAmount;
                        found = true;
                        break;
                    }
                }
                if (!found && RoundOffPaymentModeId != -1)
                {
                    staticData.PaymentModeDetail pd = new staticData.PaymentModeDetail();
                    pd.PaymentModeId = RoundOffPaymentModeId;
                    pd.Reference = "";
                    pd.Amount = PaymentRoundOffAmount;
                    PaymentModeDetails.Add(pd);
                }
            }
            else
            {
                foreach (staticData.PaymentModeDetail pd in PaymentModeDetails)
                {
                    if (Convert.ToInt32(pd.PaymentModeId) == RoundOffPaymentModeId)
                    {
                        PaymentModeDetails.Remove(pd);
                        break;
                    }
                }
            }
        }

        public void ClearRoundOffPayment()
        {
            PaymentOtherModeAmount -= PaymentRoundOffAmount;
            PaymentCashAmount += PaymentRoundOffAmount;
            PaymentRoundOffAmount = 0;
            foreach (staticData.PaymentModeDetail pd in PaymentModeDetails)
            {
                if (Convert.ToInt32(pd.PaymentModeId) == RoundOffPaymentModeId)
                {
                    PaymentModeDetails.Remove(pd);
                    break;
                }
            }
        }
    }
}
