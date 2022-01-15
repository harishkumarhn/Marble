using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject
{
    public class ResultStatus
    {
        public ResultStatus()
        {

        }
        public ResultStatus(int code,string message)
        {
            this.Result = code;
            this.Message = message;
        }
        public int Result { get; set; }

        public string Message { get; set; }
    }
}
