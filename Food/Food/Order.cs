using System;
using System.Collections.Generic;
using System.Text;

namespace Food
{
    public class Order
    {
        public Auth user { get; set; }
        public List<Cart> cartList { get; set; }

        public string address { get; set; }
        public string sdt { get; set; }
    }
}
