using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom.Models
{
    public class Payment
    {
        public Bill_Infor bill_infor { get; set; }
        public List<PayProducts> products_cart { get; set; }
    }
}