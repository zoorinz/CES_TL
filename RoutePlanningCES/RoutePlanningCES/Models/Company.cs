using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Company
    {
        public Company(string name) : this()
        {
            this.Name = name;
        }

        private Company() { }

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

    }
}