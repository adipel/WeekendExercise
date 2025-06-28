using System;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime time1 = new DateTime(2025, 3, 4, 20, 30, 0);
            Show show = new Show("Annie", 45, time1, 5, 7);

            List<string> instruments = new List<string> {"Guitar", "Drums", "Violin"};
            DateTime time2 = new DateTime(2025, 7, 10, 23, 00, 0);
            Concert concert = new Concert(instruments, 120, time2, 3, 18);

            DateTime time3 = new DateTime(2026, 1, 10, 16, 30, 0);
            Show show2 = new Show("Hamilton", 165, time3, 5, 15);

            List<Event> events = new List<Event> {show, concert, show2};

            DateOnly dateOnly = new DateOnly(2020, 2, 2);
            Worker theCEO = new Worker("adi peled", 215976226, dateOnly, 100000, "CEO");

            Worker worker1 = new Worker("max li", 123456789, dateOnly, 2000, "cleaner");
            Worker worker2 = new Worker("alexander hamilton", 123456789, dateOnly, 50000, "worker");
            List<Worker> workers = new List<Worker> { worker1, worker2 };

            CulturalHall culturalHall = new CulturalHall(events, theCEO, workers);

            Menu menu = new Menu(culturalHall);

            NullCatch(menu);
            
        }

        public static void NullCatch(Menu menu)
        {
            try
            {
                menu.MainMenuStart();
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Input cannot be null.");
                NullCatch(menu);
            }
        }
    }
}
