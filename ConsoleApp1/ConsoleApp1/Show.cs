using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Show : Event
    {
        public string Title { get; set; }

        public Show(string title, double length, DateTime time, int hall, int minimumAge) : base(length, time, hall, minimumAge)
        {
            Title = title;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Title: {Title}");
        }
    }
}
