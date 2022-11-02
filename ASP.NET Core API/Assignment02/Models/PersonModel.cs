namespace Assignment02.Models
{
    public class PersonModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string BirthPlace { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public PersonModel(string firstName, string lastName, DateTime dateOfBirth, string gender, string birthPlace)
        {
            this.Id = Guid.NewGuid();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.BirthPlace = birthPlace;

        }
    }
}