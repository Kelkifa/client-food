using System;
using System.Collections.Generic;
using System.Text;

namespace Food
{
    public class Food
    {   
        public string _id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public string production { get; set; }
        public int cost { get; set; }
        public string unit { get; set; }
        public string minMass { get; set; }
        public string maxMass { get; set; }
    }
}
