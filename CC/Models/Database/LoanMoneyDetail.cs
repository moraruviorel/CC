
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace CC.Models.Database
{

using System;
    using System.Collections.Generic;
    
public partial class LoanMoneyDetail
{

    public int id { get; set; }

    public Nullable<int> LoanMoneyId { get; set; }

    public Nullable<System.DateTime> pay_date { get; set; }

    public Nullable<decimal> pay_sum { get; set; }

    public string description { get; set; }

    public Nullable<int> money_id { get; set; }

}

}