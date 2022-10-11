using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ASP.NET_MVC__2.Models
{
    public class PersonUpdateModel
    {
        [Required, DisplayName("First Name")]
        public String? FirstName { get; set; }
        [Required, DisplayName("Last Name")]
        public String? LastName { get; set; }
        public String? PhoneNumber { get; set; }
        public String? BirthPlace { get; set; }
    }
}