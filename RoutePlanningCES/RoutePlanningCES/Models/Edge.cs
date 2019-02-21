using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Edge
    {
        public int ID { get; set; }
        public int SourceCity { get; set; }
        public int DestinationCity { get; set; }
        public float Duration { get; set; }
        public float Price { get; set; }
        public float MaxWeight { get; set; }
        public  int Company { get; set; }

    }
}