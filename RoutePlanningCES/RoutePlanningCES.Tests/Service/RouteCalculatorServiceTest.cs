using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;
using System.Linq;
using System.Collections.Generic;

namespace RoutePlanningCES.Tests.Service
{
    [TestClass]
    public class RouteCalculatorServiceTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var graph = new Graph<int, string>();

            graph.AddNode(1);
            graph.AddNode(2);
            graph.AddNode(3);
            graph.AddNode(4);

            graph.Connect(1, 2, 5, ""); 
            graph.Connect(2, 3, 2, ""); 
            graph.Connect(3, 4, 4, ""); 
            graph.Connect(2, 4, 5, ""); 


            ShortestPathResult result = graph.Dijkstra(1, 4); //result contains the shortest path

            List<uint> path = result.GetPath().ToList();

            int i = 3 + 3;
        }
    }
}
