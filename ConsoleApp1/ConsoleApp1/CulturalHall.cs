using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project
{
    internal class CulturalHall
    {
        private List<Event> _events;
        public Dictionary<string, Event> TicketsOrders;

        public CulturalHall()
        {
            _events = new List<Event>();
        }

        public CulturalHall(List<Event> events)
        {
            _events = events;
        }

        public void AddEvent(Event newEvent)
        {
            _events.Add(newEvent);
        }

        public void RemoveEvent(Event Event)
        {
            _events.Remove(Event);
        }

        public void DisplayEvents()
        {
            foreach (var Event in _events)
            {
                Event.Display();
                Console.WriteLine("");
            }
        }

        public void DisplayOptionsForTickets()
        {
            Console.WriteLine("");
            Console.WriteLine("---Future events available---");
            Console.WriteLine("");
            Event[] futureEvents = GetFutureEvents();
            int count = 0;
            foreach (var Event in futureEvents)
            {
                Console.WriteLine("");
                Console.WriteLine($"---option {count}---");
                Event.Display();
                Console.WriteLine("");
                count++;
            }
        }

        public Event[] GetFutureEvents()
        {
            int count = 0;
            foreach (var Event in _events)
            {
                if (Event.Time.Date > DateTime.Now)
                {
                    count++;
                }
            }
            Event[] futureEvents = new Event[count];
            int eventNumber = 0;
            foreach (var Event in _events)
            {
                if (Event.Time.Date > DateTime.Now)
                {
                    futureEvents[eventNumber++] = Event;
                }
            }
            return futureEvents;
        }

        public List<Event> GetEventsByDate(DateTime time)
        {
            List<Event> events = new List<Event>();

            foreach (var Event in _events)
            {
                if (Event.Time.Date == time.Date)
                {
                    events.Add(Event);
                }
            }
            return events;
        }



    }
}
