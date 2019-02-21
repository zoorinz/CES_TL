using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoutePlanningCES.Models.DTOs;

namespace RoutePlanningCES.Controllers
{
    public class SearchResultController : Controller
    {
        public ActionResult SearchResult() //int SourceId, int DestinationId, List<int> ParcelTypes, int weight, int width, int height, int length
        {
            var cPath = new PathDTO()
            {
                Cities = new List<CityDTO>(),
                Duration = 42.1F,
                Price = 42.1F
            };

            var fPath = new PathDTO()
            {
                Cities = new List<CityDTO>
                {
                    new CityDTO
                    {
                        Id = 1,
                        Name = "Helsinki"
                    },
                    new CityDTO
                    {
                        Id = 12,
                        Name = "Rome"
                    }
                },
                Duration = new Random().Next(),
                Price = 42.2F
            };

            var bPath = new PathDTO()
            {
                Cities = new List<CityDTO>(),
                Duration = 42.3F,
                Price = 42.3F
            };

            var result = new SearchResultDTO
            {
                Cheapest = cPath,
                Fastest = fPath,
                Best = bPath
            };

            return PartialView(result);
        }
    }
}