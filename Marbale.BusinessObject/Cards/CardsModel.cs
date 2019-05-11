using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Cards
{
   public class CardsModel
    {
        public int CardId { get; set; }
        public string CardNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public float FaceValue { get; set; }
        public string Custemer { get; set; }
        public bool VIPCustomer { get; set; }
        public float Credits { get; set; }
        public float Courtesy { get; set; }
        public float CreditPlus { get; set; }
        public float Bonus { get; set; }
        public int GameTime { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime RefundDate { get; set; }
        public DateTime LastUpdatedTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public float RefundAmount { get; set; }
        public string Note { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime LastPlayTime { get; set; }
        public int TicketCount { get; set; }
        public bool TicketAllowed { get; set; }
        public bool RealTicketMode { get; set; }
        public string TechGames { get; set; }
        public bool TimerResetCard { get; set; }
        public string TechCardType { get; set; }
        public bool TechnicianCard { get; set; }
        public DateTime ToDate { get; set; }
        public float CreditsPlayed { get; set; }
    }
}
