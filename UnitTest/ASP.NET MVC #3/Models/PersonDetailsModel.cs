using System.ComponentModel;

namespace ASP.NET_MVC__3.Models
{
    public class PersonDetailsModel
    {
        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        public int? Gender { get; set; }

        [DisplayName("Phone Number")]
        public string? PhoneNumber { get; set; }

        [DisplayName("Birth Place")]
        public string? BirthPlace { get; set; }
        // public int Age { get; set; }
        public int Age
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }
    }
}