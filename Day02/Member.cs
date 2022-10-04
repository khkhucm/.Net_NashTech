namespace Day02
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }
    public class Member
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Gender Gender { get; set; }
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
        public Member(String firstName, String lastName, Gender gender, DateTime dateOfBirth, String phoneNumber, String birthPlace, bool isGraduated)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.DateOfBirth = dateOfBirth;
            this.PhoneNumber = phoneNumber;
            this.BirthPlace = birthPlace;
            this.IsGraduated = isGraduated;
        }
        public string Info
        {
            get
            {
                return string.Format($"First Name: {FirstName}" + Environment.NewLine +
                $"Last Name: {LastName}" + Environment.NewLine +
                $"Gender: {Gender}" + Environment.NewLine +
                $"Date Of Birth: {DateOfBirth}" + Environment.NewLine +
                $"Phone Number: {PhoneNumber}" + Environment.NewLine +
                $"Birth Place: {BirthPlace}" + Environment.NewLine +
                $"Age: {Age}" + Environment.NewLine +
                $"Is Graduated: {IsGraduated}" + Environment.NewLine +
                $"--------------------------------------------");
            }
        }
    }

}