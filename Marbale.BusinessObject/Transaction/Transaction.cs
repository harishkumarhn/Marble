using Marbale.BusinessObject.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.POSTransaction
{
    public class Transaction
    {
        public int Trx_id { get; set; }
        public DateTime TransactionDate { get; set; }
        public double CashAmount { get; set; }
        public double Discount_Amount { get; set; }

        public decimal Discount_Percentage { get; set; }

        public string LoginID { get; set; }
        public decimal Net_Transaction_Amount { get; set; }
        public string originalSystemReference { get; set; }
        public int OriginalTrxId { get; set; }
        public double OtherModeAmount { get; set; }
        public int PaymentMode { get; set; }
        public string PaymentReference { get; set; }
        public string POSMachine { get; set; }
        public int POSMachineId { get; set; }
        public int POSTypeId { get; set; }
        public double Pre_TaxAmount { get; set; }
        public string Status { get; set; }
        public decimal Tax_Amount { get; set; }
        public double Tip_Amount { get; set; }
        public int TokenNumber { get; set; }
        public double TotalPaidAmount { get; set; }

        public decimal Transaction_Amount { get; set; }
        public DateTime TrxDate { get; set; }
        public List<TransactionLine> TrxLines { get; set; }
        public int TrxProfileId { get; set; }

        public string Trx_No { get; set; }
        public string Username { get; set; }

        public int UserId { get; set; }
        public int CustomerId { get; set; }

        public double CreditCardAmount { get; set; }

        public double GameCardAmount { get; set; }

        public int PrimaryCardId { get; set; }

        public int OrderId { get; set; }

        public string Remarks { get; set; }

        public string ExternalSystemReference { get; set; }

        public DateTime LastUpdatedTime { get; set; }


        public List<TransactionLine> TransactionLines { get; set; }

        public Customer.Customers customer { get; set; }

        public Cards.Card Card;

        public Discounts discounts;

    }


    public class TransactionLine
    {
        public int trxId { get; set; }

        public string ProductName { get; set; }
        public decimal quantity { get; set; }

        public decimal Price { get; set; }

        public bool AllowCancel { get; set; }
        public bool AllowEdit { get; set; }
        public bool AllowPriceOverride { get; set; }
        public string AttractionDetails { get; set; }
        public decimal Bonus { get; set; }
        public bool CancelledLine { get; set; }
        //public Card card { get; set; }
        public string CardNumber { get; set; }
        public int CardTypeId { get; set; }
        public int CategoryId { get; set; }
        public bool ComboChildLine { get; set; }
        public decimal Courtesy { get; set; }
        public bool CreditPlusConsumptionApplied { get; set; }
        public int CreditPlusConsumptionId { get; set; }
        public decimal Credits { get; set; }
        public int DBLineId { get; set; }
        public bool LineProcessed { get; set; }
        public bool LineValid { get; set; }
        public int LockerAllocationId { get; set; }
        public string LockerName { get; set; }
        public int LockerNumber { get; set; }
        public bool ModifierLine { get; set; }
        public object ModifierSetId { get; set; }
        public int OriginalLineID { get; set; }
        public double OriginalPrice { get; set; }
        public int OrigRentalTrxId { get; set; }
        public TransactionLine ParentLine { get; set; }


        public bool PrintKOT { get; set; }
        public int ProductID { get; set; }

        public bool productSplitTaxExists { get; set; }
        public string ProductType { get; set; }
        public string ProductTypeCode { get; set; }



        public string Remarks { get; set; }

        public string TaxInclusivePrice { get; set; }
        public string taxName { get; set; }
        public decimal tax_amount { get; set; }
        public int tax_id { get; set; }

        public int tax_structer_id { get; set; }

        public decimal tax_percentage { get; set; }


        public decimal LineAmount { get; set; }
        public decimal amount { get; set; }

        public decimal Discount_Percentage { get; set; }
        public int cardId { get; set; }

        public decimal time { get; set; }

        public decimal tickets { get; set; }
        public int loyaltyPoints { get; set; }

        public string productDescription { get; set; }

        public Customer.Customers customer { get; set; }

        public List<Discounts.DiscountLine> discountLines = new List<Discounts.DiscountLine>();

        public int LineId;

        public bool toBeSaved = false;
    }
}
