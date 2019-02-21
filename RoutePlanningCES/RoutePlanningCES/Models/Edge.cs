using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Edge
    {
        public int ID { get; set; }
        public int sourceCity { get; set; }
        public int destinationCity { get; set; }
        public float duration { get; set; }
        public float price { get; set; }
        public float maxWeight { get; set; }
        public  int company { get; set; }

    }
}