namespace ASP.NET_MVC__2.Models
{
    public class PersonModel
    {
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public String? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public String? PhoneNumber { get; set; }
        public String? BirthPlace { get; set; }
        public bool IsGraduated { get; set; }

        public int Age
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth?.Year ?? 0;
            }
        }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}