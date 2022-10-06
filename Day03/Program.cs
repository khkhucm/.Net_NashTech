using Day03.Events;

namespace Day03
{
    class Program
    {
        public static void Subcribe(Clock clock)
        {
            clock.eventClock += new delegateClock(ShowClock);
        }
        public static void ShowClock(object clock, ClockInfo clockInfo)
        {
            Console.WriteLine(clockInfo);
        }
        static async Task PrimeNumber(int firstNumb, int lastNumb)
        {
            bool checkPrime = true;

            await Task.Run(async () =>
            {
                for (int i = firstNumb; i < lastNumb; i++)
                {
                    checkPrime = true;
                    if (i > 1)
                    {
                        for (int j = 2; j < i; j++)
                        {
                            if (i % j == 0)
                            {
                                checkPrime = false;
                                break;
                            }
                        }
                        if (checkPrime)
                        {
                            Console.Write(i + " ");
                            await Task.Delay(200);
                        }
                    }
                }
            });

        }
        public static void Main()
        {
            var option = "";
            Clock clock = new Clock();

            do
            {
                Console.Clear();
                Console.WriteLine("1. Clock Application");
                Console.WriteLine("2. Prime Number for a range");
                Console.WriteLine("0. Exit");
                Console.Write("Enter key: ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Subcribe(clock);
                        clock.ShowTime();
                        break;
                    case "2":
                        PrimeNumber(0, 100);
                        PrimeNumber(100, 200);
                        break;
                }
                Console.ReadKey();
            } while (option != "0");
        }
    }
}