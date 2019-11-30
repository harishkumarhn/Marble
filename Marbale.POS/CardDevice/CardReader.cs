using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.POS.CardDevice
{
    public static class CardReader
    {
        public static bool CardSwiped = false;
        public static string CardNumber = "";

        public static bool RequiredByOthers = false;

        public delegate void InvokeHandle();

        static InvokeHandle receiveAction;

        public static void OthersTasks()
        {
            if (receiveAction != null)
                receiveAction.Invoke();
        }

        public static InvokeHandle setReceiveAction
        {
            get
            {
                return receiveAction;
            }
            set
            {
                receiveAction = value;
            }
        }
    }
}
