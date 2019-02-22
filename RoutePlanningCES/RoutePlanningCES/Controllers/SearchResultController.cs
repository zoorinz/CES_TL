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
        public ActionResult SearchResult(int width, int height, int length, int weight, string sourceCity, string destinationCity, List<string> parcelType) //int SourceId, int DestinationId, List<int> ParcelTypes, int weight, int width, int height, int length
        //, int height, int length, int weight, string sourceCity, string destinationCity, List<string> parcelType
        {
            var cPath = new PathDTO()
            {
                Cities = new List<CityDTO>(),
                Duration = width,
                Price = width
            };

            var fPath = new PathDTO()
            {
                Cities = new List<CityDTO>
                {
                    new CityDTO
                    {
                        Id = 1,
                        Name = sourceCity
                    },
                    new CityDTO
                    {
                        Id = 12,
                        Name = destinationCity
                    }
                },
                Duration = width,
                Price = width
            };

            var bPath = new PathDTO()
            {
                Cities = new List<CityDTO>(),
                Duration = width,
                Price = width
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