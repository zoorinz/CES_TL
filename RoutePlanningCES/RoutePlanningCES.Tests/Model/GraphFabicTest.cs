
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Collections.Generic;

namespace RoutePlanningCES.Tests.Model
{
    [TestClass]
    public class GraphFabicTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            IList<City> cities = new List<City>();
            IList<Edge> edges = new List<Edge>();
            for (int i = 0; i < 4; i++)
            {
                City city = new City(i.ToString());
                city.ID = i;
                cities.Add(city);
            }

            Company company = new Company("company");
            IList<Type> allowedTypes = new List<Type>();
            allowedTypes.Add(new Type("type"));
            edges.Add(new Edge(3.0f, 3.0f, 3.0f, company, cities[0], cities[1], allowedTypes));
            edges.Add(new Edge(4.0f, 4.0f, 4.0f, company, cities[1], cities[2], allowedTypes));
            edges.Add(new Edge(2.0f, 2.0f, 2.0f, company, cities[2], cities[3], allowedTypes));
            edges.Add(new Edge(1.0f, 1.0f, 1.0f, company, cities[1], cities[3], allowedTypes));
            var graph = GraphFabric.CreateGraphPrice(cities, edges, "description");
            int j = 3 + 3;
        }
    }
}
