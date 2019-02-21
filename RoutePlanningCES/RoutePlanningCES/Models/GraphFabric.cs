using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dijkstra.NET.Graph;
using Models;

namespace RoutePlanningCES.Models
{
    public class GraphFabric
    {
        public static Graph<City, string> createGraphPrice(IList<City> vertices, IList<Edge> edges, string costDescription)
        {
            Graph<City, string> graph = new Graph<City, string>();
            addVertices(graph, vertices);

            foreach (var edge in edges)
            {
                graph.Connect((uint)edge.SourceCityRefId, (uint)edge.DestinationCityRefId, (int)edge.price, costDescription);
            }
            return graph;
        }

        public static Graph<City, string> createGraphTime(IList<City> vertices, IList<Edge> edges, string costDescription)
        {
            Graph<City, string> graph = new Graph<City, string>();
            addVertices(graph, vertices);

            foreach (var edge in edges)
            {
                graph.Connect((uint)edge.SourceCityRefId, (uint)edge.DestinationCityRefId, (int)edge.duration, costDescription);
            }
            return graph;
        }

        private static Graph<City, string> addVertices(Graph<City, string> graph, IList<City> vertices)
        {
            foreach (var vertice in vertices)
            {
                graph.AddNode(vertice);
            }
            return graph;
        }
    }
}