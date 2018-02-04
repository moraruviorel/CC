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
            if (!string.IsNullOrEmpty(_value) && _value.Contains(","))
                _value = _value.Replace(",", ".");
            if (_value == string.Empty)
                _value = null;
            //_value = _value == string.Empty ? null : _value;

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