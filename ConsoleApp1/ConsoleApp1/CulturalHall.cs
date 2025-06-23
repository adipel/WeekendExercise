using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project
{
    internal class CulturalHall
    {
        private List<Event> _events;

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
            }
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
