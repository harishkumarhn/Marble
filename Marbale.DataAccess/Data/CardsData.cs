using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marbale.BusinessObject.Cards;
using System.Data;
using System.Data.SqlClient;
namespace Marbale.DataAccess.Data
{
    public class CardsData
    {
        private DBConnection conn;

        public CardsData()
        {
            conn = new DBConnection();
        }


        public DataTable InsertOrUpdateCards(CardsModel cardmodel)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[25];
                sqlParameters[0] = new SqlParameter("@CardId", cardmodel.CardId);
                sqlParameters[1] = new SqlParameter("@CardNumber", cardmodel.CardNumber);
                //sqlParameters[2] = new SqlParameter("@CustomerName ", cardmodel.Customer);
                if (cardmodel.CardNumber == null)
                {
                    sqlParameters[2] = new SqlParameter("@FaceValue", DBNull.Value);
                }
                else
                {
                    sqlParameters[2] = new SqlParameter("@FaceValue", cardmodel.FaceValue);
                }

                if (cardmodel.IssueDateP == null)
                {
                    sqlParameters[3] = new SqlParameter("@IssueDate", DBNull.Value);
                }
                else
                {
                    sqlParameters[3] = new SqlParameter("@IssueDate", cardmodel.IssueDateP);
                }

                if (cardmodel.LastPlayTime == null)
                {
                    sqlParameters[4] = new SqlParameter("@LastPlayTime", DBNull.Value);
                }
                else
                {
                    sqlParameters[4] = new SqlParameter("@LastPlayTime", cardmodel.LastPlayTime);
                }


                if (cardmodel.LastUpdatedBy == null)
                {
                    sqlParameters[5] = new SqlParameter("@LastUpdatedBy", DBNull.Value);
                }
                else
                {
                    sqlParameters[5] = new SqlParameter("@LastUpdatedBy", cardmodel.LastUpdatedBy);
                }

                sqlParameters[6] = new SqlParameter("@LastUpdatedTime", DateTime.Now);


                if (cardmodel.Note == null)
                {
                    sqlParameters[7] = new SqlParameter("@Note", DBNull.Value);

                }
                else
                {
                    sqlParameters[7] = new SqlParameter("@Note", cardmodel.Note);
                }




                //if (cardmodel.RealTicketMode == null)
                //{
                //    sqlParameters[9] = new SqlParameter("@RealTicketMode", cardmodel.RealTicketMode);
                //}
                //else
                //{
                //    sqlParameters[9] = new SqlParameter("@RealTicketMode", cardmodel.RealTicketMode);
                //}
                sqlParameters[8] = new SqlParameter("@RealTicketMode", cardmodel.RealTicketMode);

                if (cardmodel.RefundDate == null)
                {
                    sqlParameters[9] = new SqlParameter("@RefundDate", DBNull.Value);
                }
                else
                {
                    sqlParameters[9] = new SqlParameter("@RefundDate", cardmodel.RefundDate);
                }


                if (cardmodel.StartTime == null)
                {
                    sqlParameters[10] = new SqlParameter("@StartTime", DBNull.Value);
                }
                else
                {
                    sqlParameters[10] = new SqlParameter("@StartTime", cardmodel.StartTime);
                }


                if (cardmodel.TechGames == null)
                {
                    sqlParameters[11] = new SqlParameter("@TechGames", DBNull.Value);
                }
                else
                {
                    sqlParameters[11] = new SqlParameter("@TechGames", cardmodel.TechGames);
                }



                sqlParameters[12] = new SqlParameter("@TicketAllowed", cardmodel.TicketAllowed);



                if (cardmodel.TicketCount == null)
                {
                    sqlParameters[13] = new SqlParameter("@TicketCount", DBNull.Value);
                }
                else
                {
                    sqlParameters[13] = new SqlParameter("@TicketCount", cardmodel.TicketCount);
                }

                sqlParameters[14] = new SqlParameter("@TimerResetCard", cardmodel.TimerResetCard);
                sqlParameters[15] = new SqlParameter("@VIPCustomer", cardmodel.VIPCustomer);

                if (cardmodel.RefundAmount == null)
                {
                    sqlParameters[16] = new SqlParameter("@RefundAmount", DBNull.Value);
                }
                else
                {
                    sqlParameters[16] = new SqlParameter("@RefundAmount", cardmodel.RefundAmount);
                }

