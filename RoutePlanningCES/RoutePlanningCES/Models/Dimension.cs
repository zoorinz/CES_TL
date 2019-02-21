using System.Web.Services.Description;
using Newtonsoft.Json;

namespace Models
{
    public class Dimension
    {
        public int ID { get; set; }
        public float width { get; set; }
        public float height { get; set; }
        public  float length { get; set; }

    }
}