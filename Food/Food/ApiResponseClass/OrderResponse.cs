using System;
using System.Collections.Generic;
using System.Text;

namespace Food.ApiResponseClass
{
    public class OrderResponse : ApiResponse
    {
        public List<Order> response { get; set; }
    }
}
