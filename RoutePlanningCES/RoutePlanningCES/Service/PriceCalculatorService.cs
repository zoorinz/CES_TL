using System.Collections.Generic;
using System.Diagnostics;
using Models;
using RoutePlanningCES.SharedConstants;

namespace Service
{
    public class PriceCalculatorService : IPriceCalculatorService
    {
        public List<Edge> EdgePriceCalculator(Parcel parcel, List<Edge> edges)
        {
            foreach (var edge in edges)
            {
                if (edge.Company.Name == Constants.CompanyTS)
                {
                    var segments = edge.Duration / (4 * 60);
                    var segmentPrice = Constants.Baseprice;

                    foreach (var type in parcel.Type)
                    {
                        if (type.Name == Constants.RecommendedType)
                            segmentPrice += Constants.RecommendedAddOn;
                        if (type.Name == Constants.LiveAnimalsType)
                            segmentPrice += Constants.Baseprice * Constants.LiveAnmialsAddOn;
                        if (type.Name == Constants.CautiousParcelsType)
                            segmentPrice += Constants.Baseprice * Constants.CautiousParcelsAddOn;
                        if (type.Name == Constants.RefrigeratedGoodsType)
                            segmentPrice += Constants.Baseprice * Constants.RefrigeratedGoodsAddOn;
                    }

                    float priceEdge = segments * segmentPrice;
                    edge.Price = priceEdge;
                }
            }
            return edges;
        }

        public float RoutePriceCalculator(List<Edge> edges)
        {
            var priceRoute = 0F;

            foreach (var edge in edges)
            {
                priceRoute += edge.Price;
            }

            return priceRoute;
        }
    }
}