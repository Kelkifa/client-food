using System;
using System.Collections.Generic;
using System.Text;

namespace Food
{
    public class User
    {
        public string _id { get; set; }
        public string fullname { get; set; }

        public bool isAdmin { get; set; }
        public string address { get; set; }
        public string sdt { get; set; }
        public string username { get; set; }
    }
}
