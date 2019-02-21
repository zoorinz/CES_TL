using System.ComponentModel.DataAnnotations;
using System.Web.Services.Description;

namespace Models
{
    public class Type
    {
        public Type(string name)
        {
            this.Name = name;
        }

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}