using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom.Models
{
    public class ProductDetails
    {
        public long ID { get; set; }
        public long ID_Product { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
    }
}