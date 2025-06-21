using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    interface IEvent
    {
        public double Length { get; set; }
        public DateTime Time { get; set; }
        public int Hall { get; set; }

        void Display()
        {
            Console.WriteLine("--Event details--");
            Console.WriteLine("");
            Console.WriteLine($"Length (in min): {Length}");
            Console.WriteLine($"Time: {Time}");
            Console.WriteLine($"Hall: {Hall}");
        }

    }
}
