using System;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime t = new DateTime(2025, 3, 4, 20, 30, 0);
            Show A = new Show("a", 45, t, 5);

            A.Display();
        }
    }
}
