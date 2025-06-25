using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Project
{

    internal class Menu
    {
        private CulturalHall _culturalHall;
        private string _userName;

        public Menu(CulturalHall culturalHall)
        {
            _culturalHall = culturalHall;
        }

        public void Start()
        {
            Console.WriteLine("Please enter your username");
            _userName = Console.ReadLine();

            if (IsAdmin(_userName))
            {
                AdminMenu();
            }
            else
            {
                RegularMenu();
            }

        }

        private void RegularMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("------MENU------");
                Console.WriteLine("Enter 1 - To exit");
                Console.WriteLine("Enter 2 - To change username");
                Console.WriteLine("Enter 3 - To see all of the existing events");
                Console.WriteLine("Enter 4 - To buy a ticket to a future event");

                int selection = int.Parse(Console.ReadLine());


                switch (selection)
                {
                    case 1:
                        exit = true;
                    break;

                    case 2:
                        Start();
                    break;

                    case 3:
                        _culturalHall.DisplayEvents();
                    break;
                    
                    case 4:
                        BuyTickets();
                    break;

                    default:
                        Console.WriteLine("Please select one of the options");
                    break;

                }
            }
        }

        private void AdminMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("---ADMIN MENU---");
                Console.WriteLine("Enter 1 - To exit");
                Console.WriteLine("Enter 2 - To create a new event");
                Console.WriteLine("Enter 3 - To see all of the existing events");
                Console.WriteLine("Enter 4 - To see events on a specific date");
                Console.WriteLine("Enter 5 - To see all tickets ordered by a specific user");
                int selection = int.Parse(Console.ReadLine());


                switch (selection)
                {
                    case 1:
                        exit = true;
                    break;

                    case 2:
                        AddEvent();
                    break;

                    case 3:
                        _culturalHall.DisplayEvents();
                    break;

                    case 4:
                        GetEventsOnDate();
                    break;

                    case 5:
                        DisplayTicketsOfUser();
                    break;

                    default:
                        Console.WriteLine("Please select one of the options");
                    break;
                }
            }
        }

        private void DisplayTicketsOfUser()
        {
            Console.WriteLine("Enter the username whose tickets you would like to see:");
            string usernameToSee = Console.ReadLine();
            List<Event> userEvents = new List<Event>();

            foreach (string name in _culturalHall.TicketsOrders.Keys)
            {
                if(name ==  usernameToSee)
                {
                    userEvents.Add(_culturalHall.TicketsOrders[name]);
                }
            }
            if (userEvents.Count > 0)
            {
                foreach (Event events in userEvents)
                {
                    events.Display();
                }
            }
            else
            {
                Console.WriteLine("This user has not ordered any tickets");
            }

        }


        private void BuyTickets()
        {
            _culturalHall.DisplayOptionsForTickets();
            Event selectedEvent = GetSelectedTicket();
            Dictionary<string, int> invitedPeople = GetInvitedPeople();

            bool allAgesAreValid = true;

            foreach(int age  in invitedPeople.Values)
            {
                if (age < 0 || age < selectedEvent.MinimumAge)
                {
                    allAgesAreValid = false;
                }
            }
            if (allAgesAreValid)
            {
                Console.WriteLine("The order was placed successfully");
                _culturalHall.TicketsOrders.Add(_userName, selectedEvent);
            }
            else
            {
                Console.WriteLine($"Sorry, it is not possible to book a ticket for the event. One or more of the people is under the age limit ({selectedEvent.MinimumAge}), or one or more of the ages are incorrect (below zero)");
            }
        }

        private Dictionary<string, int> GetInvitedPeople()
        {
            Console.WriteLine("Please enter the number of people you would like to order a ticket for: ");
            int numberOfPeople = int.Parse(Console.ReadLine());

            Dictionary<string, int> invitedPeople = new Dictionary<string, int>();
            for (int i = 0; i < numberOfPeople; i++)
            {
                Console.WriteLine($"{i} Enter name:");
                string name = Console.ReadLine();
                Console.WriteLine($"{i} Enter age:");
                int age = int.Parse(Console.ReadLine());
                invitedPeople[name] = age;
            }
            return invitedPeople;
        }

        private Event GetSelectedTicket()
        {
            Event[] OptionsForTickets = _culturalHall.GetFutureEvents();
            int selection;
            do
            {
                Console.WriteLine("Please enter the event number you would like to buy a ticket for (one of the Options)");
                selection = int.Parse(Console.ReadLine());
            }
            while (!(selection >= 0 && selection < OptionsForTickets.Length + 1));

            Event selectedTicket = OptionsForTickets[selection];

            Console.WriteLine("Selected event -");
            selectedTicket.Display();
            Console.WriteLine("Confirm that this is the event you want to buy a ticket for ('yes', any other answer will be considered no):");
            string confirm = Console.ReadLine();
            if(confirm == "yes")
            {
                return selectedTicket;
            }
            else
            {
                return GetSelectedTicket();
            }
        }


        private void GetEventsOnDate()
        {
            Console.WriteLine("Enter date:");
            string dateStr = Console.ReadLine();
            DateTime date;
            while (!DateTime.TryParse(dateStr, out date))
            {
                Console.WriteLine($"Input in incorrect format (MM/dd/yyyy HH:mm:ss) The input received was - {dateStr}");
                Console.WriteLine("Please try again in the correct format: ");
                dateStr = Console.ReadLine();
            }

            List<Event> eventsOnDate = _culturalHall.GetEventsByDate(date);

            if (eventsOnDate.Count > 0)
            {
                Console.WriteLine($"The events on {DateOnly.FromDateTime(date)}:");
                foreach (Event events in eventsOnDate)
                {
                    events.Display();
                }
            }
            else
            {
                Console.WriteLine($"There are no events on {date}");
            }

        }

        private void AddEvent()
        {
            Console.WriteLine("--Add a new event--");
            string eventType = GetEventType();
            _culturalHall.AddEvent(CreateEvent(eventType));
        }

        private Event CreateEvent(string eventType)
        {
            Console.WriteLine("Enter date and time:");
            string eventTimeStr = Console.ReadLine();
            DateTime eventTime;
            while (!DateTime.TryParse(eventTimeStr, out eventTime))
            {
                Console.WriteLine($"Input in incorrect format (MM/dd/yyyy HH:mm:ss) The input received was - {eventTimeStr}");
                Console.WriteLine("Please try again in the correct format");
            }

            Console.WriteLine("Enter length (in min):");
            double eventLength = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter hall:");
            int eventHall = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter minimum age:");
            int minimumAge = int.Parse(Console.ReadLine());

            if (eventType == "show")
            {
                Event newEvent = CreateShow(eventLength, eventTime, eventHall, minimumAge);
                return newEvent;
            }
            else if (eventType == "concert")
            {
                Event newEvent = CreateConcert(eventLength, eventTime, eventHall, minimumAge);
                return newEvent;
            }
            else
            {
                throw new Exception($"Invalid event type - {eventType}");
            }
        }

        private Event CreateConcert(double length, DateTime time, int hall, int minimumAge)
        {
            Console.WriteLine("Enter musical instruments");
            Console.WriteLine("How many musical instruments are there in the concert?");
            int numberOfInstruments = int.Parse(Console.ReadLine());
            List<string> instrument = new List<string>();
            for (int i = 0; i < numberOfInstruments; i++)
            {
                Console.WriteLine($"{i} Enter musical instrument:");
                instrument.Add(Console.ReadLine());
            }

            Concert newConcert = new Concert(instrument, length, time, hall, minimumAge);
            return newConcert;
        }

        private Event CreateShow(double length, DateTime time, int hall, int minimumAge)
        {
            Console.WriteLine("Enter title:");
            string eventTitle = Console.ReadLine();

            Show newShow = new Show(eventTitle, length, time, hall, minimumAge);
            return newShow;
        }

        private string GetEventType()
        {
            Console.WriteLine("Please enter the type of event you want to add (show or concert)");
            string eventType = Console.ReadLine();
            while (eventType != "show" && eventType != "concert")
            {
                Console.WriteLine("Please enter 'show' or 'concert'");
                eventType = Console.ReadLine();
            }
            return eventType;
        }


        private bool IsAdmin(string userName)
        {

            if (userName == "admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
