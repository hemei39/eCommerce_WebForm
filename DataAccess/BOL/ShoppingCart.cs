using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess
{
    public partial class ShoppingCart
    {
        public string Username { get; set;}
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Single Discount { get; set; }

        public decimal SubTotal { get; set; }
    }
}