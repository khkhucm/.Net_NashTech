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
        public bool IsGraduated { get; set; }
        public Member(String FirstName, String LastName, Gender Gender, DateTime DateOfBirth, String PhoneNumber, String BirthPlace, bool IsGraduated)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Gender = Gender;
            this.DateOfBirth = DateOfBirth;
            this.PhoneNumber = PhoneNumber;
            this.BirthPlace = BirthPlace;
            this.IsGraduated = IsGraduated;
        }

        public string GetInfo
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
                $"Is Graduated: {IsGraduated}" + Environment.NewLine+
                $"--------------------------------------------");
            }
        }
    }

}