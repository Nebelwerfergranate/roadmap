//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Roadmap.BLL
{
    using System;
    using System.Collections.Generic;
    
    public partial class rdm_bills
    {
        public int id { get; set; }
        public System.DateTime date { get; set; }
        public string billNumber { get; set; }
        public int contractorID { get; set; }
        public string description { get; set; }
        public int statusID { get; set; }
        public decimal sum { get; set; }
    
        public virtual rdm_billStatuses rdm_billStatuses { get; set; }
        public virtual rdm_contractors rdm_contractors { get; set; }
    }
}