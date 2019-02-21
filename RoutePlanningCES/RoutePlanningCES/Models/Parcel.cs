using System.ComponentModel.DataAnnotations;
using System.Web.UI;

namespace Models
{
    public class Parcel
    {
        [Key]
        public int ID { get; set; }
        public int sourceCity { get; set; }
        public int destinationCity { get; set; }
        public int sender { get; set; }
        public  int reciver { get; set; }
        public int dimension { get; set; }
    }
}