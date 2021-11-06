using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject
{
    public static class GlobalMessage
    {

        public static string TAP_NEW_CARD = "Please Tap the NEW card";
        public static string NO_CARD_NOT_PRESENT = "Please chose the card";
        public static string ATLEAST_ONE_CARD_PRESENT = "At least Cards required";
        public static string CHOOSE_NEW_CARD = "Please choose a NEW, CARDSALE or GAMETIME Card Product";
        public static string MAXLOADMULTIPLECARDS_REACHED = "Reached maximum cards limit";


        public static string ENTER_CREDITS_GREATER_THAN_ZERO_TO_REFUND = "Enter credits greater than zero to Refund";


        public static string ENTER_CREDITS_LESS_THAN_OR_EQUAL_TO_AVAILABLE_CREDITS = "Enter credits less than or equal to available credits";

        public static string ENTER_CREDITS_EQUAL_TO_AVAILABLE_CREDITS = "Enter credits equal to available credits";

        public static string ENTER_CREDITS_EQUAL_TO = "Enter credits equal to amount  : @amount ";
        public static string ENTER_CREDITS_LESS_THAN_OR_EQUAL = "Enter credits less than or equal to amount  : @amount ";

        public static string REQUIRED_TRANSACTION_HEADER_REMARKS = "Enter Transation Header Remarks";

        public static string REQUIRED_TRANSACTION_LINE_REMARKS = "Enter Transation Line Remarks";

        public static string REQUIRED_REMARKS = "Please Enter Remarks";

        public static string COMPLETE_CUSTOMER_REGISTRATION = "Please Complete Customer registration";
    }


    public static class GlobalConstant
    {

        public static string TAP_NEW_CARD = "Please Tap the NEW card";

        public static string ALLOW_PARTIAL_REFUND = "ALLOW_PARTIAL_REFUND";

        public static string ALLOW_FULL_REFUND = "ALLOW_FULL_REFUND";

       

        //public static string   ALLOW_REFUND_OF_CARD_DEPOSIT ="Allow_Refund_Of_Card_Deposit";

        //public static string ALLOW_REFUND_OF_CARD_CREDITS = "Allow_Refund_of_Card_Credits";
    }
}
