using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models
{
    public class City
    {
        public City(string name) : this()
        {
            this.Name = name;
        }

        private City() { }

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    } 
}