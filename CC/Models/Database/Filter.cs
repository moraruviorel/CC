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
    
    public partial class Filter
    {
        public int id { get; set; }
        public Nullable<int> controller_id { get; set; }
        public Nullable<int> operation_id { get; set; }
        public string column_name { get; set; }
        public string compare_value { get; set; }
        public string user_id { get; set; }
        public Nullable<int> table_name_id { get; set; }
    }
}
