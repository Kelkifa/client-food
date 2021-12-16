using System;
using System.Collections.Generic;
using System.Text;

namespace Food
{
    public class Cart
    {
        public string _id { get; set; }

        public Food food { get; set; }
        public int soLuong { get; set; }

        public bool isChecked { get; set; } = false;

    }
}
