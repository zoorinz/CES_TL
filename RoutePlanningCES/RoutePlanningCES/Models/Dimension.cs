using System.ComponentModel.DataAnnotations;
using System.Web.Services.Description;
using Newtonsoft.Json;

namespace Models
{
    public class Dimension
    {
        [Key]
        public int ID { get; set; }
        public float width { get; set; }
        public float height { get; set; }
        public  float length { get; set; }

    }
}