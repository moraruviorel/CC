
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
    
public partial class ObjectPayments
{

    public int id { get; set; }

    public Nullable<int> object_id { get; set; }

    public Nullable<System.DateTime> payment_date { get; set; }

    public Nullable<double> amount { get; set; }

    public string notice { get; set; }

    public string person { get; set; }

}

}
