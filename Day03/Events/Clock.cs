namespace Day03.Events
{
    public delegate void delegateClock(object clock, ClockInfo detailClock);
    public class Clock
    {
        public event delegateClock eventClock;
        public void Timer(object clock, ClockInfo clockInfo)
        {
            eventClock.Invoke(clock, clockInfo);
        }

        public void ShowTime()
        {
            while (!Console.KeyAvailable)
            {
                Thread.Sleep(1000);
                Console.Clear();
                DateTime time = DateTime.Now;
                ClockInfo clockInfo = new ClockInfo(time.Year, time.Month, time.Day,
                                                    time.Hour, time.Minute, time.Second);
                Timer(this, clockInfo);
            }
        }
    }
}
