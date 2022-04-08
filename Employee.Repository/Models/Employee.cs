using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class Employee : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Birth { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
