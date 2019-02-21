using System.Collections.Generic;
using Models;

namespace Service
{
    public class MappingService : IMappingService
    {
        public List<City> GetCities()
        {
            return new List<City>()
            {
                new City("Tanger"),
                new City("Marrakesh"),
                new City("Tunis"),
                new City("Sahara"),
                new City("Dakar"),
                new City("Sierra Leone"),
                new City("Timbuktu"),
                new City("Guldkysten"),
                new City("Slavekysten"),
                new City("Tripoli"),
                new City("Omdurman"),
                new City("Wadai"),
                new City("Dafur"),
                new City("Congo"),
                new City("Cairo"),
                new City("Suakin"),
                new City("Bahr El Ghazal"),
                new City("Addis Abeba"),
                new City("Kap Guardafui"),
                new City("Victoria Søen"),
                new City("Zanzibar"),
                new City("Kabalo"),
                new City("Luanda"),
                new City("Hvalbugten"),
                new City("Victoria Faldene"),
                new City("Mocambique"),
                new City("Dragebjerget"),
                new City("Kapstaden"),
                new City("De Kanariske Øer"),
                new City("ST. Helena"),
                new City("Kap St. Marie"),
                new City("Amatave"),
            };
        }
    }
}