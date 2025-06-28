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
        private List<User> _users;
        public List<Worker> Workers;
        public Worker CEO {  get; set; }

        public CulturalHall(Worker theCEO)
        {
            CEO = theCEO;
            _events = new List<Event>();
            _users = new List<User>();
            Workers = new List<Worker>();

        }
        
        public CulturalHall(List<Event> events, Worker theCEO)
        {
            CEO = theCEO;
            _events = events;
            _users = new List<User>();
            Workers = new List<Worker>();
        }

        public CulturalHall(List<Event> events, Worker theCEO, List<Worker> workers)
        {
            CEO = theCEO;
            _events = events;
            Workers = workers;
            _users = new List<User>();
        }

        public void ReplaceCEO(Worker newCEO)
        {
            CEO = newCEO;
        }

        public void DisplayWorkers()
        {
            for (int i = 0; i < Workers.Count; i++)
            {
                Console.WriteLine($"Employee {i}");
                Console.WriteLine("");
                Workers[i].Display();
            }
        }

        public void AddWorker(Worker newWorker)
        {
            Workers.Add(newWorker);
        }

        public void FireEmployee(int workerIndex)
        {
            Workers.RemoveAt(workerIndex);
        }

        public void FireEmployee(Worker worker)
        {
            Workers.Remove(worker);
        }

        public bool IsHallOccupied(DateTime newEventTime, int newEventHall)
        {
            foreach (Event existingEvent in _events)
            {
                if (existingEvent.Hall == newEventHall && existingEvent.Time == newEventTime)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsUserExists(string username)
        {
            if(_users != null)
            {
                foreach (User user in _users)
                {
                    if (user.UserName == username) return true;
                }
            }
            return false;
            
        }

        public void AddOrderToExistingUser(string userName, Order newOrder)
        {
            foreach (User user in _users)
            {
                if (user.UserName == userName)
                {
                    user.AddOrder(newOrder);
                }
            }
        }

        public void AddUser(User user)
        {
            _users.Add(user);
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

        public void DisplayTicketsOfUser(User selectedUser)
        {
            foreach (User user in _users)
            {
                if (user == selectedUser)
                {
                    user.Display();
                }
            }
        }

        public void DisplayTicketsOfUser(string usernameToSee)
        {
            bool userExist = false;
            if (_users != null)
            {
                foreach (User user in _users)
                {
                    if (user.UserName == usernameToSee)
                    {
                        user.Display();
                        userExist = true;
                    }
                }
                if(!userExist)
                {
                    Console.WriteLine("There are no existing orders for this user.");
                }
            }
            else
            {
                Console.WriteLine("There are no orders in the system.");
            }  
        }



    }
}
