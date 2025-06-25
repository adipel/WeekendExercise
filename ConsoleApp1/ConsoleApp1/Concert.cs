using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Concert : Event
    {
        public List<string> Instruments { get; set; }

        public Concert(List<string> instruments, double length, DateTime time, int hall, int minimumAge) : base(length, time, hall, minimumAge)
        {
            Instruments = instruments;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("Musical instruments:");
            foreach (var instrument in Instruments)
            {
                Console.WriteLine($"- {instrument}");
            }
        }

    }
}
