using Marbale.BusinessObject;
using Marbale.BusinessObject.Cards;
using Marbale.BusinessObject.Customer;
using Marbale.BusinessObject.Discount;
using Marbale.BusinessObject.Messages;
using Marbale.BusinessObject.POSTransaction;
using Marbale.BusinessObject.SiteSetup;
using Marble.DataLoggerService;
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
        private readonly DataLogger dataLogger = new DataLogger();

        public TransactionData()
        {
            conn = new DBConnection();
        }

        public void SaveAllCards(ref Transaction trx)
        {

            try
            {
                bool firstOne = false;

                if (trx.TransactionLines != null)
                {
                    for (int i = 0; i < trx.TransactionLines.Count; i++)
                    {
                        int cardid = -1;
                        if (trx.TransactionLines[i].IsDepositLine != true)
                        {
                            firstOne = true;
                            trx.TransactionLines[i].Card.customer_id = trx.CustomerId;
                            cardid = SaveCard(trx.TransactionLines[i].Card);

                            //Setting card Id
                            trx.TransactionLines[i].cardId = cardid;
                            trx.TransactionLines[i].Card.card_id = cardid;

                            if (firstOne == true)
                            {
                                firstOne = false;
                                trx.PrimaryCardId = cardid;
                                if (!trx.IsMultipleCard)
                                {
                                    break;
                                }
                            }
                        }

                    }

                    List<TransactionLine> lines = trx.TransactionLines.Where(x => x.IsDepositLine == false).ToList();

                    if (lines != null)
                    {
                        for (int i = 0; i < lines.Count; i++)
                        {
                            ///setting up card id for deposit line
                            for (int k = 0; k < trx.TransactionLines.Count; k++)
                            {
                                if (trx.TransactionLines[k].IsDepositLine == true && trx.TransactionLines[k].CardNumber == lines[i].CardNumber
                                      )
                                {

                                    trx.TransactionLines[k].cardId = lines[i].cardId;
                                    trx.TransactionLines[k].Card = lines[i].Card;
                                }
                            }
                        }
                    }
                }

                //Card primaryCard = new Card();
                //if (trx.IsMultipleCard)
                //{


                //}
                //else
                //{
                //    if (trx.TransactionLines != null)
                //    {
                //        for (int i = 0; i <= 1; i++)
                //        {
                //            if (trx.TransactionLines[i].IsDepositLine != true)
                //            {
                //                //Saving Card
                //                trx.TransactionLines[i].Card.customer_id = trx.CustomerId;
                //                int cardid = SaveCard(trx.TransactionLines[i].Card);

                //                //Setting card Id
                //                trx.TransactionLines[i].cardId = cardid;
                //                trx.TransactionLines[i].Card.card_id = cardid;

                //                if (i == 0)
                //                {

                //                    trx.PrimaryCardId = cardid;
                //                }
                //            }
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                dataLogger.Error("Error POS ValidateCustomer", ex);
                throw;
            }
        }

        public int SaveTransaction(Transaction trx)
        {
            try
            {
                if (trx.customer != null)
                    trx.CustomerId = SaveCustomer(trx.customer);

                SaveAllCards(ref trx);

                SqlParameter[] sqlParameters = new SqlParameter[27];

                sqlParameters[0] = new SqlParameter("@trxId", SqlDbType.Int);
                sqlParameters[0].Value = 0;

                sqlParameters[1] = new SqlParameter("@TrxDate", trx.TransactionDate);
                sqlParameters[2] = new SqlParameter("@TrxAmount", trx.Transaction_Amount);

                sqlParameters[3] = new SqlParameter("@TrxDiscountPercentage", SqlDbType.Decimal);
                sqlParameters[3].Value = trx.Discount_Percentage;

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
                trx.Trx_id = trxId;
                //List<TransactionLine> activetrxLines = trx.TransactionLines.FindAll(x => x.LineValid = true && x.CancelledLine == false);
                List<TransactionLine> activetrxLines = new List<TransactionLine>();

                //Get All Active Transaction lines
                foreach (TransactionLine tln in trx.TransactionLines)
                {
                    if (tln.LineValid)
                        activetrxLines.Add(tln);
                }

                //Save only active Trax
                foreach (TransactionLine trxLn in activetrxLines)
                {
                    SaveTransactionLines(trxLn, trx);
                    SaveTransactionTaxLines(trxLn, trxId);
                    SaveTransactionDiscountLines(trxLn, trxId);
                }

                return trxId;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void SaveTransactionLines(TransactionLine trxLine, Transaction trx)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[24];

                sqlParameters[0] = new SqlParameter("@trxId", SqlDbType.Int);
                sqlParameters[0].Value = trx.Trx_id;

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

        public void SaveTransactionTaxLines(TransactionLine trxLine, int trxId)
        {
            try
            {

                if (trxLine.tax_amount > 0)
                {
                    SqlParameter[] sqlParameters = new SqlParameter[7];

                    sqlParameters[0] = new SqlParameter("@trxId", SqlDbType.Int);
                    sqlParameters[0].Value = trxId;

                    sqlParameters[1] = new SqlParameter("@LineId", trxLine.LineId);

                    sqlParameters[2] = new SqlParameter("@TaxId", trxLine.tax_id);

                    sqlParameters[3] = new SqlParameter("@TaxStructureId", trxLine.tax_structer_id);

                    sqlParameters[4] = new SqlParameter("@Percentage", trxLine.tax_percentage);

                    sqlParameters[5] = new SqlParameter("@Amount", trxLine.tax_amount);

                    sqlParameters[6] = new SqlParameter("@ProductSplitAmount", 0);

                    conn.executeUpdateQuery("sp_InsertTransactionTaxLines", sqlParameters);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void SaveTransactionDiscountLines(TransactionLine trxLine, int trxId)
        {
            try
            {

                List<Discounts.DiscountLine> activeDiscountLines = trxLine.discountLines.FindAll(x => x.LineValid);

                if (activeDiscountLines != null && activeDiscountLines.Count > 0)
                {
                    foreach (Discounts.DiscountLine dsLn in activeDiscountLines)
                    {
                        SqlParameter[] sqlParameters = new SqlParameter[7];

                        sqlParameters[0] = new SqlParameter("@trxId", SqlDbType.Int);
                        sqlParameters[0].Value = trxId;

                        sqlParameters[1] = new SqlParameter("@LineId", trxLine.LineId);

                        sqlParameters[2] = new SqlParameter("@DiscountId", dsLn.DiscountId);

                        decimal trxLineDiscountAmnt = (trxLine.LineAmount * dsLn.DiscountPercentage) / 100;

                        sqlParameters[3] = new SqlParameter("@DiscountAmount", trxLineDiscountAmnt);

                        sqlParameters[4] = new SqlParameter("@DiscountPercentage", dsLn.DiscountPercentage);

                        sqlParameters[5] = new SqlParameter("@Remarks", string.Empty);

                        sqlParameters[6] = new SqlParameter("@ApprovedBy", 0);

                        conn.executeUpdateQuery("sp_InsertTransactionDiscountLines", sqlParameters);
                    }
                }
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
                SqlParameter[] sqlParameters = new SqlParameter[12];

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
                    sqlParameters[10] = new SqlParameter("@Email", Customer.email);
                }
                else
                {
                    sqlParameters[10] = new SqlParameter("@Email", DBNull.Value);
                }

                sqlParameters[11] = new SqlParameter("@custId", SqlDbType.Int);
                sqlParameters[11].Direction = ParameterDirection.Output;

                conn.executeUpdateQuery("sp_InsertOrUpdateCustomer", sqlParameters);

                custId = Convert.ToInt32(sqlParameters[11].Value);
            }
            catch (Exception ex)
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

        public int SaveCard(Card card)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[29];

                sqlParameters[0] = new SqlParameter("@CardId", card.card_id);

                if (!string.IsNullOrEmpty(card.CardNumber))
                {
                    sqlParameters[1] = new SqlParameter("@CardNumber", card.CardNumber);
                }
                else
                {
                    sqlParameters[1] = new SqlParameter("@CardNumber", DBNull.Value);
                }

                if (card.issue_date != DateTime.MinValue)
                {
                    sqlParameters[2] = new SqlParameter("@IssueDate", card.issue_date);
                }
                else
                {
                    sqlParameters[2] = new SqlParameter("@IssueDate", DBNull.Value);
                }

                sqlParameters[3] = new SqlParameter("@FaceValue", card.face_value);

                if (card.refund_date != DateTime.MinValue)
                {
                    sqlParameters[4] = new SqlParameter("@RefundDate", card.refund_date);
                }
                else
                {
                    sqlParameters[4] = new SqlParameter("@RefundDate", DBNull.Value);
                }


                sqlParameters[5] = new SqlParameter("@RefundFlag", card.refund_flag);
                sqlParameters[6] = new SqlParameter("@RefundAmount", card.refund_amount);
                sqlParameters[7] = new SqlParameter("@ValidFlag", card.valid_flag);
                sqlParameters[8] = new SqlParameter("@TicketCount", card.ticket_count);
                sqlParameters[9] = new SqlParameter("@LastUpdated", DateTime.Now);
                sqlParameters[10] = new SqlParameter("@Credits", card.credits);
                sqlParameters[11] = new SqlParameter("@Courtesy", card.courtesy);
                sqlParameters[12] = new SqlParameter("@Bonus", card.bonus);

                if (card.customer_id != 0)
                {
                    sqlParameters[13] = new SqlParameter("@CustomerId", card.customer_id);
                }
                else
                {
                    sqlParameters[13] = new SqlParameter("@CustomerId", DBNull.Value);
                }


                sqlParameters[14] = new SqlParameter("@CreditsPlayed", card.credits_played);
                sqlParameters[15] = new SqlParameter("@TicketAllowed", card.ticket_allowed);
                sqlParameters[16] = new SqlParameter("@RealTicketMode", card.real_ticket_mode);
                sqlParameters[17] = new SqlParameter("@VIPCustomer", card.vip_customer);

                if (!string.IsNullOrEmpty(card.notes))
                {
                    sqlParameters[18] = new SqlParameter("@Notes", card.notes);
                }
                else
                {
                    sqlParameters[18] = new SqlParameter("@Notes", DBNull.Value);
                }

                if (card.start_time != DateTime.MinValue)
                {
                    sqlParameters[19] = new SqlParameter("@StartDateTime", card.start_time);

                }
                else
                {
                    sqlParameters[19] = new SqlParameter("@StartDateTime", DBNull.Value);
                }

                if (card.last_played_time != DateTime.MinValue)
                {
                    sqlParameters[20] = new SqlParameter("@LastTimePlayed", card.last_played_time);
                }
                else
                {
                    sqlParameters[20] = new SqlParameter("@LastTimePlayed", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(card.lastUpdatedBy))
                {
                    sqlParameters[21] = new SqlParameter("@LastUpdatedBy", card.lastUpdatedBy);
                }
                else
                {
                    sqlParameters[21] = new SqlParameter("@LastUpdatedBy", DBNull.Value);
                }

                sqlParameters[22] = new SqlParameter("@TechnicianCard", card.technician_card);
                sqlParameters[23] = new SqlParameter("@TechGames", card.tech_games);


                sqlParameters[24] = new SqlParameter("@TimerResetCard", card.TimerResetCard);

                sqlParameters[25] = new SqlParameter("@LoyaltyPoints", card.loyalty_points);

                sqlParameters[26] = new SqlParameter("@CardTypeId", card.CardTypeId);

                if (card.ExpiryDate != DateTime.MinValue)
                {
                    sqlParameters[27] = new SqlParameter("@ExpiryDate", card.ExpiryDate);
                }
                else
                {
                    sqlParameters[27] = new SqlParameter("@ExpiryDate", DBNull.Value);

                }

                sqlParameters[28] = new SqlParameter("@CrdId", SqlDbType.Int);
                sqlParameters[28].Direction = ParameterDirection.Output;

                conn.executeInsertQuery("sp_InsertOrUpdateCard", sqlParameters);

                return Convert.ToInt32(sqlParameters[28].Value);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Transfercard(int fromcardId, int toCardId, string lastUpdatedBy)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[3];

                sqlParameters[0] = new SqlParameter("@fromCardId", fromcardId);
                sqlParameters[1] = new SqlParameter("@toCardId", toCardId);

                if (!string.IsNullOrEmpty(lastUpdatedBy))
                {
                    sqlParameters[2] = new SqlParameter("@LastUpdatedBy", lastUpdatedBy);
                }
                else
                {
                    sqlParameters[2] = new SqlParameter("@LastUpdatedBy", DBNull.Value);
                }

                conn.executeInsertQuery("sp_TransferCard", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable GetCard(int cardId, string cardNumber)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];

                if (cardId != 0)
                {
                    sqlParameters[0] = new SqlParameter("@cardId", cardId);
                }
                else
                {
                    sqlParameters[0] = new SqlParameter("@cardId", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(cardNumber))
                {
                    sqlParameters[1] = new SqlParameter("@cardNumber", cardNumber);
                }
                else
                {
                    sqlParameters[1] = new SqlParameter("@cardNumber", DBNull.Value);
                }

                return conn.executeSelectQuery("sp_GetCard", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ConsolidateCards(Card toCard, string lastUpdatedBy)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[6];

                sqlParameters[0] = new SqlParameter("@toCardId", toCard.card_id);
                sqlParameters[1] = new SqlParameter("@credits", toCard.credits);
                sqlParameters[2] = new SqlParameter("@courtesy", toCard.courtesy);
                sqlParameters[3] = new SqlParameter("@bonus", toCard.bonus);
                sqlParameters[4] = new SqlParameter("@ticket_count", toCard.ticket_count);


                if (!string.IsNullOrEmpty(lastUpdatedBy))
                {
                    sqlParameters[5] = new SqlParameter("@lastUpdatedBy", lastUpdatedBy);
                }
                else
                {
                    sqlParameters[5] = new SqlParameter("@lastUpdatedBy", DBNull.Value);
                }

                conn.executeInsertQuery("sp_ConsolidateCards", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void RefundCard(int cardId, decimal refundAmount, decimal credits, int faceValue, bool valid, string lastUpdatedBy)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[6];

                sqlParameters[0] = new SqlParameter("@card_id", cardId);
                sqlParameters[1] = new SqlParameter("@refund_amount", refundAmount);
                sqlParameters[2] = new SqlParameter("@credits", credits);
                sqlParameters[3] = new SqlParameter("@faceValue", faceValue);
                sqlParameters[4] = new SqlParameter("@valid", valid);

                if (!string.IsNullOrEmpty(lastUpdatedBy))
                {
                    sqlParameters[5] = new SqlParameter("@lastUpdatedBy", lastUpdatedBy);
                }
                else
                {
                    sqlParameters[5] = new SqlParameter("@lastUpdatedBy", DBNull.Value);
                }

                conn.executeInsertQuery("sp_RefundCard", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataSet GetTransactionList(int userId)
        {

            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];

                if (userId != 0)
                {
                    sqlParameters[0] = new SqlParameter("@userId", userId);
                }
                else
                {
                    sqlParameters[0] = new SqlParameter("@userId", DBNull.Value);
                }

                return conn.executeSelectdatasetQuery("sp_GetTrxHeaderLines", sqlParameters);

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public double GetCardRechargedAmount(int cardId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@cardId", cardId);

            DataTable dt = conn.executeSelectQuery("[sp_GetCardRechargedAmount]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                return Convert.ToDouble(dt.Rows[0][0]);
            }
            else
            {
                return 0;
            }
        }

        public int ReverseTransaction(int TrxId, int posMachineId, string loginName)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[4];
                sqlParameters[0] = new SqlParameter("@RevereseTrxId", TrxId);

                sqlParameters[1] = new SqlParameter("@POSMachineId", posMachineId);

                if (!string.IsNullOrEmpty(loginName))
                {
                    sqlParameters[2] = new SqlParameter("@LoginName", loginName);
                }
                else
                {
                    sqlParameters[2] = new SqlParameter("@LoginName", DBNull.Value);
                }

                sqlParameters[3] = new SqlParameter("@trxId", SqlDbType.Int);
                sqlParameters[3].Direction = ParameterDirection.Output;

                conn.executeUpdateQuery("sp_ReverseTransaction", sqlParameters);

                return Convert.ToInt32(sqlParameters[3].Value);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int ReverseTransactionLine(int TrxId, int lineId, int userId, string loginName, int posMachineId, string posMachine, string reference)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[8];
                sqlParameters[0] = new SqlParameter("@oldTrxid", TrxId);
                sqlParameters[1] = new SqlParameter("@lineId", lineId);

                sqlParameters[2] = new SqlParameter("@userId", userId);

                if (!string.IsNullOrEmpty(loginName))
                {
                    sqlParameters[3] = new SqlParameter("@loginId", loginName);
                }
                else
                {
                    sqlParameters[3] = new SqlParameter("@loginId", DBNull.Value);
                }

                sqlParameters[4] = new SqlParameter("@pos_machineId", posMachineId);

                if (!string.IsNullOrEmpty(posMachine))
                {
                    sqlParameters[5] = new SqlParameter("@pos_machine", posMachine);
                }
                else
                {
                    sqlParameters[5] = new SqlParameter("@pos_machine", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(reference))
                {
                    sqlParameters[6] = new SqlParameter("@reference", reference);
                }
                else
                {
                    sqlParameters[6] = new SqlParameter("@reference", DBNull.Value);
                }

                sqlParameters[7] = new SqlParameter("@reversedTrxId", SqlDbType.Int);
                sqlParameters[7].Direction = ParameterDirection.Output;

                conn.executeUpdateQuery("sp_ReverseTransactionLine", sqlParameters);

                return Convert.ToInt32(sqlParameters[7].Value);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
