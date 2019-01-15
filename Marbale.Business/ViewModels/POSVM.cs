using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.Business.ViewModels
{
    public class POSVM
    {
        public string SkinColor { get; set; }
        public bool FingerPointAuthentication { get; set; }
        public string DefaultPayMode { get; set; }
        public string ShoePosShiftCollection { get; set; }
        public int MaxTokenNumber { get; set; }
        public bool EnableRefund { get; set; }
        public string EnableCardDetail { get; set; }
        public string CardReaderSerialNumber { get; set; }
    }
}
