//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkerSalaryContract
    {
        public int id { get; set; }
        public Nullable<int> worker_id { get; set; }
        public Nullable<System.DateTime> new_contract_date { get; set; }
        public Nullable<double> worker_sum { get; set; }
        public string worker_function { get; set; }
    }
}