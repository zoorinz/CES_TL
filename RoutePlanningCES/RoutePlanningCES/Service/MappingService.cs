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
                new City("Tanger"){ ID =0 }, //0
                new City("Marrakesh"){ ID =1 }, //1
                new City("Tunis"){ ID =2 }, //2
                new City("Sahara"){ ID =3 }, //3
                new City("Dakar"){ ID =4 }, //4
                new City("Sierra Leone"){ ID =5 }, //5
                new City("Timbuktu"){ ID =6 }, //6
                new City("Guldkysten"){ ID =7 }, //7
                new City("Slavekysten"){ ID =8 }, //8
                new City("Tripoli"){ ID =9 }, //9
                new City("Omdurman"){ ID =10 }, //10
                new City("Wadai"){ ID =11 }, //11
                new City("Dafur"){ ID =12 },//12
                new City("Congo"){ ID =13 },//13
                new City("Cairo"){ ID =14 },//14
                new City("Suakin"){ ID =15 },//15
                new City("Bahr El Ghazal"){ ID =16 },//16
                new City("Addis Abeba"){ ID =17 },//17
                new City("Kap Guardafui"){ ID =18 },//18
                new City("Victoria Søen"){ ID =19 },//19
                new City("Zanzibar"){ ID =20 },//20
                new City("Kabalo"){ ID =21 },//21
                new City("Luanda"){ ID =22 },//22
                new City("Hvalbugten"){ ID =23 },//23
                new City("Victoria Faldene"){ ID =24 },//24
                new City("Mocambique"){ ID =25 },//25
                new City("Dragebjerget"){ ID =26 },//26
                new City("Kapstaden"){ ID =27 },//27
                new City("De Kanariske Øer"){ ID =28 },//28
                new City("ST. Helena"){ ID =29 },//29
                new City("Kap St. Marie"){ ID =30 },//30
                new City("Amatave"){ ID =31 },//31
            };
        }

        public static List<Type> GetParcelTypes()
        {
            return new List<Type>()
            {
                new Type("Recommended parcels"),
                new Type("Cautious parcels"),
                new Type("Refridgerated goods"),
                new Type("Livestock"),
                new Type("Weapons"),
            };
        }

        public static List<Edge> GetEdges(List<City> cities)
        {
            List<Type> allowedTypes = new List<Type>()
            {
                new Type("recordedDelivery"),
                new Type("cautiousParcels"),
                new Type("refridgeratedGoods"),
                new Type("liveAnimals")
            };
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