using System.ComponentModel.DataAnnotations;
using System.Web.Services.Description;

namespace Models
{
    public class Type
    {
        [Key]
        public int ID { get; set; }
        public  string name { get; set; }
    }
}