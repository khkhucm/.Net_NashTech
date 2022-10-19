using System.ComponentModel.DataAnnotations;

namespace Assignment01.Models
{
    public class Student : BaseEntity<int>
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
    }
}