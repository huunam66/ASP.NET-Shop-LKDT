using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom.Models
{
    public class SearchProductAdmin
    {
        public long type { get; set; }
        public String content { get; set; }
        public List<Product> result { get; set; }
    }
}