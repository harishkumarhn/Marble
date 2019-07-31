using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.POS.Transaction
{
    public class Transaction
    {
        public double CashAmount;
        public double Discount_Amount;
        public string LoginID;
        public double Net_Transaction_Amount;
        public string originalSystemReference;
        public int OriginalTrxId;
        public double OtherModeAmount;
        public int PaymentMode;
        public string PaymentReference;
        public string POSMachine;
        public int POSMachineId;
        public int POSTypeId;
        public double Pre_TaxAmount;
        public string Status;
        public double Tax_Amount;
        public double Tip_Amount;
        public int TokenNumber;
        public double TotalPaidAmount;
        public DateTime TransactionDate;
        public clsTransactionInfo TransactionInfo;
        public double Transaction_Amount;
        public DateTime TrxDate;
        public List<TransactionLine> TrxLines;
        public int TrxProfileId;
        public int Trx_id;
        public string Trx_No;
        public string Username;
        public int UserId;
        public double CreditCardAmount;
        public double GameCardAmount;
        public int PrimaryCardId;
        public int OrderId;
        public string Remarks;
        public int CustomerId;
        public string ExternalSystemReference;
        public DateTime LastUpdatedTime;

        public bool isSavedTransaction { get; }


        public class clsTransactionInfo
        {
            public string Address;
            public double amountInOtherCurrency;
            public double ChangeAmount;
            public string City;

            public string currencyCode;
            public double currencyRate;
            public double DiscountAmountExclTax;
            public double DiscountedTaxAmount;
            public double ExpiringCPBonus;
            public double ExpiringCPCredits;
            public double ExpiringCPLoyalty;
            public int ExpiringCPTickets;
            public double LoyaltyPoints;
            public string nameOnCreditCard;
            public double NonTaxableAmount;
            public string OrderCustomerName;
            public int OrderId;
            public string originalTrxNo;
            public string OtherPaymentMode;
            public double PaymentCashAmount;
            public double PaymentCreditCardAmount;
            public string PaymentCreditCardNumber;
            public double PaymentGameCardAmount;
            //public List<staticDataExchange.PaymentModeDetail> PaymentModes;
            public double PaymentOtherModeAmount;
            public string PaymentReference;
            public double PaymentRoundOffAmount;
            public string Phone;
            public string Pin;

            public double PrimaryCardBalance;
            public double PrimaryCardBonusBalance;
            public double PrimaryCardCreditBalance;
            public string PrimaryCustomerName;
            public int PrimaryPaymentCardId;
            public string PrimaryPaymentCardNumber;
            public double rentalAmount;
            public double rentalDepositAmount;
            public int splitCnt;
            public string splitLineId;
            public string State;
            public string TableNumber;
            public double TaxableAmount;
            public double TenderedAmount;
            public int Tickets;
            public string transactionSeq;

            public string TrxCustomerName;
            public string TrxCustomerPhone;
            public string TrxProfile;

            public string WaiterName;
        }

        public class TransactionLine
        {
            public bool AllowCancel;
            public bool AllowEdit;
            public bool AllowPriceOverride;
            public string AttractionDetails;
            public double Bonus;
            public bool CancelledLine;
            //public Card card;
            public string CardNumber;
            public int CardTypeId;
            public int CategoryId;
            public bool ComboChildLine;
            public double Courtesy;
            public bool CreditPlusConsumptionApplied;
            public int CreditPlusConsumptionId;
            public double Credits;
            public int DBLineId;


            public bool LineProcessed;
            public bool LineValid;
            public int LockerAllocationId;
            public string LockerName;
            public int LockerNumber;
            public bool ModifierLine;
            public object ModifierSetId;
            public int OriginalLineID;
            public double OriginalPrice;
            public int OrigRentalTrxId;
            public TransactionLine ParentLine;

            public double Price;
            public bool PrintKOT;
            public int ProductID;
            public string ProductName;
            public bool productSplitTaxExists;
            public string ProductType;
            public string ProductTypeCode;

            public decimal quantity;

            public string Remarks;

            public string TaxInclusivePrice;
            public string taxName;
            public double tax_amount;
            public int tax_id;
            public double tax_percentage;
        }
    }
}
