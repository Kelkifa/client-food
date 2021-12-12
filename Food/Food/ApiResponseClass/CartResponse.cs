using System;
using System.Collections.Generic;
using System.Text;

namespace Food.ApiResponseClass
{
    public class CartResponse : ApiResponse
    {
        public List<Cart> response {get; set;}   
    }
}
