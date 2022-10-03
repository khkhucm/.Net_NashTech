namespace Day02
{
    public class Program
    {
        public static void GetListOfMale(List<Member> members)
        {
            Console.WriteLine("List male member:");
            var male = members.Where(x => x.Gender.Equals(Gender.Male));

            foreach (var i in male)
            {
                Console.WriteLine(i.GetInfo);
            }
        }
        public static void GetOldestMember(List<Member> members)
        {
            var age = members.Max(x => x.Age);
            var mem = members.Where(x => x.Age.Equals(age));
            var oldestAge = mem.First();
            Console.WriteLine(oldestAge.GetInfo);
        }
        public static List<String> GetFullNameList(List<Member> members)
        {
            List<String> fullNameList = new List<String>();
            fullNameList = (from x in members
            select x.FirstName+ " " + x.LastName).ToList();

            return fullNameList;
        }
        public static void FirstMemberInHaNoi(List<Member> members)
        {
            var memsBornInHaNoi = members.Where(x => x.BirthPlace.ToLower().Equals("ha noi"));
            var memBornInHaNoi = memsBornInHaNoi.First();
            Console.WriteLine(memBornInHaNoi.GetInfo);
        }
        public static void GetList(List<Member> members)
        {
            List<Member> greaterThan2000 = new List<Member>();
            List<Member> is2000 = new List<Member>();
            List<Member> smallerThan2000 = new List<Member>();
            int option = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("1. List of members who has birth year is 2000:");
                Console.WriteLine("2. List of members who has birth year greater than 2000:");
                Console.WriteLine("3. List of members who has birth year smaller than 2000:");
                Console.WriteLine("0. Return menu");
                Console.Write("Enter key: ");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        var mem = members.Where(x => x.DateOfBirth.Year.Equals(2000));
                        foreach (var m in mem)
                        {
                            Console.WriteLine(m.GetInfo);
                        }
                        break;
                    case 2:
                        var memGreaterThan2000 = members.Where(x => x.DateOfBirth.Year > 2000);
                        foreach (var m in memGreaterThan2000)
                        {
                            Console.WriteLine(m.GetInfo);
                        }
                        break;
                    case 3:
                        var memSmallerThan2000 = members.Where(x => x.DateOfBirth.Year < 2000);
                        foreach (var m in memSmallerThan2000)
                        {
                            Console.WriteLine(m.GetInfo);
                        }
                        break;
                }
                Console.ReadKey();
            } while (option != 0);
        }
        public static void Main()
        {
            Member m1 = new Member("Dong", "Nguyen", Gender.Male, new DateTime(1995, 12, 10), "01234567432", "Ha Noi", true);
            Member m2 = new Member("Duc", "Dam", Gender.Male, new DateTime(2012, 01, 02), "123421042123", "Ha Giang", false);
            Member m3 = new Member("Kien", "Tran", Gender.Male, new DateTime(2008, 04, 21), "3212990221", "Ha Noi", true);
            Member m4 = new Member("Binh", "Pham", Gender.Female, new DateTime(2000, 11, 25), "1289012342", "Ha Nam", true);
            Member m5 = new Member("An", "Tran", Gender.Female, new DateTime(2002, 12, 25), "09821942142", "Nam Dinh", false);
            List<Member> members = new List<Member>();
            List<String> fullNameMembers = new List<String>();
            int option = 0;
            members.Add(m1);
            members.Add(m2);
            members.Add(m3);
            members.Add(m4);
            members.Add(m5);

            do
            {
                Console.Clear();
                Console.WriteLine("1. List of member who is male:");
                Console.WriteLine("2. Oldest person based on age:");
                Console.WriteLine("3. Full name list:");
                Console.WriteLine("4. Return 3 lists:");
                Console.WriteLine("5. First person who was born in Ha Noi:");
                Console.WriteLine("0. Exit");
                Console.Write("Enter key: ");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        GetListOfMale(members);
                        break;
                    case 2:
                        GetOldestMember(members);
                        break;
                    case 3:
                        fullNameMembers = GetFullNameList(members);
                        foreach (String m in fullNameMembers)
                        {
                            Console.WriteLine(m);
                        }
                        break;
                    case 4:
                        GetList(members);
                        break;
                    case 5:
                        FirstMemberInHaNoi(members);
                        break;
                }
                Console.ReadKey();
            } while (option != 0);
        }
    }
}