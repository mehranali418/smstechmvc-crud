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
    
    public partial class StudentPayments_History
    {
        public int ID { get; set; }
        public string Action { get; set; }
        public Nullable<System.DateTime> ActionDate { get; set; }
        public Nullable<int> ActionUserID { get; set; }
        public string StudentPaymentsID { get; set; }
        public Nullable<int> StudentID { get; set; }
        public Nullable<int> SectionID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string FeeType { get; set; }
        public Nullable<int> DuesFrom { get; set; }
        public Nullable<int> DuesTo { get; set; }
        public Nullable<int> PaidFrom { get; set; }
        public Nullable<int> PaidTo { get; set; }
        public Nullable<System.DateTime> S_Date { get; set; }
        public Nullable<int> PersonalizedFeeID { get; set; }
        public Nullable<int> FeeTypeID { get; set; }
        public Nullable<int> FeeChallanDetailID { get; set; }
        public string Status { get; set; }
        public Nullable<int> Fine { get; set; }
        public Nullable<int> LateDays { get; set; }
        public Nullable<decimal> WaiveOff { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> WaiveOffUserID { get; set; }
    }
}