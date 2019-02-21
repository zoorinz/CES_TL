using System.Collections.Generic;
using Models;
using RoutePlanningCES.SharedConstants;

namespace Service
{
    public class PriceCalculatorService
    {
        public int PriceCalculator(Parcel parcel, List<Edge> edges)
        {
            foreach (var edge in edges)
            {
                if (edge.Company.Name == Constants.CompanyTS)
                {
                    var segments = edge.Duration / (4 * 60);
                    var price = Constants.Baseprice;

                    
                }
            }
            return 1;
        }
    }
}