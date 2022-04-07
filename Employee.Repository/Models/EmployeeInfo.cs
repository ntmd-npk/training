using System.ComponentModel.DataAnnotations;

namespace Employee.Repository.Models
{
    public class EmployeeInfo
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Birth { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
