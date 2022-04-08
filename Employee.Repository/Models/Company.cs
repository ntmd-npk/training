using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class Company : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
    }
}
