using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI;

namespace Models
{
    public class Parcel
    {
        [Key]
        public int ParcelId { get; set; }
        public int Sender { get; set; }
        public int Reciver { get; set; }
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
        public User Recivers { get; set; }

        [ForeignKey("Senders"), Required]
        public int SenderRefId { get; set; }
        public User Senders { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
