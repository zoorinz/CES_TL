using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Models;
using System.Linq;

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
        public virtual DbSet<ExposedConnection> ExposedConnection { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public IList<City> GetCities()
        {
            using (var contex = new TLContext())
            {
                return contex.City.ToList().GetRange(0,32); 
            }
        }
        public IList<Edge> GetAllEdges()
        {

            using (var context = new TLContext())
            {
                var query = this.GetAllEdgesQuery(context);
                return query.ToListAsync().Result;
            }
        }

     public IQueryable<Edge> GetAllEdgesQuery(TLContext context)
     {
            return context.Edge.Include(edge => edge.SourceCity)
                .Include(edge => edge.DestinationCity)
                .Include(edge => edge.Company)
                .Include(edge => edge.Type);
            
     }

     public User GetUser(string username, string password)
        {
            User user;
            using (var context = new TLContext())
            {
                user = (from u in context.User
                       where u.Username == username && u.Password == password
                       select u).FirstOrDefault<User>(); 
            }
            return user;
        }
    }
}