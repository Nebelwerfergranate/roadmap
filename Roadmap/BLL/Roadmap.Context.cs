﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Roadmap : DbContext
    {
        public Roadmap()
            : base("name=Roadmap")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<rdm_bills> rdm_bills { get; set; }
        public virtual DbSet<rdm_billStatuses> rdm_billStatuses { get; set; }
        public virtual DbSet<rdm_contractors> rdm_contractors { get; set; }
        public virtual DbSet<rdm_documents> rdm_documents { get; set; }
        public virtual DbSet<rdm_documentStatuses> rdm_documentStatuses { get; set; }
        public virtual DbSet<rdm_documentTypes> rdm_documentTypes { get; set; }
        public virtual DbSet<rdm_mails> rdm_mails { get; set; }
        public virtual DbSet<rdm_mailStatuses> rdm_mailStatuses { get; set; }
        public virtual DbSet<rdm_mailSystems> rdm_mailSystems { get; set; }
    }
}