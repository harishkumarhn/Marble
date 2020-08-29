using Marbale.BusinessObject;
using Marbale.BusinessObject.Cards;
using Marbale.DataAccess;
using Marbale.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace Marble.Business
{
    public class CardsBL
    {
        private CardsData cardData;
        private CommonData commonData;

        public CardsBL()
        {
            cardData = new CardsData();
            commonData = new CommonData();
        }
        public int InsertOrUpdateCards(CardsModel cardmodel)
        {
            try
            {
                return cardData.InsertOrUpdateCards(cardmodel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<CardsModel> GetAllCards(CardsModel c)
        {
            if (c.IssueDate != null || c.ToDate != null)
            {
                var cardslist = cardData.GetAllCards(c);
                List<CardsModel> listcards = new List<CardsModel>();
                listcards = getAllCardsProperties(cardslist);
                return listcards;
            }
            return null;
        }
        public List<CardsModel> getAllCardsProperties(DataTable cardslist)
        {
            List<CardsModel> listcards = new List<CardsModel>();

            foreach (DataRow dr in cardslist.Rows)
            {
                CardsModel pType = new CardsModel();
                pType.CardId = dr.IsNull("CardId") ? 0 : int.Parse(dr["CardId"].ToString());
                pType.CardNumber = dr.IsNull("CardNumber") ? "" : (dr["CardNumber"].ToString());
                pType.Customer = dr.IsNull("Customer") ? "" : dr["Customer"].ToString();
                pType.ExpiryDate = dr.IsNull("ExpiryDate") ? new DateTime() : Convert.ToDateTime(dr["ExpiryDate"].ToString());
                pType.LastUpdatedBy = dr.IsNull("LastUpdatedBy") ? "" : dr["LastUpdatedBy"].ToString();
                pType.LastUpdatedTime = dr.IsNull("LastUpdatedTime") ? new DateTime() : Convert.ToDateTime(dr["LastUpdatedTime"]);
                pType.FaceValue = dr.IsNull("FaceValue") ? 0 : float.Parse(dr["FaceValue"].ToString());
                pType.IssueDateP = dr.IsNull("IssueDate") ? new DateTime() : Convert.ToDateTime(dr["IssueDate"].ToString());
                pType.LastPlayTime = dr.IsNull("LastTimePlayed") ? new DateTime() : Convert.ToDateTime(dr["LastTimePlayed"].ToString());
                pType.Note = dr.IsNull("Note") ? "" : dr["Note"].ToString();
                pType.RefundAmount = dr.IsNull("RefundAmount") ? 0 : float.Parse(dr["RefundAmount"].ToString());
                pType.RefundDate = dr.IsNull("RefundDate") ? new DateTime() : Convert.ToDateTime(dr["RefundDate"].ToString());
                pType.StartTime = dr.IsNull("StartDateTtime") ? new DateTime() : Convert.ToDateTime(dr["StartDateTtime"].ToString());
                pType.TechGames = dr.IsNull("TechGames") ? "" : dr["TechGames"].ToString();
                pType.TimerResetCard = dr.IsNull("TimerResetCard") ? false : bool.Parse(dr["TimerResetCard"].ToString());
                pType.VIPCustomer = dr.IsNull("VIPCustomer") ? false : bool.Parse(dr["VIPCustomer"].ToString());
                pType.TechCardType = dr.IsNull("TechnicianCard") ? 0 : int.Parse(dr["TechnicianCard"].ToString());

                pType.Credits = dr.IsNull("Credits") ? 0 : float.Parse(dr["Credits"].ToString());
                pType.CreditPlus = dr.IsNull("CreditPlus") ? 0 : float.Parse(dr["CreditPlus"].ToString());
                pType.CreditsPlayed = dr.IsNull("CreditsPlayed") ? 0 : float.Parse(dr["CreditsPlayed"].ToString());


                pType.Courtesy = dr.IsNull("Courtesy") ? 0 : float.Parse(dr["Courtesy"].ToString());
                pType.Bonus = dr.IsNull("Bonus") ? 0 : float.Parse(dr["Bonus"].ToString());
                pType.RealTicketMode = dr.IsNull("RealTicketMode") ? false : bool.Parse(dr["RealTicketMode"].ToString());
                pType.TicketCount = dr.IsNull("TicketCount") ? 0 : int.Parse(dr["TicketCount"].ToString());
                pType.TicketAllowed = dr.IsNull("TicketAllowed") ? false : bool.Parse(dr["TicketAllowed"].ToString());
                listcards.Add(pType);
            }
            return listcards;
        }
        public CardsModel getCardById(int CardId)
        {
            var cards = cardData.GetCardById(CardId);
            List<CardsModel> pType = new List<CardsModel>();
            pType = getAllCardsProperties(cards);
            return pType[0];
        }

        public List<IdValue> gettechcardtype()
        {
            var techcard = cardData.GetTechCardType();
            var typeList = new List<IdValue>();
            typeList.Add(new IdValue() { Id = 0, Value = "Select" });
            foreach (DataRow dr in techcard.Rows)
            {
                IdValue idValues = new IdValue();
                idValues.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                idValues.Value = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                typeList.Add(idValues);
            }
            return typeList;
        }

        public int AddDeleteInventory(Inventory inventory)
        {
            var status = cardData.AddDeleteInventory(inventory);
            var data = cardData.GetInventory(inventory);
            int TotalNumberOfCards = GetTotalNumberOfCards(data);
            return TotalNumberOfCards;

        }
        public int GetTotalNumberOfCards(DataTable data)
        {
            Inventory inv = null;
            foreach (DataRow dr in data.Rows)
            {
                inv = new Inventory();
                inv.TotalNumberOfCards = dr.IsNull("TotalNumberOfCards") ? 0 : int.Parse(dr["TotalNumberOfCards"].ToString());

            }
            return inv.TotalNumberOfCards;
        }

        public List<Inventory> GetInventory(Inventory inventory)
        {
            List<Inventory> inventorylist = new List<Inventory>();
            var dataTable = cardData.GetInventory(inventory);
            foreach (DataRow dr in dataTable.Rows)
            {
               Inventory inv = new Inventory();
                inv.NumberOfCards = dr.IsNull("NumberOfCards") ? 0 : int.Parse(dr["NumberOfCards"].ToString());
                inv.User = dr.IsNull("User") ? "" : (dr["User"].ToString());
                inv.ActionBy = dr.IsNull("ActionBy") ? "" : (dr["ActionBy"].ToString());
                inv.ActionName = dr.IsNull("Action") ? "" : (dr["Action"].ToString());
                inv.ActionDateString = dr.IsNull("ActionDate") ? "" : (dr["ActionDate"].ToString());
                inv.ActionDate = Convert.ToDateTime(dr.IsNull("ActionDate") ? "01-01-2019" : (dr["ActionDate"].ToString()));
                inv.TotalNumberOfCards = dr.IsNull("TotalNumberOfCards") ? 0 : int.Parse(dr["TotalNumberOfCards"].ToString());
                //inv.RecievedDate = dr.IsNull("RecievedDate") ? "01/01/2019" : (dr["RecievedDate"].ToString());

                inventorylist.Add(inv);
            }
            return inventorylist;
        }
      
        public int DeleteCardById(int Id, string from)
        {
            try
            {
                return commonData.DeleteById(Id, from);
            }
            catch (Exception e)
            {
                //   LogError.Instance.LogException("DeleteProductbyId", e);
                throw e;
            }
        }

    }
}
