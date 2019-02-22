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

        public void ClickCalculate(Parcel parcel, City source, City destination)
        {
            IList<Edge> edges;
            IList<City> cities;
            using (var context = new TLContext())
            {
                edges = context.GetAllEdges();
                cities = context.City.ToList();
            }
            Graph<City, string> graphPrice = GraphFabric.CreateGraphPrice(cities, edges, "priceCost", parcel);
            Graph<City, string> graphTime = GraphFabric.CreateGraphTime(cities, edges, "timeCost");

            RouteCalculatorService routeCalcPrice = new RouteCalculatorService(graphPrice);
            ShortestPathResult resultPrice = routeCalcPrice.CalculateShortestPath(source, destination);
            List<City> pathPrice = routeCalcPrice.GetCityPath(resultPrice);

            RouteCalculatorService routeCalcTime = new RouteCalculatorService(graphTime);
            ShortestPathResult resultTime = routeCalcPrice.CalculateShortestPath(source, destination);
            List<City> pathTime = routeCalcTime.GetCityPath(resultTime);

        }
    }
}