using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dijkstra.NET.Graph;
using Models;
using Service;

namespace Models
{
    public class GraphFabric
    {
        public static Graph<City, string> CreateGraphPrice(IList<City> vertices, IList<Edge> edges, string costDescription, Parcel parcel)
        {
            edges = PriceCalculatorService.EdgePriceCalculator(parcel, edges.ToList());

            Graph<City, string> graph = new Graph<City, string>();
            AddVertices(graph, vertices);

            foreach (var edge in edges)
                graph.Connect(1, 2, (int)edge.Price, costDescription);

            return graph;
        }

        public static Graph<City, string> CreateGraphTime(IList<City> vertices, IList<Edge> edges, string costDescription)
        {
            Graph<City, string> graph = new Graph<City, string>();
            AddVertices(graph, vertices);

            foreach (var edge in edges)
                graph.Connect(1, 2, (int)edge.Duration, costDescription);

            return graph;
        }

        private static Graph<City, string> AddVertices(Graph<City, string> graph, IList<City> vertices)
        {
            foreach (var vertice in vertices)
                graph.AddNode(vertice);

            return graph;
        }
    }
}