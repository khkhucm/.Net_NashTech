using System;
namespace Day01
{

    public class Program
    {
        public static void listOfMale(List<Member> members)
        {
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].gender == Gender.MALE)
                {
                    Console.WriteLine(members[i].getInfo);
                }
            }
        }
        public static void oldestMember(List<Member> members)
        {
            int oldest = 0;
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].age > members[oldest].age)
                {
                    oldest = i;
                }
            }
            Console.WriteLine("Oldest member is {0}", members[oldest].getInfo);
        }
        public static List<String> fullNameList(List<Member> members)
        {
            List<String> newMembers = new List<String>();
            foreach (Member m in members)
            {
                String newFullName = m.firstName + " " + m.lastName;
                newMembers.Add(newFullName);
            }
            return newMembers;
        }
        public static void liveInHaNoi(List<Member> members)
        {
            int i = 0;
            while (!members[i].birthPlace.Equals("Ha Noi"))
            {
                i++;
            }
            Console.WriteLine(members[i].getInfo);
        }
        public static void return3List(List<Member> members)
        {
            List<Member> greaterThan2000 = new List<Member>();
            List<Member> is2000 = new List<Member>();
            List<Member> smallerThan2000 = new List<Member>();
            foreach (Member m in members)
            {
                int year = m.dateOfBirth.Year;
                if (year > 2000)
                {
                    year = 1;
                }
                switch (year)
                {
                    case 2000:
                        is2000.Add(m);
                        break;
                    case 1:
                        greaterThan2000.Add(m);
                        break;
                    default:
                        smallerThan2000.Add(m);
                        break;
                }
            }
            Console.WriteLine("List member birth year greater than 2000 :");
            foreach (Member m in greaterThan2000)
            {
                Console.WriteLine(m.getInfo);
            }
            Console.WriteLine("List member birth year is 2000 :");
            foreach (Member m in is2000)
            {
                Console.WriteLine(m.getInfo);
            }
            Console.WriteLine("List member birth year smaller than 2000 :");
            foreach (Member m in smallerThan2000)
            {
                Console.WriteLine(m.getInfo);
            }

        }
        public static void Main()
        {
            Member m1 = new Member("Dong", "Nguyen", Gender.MALE, new DateTime(1995, 12, 10), "1", "Ha Nam", 26, true);
            Member m2 = new Member("Duc", "Dam", Gender.MALE, new DateTime(2012, 01, 02), "2", "Ha Giang", 10, false);
            Member m3 = new Member("Kien", "Tran", Gender.MALE, new DateTime(2008, 04, 21), "3", "Ha Noi", 14, true);
            Member m4 = new Member("Binh", "Pham", Gender.FEMALE, new DateTime(2000, 11, 25), "4", "Ha Nam", 21, true);
            Member m5 = new Member("An", "Tran", Gender.FEMALE, new DateTime(2002, 12, 25), "5", "Nam Dinh", 19, false);
            List<Member> members = new List<Member>();
            List<String> newMembers = new List<String>();
            members.Add(m1);
            members.Add(m2);
            members.Add(m3);
            members.Add(m4);
            members.Add(m5);
            Console.WriteLine("---------------------------------- Cau 1 ----------------------------------");
            listOfMale(members);
            Console.WriteLine("---------------------------------- Cau 2 ----------------------------------");
            oldestMember(members);
            Console.WriteLine("---------------------------------- Cau 3 ----------------------------------");
            newMembers = fullNameList(members);
            foreach(String m in newMembers){
               Console.WriteLine(m);
            }
            Console.WriteLine("---------------------------------- Cau 4 ----------------------------------");
            return3List(members);
            Console.WriteLine("---------------------------------- Cau 5 ----------------------------------");
            liveInHaNoi(members);
            
        }
    }
}
