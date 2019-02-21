using System.Collections.Generic;
using Models;

namespace Service
{
    public interface IMappingService
    {
        List<City> GetCities();
        List<Edge> GetEdges();
    }
}