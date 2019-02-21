using System.Collections.Generic;
using Models;

namespace Service
{
    public class PriceCalculatorService
    {
        public int PriceCalculator(Parcel parcel, List<Edge> edges)
        {
            foreach (var edge in edges)
            {
                if (edge.Company == 1)
                {
                    var segments = edge.Duration / (4 * 60);
                }
            }
            return 1;
        }
    }
}