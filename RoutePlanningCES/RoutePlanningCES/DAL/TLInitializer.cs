using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using Models;

namespace RoutePlanningCES.DAL
{
    public class TLInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TLContext>
    {
        protected override void Seed(TLContext context)
        {
            PopulateCity(context);
            PopulateEdge(context);
            PopulateType(context);
        }

        private void PopulateCity(TLContext context)
        {
            List<City> cities = new List<City>();
            cities.ForEach(c => context.City.Add(c));
            context.SaveChanges();
        }

        private void PopulateEdge(TLContext context)
        {
            List<Edge> edges = new List<Edge>();
            edges.ForEach(e => context.Edge.Add(e));
            context.SaveChanges();
        }

        private void PopulateType(TLContext context)
        {
            List<Models.Type> edges = new List<Models.Type>();
            edges.ForEach(t => context.Type.Add(t));
            context.SaveChanges();
        }
    }
}