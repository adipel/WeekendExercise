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

        public Show(string title, double length, DateTime time, int hall) : base(length, time, hall)
        {
            Title = title;
        }

        public void Display()
        {
            base.Display();
            Console.WriteLine($"Title: {Title}");
        }
    }
}
