using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ASP.NET_MVC__2.Models
{
    public class PersonCreateModel
    {
        [DisplayName("First Name")]
        [Required(ErrorMessage ="First name is required!")]
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public String? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public String? PhoneNumber { get; set; }
        public String? BirthPlace { get; set; }
    }
}