namespace Day03.Events
{
    public class ClockInfo : EventArgs
    {
        public ClockInfo(int year, int month, int day, int hour, int minute, int second)
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
            string month = Month.ToString("D2");
            string day = Day.ToString("D2");
            string hour = Hour.ToString("D2");
            string minute = Minute.ToString("D2");
            string second = Second.ToString("D2");

            return string.Format($"{month}/{day}/{Year}\r\n" +
                $"{hour}:{minute}:{second}");
        }
    }
}
