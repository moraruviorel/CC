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
    
    public partial class ObjectMaterial
    {
        public int id { get; set; }
        public Nullable<int> object_id { get; set; }
        public Nullable<int> material_id { get; set; }
        public Nullable<System.DateTime> buyed_date { get; set; }
        public Nullable<double> quantity { get; set; }
        public Nullable<double> total_price { get; set; }
        public string material_description { get; set; }
        public Nullable<short> visible { get; set; }
    }
}
