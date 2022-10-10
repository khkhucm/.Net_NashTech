namespace ASP.NET_MVC.DataAccess
{
    public class StaticDataAccess
    {
        private List<Person> _people = new List<Person>{
            new Person("Dong", "Nguyen Phuong", "Male", new DateTime(2000, 1, 13),"123456","Ha Noi", true),
            new Person("Thuy", "Nguyen Phuong", "FeMale", new DateTime(2001, 12, 22),"328102","Ha Giang", false),
            new Person("Anh", "Le Lan", "Female", new DateTime(2002, 5, 10),"123462","Ha Noi", true),
            new Person("Anh", "Le Lan", "Female", new DateTime(2002, 5, 10),"123462","Ha Noi", false),
            new Person("Dan", "Tran Quan", "Male", new DateTime(1999, 1, 1),"425456","Hai Phong", true),
            new Person("Huong", "Duong Lan", "FeMale", new DateTime(1998, 1, 12),"15351","Binh Duong", false),
        };
        public List<Person> GetPeople()
        {
            return _people;
        }
    }
}