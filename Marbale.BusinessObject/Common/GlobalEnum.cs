using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject
{
    public static class GlobalEnum
    {

        public enum ProductType
        {
            [Description("New Card")]
            NEW_CARD,
            [Description("RECHARGE")]
            RECHARGE,
            [Description("MANUAL")]
            MANUAL,
            [Description("VARIABLE CARD")]
            VARIABLE_CARD,
            [Description("TIMER")]
            TIMER,
            [Description("VARIABLE RECHARGE")]
            VARIABLE_RECHARGE,
            [Description("REFUND")]
            REFUND,
            [Description("FOOD")]
            FOOD,
        }

        public enum CARD_STATUS
        {
            [Description("NEW")]
            NEW,
            [Description("ISSUED")]
            ISSUED
        }
        public enum MadatoryOption
        {
            [Description("NotUsed")]
            NotUsed=0,
            [Description("Option")]
            Option=1,
           [Description("Mandatory")]
            Mandatory=2
        }


        public static string DescriptionAttr<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }

        public enum RemarksMode
        {
            [Description("TransactionHeader")]
            TransactionHeader = 1,
            [Description("TransactionLine")]
            TransactionLine =2 
         
        }

    }
}
