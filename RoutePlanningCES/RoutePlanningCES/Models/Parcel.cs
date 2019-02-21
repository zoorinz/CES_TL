using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.UI;

namespace Models
{
    public class Parcel
    {
        [Key]
        public int ParcelId { get; set; }
        public int SourceCity { get; set; }
        public int DestinationCity { get; set; }
        public int Sender { get; set; }
        public int Reciver { get; set; }
        public int Dimension { get; set; }

        public ICollection<User> Users { get; set; }
    }
}