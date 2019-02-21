namespace RoutePlanningCES.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Service;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.TLContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAL.TLContext context)
        {
            var cities = MappingService.GetCities();
            cities.ForEach(city => context.City.AddOrUpdate(city));

            var edges = MappingService.GetEdges();
            edges.ForEach(edge => context.Edge.AddOrUpdate(edge));

            context.SaveChangesAsync();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
