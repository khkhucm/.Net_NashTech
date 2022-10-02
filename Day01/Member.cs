namespace Day01
{
    public enum Gender
    {
        MALE,
        FEMALE,
        OTHER
    }
    public class Member
    {
        public String firstName { get; set; }
        public String lastName { get; set; }
        public Gender gender { get; set; }
        public DateTime dateOfBirth { get; set; }
        public String phoneNumber { get; set; }
        public String birthPlace { get; set; }
        public int age { get; set; }
        public bool isGraduated { get; set; }
        public Member(String firstName, String lastName, Gender gender, DateTime dateOfBirth, String phoneNumber, String birthPlace, int age, bool isGraduated)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
            this.phoneNumber = phoneNumber;
            this.birthPlace = birthPlace;
            this.age = age;
            this.isGraduated = isGraduated;
        }

        public string getInfo
        {
            get
            {
                return string.Format($"First Name: {firstName}" + Environment.NewLine +
                $"Last Name: {lastName}" + Environment.NewLine +
                $"Gender: {gender}" + Environment.NewLine +
                $"Date Of Birth: {dateOfBirth}" + Environment.NewLine +
                $"Phone Number: {phoneNumber}" + Environment.NewLine +
                $"Birth Place: {birthPlace}" + Environment.NewLine +
                $"Age: {age}" + Environment.NewLine +
                $"Is Graduated: {isGraduated}");
            }
        }
    }

}