using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoutePlanningCES.Models.DTOs
{
    public class HomeDTO
    {
        public List<CityDTO> SourceCitites { get; set; }
        public List<CityDTO> DestinationCitites { get; set; }

        public List<Type> ParcelTypes { get; set; }
    }
}