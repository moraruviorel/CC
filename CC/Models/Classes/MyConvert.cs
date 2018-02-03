using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace CC.Models.Classes
{
    public class MyConvert
    {
        public static decimal ToDecimal(string _value)
        {
            if (_value.Contains(","))
                _value = _value.Replace(",", ".");

            return Convert.ToDecimal(_value, new CultureInfo("en-US"));
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

       
    }
}