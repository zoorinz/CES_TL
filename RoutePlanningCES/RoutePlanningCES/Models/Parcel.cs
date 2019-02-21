using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Services.Description;
using System.Web.UI;

namespace Models
{
    public class Parcel
    {
        public Parcel()
        {
            this.Type = new HashSet<Type>(); 
        }
        [Key]
        public int Id { get; set; }
        public City DestinationCity { get; set; }
        public City SourceCity { get; set; }
        public Dimension Dimensions { get; set; }
        public User Reciver { get; set; }
        public User Sender { get; set; }
        public virtual ICollection<Type> Type { get; set; }
    }
}
