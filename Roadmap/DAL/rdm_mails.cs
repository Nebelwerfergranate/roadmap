//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Roadmap.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class rdm_mails
    {
        public int id { get; set; }
        public Nullable<System.DateTime> dateSent { get; set; }
        public Nullable<System.DateTime> dateRecieved { get; set; }
        public string sender { get; set; }
        public string recipient { get; set; }
        public string description { get; set; }
        public Nullable<int> mailSystemID { get; set; }
        public Nullable<System.DateTime> replyDateSent { get; set; }
        public Nullable<System.DateTime> replyDateRecieved { get; set; }
        public string trackingNumber { get; set; }
        public string replyTrackingNumber { get; set; }
        public int statusID { get; set; }
    
        public virtual rdm_mailStatuses rdm_mailStatuses { get; set; }
        public virtual rdm_mailSystems rdm_mailSystems { get; set; }
    }
}
