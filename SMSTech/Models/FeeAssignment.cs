//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SMSTech.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FeeAssignment
    {
        public int ID { get; set; }
        public Nullable<int> FeeChallanID { get; set; }
        public string FeeFrequency { get; set; }
        public Nullable<System.DateTime> sDate { get; set; }
        public string FeeTypes { get; set; }
        public string Classes { get; set; }
    }
}