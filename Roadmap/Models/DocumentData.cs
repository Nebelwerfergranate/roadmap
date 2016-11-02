using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roadmap.Models
{
    public class DocumentData
    {
        public int Id { get; set; }
        public string DocumentUrl { get; set; }
        public string ContractorFirstName { get; set; }
        public string ContractorLastname { get; set; }
        public DateTime Date { get; set; }
        public string DocumentNumber { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int ActsCount { get; set; }
        public int AgreementsCount { get; set; }
        public string ParentDocumentUrl { get; set; }
        public string Type { get; set; }
        public int TypeId { get; set; }
    }
}