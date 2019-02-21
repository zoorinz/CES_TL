using System.Data.Entity;

namespace Models.Database
{
 public class DBContext : DbContext {
            public virtual DbSet<City> City { get; set; }
            public virtual DbSet<Company> Company { get; set; }
            public virtual DbSet<Dimension> Dimension { get; set; }
            public virtual DbSet<Edge> Edge { get; set; }
            public virtual DbSet<Parcel> Parcels { get; set; }
            public virtual DbSet<Type> Type { get; set; }
            public virtual DbSet<User> User { get; set; }
    }
}