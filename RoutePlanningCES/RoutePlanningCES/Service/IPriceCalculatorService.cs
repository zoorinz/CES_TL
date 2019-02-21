using System.Collections.Generic;
using Models;

namespace Service
{
    public interface IPriceCalculatorService
    {
        List<Edge> EdgePriceCalculator(Parcel parcel, List<Edge> edges);
    }
}