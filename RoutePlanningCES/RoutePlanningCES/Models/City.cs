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
        public City(string name)
        {
            this.Name = name;
        }

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        [ForeignKey("DestinationCity"), Required]
        public int DestinationCityRefId { get; set; }
        public Parcel DestinationCity { get; set; }

    }


     
}