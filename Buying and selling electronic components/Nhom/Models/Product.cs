using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom.Models
{
    public class Product
    {
        public long ID { get; set; }
        public String Name { get; set; }
        public decimal Price { get; set; }
        public String Status { get; set; }
        public String Attribute { get; set; }
        public long ID_Type { get; set; }
        public String Product_Type { get; set; }
        public int Count { get; set; }
        public String Code { get; set; }
        public List<ProductDetails> Product_Details { get; set; }
        public List<Assest> Assests { get; set; }
    }
}