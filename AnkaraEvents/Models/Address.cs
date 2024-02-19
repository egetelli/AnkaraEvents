using System.ComponentModel.DataAnnotations;

namespace AnkaraEvents.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }

    }
}
