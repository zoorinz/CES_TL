using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using Models;

namespace DAL
{
    public class TLInitializer
    {
        private void PopulateCity(TLContext context)
        {
            List<City> cities = new List<City>();
            cities.Add(new City("test"));
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

        public void PopulateDatabase()
        {
            using (var db = new TLContext()) {
                this.PopulateCity(db);
                this.PopulateEdge(db);
                this.PopulateType(db);
            }
        }
    }
}