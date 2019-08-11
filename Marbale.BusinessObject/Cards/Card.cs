using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Cards
{
    public class Card
    {
        public string CardNumber;
        public string CardStatus;
        public int card_id = -1;
        public DateTime issue_date;
        public DateTime ExpiryDate;
        public decimal face_value;
        public bool refund_flag = true;
        public float refund_amount;
        public DateTime refund_date;
        public bool valid_flag = true;
        public int ticket_count;
        public int addTicketCount;
        public string notes = "";
        public DateTime last_update_time;
        public decimal credits;
        public decimal courtesy;
        public decimal bonus;
        public double time;
        public double addCredits;
        public double addCourtesy;
        public double addBonus;
        public double addTime;
        public int customer_id = -1;
        public double credits_played;
        public double loyalty_points;
        public bool ticket_allowed = true;
        public bool real_ticket_mode;
        public bool vip_customer = false;
        public Customer.Customers customer;
        public DateTime start_time = DateTime.MinValue;
        public DateTime last_played_time = DateTime.MinValue;
        public bool technician_card;
        public int tech_games;
        public int CardGames;
        public double CreditPlusCardBalance;
        public double addCreditPlusCardBalance;
        public double CreditPlusCredits;
        public double CreditPlusBonus;
        public double CreditPlusLoyaltyPoints;
        public int CreditPlusTickets;
        public string loginId;
        public int siteId = -1;
        public int CardTypeId = -1;
        public string CardType = "Normal";
        public double TotalRechargeAmount;
        public double creditPlusItemPurchase;
        public string lastUpdatedBy;
        public bool TimerResetCard;
    }
}
