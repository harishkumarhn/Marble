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


        public int InsertOrUpdateCards(CardsModel cardmodel)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[26];
                sqlParameters[0] = new SqlParameter("@CardId", cardmodel.CardId);
                sqlParameters[1] = new SqlParameter("@CardNumber", cardmodel.CardNumber);
                sqlParameters[2] = new SqlParameter("@Custemer", cardmodel.Customer);
                sqlParameters[3] = new SqlParameter("@FaceValue", cardmodel.FaceValue);
                sqlParameters[4] = new SqlParameter("@IssueDate", cardmodel.IssueDateP);
                sqlParameters[5] = new SqlParameter("@LastPlayTime", cardmodel.LastPlayTime);
                sqlParameters[6] = new SqlParameter("@LastUpdatedBy", cardmodel.LastUpdatedBy);
                sqlParameters[7] = new SqlParameter("@LastUpdatedTime", DateTime.Now);
                sqlParameters[8] = new SqlParameter("@Note", cardmodel.Note);
                sqlParameters[9] = new SqlParameter("@RealTicketMode", cardmodel.RealTicketMode);
                sqlParameters[10] = new SqlParameter("@RefundDate", cardmodel.RefundDate);
                sqlParameters[11] = new SqlParameter("@StartTime", cardmodel.StartTime);
                sqlParameters[12] = new SqlParameter("@TechGames", cardmodel.TechGames);

                sqlParameters[13] = new SqlParameter("@TicketAllowed", cardmodel.TicketAllowed);
                sqlParameters[14] = new SqlParameter("@TicketCount", cardmodel.TicketCount);
                sqlParameters[15] = new SqlParameter("@TimerResetCard", cardmodel.TimerResetCard);
                sqlParameters[16] = new SqlParameter("@VIPCustomer", cardmodel.VIPCustomer);
                sqlParameters[17] = new SqlParameter("@TechCardType", cardmodel.TechCardType);
                sqlParameters[18] = new SqlParameter("@RefundAmount", cardmodel.RefundAmount);

                sqlParameters[19] = new SqlParameter("@Credits", cardmodel.Credits);
                sqlParameters[20] = new SqlParameter("@CreditPlus", cardmodel.CreditPlus);
                sqlParameters[21] = new SqlParameter("@Courtesy", cardmodel.Courtesy);
                sqlParameters[22] = new SqlParameter("@CreditsPlayed", cardmodel.CreditsPlayed);
                sqlParameters[23] = new SqlParameter("@Bonus", cardmodel.Bonus);
                sqlParameters[24] = new SqlParameter("@ExpiryDate", cardmodel.ExpiryDate);
                sqlParameters[25] = new SqlParameter("@Valid", cardmodel.ValidFlag);

                return conn.executeInsertQuery("sp_InsertOrUpdateCards", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable GetAllCards(CardsModel cardmodel)
        {
            try
            {
                
                SqlParameter[] sqlParameters = new SqlParameter[6];
                sqlParameters[0] = new SqlParameter("@TechnicianCard", cardmodel.TechnicianCard);
                sqlParameters[1] = new SqlParameter("@CardNumber", cardmodel.CardNumber);
                sqlParameters[2] = new SqlParameter("@Custemer", string.IsNullOrEmpty(cardmodel.Customer) ? "" : cardmodel.Customer);
                sqlParameters[3] = new SqlParameter("@VIPCustomer", cardmodel.VIPCustomer);
                sqlParameters[4] = new SqlParameter("@IssueDate", cardmodel.IssueDate);
                sqlParameters[5] = new SqlParameter("@ToDate", cardmodel.ToDate);
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
    }
}
