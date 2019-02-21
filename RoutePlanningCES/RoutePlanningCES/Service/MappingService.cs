using System.Collections.Generic;
using System.Net;
using Models;
using RoutePlanningCES.SharedConstants;

namespace Service
{
    public class MappingService 
    {
        public static List<City> GetCities()
        {
            return new List<City>()
            {
                new City("Tanger"), //0
                new City("Marrakesh"), //1
                new City("Tunis"), //2
                new City("Sahara"), //3
                new City("Dakar"), //4
                new City("Sierra Leone"), //5
                new City("Timbuktu"), //6
                new City("Guldkysten"), //7
                new City("Slavekysten"), //8
                new City("Tripoli"), //9
                new City("Omdurman"), //10
                new City("Wadai"), //11
                new City("Dafur"),//12
                new City("Congo"),//13
                new City("Cairo"),//14
                new City("Suakin"),//15
                new City("Bahr El Ghazal"),//16
                new City("Addis Abeba"),//17
                new City("Kap Guardafui"),//18
                new City("Victoria Søen"),//19
                new City("Zanzibar"),//20
                new City("Kabalo"),//21
                new City("Luanda"),//22
                new City("Hvalbugten"),//23
                new City("Victoria Faldene"),//24
                new City("Mocambique"),//25
                new City("Dragebjerget"),//26
                new City("Kapstaden"),//27
                new City("De Kanariske Øer"),//28
                new City("ST. Helena"),//29
                new City("Kap St. Marie"),//30
                new City("Amatave"),//31
            };
        }

        public static List<Edge> GetEdges()
        {
            List<Type> allowedTypes = new List<Type>()
            {
                new Type("recordedDelivery"),
                new Type("cautiousParcels"),
                new Type("refridgeratedGoods"),
                new Type("liveAnimals"),
                new Type("")
            };
            var cities = GetCities();
            List<Edge> edges = new List<Edge>()
            {
                new Edge(480, 6, 40, cities[0], cities[1]),
                new Edge(1200, 15, 40, cities[0], cities[2]),
                new Edge(1200, 15, 40, cities[0], cities[3]),
                new Edge(1200, 15, 40, cities[1], cities[3]),
                new Edge(720, 9, 40, cities[2], cities[9]),
                new Edge(1920, 24, 40, cities[1], cities[4]),
                new Edge(1440, 18, 40, cities[9], cities[10]),
                new Edge(960, 12, 40, cities[10], cities[14]),
                new Edge(960, 12, 40, cities[4], cities[5]),
                new Edge(1200, 15, 40, cities[5], cities[6]),
                new Edge(960, 12, 40, cities[6], cities[7]),
                new Edge(1200, 15, 40, cities[5], cities[7]),
                new Edge(1200, 15, 40, cities[6], cities[8]),
                new Edge(1920, 24, 40, cities[3], cities[12]),
                new Edge(720, 9, 40, cities[10], cities[12]),
                new Edge(960, 12, 40, cities[11], cities[12]),
                new Edge(1680, 21, 40, cities[8], cities[11]),
                new Edge(1680, 21, 40, cities[8], cities[12]),
                new Edge(1200, 15, 40, cities[8], cities[13]),
                new Edge(1440, 18, 40, cities[12], cities[13]),
                new Edge(960, 12, 40, cities[12], cities[15]),
                new Edge(480, 6, 40, cities[12], cities[16]),
                new Edge(480, 6, 40, cities[16], cities[19]),
                new Edge(720, 9, 40, cities[15], cities[17]),
                new Edge(720, 9, 40, cities[17], cities[18]),
                new Edge(720, 9, 40, cities[17], cities[19]),
                new Edge(1440, 18, 40, cities[18], cities[20]),
                new Edge(960, 12, 40, cities[19], cities[21]),
                new Edge(720, 9, 40, cities[13], cities[22]),
                new Edge(960, 12, 40, cities[21], cities[22]),
                new Edge(1440, 18, 40, cities[19], cities[25]),
                new Edge(720, 9, 40, cities[20], cities[25]),
                new Edge(1200, 15, 40, cities[19], cities[20]),
                new Edge(2400, 30, 40, cities[22], cities[25]),
                new Edge(1200, 15, 40, cities[24], cities[25]),
                new Edge(2640, 33, 40, cities[22], cities[24]),
                new Edge(1200, 15, 40, cities[25], cities[26]),
                new Edge(720, 9, 40, cities[24], cities[26]),
                new Edge(960, 12, 40, cities[25], cities[26]),
                new Edge(960, 12, 40, cities[23], cities[24]),
                new Edge(960, 12, 40, cities[23], cities[27]),
            };
            edges.ForEach(e => e.Company = new Company("TL"));
            edges.ForEach(e => e.Type = allowedTypes);
            return edges;
        }
    }
}