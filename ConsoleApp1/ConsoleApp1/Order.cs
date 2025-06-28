using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Order : IDisplayable
    {
        public Event TheEvent {  get; set; }
        public Dictionary<string, int> InvitedPeopleAndAge { get; set; }

        public Order(Event theEvent, Dictionary<string, int> invitedPeopleAndAge)
        {
            TheEvent = theEvent;
            InvitedPeopleAndAge = invitedPeopleAndAge;
        }

        public void Display()
        {
            TheEvent.Display();
            Console.WriteLine("");
            Console.WriteLine("Invited People");
            Console.WriteLine("");
            foreach (var person in InvitedPeopleAndAge)
            {
                Console.WriteLine($"Name - {person.Key}   Age - {person.Value}");
            }
            Console.WriteLine("");

        }
    }
}
