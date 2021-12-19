using System;
using System.Collections.Generic;
using System.Text;

namespace Food
{
    public class Order
    {
        public User user {get;set;}
        public List<Cart> cartList { get; set; }

        public string address { get; set; }
        public string sdt { get; set; }

        public bool isAccept { get; set; }
        public string updatedAt { get; set; }
        public string createdAt { get; set; }
    }
}
