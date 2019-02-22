using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Services.Description;
using System.Web.UI;

namespace Models
{
    public class Parcel
    {
        public Parcel(City destination, City source, Dimension dimension, User Receiver, 
            User Sender, ICollection<Type> type) : this()
        {
            this.DestinationCity = destination;
            this.SourceCity = source;
            this.Dimensions = dimension;
            this.Receiver = Receiver;
            this.Sender = Sender;
            this.Type = type;
        }
        private Parcel()
        {
            this.Type = new HashSet<Type>(); 
        }

        [Key]
        public int ID { get; set; }
        
        public City DestinationCity { get; set; }
        
        public City SourceCity { get; set; }
        [Required]
        public Dimension Dimensions { get; set; }
        
        public User Receiver { get; set; }
        
        public User Sender { get; set; }
        public virtual ICollection<Type> Type { get; set; }
    }
}
