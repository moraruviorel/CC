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
    
    public partial class WorkerPayment
    {
        public int id { get; set; }
        public int worker_id { get; set; }
        public Nullable<int> work_id { get; set; }
        public string userId { get; set; }
        public Nullable<System.DateTime> payment_date { get; set; }
        public string notice { get; set; }
        public Nullable<int> payment_type { get; set; }
        public Nullable<bool> is_advance_excluded { get; set; }
        public Nullable<decimal> amount { get; set; }
    }
}
