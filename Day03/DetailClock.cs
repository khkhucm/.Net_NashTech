
namespace Day03
{
    public class DetailClock
    {
        public DetailClock(int year, int month, int day, int hour, int minute, int second)
        {
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public int Year { get; }
        public int Month { get; }
        public int Day { get; }
        public int Hour { get; }
        public int Minute { get; }
        public int Second { get; }

        public override string ToString()
        {
            String month = Month.ToString("D2");
            String day = Day.ToString("D2");
            String hour = Hour.ToString("D2");
            String minute = Minute.ToString("D2");
            String second = Second.ToString("D2");

            return String.Format($"{month}/{day}/{Year}\r\n" +
                $"{hour}:{minute}:{second}");
        }
    }
}
