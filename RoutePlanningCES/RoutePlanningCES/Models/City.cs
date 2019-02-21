using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class City
    {
        public City(CityNames name)
        {
            this.Name = name;
        }

        public CityNames Name { get; private set; }
        public uint CityId { get { return (uint)Name; } }

        [Key]
        public int CityID { get; set; }
        public string name { get; set; }

    }


     
}