                sqlParameters[17] = new SqlParameter("@TechCardType", cardmodel.TechCardType);

               

                if (cardmodel.Credits == null)
                {
                    sqlParameters[18] = new SqlParameter("@Credits", DBNull.Value);
                }
                else
                {
                    sqlParameters[18] = new SqlParameter("@Credits", cardmodel.Credits);
                }


                if (cardmodel.CreditPlus == null)
                {
                    sqlParameters[19] = new SqlParameter("@CreditPlus", DBNull.Value);
                }
                else
                {
                    sqlParameters[19] = new SqlParameter("@CreditPlus", cardmodel.CreditPlus);
                }


                if (cardmodel.Courtesy == null)
                {
                    sqlParameters[20] = new SqlParameter("@Courtesy", DBNull.Value);
                }
                else
                {
                    sqlParameters[20] = new SqlParameter("@Courtesy", cardmodel.Courtesy);
                }

                sqlParameters[21] = new SqlParameter("@CreditsPlayed", cardmodel.CreditsPlayed);

                if (cardmodel.Bonus == null)
                {
                    sqlParameters[22] = new SqlParameter("@Bonus", DBNull.Value);
                }
                else
                {
                    sqlParameters[22] = new SqlParameter("@Bonus", cardmodel.Bonus);
                }

                if (cardmodel.ExpiryDate == null)
                {
                    sqlParameters[23] = new SqlParameter("@ExpiryDate", DBNull.Value);
                }
                else
                {
                    sqlParameters[23] = new SqlParameter("@ExpiryDate", cardmodel.ExpiryDate);
                }
                sqlParameters[24] = new SqlParameter("@Valid", cardmodel.ValidFlag);

               
                return conn.executeSelectQuery("sp_InsertOrUpdateCards", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable GetAllCards(ViewCard cardSearchCriteria)
        {
            try
            {

                SqlParameter[] sqlParameters = new SqlParameter[6];
                sqlParameters[0] = new SqlParameter("@TechnicianCard", cardSearchCriteria.TechnicianCard);
                sqlParameters[1] = new SqlParameter("@CardNumber", cardSearchCriteria.CardNumber);
                sqlParameters[2] = new SqlParameter("@Custemer", string.IsNullOrEmpty(cardSearchCriteria.Customer) ? "" : cardSearchCriteria.Customer);
                sqlParameters[3] = new SqlParameter("@VIPCustomer", cardSearchCriteria.VIPCustomer);
                sqlParameters[4] = new SqlParameter("@IssueDate", cardSearchCriteria.IssueDate);
                sqlParameters[5] = new SqlParameter("@ToDate", cardSearchCriteria.ToDate);
                return conn.executeSelectQuery("sp_GetAllCards", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable GetCardById(int CardId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@CardId", CardId);
            return conn.executeSelectQuery("sp_GetCardById", sqlParameters);
        }

        public DataTable GetTechCardType()
        {
            return conn.executeSelectQuery("GetTechCardType");
        }

        public int AddDeleteInventory(Marbale.BusinessObject.Cards.Inventory inventory)
        {
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@Action", inventory.ActionName);
            sqlParameters[1] = new SqlParameter("@NumberOfCards", inventory.NumberOfCards);
            sqlParameters[2] = new SqlParameter("@ActionDate", DateTime.Now);
            sqlParameters[3] = new SqlParameter("@ActionBy", inventory.ActionBy);
            return conn.executeInsertQuery("InsertDeleteInventory", sqlParameters);
        }

        public DataTable GetInventory(Marbale.BusinessObject.Cards.Inventory inventory)
        {


            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@From", inventory.From);
            sqlParameters[1] = new SqlParameter("@To", inventory.To);
            return conn.executeSelectQuery("GetInventory", sqlParameters);

        }

        public int DeleteCardById(int Id)
        {

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@CardId", Id);

            return conn.executeInsertQuery("DeleteCardById", sqlParameters);
        }


        public DataTable CardTransactionSelect(int cardId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@cardid", cardId);
            return conn.executeSelectQuery("CardTransactionSelect", sqlParameters);
        }

        public DataTable CardGameplay_Select(string cardNumber)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@CardNumber", cardNumber);
            return conn.executeSelectQuery("CardGameplay_Select", sqlParameters);
        }

    }
}
