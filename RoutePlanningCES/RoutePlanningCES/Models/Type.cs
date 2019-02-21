using System.ComponentModel.DataAnnotations;
using System.Web.Services.Description;
using System.Collections.Generic;
using Models;
namespace Models
{
    public class Type
    {
        public Type(string name)
        {
            this.Name = name;
            this.Parcel = new HashSet<Parcel>();
        }

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Parcel> Parcel { get; set; }
    }
}