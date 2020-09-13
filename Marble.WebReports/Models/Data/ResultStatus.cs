using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marble.WebReports 
{
    public class ResultStatus
    {
        private int result;

        public int Result
        {
            get { return result; }
            set { result = value; }
        }
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public ResultStatus(int Result, string Message)
        {
            this.result = Result;
            this.message = Message;
        }
        public ResultStatus()
        {

        }
    }
}