using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoutePlanningCES.Models.DTOs
{
    public class SearchResultDTO
    {
        public PathDTO Cheapest { get; set; }
        public PathDTO Fastest { get; set; }
        public PathDTO Best { get; set; }
    }

    public class PathDTO
    {
        public float Duration { get; set; }
        public float Price { get; set; }
        public List<CityDTO> Cities { get; set; }
    }
   
}