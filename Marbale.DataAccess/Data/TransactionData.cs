using Marbale.BusinessObject.Cards;
using Marbale.BusinessObject.Customer;
using Marbale.BusinessObject.Messages;
using Marbale.BusinessObject.POSTransaction;
using Marbale.BusinessObject.SiteSetup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.DataAccess.Data
{
    public class TransactionData
    {
        private DBConnection conn;

        public TransactionData()
        {
            conn = new DBConnection();
        }

        public int SaveTransaction(Transaction trx)
        {
            try
            {
                if (trx.customer != null)
                    trx.CustomerId = SaveCustomer(trx.customer);

                SqlParameter[] sqlParameters = new SqlParameter[27];

                sqlParameters[0] = new SqlParameter("@trxId", SqlDbType.Int);
                sqlParameters[0].Value = 0;

                sqlParameters[1] = new SqlParameter("@TrxDate", trx.TransactionDate);
                sqlParameters[2] = new SqlParameter("@TrxAmount", trx.Transaction_Amount);

                sqlParameters[3] = new SqlParameter("@TrxDiscountPercentage", SqlDbType.Decimal);
                sqlParameters[3].Value = 0;

                sqlParameters[4] = new SqlParameter("@TaxAmount", trx.Tax_Amount);
                sqlParameters[5] = new SqlParameter("@TrxNetAmount", trx.Net_Transaction_Amount);

                if (!string.IsNullOrEmpty(trx.POSMachine))
                {
                    sqlParameters[6] = new SqlParameter("@POSMachine", trx.POSMachine);
                }
                else
                {
                    sqlParameters[6] = new SqlParameter("@POSMachine", DBNull.Value);
                }

                sqlParameters[7] = new SqlParameter("@UserId", trx.UserId);
                sqlParameters[8] = new SqlParameter("@PaymentMode", trx.UserId);
                sqlParameters[9] = new SqlParameter("@CashAmount", trx.CashAmount);
                sqlParameters[10] = new SqlParameter("@CreditCardAmount", trx.CreditCardAmount);
                sqlParameters[11] = new SqlParameter("@GameCardAmount", trx.GameCardAmount);

                if (!string.IsNullOrEmpty(trx.PaymentReference))
                {
                    sqlParameters[12] = new SqlParameter("@PaymentReference", trx.PaymentReference);
                }
                else
                {
                    sqlParameters[12] = new SqlParameter("@PaymentReference", DBNull.Value);
                }

                sqlParameters[13] = new SqlParameter("@PrimaryCardId", trx.PrimaryCardId);

                sqlParameters[14] = new SqlParameter("@OrderId", trx.OrderId);

                sqlParameters[15] = new SqlParameter("@POSTypeId", trx.POSTypeId);

                if (!string.IsNullOrEmpty(trx.Trx_No))
                {
                    sqlParameters[16] = new SqlParameter("@TrxNummber", trx.Trx_No);
                }
                else
                {
                    sqlParameters[16] = new SqlParameter("@TrxNummber", DBNull.Value);
                }


                if (!string.IsNullOrEmpty(trx.Remarks))
                {
                    sqlParameters[17] = new SqlParameter("@Remarks", trx.Remarks);
                }
                else
                {
                    sqlParameters[17] = new SqlParameter("@Remarks", DBNull.Value);
                }

                sqlParameters[18] = new SqlParameter("@POSMachineId", trx.POSMachineId);
                sqlParameters[19] = new SqlParameter("@OtherPaymentModeAmount", trx.OtherModeAmount);

                if (!string.IsNullOrEmpty(trx.Status))
                {
                    sqlParameters[20] = new SqlParameter("@Status", trx.Status);
                }
                else
                {
                    sqlParameters[20] = new SqlParameter("@Status", DBNull.Value);
                }

                sqlParameters[21] = new SqlParameter("@TrxProfileId", trx.TrxProfileId);

                sqlParameters[22] = new SqlParameter("@LastUpdateTime", DateTime.Now);

                if (!string.IsNullOrEmpty(trx.Username))
                {
                    sqlParameters[23] = new SqlParameter("@LastUpdatedBy", trx.Username);
                }
                else
                {
                    sqlParameters[23] = new SqlParameter("@LastUpdatedBy", DBNull.Value);
                }

                sqlParameters[24] = new SqlParameter("@CustomerId", trx.CustomerId);

                sqlParameters[25] = new SqlParameter("@OriginalTrxID", trx.OriginalTrxId);

                sqlParameters[26] = new SqlParameter("@txId", SqlDbType.Int);
                sqlParameters[26].Direction = ParameterDirection.Output;

                conn.executeUpdateQuery("sp_InsertOrUpdateTrxHeader", sqlParameters);

                int trxId = Convert.ToInt32(sqlParameters[26].Value);

                List<TransactionLine> activetrxLines = trx.TransactionLines.FindAll(x => x.LineValid = true && x.CancelledLine == false);

                foreach (TransactionLine trxLn in activetrxLines)
                {
                    SaveTransactionLines(trxLn, trxId);
                }

                return trxId;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void SaveTransactionLines(TransactionLine trxLine, int trxId)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[24];

                sqlParameters[0] = new SqlParameter("@trxId", SqlDbType.Int);
                sqlParameters[0].Value = trxId;

                sqlParameters[1] = new SqlParameter("@LineId", trxLine.LineId);
                sqlParameters[2] = new SqlParameter("@ProductId", trxLine.ProductID);

                sqlParameters[3] = new SqlParameter("@Price", SqlDbType.Decimal);
                sqlParameters[3].Value = trxLine.amount;

                sqlParameters[4] = new SqlParameter("@Quantity", trxLine.quantity);
                sqlParameters[5] = new SqlParameter("@Amount", trxLine.LineAmount);

                sqlParameters[6] = new SqlParameter("@CardId", trxLine.cardId);

                if (!string.IsNullOrEmpty(trxLine.CardNumber))
                {
                    sqlParameters[7] = new SqlParameter("@CardNumber", trxLine.CardNumber);
                }
                else
                {
                    sqlParameters[7] = new SqlParameter("@CardNumber", DBNull.Value);
                }

                sqlParameters[8] = new SqlParameter("@Credits", trxLine.Credits);

                sqlParameters[9] = new SqlParameter("@Courtesy", trxLine.Courtesy);
                sqlParameters[10] = new SqlParameter("@TaxPercentage", trxLine.tax_percentage);
                sqlParameters[11] = new SqlParameter("@TaxId", trxLine.tax_id);
                sqlParameters[12] = new SqlParameter("@Time", trxLine.time);
                sqlParameters[13] = new SqlParameter("@Bonus", trxLine.Bonus);
                sqlParameters[14] = new SqlParameter("@Tickets", trxLine.tickets);
                sqlParameters[15] = new SqlParameter("@LoyaltyPoints", trxLine.loyaltyPoints);

                if (!string.IsNullOrEmpty(trxLine.Remarks))
                {
                    sqlParameters[16] = new SqlParameter("@Remarks", trxLine.Remarks);
                }
                else
                {
                    sqlParameters[16] = new SqlParameter("@Remarks", DBNull.Value);
                }

                sqlParameters[17] = new SqlParameter("@PromotionId", SqlDbType.Int);
                sqlParameters[17].Value = 0;

                sqlParameters[18] = new SqlParameter("@ParentLineId", SqlDbType.Int);
                sqlParameters[18].Value = 0;

                sqlParameters[19] = new SqlParameter("@GameplayId", SqlDbType.Int);
                sqlParameters[19].Value = 0;

                sqlParameters[20] = new SqlParameter("@CancelledTime", DBNull.Value);
                sqlParameters[21] = new SqlParameter("@CancelledBy", DBNull.Value);

                if (!string.IsNullOrEmpty(trxLine.productDescription))
                {
                    sqlParameters[22] = new SqlParameter("@ProductDescription", trxLine.productDescription);
                }
                else
                {
                    sqlParameters[22] = new SqlParameter("@ProductDescription", DBNull.Value);
                }


                sqlParameters[23] = new SqlParameter("@OriginalLineID", trxLine.OriginalLineID);


                conn.executeUpdateQuery("sp_InsertOrUpdateTrxLines", sqlParameters);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int SaveCustomer(Customers Customer)
        {
            int custId = 0;
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[11];

                sqlParameters[0] = new SqlParameter("@CustomerId", SqlDbType.Int);
                sqlParameters[0].Value = Customer.customer_id;

                if (!string.IsNullOrEmpty(Customer.first_name))
                {
                    sqlParameters[1] = new SqlParameter("@CustomerName", Customer.first_name);
                }
                else
                {
                    sqlParameters[1] = new SqlParameter("@CustomerName", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(Customer.last_name))
                {
                    sqlParameters[2] = new SqlParameter("@LastName", Customer.last_name);
                }
                else
                {
                    sqlParameters[2] = new SqlParameter("@LastName", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(Customer.contact_phone1))
                {
                    sqlParameters[3] = new SqlParameter("@ContactPhone1", Customer.contact_phone1);
                }
                else
                {
                    sqlParameters[3] = new SqlParameter("@ContactPhone1", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(Customer.contact_phone2))
                {
                    sqlParameters[4] = new SqlParameter("@ContactPhone2", Customer.contact_phone2);
                }
                else
                {
                    sqlParameters[4] = new SqlParameter("@ContactPhone2", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(Customer.address1))
                {
                    sqlParameters[5] = new SqlParameter("@Address1", Customer.address1);
                }
                else
                {
                    sqlParameters[5] = new SqlParameter("@Address1", DBNull.Value);
                }

                sqlParameters[6] = new SqlParameter("@Gender", Customer.gender);

                if (!string.IsNullOrEmpty(Customer.city))
                {
                    sqlParameters[7] = new SqlParameter("@City", Customer.city);
                }
                else
                {
                    sqlParameters[7] = new SqlParameter("@City", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(Customer.state))
                {
                    sqlParameters[8] = new SqlParameter("@State", Customer.state);
                }
                else
                {
                    sqlParameters[8] = new SqlParameter("@State", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(Customer.country))
                {
                    sqlParameters[9] = new SqlParameter("@Country", Customer.country);
                }
                else
                {
                    sqlParameters[9] = new SqlParameter("@Country", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(Customer.email))
                {
                    sqlParameters[9] = new SqlParameter("@Email", Customer.email);
                }
                else
                {
                    sqlParameters[9] = new SqlParameter("@Email", DBNull.Value);
                }

                sqlParameters[10] = new SqlParameter("@custId", SqlDbType.Int);
                sqlParameters[10].Direction = ParameterDirection.Output;

                conn.executeUpdateQuery("sp_InsertOrUpdateCustomer", sqlParameters);

                custId = Convert.ToInt32(sqlParameters[10].Value);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return custId;
        }

        public DataTable GetCustomer(int customerId, string phoneNumber)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];

                if (customerId != 0)
                {
                    sqlParameters[0] = new SqlParameter("@customerId", customerId);
                }
                else
                {
                    sqlParameters[0] = new SqlParameter("@customerId", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(phoneNumber))
                {
                    sqlParameters[1] = new SqlParameter("@phoneNumber", phoneNumber);
                }
                else
                {
                    sqlParameters[1] = new SqlParameter("@phoneNumber", DBNull.Value);
                }
                
                return conn.executeSelectQuery("sp_GetCustomer", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int InsertOrUpdateCards(CardsModel card)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[24];

                sqlParameters[0] = new SqlParameter("@CardId", card.CardId);
                sqlParameters[1] = new SqlParameter("@CardNumber", card.CardNumber);
                sqlParameters[2] = new SqlParameter("@IssueDate", card.IssueDate);
                sqlParameters[3] = new SqlParameter("@FaceValue", card.FaceValue);
                sqlParameters[4] = new SqlParameter("@RefundDate", card.RefundDate);
                sqlParameters[5] = new SqlParameter("@RefundFlag", card.RefundFlag);
                sqlParameters[6] = new SqlParameter("@RefundAmount", card.RefundAmount);
                sqlParameters[7] = new SqlParameter("@ValidFlag", card.ValidFlag);
                sqlParameters[8] = new SqlParameter("@TicketCount", card.TicketCount);
                sqlParameters[9] = new SqlParameter("@LastUpdated", DateTime.Now);
                sqlParameters[10] = new SqlParameter("@Credits", card.Credits);
                sqlParameters[11] = new SqlParameter("@Courtesy", card.Courtesy);
                sqlParameters[12] = new SqlParameter("@Bonus", card.Bonus);
                sqlParameters[13] = new SqlParameter("@CustomerId", card.CustomerId);
                sqlParameters[14] = new SqlParameter("@CreditsPlayed", card.CreditsPlayed);
                sqlParameters[15] = new SqlParameter("@TicketAllowed", card.TicketAllowed);
                sqlParameters[16] = new SqlParameter("@RealTicketMode", card.RealTicketMode);
                sqlParameters[17] = new SqlParameter("@VIPCustomer", card.VIPCustomer);
                sqlParameters[18] = new SqlParameter("@Notes", card.Note);
                sqlParameters[19] = new SqlParameter("@StartDateTime", card.StartTime);
                sqlParameters[20] = new SqlParameter("@LastTimePlayed", card.LastPlayTime);
                sqlParameters[21] = new SqlParameter("@LastUpdatedBy", card.LastUpdatedBy);
                sqlParameters[22] = new SqlParameter("@TechnicianCard", card.TechnicianCard);
                sqlParameters[23] = new SqlParameter("@TechGames", card.TechGames);
                sqlParameters[24] = new SqlParameter("@TimerResetCard", card.TimerResetCard);
                sqlParameters[25] = new SqlParameter("@LoyaltyPoints", card.LoyaltyPoints);
                sqlParameters[26] = new SqlParameter("@LoyaltyPoints", card.CardTypeId);
                sqlParameters[15] = new SqlParameter("@ExpiryDate", card.ExpiryDate);

                sqlParameters[10] = new SqlParameter("@CrdId", SqlDbType.Int);
                sqlParameters[10].Direction = ParameterDirection.Output;

                return conn.executeInsertQuery("sp_InsertOrUpdateCards", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
