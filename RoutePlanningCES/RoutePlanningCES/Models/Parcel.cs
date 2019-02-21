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
        public int Dimension { get; set; }


        [ForeignKey("DestinationCity"), Required]
        public int DestinationCityRefId { get; set; }
        public City DestinationCity { get; set; }

        [ForeignKey("SourceCity"), Required]
        public int SourceCityRefId { get; set; }
        public City SourceCity { get; set; }

        [ForeignKey("Dimensions"), Required]
        public int DimensionRefId { get; set; }
        public City Dimensions { get; set; }

        [ForeignKey("Recivers"), Required]
        public int ReciverRefId { get; set; }
        public User Reciver { get; set; }

        [ForeignKey("Senders"), Required]
        public int SenderRefId { get; set; }
        public User Sender { get; set; }

        public virtual ICollection<Type> Type { get; set; }
    }
}
