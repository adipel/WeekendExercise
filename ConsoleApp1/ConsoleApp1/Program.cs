using System;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime time1 = new DateTime(2025, 3, 4, 20, 30, 0);
            Show show = new Show("Annie", 45, time1, 5);

            var instruments = new List<string> { "Guitar", "Drums", "Violin" };
            DateTime time2 = new DateTime(2025, 7, 10, 20, 30, 0);
            Concert concert = new Concert(instruments, 120, time2, 3);

            show.Display();
            concert.Display();
        }
    }
}
