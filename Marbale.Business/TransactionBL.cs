using Marbale.BusinessObject;
using Marbale.BusinessObject.POSTransaction;
using Marbale.BusinessObject.Tax;
using Marbale.DataAccess;
using Marbale.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marbale.BusinessObject.Customer;
using Marbale.BusinessObject.Cards;

namespace Marble.Business
{
    public class TransactionBL
    {
        private TransactionData trxData;

        public TransactionBL()
        {
            trxData = new TransactionData();
        }

        public int SaveTransaction(Transaction trx)
        {
            return trxData.SaveTransaction(trx);
        }

        public Customers GetCustomer(int customerId, string phoneNumber)
        {
            DataTable dt = trxData.GetCustomer(customerId, phoneNumber);

            Customers customer = new Customers();

            if (dt != null && dt.Rows.Count > 0)
            {
                customer.customer_id = dt.Rows[0]["CustomerId"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["CustomerId"]);
                customer.first_name = dt.Rows[0]["CustomerName"] == DBNull.Value ? string.Empty: dt.Rows[0]["CustomerName"].ToString();
                customer.last_name = dt.Rows[0]["LastName"] == DBNull.Value ? string.Empty : dt.Rows[0]["LastName"].ToString();
                customer.contact_phone1 = dt.Rows[0]["ContactPhone1"] == DBNull.Value ? string.Empty : dt.Rows[0]["ContactPhone1"].ToString();
                customer.address1 = dt.Rows[0]["Address1"] == DBNull.Value ? string.Empty : dt.Rows[0]["Address1"].ToString();
                customer.city = dt.Rows[0]["City"] == DBNull.Value ? string.Empty : dt.Rows[0]["City"].ToString();
                customer.state = dt.Rows[0]["State"] == DBNull.Value ? string.Empty : dt.Rows[0]["State"].ToString();
                customer.country = dt.Rows[0]["Country"] == DBNull.Value ? string.Empty : dt.Rows[0]["Country"].ToString();
                customer.email = dt.Rows[0]["Email"] == DBNull.Value ? string.Empty : dt.Rows[0]["Email"].ToString();

                customer.gender = dt.Rows[0]["Gender"] == DBNull.Value ? 'N' : Convert.ToChar(dt.Rows[0]["Gender"]);

                customer.birth_date = dt.Rows[0]["DateOfBirth"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["DateOfBirth"]);
            }

            return customer;
        }

