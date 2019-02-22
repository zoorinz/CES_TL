using Dijkstra.NET.ShortestPath;
using Dijkstra.NET.Graph;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
namespace Service
{
    public class RouteCalculatorService
    {
        public RouteCalculatorService(Graph<City, string> graph)
        {
            this.Graph = graph;
        }

        public Graph<City, string> Graph { get; private set; }

        public ShortestPathResult CalculateShortestPath( City source, City destination)
        {
            ShortestPathResult result = Graph.Dijkstra((uint)source.ID, (uint)destination.ID);

            return result;
        }

        public List<City> GetCityPath(ShortestPathResult result)
        {
            List<City> cities = new List<City>();
            foreach (var node in result.GetPath())
            {
                cities.Add(Graph[node].Item);
            }
            return cities;
        }
    }
}