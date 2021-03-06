﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject.Cards
{
  public  class Inventory
    {
        public string ActionDateString { get; set; }
        public string User { get; set; }
        public string RecievedDate { get; set; }
        public int NumberOfCards { get; set; }
        public DateTime ?From { get; set; }
        public DateTime  ? To { get; set; }
        public string ActionName { get; set; }
        public DateTime ActionDate { get; set; }
        public string ActionBy { get; set; }
        public bool TillDate { get; set; }
        public bool ForPeriod { get; set; }
        public int TotalNumberOfCards { get; set; }
    }
}
