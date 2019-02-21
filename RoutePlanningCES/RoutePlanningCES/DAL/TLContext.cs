using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Models;

namespace DAL
{
 public class TLContext : DbContext {
        public TLContext() : base("name=TLContext")
        {
            
        }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Dimension> Dimension { get; set; }
        public virtual DbSet<Edge> Edge { get; set; }
        public virtual DbSet<Parcel> Parcels { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public List<Edge> GetAllEdges()
        {
            List<Edge> edges;
            using (var contex = new TLContext())
            {
                var query = contex.Edge.Include(edge =>  edge.SourceCity)
                    .Include(edge => edge.DestinationCity)
                    .Include(edge => edge.Company)
                    .Include(edge => edge.Type);
                edges = query.ToListAsync().Result;
            }
            return edges;
        }
    }
}