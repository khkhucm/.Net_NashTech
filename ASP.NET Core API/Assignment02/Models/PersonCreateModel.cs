using System.ComponentModel.DataAnnotations;

namespace Assignment02.Models
{
    public class PersonCreateModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string BirthPlace { get; set; }
    }
}
