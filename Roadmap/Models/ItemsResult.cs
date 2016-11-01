using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roadmap.Models
{
    public class ItemsResult<T>
    {
        public List<T> Items { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int ItemsPerPage { get; set; }
        public int Page { get; set; }
        public int Total { get; set; }
    }
}