using System.Collections.Generic;
using Models;

namespace Service
{
    public interface IPriceCalculatorService
    {
        int PriceCalculator(Parcel parcel, List<Edge> edges);
    }
}