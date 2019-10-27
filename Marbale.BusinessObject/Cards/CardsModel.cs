using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Cards
{
    public class CardsModel
    {
        public int CardId { get; set; }
        [Required]
        public string CardNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "{0} Must be a Number")]
        public float? FaceValue { get; set; }
        public string Customer { get; set; }
        public bool VIPCustomer { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "{0} Must be a Number")]
        public float? Credits { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "{0} Must be a Number")]
        public float? Courtesy { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "{0} Must be a Number")]
        public float? CreditPlus { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "{0} Must be a Number")]
        public float? Bonus { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "{0} Must be a Number")]
        public int? GameTime { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? RefundDate { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
        public string LastUpdatedBy { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "{0} Must be a Number")]
        public float? RefundAmount { get; set; }
        public string Note { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? LastPlayTime { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "{0} Must be a Number")]
        public int? TicketCount { get; set; }
        public bool TicketAllowed { get; set; }
        public bool RealTicketMode { get; set; }
        public string TechGames { get; set; }
        public bool TimerResetCard { get; set; }
        public int TechCardType { get; set; }
        public bool TechnicianCard { get; set; }
        public DateTime? ToDate { get; set; }
        public float CreditsPlayed { get; set; }

        public bool RefundFlag { get; set; }
        public bool ValidFlag { get; set; }

        public int CustomerId { get; set; }

        public int LoyaltyPoints { get; set; }

        public int CardTypeId { get; set; }

        public DateTime? IssueDateP { get; set; }
    }
}
