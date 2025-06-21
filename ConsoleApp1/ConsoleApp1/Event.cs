using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    abstract class Event : IDisplayable
    {
        public double Length { get; set; }
        public DateTime Time { get; set; }
        public int Hall { get; set; }

        public Event(double length, DateTime time, int hall)
        {
            Length = length;
            Time = time;
            Hall = hall;
        }

        public virtual void Display()
        {
            Console.WriteLine("");
            Console.WriteLine("--Event details--");
            Console.WriteLine("");
            Console.WriteLine($"Time: {Time}");
            Console.WriteLine($"Length: {Length} min");
            Console.WriteLine($"Hall: {Hall}");

        }

    }
}
