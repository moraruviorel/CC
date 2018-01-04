using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.Classes
{
    public class MyConvert
    {
        public static decimal ToDecimal(string _value)
        {
            if (_value.Contains("."))
                return Convert.ToDecimal(_value.Replace(".", ","));
            else
                return Convert.ToDecimal(_value);
        }
    }
}