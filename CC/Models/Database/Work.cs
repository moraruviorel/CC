
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
    
public partial class Work
{

    public int id { get; set; }

    public Nullable<int> object_id { get; set; }

    public Nullable<int> worker_id { get; set; }

    public string name { get; set; }

    public string surface { get; set; }

    public Nullable<decimal> unit_price { get; set; }

    public Nullable<System.DateTime> date_start { get; set; }

    public Nullable<System.DateTime> date_end { get; set; }

    public short is_paid { get; set; }

    public short visible { get; set; }

    public Nullable<int> unit_id { get; set; }

}

}