        public Card GetCard(int cardId, string cardNumber)
        {
            DataTable dt = trxData.GetCard(cardId, cardNumber);

            Card card = new Card();

            if (dt != null && dt.Rows.Count > 0)
            {
                card = new Card();

                card.card_id = dt.Rows[0]["CardId"] == DBNull.Value ?  0 : Convert.ToInt32(dt.Rows[0]["CardId"]);
                card.CardNumber = dt.Rows[0]["CardNumber"] == DBNull.Value ? string.Empty : dt.Rows[0]["CardNumber"].ToString();
                card.issue_date = dt.Rows[0]["IssueDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["IssueDate"]);

                card.CardStatus = "ISSUED";

                card.ExpiryDate = dt.Rows[0]["ExpiryDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["ExpiryDate"]);
                card.lastUpdatedBy = dt.Rows[0]["LastUpdatedBy"] == DBNull.Value ? string.Empty : dt.Rows[0]["LastUpdatedBy"].ToString();
                card.last_update_time = dt.Rows[0]["LastUpdated"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["LastUpdated"]);
                card.face_value = dt.Rows[0]["FaceValue"] == DBNull.Value ? 0 : Convert.ToDecimal(dt.Rows[0]["FaceValue"]);
                card.last_played_time = dt.Rows[0]["LastTimePlayed"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["LastTimePlayed"]);
                card.notes = dt.Rows[0]["Notes"] == DBNull.Value ? string.Empty : dt.Rows[0]["Notes"].ToString();
                card.refund_date = dt.Rows[0]["RefundDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["RefundDate"]);
                card.ticket_allowed = dt.Rows[0]["TicketAllowed"] == DBNull.Value ? false : Convert.ToBoolean(dt.Rows[0]["TicketAllowed"]);
                card.customer_id = dt.Rows[0]["CustomerId"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["CustomerId"]);

                //card.refund_amount = dr.IsNull("RefundAmount") ? 0 : float.Parse(dr["RefundAmount"].ToString());

                //card.start_time = dr.IsNull("StartTime") ? new DateTime() : Convert.ToDateTime(dr["StartTime"].ToString());
                //card.tech_games = dr.IsNull("TechGames") ? "" : dr["TechGames"].ToString();
                //card.TimerResetCard = dr.IsNull("TimerResetCard") ? false : bool.Parse(dr["TimerResetCard"].ToString());
                //card.vip_customer = dr.IsNull("VIPCustomer") ? false : bool.Parse(dr["VIPCustomer"].ToString());

                card.credits = dt.Rows[0]["Credits"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["Credits"]);                
                //card.credits_played = dr.IsNull("CreditsPlayed") ? 0 : float.Parse(dr["CreditsPlayed"].ToString());


                card.courtesy = dt.Rows[0]["Courtesy"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["Courtesy"]);
                card.bonus = dt.Rows[0]["Bonus"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["Bonus"]);
                //card.real_ticket_mode = dr.IsNull("RealTicketMode") ? false : bool.Parse(dr["RealTicketMode"].ToString());
                card.ticket_count = dt.Rows[0]["TicketCount"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["TicketCount"]);

                if (card.customer_id != 0)
                card.customer = GetCustomer(card.customer_id, string.Empty);
            }
            else
            {
                card = new Card();
                card.CardNumber = cardNumber;
                card.CardStatus = "NEW";
            }

            return card;
        }


        public List<Transaction> GetTransactionList(int userId)
        {
            List<Transaction> lstTransaction = new List<Transaction>();
            Transaction trx;
            DataSet ds = trxData.GetTransactionList(userId);

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow rw in ds.Tables[0].Rows)
                {
                    trx = new Transaction();
                    trx.Trx_id = rw["TrxId"] == DBNull.Value ? 0 : Convert.ToInt32(rw["TrxId"]);
                    trx.TransactionDate = rw["TrxDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(rw["TrxDate"]);
                    trx.Transaction_Amount = rw["TrxAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(rw["TrxAmount"]);
                    trx.Tax_Amount = rw["TaxAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(rw["TaxAmount"]);
                    trx.Net_Transaction_Amount = rw["TrxNetAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(rw["TrxNetAmount"]);
                    trx.POSMachine = rw["POSMachine"] == DBNull.Value ? string.Empty : rw["POSMachine"].ToString();
                    trx.UserId = rw["UserId"] == DBNull.Value ? 0 : Convert.ToInt32(rw["UserId"]);
                    trx.PaymentMode = rw["PaymentMode"] == DBNull.Value ? 0 : Convert.ToInt32(rw["PaymentMode"]);
                    trx.CashAmount = rw["CashAmount"] == DBNull.Value ? 0 : Convert.ToDouble(rw["CashAmount"]);
                    trx.CreditCardAmount = rw["CreditCardAmount"] == DBNull.Value ? 0 : Convert.ToDouble(rw["CreditCardAmount"]);
                    trx.GameCardAmount = rw["GameCardAmount"] == DBNull.Value ? 0 : Convert.ToDouble(rw["GameCardAmount"]);
                    trx.PaymentReference = rw["PaymentReference"] == DBNull.Value ? string.Empty : rw["PaymentReference"].ToString();
                    trx.PrimaryCardId = rw["PrimaryCardId"] == DBNull.Value ? 0 : Convert.ToInt32(rw["PrimaryCardId"]);
                    trx.OrderId = rw["OrderId"] == DBNull.Value ? 0 : Convert.ToInt32(rw["OrderId"]);
                    trx.POSTypeId = rw["POSTypeId"] == DBNull.Value ? 0 : Convert.ToInt32(rw["POSTypeId"]);
                    trx.OtherModeAmount = rw["OtherPaymentModeAmount"] == DBNull.Value ? 0 : Convert.ToDouble(rw["OtherPaymentModeAmount"]);
                    trx.CustomerId = rw["CustomerId"] == DBNull.Value ? 0 : Convert.ToInt32(rw["CustomerId"]);

                    trx.TransactionLines = GetTraxLines(trx.Trx_id, ds.Tables[1]);
                    lstTransaction.Add(trx);
                }
            }

            return lstTransaction;
        }


        //public List<Transaction> FillTransactionList(DataTable dtTrx, DataTable dtTrxLines)
        //{
        //    List<Transaction> lstTransaction = new List<Transaction>();
        //    Transaction trx;
        //    if (dtTrx != null && dtTrx.Rows.Count > 0)
        //    {
        //        foreach(DataRow rw in dtTrx.Rows)
        //        {
        //            trx = new Transaction();
        //            trx.Trx_id = rw["TrxId"] == DBNull.Value ? 0 : Convert.ToInt32(rw["TrxId"]);

        //            trx.TransactionLines = GetTraxLines(trx.Trx_id, dtTrxLines);
        //            lstTransaction.Add(trx);
        //        }
        //    }
        //    return lstTransaction;
        //}

        public List<TransactionLine> GetTraxLines(int trxId, DataTable dtTrxLines)
        {
            List<TransactionLine> trxLines = new List<TransactionLine>();
            TransactionLine trxLn;

            try
            {
                if (dtTrxLines != null && dtTrxLines.Rows.Count > 0)
                {
                    var result = dtTrxLines.AsEnumerable().Where(myRow => myRow.Field<int>("TrxId") == trxId);

                    if (result != null)
                    {
                        DataTable dt = result.CopyToDataTable<DataRow>();

                        foreach (DataRow rw in dt.Rows)
                        {
                            trxLn = new TransactionLine();
                            trxLn.trxId = trxId;
                            trxLn.ProductName = rw["name"] != DBNull.Value ? rw["name"].ToString() : string.Empty;
                            trxLn.ProductID = rw["ProductId"] == DBNull.Value ? 0 : Convert.ToInt32(rw["ProductId"]);
                            trxLn.Price = rw["Price"] == DBNull.Value ? 0 : Convert.ToDecimal(rw["Price"]);
                            trxLn.trxId = rw["TrxId"] == DBNull.Value ? 0 : Convert.ToInt32(rw["TrxId"]);
                            trxLn.LineId = rw["LineId"] == DBNull.Value ? 0 : Convert.ToInt32(rw["LineId"]);
                            trxLn.quantity = rw["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(rw["Quantity"]);
                            trxLn.amount = rw["Amount"] == DBNull.Value ? 0 : Convert.ToDecimal(rw["Amount"]);
                            trxLn.cardId = rw["CardId"] == DBNull.Value ? 0 : Convert.ToInt32(rw["CardId"]);
                            trxLn.CardNumber = rw["CardNumber"] != DBNull.Value ? rw["CardNumber"].ToString() : string.Empty;
                            trxLn.Credits = rw["Credits"] == DBNull.Value ? 0 : Convert.ToDecimal(rw["Credits"]);
                            trxLn.Courtesy = rw["Courtesy"] == DBNull.Value ? 0 : Convert.ToDecimal(rw["Courtesy"]);
                            trxLn.tax_percentage = rw["TaxPercentage"] == DBNull.Value ? 0 : Convert.ToDecimal(rw["TaxPercentage"]);
                            trxLn.time = rw["Time"] == DBNull.Value ? 0 : Convert.ToDecimal(rw["Time"]);
                            trxLn.Bonus = rw["Bonus"] == DBNull.Value ? 0 : Convert.ToDecimal(rw["Bonus"]);
                            trxLn.tickets = rw["Tickets"] == DBNull.Value ? 0 : Convert.ToDecimal(rw["Tickets"]);
                            trxLn.Remarks = rw["Remarks"] != DBNull.Value ? rw["Remarks"].ToString() : string.Empty;

                            trxLines.Add(trxLn);
                        }
                    }
                }
            }
            catch { }

            return trxLines;
        }
    }
}
