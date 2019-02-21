using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoutePlanningCES.Models.DTOs
{
    public class CityDTO
    {
        public int Id{ get; set; }
        public String Name{ get; set; }

        public override String ToString()
        {
            return Name;
        }
    }
}