namespace Day03
{
    public delegate void delegateClock(DetailClock detailClock);
    public class Clock
    {
        public event delegateClock eventClock;
        public void Timer()
        {
            DateTime time = DateTime.Now;
            eventClock.Invoke(new DetailClock(time.Year,time.Month,time.Day,
                time.Hour,time.Minute,time.Second));
        }
    }
}
