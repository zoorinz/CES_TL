namespace RoutePlanningCES.SharedConstants
{
    public class Constants
    {
        //Companies
        public static string CompanyTS = "Telstar";
        public static string CompanyOA = "Oceanic Airlines";
        public static string CompanyETC = "East Indian Trading company";

        //Prices
        public static float Baseprice = 3; //In $
        public static float RecommendedAddOn = 10; //In $
        public static float LiveAnmialsAddOn = 0.50F; //In percent
        public static float CautiousParcelsAddOn = 0.75F; // In percent
        public static float RefrigeratedGoodsAddOn = 0.10F; //In percent

        //Parcel Types
        public static string WeaponsType = "weapons";
        public static string RecommendedType = "recordedDelivery";
        public static string LiveAnimalsType = "liveAnimals";
        public static string CautiousParcelsType = "cautiousParcels";
        public static string RefrigeratedGoodsType = "refridgeratedGoods";
        public static string Empty = "";
    }
}