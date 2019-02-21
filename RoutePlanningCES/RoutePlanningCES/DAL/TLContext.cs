using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Models;

namespace DAL
{
 public class TLContext : DbContext {
        public TLContext() : base("TLContext")
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
    }
}