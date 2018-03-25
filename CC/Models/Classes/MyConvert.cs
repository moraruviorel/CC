using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace CC.Models.Classes
{
    public class MyConvert
    {
        public static decimal ToDecimal(string value)
        {
            if (!string.IsNullOrEmpty(value) && value.Contains(","))
                value = value.Replace(",", ".");
            if (value == string.Empty)
                value = null;
            //_value = _value == string.Empty ? null : _value;

            return Convert.ToDecimal(value, new CultureInfo("en-US"));
        }

        public static DateTime? ToDateTime(string _value)
        {
            if (string.IsNullOrWhiteSpace(_value))
            {
                return null;
            }
            else
            {
                return DateTime.ParseExact(_value, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

        }


        public static double ToDouble(string value)
        {
            if (!string.IsNullOrEmpty(value) && value.Contains(","))
                value = value.Replace(",", ".");
            if (value == string.Empty)
                value = null;
            //_value = _value == string.Empty ? null : _value;

            return Convert.ToDouble(value, new CultureInfo("en-US"));
        }
    }
}