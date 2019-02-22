using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;
using Models;
using RoutePlanningCES.Models.DTOs;
using Service;
using Edge = Models.Edge;

namespace RoutePlanningCES.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            var cities = MappingService.GetCities();
            var dtoCities = new List<CityDTO>();
            foreach (var city in cities)
            {
                dtoCities.Add(new CityDTO()
                {
                    Id = city.ID,
                    Name = city.Name
                });
            }

            var parcelTypes = MappingService.GetParcelTypes();
            var dtoParcelTypes = new List<ParcelTypeDTO>();
            foreach (var parcelType in parcelTypes)
            {
                dtoParcelTypes.Add(new ParcelTypeDTO()
                {
                    Id = parcelType.ID,
                    Name = parcelType.Name
                });
            }

            var model = new HomeDTO
            {
                SourceCitites = dtoCities,
                DestinationCitites = dtoCities,
                ParcelTypes = dtoParcelTypes
            };
            return View(model);
        }
    }
}