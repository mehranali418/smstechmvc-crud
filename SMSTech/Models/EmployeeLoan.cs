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
    
    public partial class EmployeeLoan
    {
        public int ID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<int> OperatorID { get; set; }
        public string AllowanceName { get; set; }
        public Nullable<decimal> ReceivedLoan { get; set; }
        public Nullable<decimal> ReturnedLoan { get; set; }
        public Nullable<System.DateTime> T_Date { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> SalaryMonthID { get; set; }
        public string ChequeNo { get; set; }
        public Nullable<bool> Processesd { get; set; }
        public Nullable<byte> PaymentMethod { get; set; }
    }
}