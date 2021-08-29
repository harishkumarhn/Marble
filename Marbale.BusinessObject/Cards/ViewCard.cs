using System;
using System.ComponentModel.DataAnnotations;

namespace Marbale.BusinessObject.Cards
{
    public class ViewCard
    {
        [Required]
        public string CardNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public string Customer { get; set; }
        public bool VIPCustomer { get; set; }
        public bool TechnicianCard { get; set; }
        public DateTime? ToDate { get; set; }
        public bool ValidFlag { get; set; }
    }
}
