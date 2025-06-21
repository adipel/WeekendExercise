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

        public Concert(List<string> instruments, double length, DateTime time, int hall) : base(length, time, hall)
        {
            Instruments = instruments;
        }

        public void Display()
        {
            base.Display();
            Console.WriteLine($"Mוsical instruments: {Instruments}");
        }

    }
}
