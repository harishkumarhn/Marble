using Marbale.BusinessObject.Cards;
using Marble.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marbale.POS
{
    public class PosCodeBL
    {
        #region declaration
        CardService cardService = new CardService();
        Utility utility = new Utility();
        #endregion


        public void BindPurchaseGrid(Card card, ref DataGridView dgPurchase  ) 
        {
            dgPurchase.DataSource = null;

            if (card == null || card.card_id<=0)
                return;

            DataTable dtCardsData = cardService.CardTransactionSelect(card.card_id);
            dgPurchase.DataSource = dtCardsData;

            dgPurchase.Columns["CardId"].Visible = false;
            dgPurchase.Columns["trxdate"].DefaultCellStyle = utility.GetGViewDateTimeCellStyle();
            dgPurchase.Columns["ProductName"].Visible = false;
            dgPurchase.Columns["Amount"].DefaultCellStyle = utility.GetGViewAmountCellStyle();
            dgPurchase.Columns["Credits"].DefaultCellStyle = utility.GetGViewAmountCellStyle();
            dgPurchase.Columns["Courtesy"].DefaultCellStyle = utility.GetGViewNumericCellStyle();
            //dgPurchase.Columns["TIME"].DefaultCellStyle = utility.GetGViewNumericCellStyle();
            // dgPurchase.Columns["Bonus"].DefaultCellStyle = utility.GetGViewDateTimeCellStyle();
            dgPurchase.Columns["Tokens"].Visible = false;
            dgPurchase.Columns["POS"].Visible = false;
            dgPurchase.Columns["UserFullName"].Visible = false;
            dgPurchase.Columns["RefId"].Visible = false;
            dgPurchase.Columns["ActivityType"].Visible = false;
          





        }


        public void BindGamePlayCardGrid(Card card, ref DataGridView dgvCardGames)
        {
            dgvCardGames.DataSource = null;

            if (card == null || card.card_id <= 0)
                return;

            DataTable dtCardsData = cardService.CardGameplay_Select(card.CardNumber);
            dgvCardGames.DataSource = dtCardsData;

            dgvCardGames.Columns["CardId"].Visible = false;
            dgvCardGames.Columns["MachineId"].Visible = false;

            dgvCardGames.Columns["PlayedDate"].DefaultCellStyle = utility.GetGViewDateTimeCellStyle();
            
            dgvCardGames.Columns["PlayedDate"].Width = 400;

            dgvCardGames.Columns["GameName"].Width =
          dgvCardGames.Columns["Profile"].Width =
            dgvCardGames.Columns["MachineAddress"].Width =
            dgvCardGames.Columns["MachineName"].Width = 300;


               dgvCardGames.Columns["credits"].DefaultCellStyle = utility.GetGViewAmountCellStyle();
            dgvCardGames.Columns["courtesy"].DefaultCellStyle = utility.GetGViewAmountCellStyle();
            dgvCardGames.Columns["bonus"].DefaultCellStyle = utility.GetGViewNumericCellStyle();
            dgvCardGames.Columns["time"].DefaultCellStyle = utility.GetGViewNumericCellStyle();
            dgvCardGames.Columns["TicketCount"].DefaultCellStyle = utility.GetGViewDateTimeCellStyle();






        }

    }
}
