namespace ASP.NET_MVC.DataAccess
{
    public class Person
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String PhoneNumber { get; set; }
        public String BirthPlace { get; set; }

        public int Age
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public bool IsGraduated { get; set; }

        public Person(String firstName, String lastName, String gender, DateTime dateOfBirth, String phoneNumber, String birthPlace, bool isGraduated)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.DateOfBirth = dateOfBirth;
            this.PhoneNumber = phoneNumber;
            this.BirthPlace = birthPlace;
            this.IsGraduated = isGraduated;
        }
    }
}