using System.ComponentModel.DataAnnotations;
using System.Web.Services.Description;
using Newtonsoft.Json;

namespace Models
{
    public class Dimension
    {
        public Dimension(float width, float height, float length) : this()
        {
            this.Width = width;
            this.Height = height;
            this.Length = length;
        }

        private Dimension() { }
        [Key]
        public int ID { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public  float Length { get; set; }

    }
}