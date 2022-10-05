namespace Day03
{
    class Program
    {
        static void ShowTime(DetailClock detailClock)
        {
            Console.WriteLine(detailClock);
        }
        static async void PrimeNumber(int firstNumb, int lastNumb)
        {
            bool checkPrime = true;

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
                        await Task.Delay(500);
                    }
                }
            }
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
                        clock.eventClock += new delegateClock(ShowTime);
                        while (!Console.KeyAvailable)
                        {
                            clock.Timer();
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                        break;
                    case "2":
                        PrimeNumber(0, 50);
                        PrimeNumber(51, 100);
                        break;
                }
                Console.ReadKey();
            } while (option != "0");
        }
    }
}