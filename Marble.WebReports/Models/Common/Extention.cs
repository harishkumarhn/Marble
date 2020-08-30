using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marble.WebReports
{
    public static class Extention
    {

        public static DateTime? ToDateTime(this string value)
        {
            if(value==null)
            {
                return null;
            }
            string[] arr = value.Split('/');
            if(arr==null || arr.Length!=3)
            {
                return null;
            }


            return new DateTime(arr[2].ToInt(), arr[0].ToInt(), arr[1].ToInt());
        }
        public static DateTime ToDateTime1(this string value)
        {
            if (value == null)
            {
                return DateTime.Now;
            }
            string[] arr = value.Split('/');
            if (arr == null || arr.Length != 3)
            {
                return DateTime.Now;
            }


            return new DateTime(arr[2].ToInt(), arr[0].ToInt(), arr[1].ToInt());
        }
        public static int ToInt(this string value)
        {
            int val = 0;
            int.TryParse(value, out val);
            return val;
        }

        public static string ToDStringDBTime(this string value)
        {
            if (value == null)
            {
                return null;
            }
            string[] arr = value.Split('/');
            if (arr == null || arr.Length != 3)
            {
                return null;
            }

            return arr[2]+"-"+arr[0]+"-"+arr[1];
        }

    }
}