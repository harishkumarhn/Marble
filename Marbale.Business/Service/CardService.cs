using Marbale.DataAccess.Data;
using Marble.DataLoggerService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marble.Business
{
    public class CardService
    {
        private readonly DataLogger dataLogger = new DataLogger();
        CardsData cardsData = new CardsData();

        public DataTable CardTransactionSelect(int cardId)
        {
            dataLogger.Debug("Begin ---CardTransactionSelect--");
            DataTable cardData = null;
            try
            {
                cardData = cardsData.CardTransactionSelect(cardId);

                dataLogger.Debug("END ---CardTransactionSelect--");
                return cardData;
            }
            catch (Exception e)
            {
                dataLogger.Error("on CardService : CardTransactionSelect", e);
                return null;
            }
        }

        public DataTable CardGameplay_Select(string cardNumber)
        {
            dataLogger.Debug("Begin ---CardGameplay_Select--");
            DataTable cardData = null;
            try
            {
                cardData = cardsData.CardGameplay_Select(cardNumber);

                dataLogger.Debug("END ---CardGameplay_Select--");
                return cardData;
            }
            catch (Exception e)
            {
                dataLogger.Error("on CardService : CardPurchase_Select", e);
                return null;
            }
        }

        
    }
}
