using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DAL;
using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;
using Models;
using RoutePlanningCES.Models.DTOs;
using Service;
using Edge = Models.Edge;
using Type = Models.Type;

namespace RoutePlanningCES.Controllers
{
    public class SearchResultController : Controller
    {
        public ActionResult SearchResult(int width, int height, int length, int weight, string sourceCity, string destinationCity, string parcelType)
        {
            IList<City> cities;// = MappingService.GetCities();
            using (var context = new TLContext())
            {
                cities = context.GetCities();
            }
            var destination = new City(destinationCity);
            destination.ID = GetCityID(cities, destination.Name);
            var source = new City(sourceCity);
            source.ID = GetCityID(cities, source.Name);

            var dimensions = new Dimension(width, height, length);
            var parcelTypes = GetParcelTypes(parcelType.Split(',').ToList());
            var parcel = new Parcel(destination, source, dimensions, null, null, parcelTypes);
            
            var result = ClickCalculate(parcel, source, destination);

            return PartialView(result);
        }

        private int GetCityID(IList<City> cities, string cityName)
        {
            foreach (var city in cities)
            {
                if (city.Name.Equals(cityName))
                {
                    return city.ID;
                }
            }
            throw new ArgumentException("There was no city with name: " + cityName);
        }

        private static List<Type> GetParcelTypes(List<string> parcelType)
        {
            var parcelTypes = new List<Type>();
            foreach (var type in parcelType)
            {
                parcelTypes.Add(new Type(type));
            }

            return parcelTypes;
        }

        public SearchResultDTO ClickCalculate(Parcel parcel, City source, City destination)
        {
            IList<Edge> edges;
            IList<City> cities;
            using (var context = new TLContext())
            {
                edges = context.GetAllEdges();
                cities = context.GetCities();
            }
            Graph<City, string> graphPrice = GraphFabric.CreateGraphPrice(cities, edges, "priceCost", parcel);
            Graph<City, string> graphTime = GraphFabric.CreateGraphTime(cities, edges, "timeCost");

            RouteCalculatorService routeCalcPrice = new RouteCalculatorService(graphPrice);
            ShortestPathResult resultPrice = routeCalcPrice.CalculateShortestPath(source, destination);
            List<City> pathPrice = routeCalcPrice.GetCityPath(resultPrice);

            RouteCalculatorService routeCalcTime = new RouteCalculatorService(graphTime);
            ShortestPathResult resultTime = routeCalcPrice.CalculateShortestPath(source, destination);
            List<City> pathTime = routeCalcTime.GetCityPath(resultTime);

            this.SaveParcel(parcel);

            var cPath = new PathDTO()
            {
                Cities = ReturnCityDtos(pathPrice),
                Duration = 42,
                Price = resultPrice.Distance
            };

            var fPath = new PathDTO()
            {
                Cities = ReturnCityDtos(pathTime),
                Duration = resultTime.Distance,
                Price = 42
            };

            var bPath = new PathDTO()
            {
                Cities = new List<CityDTO>(),
                Duration = 42,
                Price = 42
            };

             return new SearchResultDTO
            {
                Cheapest = cPath,
                Fastest = fPath,
                Best = bPath
            };
        }

        private void SaveParcel(Parcel parcel)
        {
            using (var context = new TLContext())
            {
                context.Parcels.Add(parcel);
                context.SaveChangesAsync();
            }
        }

        private List<CityDTO> ReturnCityDtos(List<City> cities)
        {
            var dtoCitites = new List<CityDTO>();
            foreach (var city in cities)
            {
                dtoCitites.Add(new CityDTO()
                {
                    Id = city.ID,
                    Name = city.Name
                });
            }

            return dtoCitites;
        }
    }
}