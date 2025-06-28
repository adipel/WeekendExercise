using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class AdminMenu : Menu
    {
        public AdminMenu(CulturalHall culturalHall) : base(culturalHall)
        {
        }

        public void Start()
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
                int selection = GetInt();


                switch (selection)
                {
                    case 1:
                        exit = true;
                    break;

                    case 2:
                        AddEvent();
                    break;

                    case 3:
                        culturalHall.DisplayEvents();
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

        private void AddEvent()
        {
            Console.WriteLine("--Add a new event--");
            string eventType = GetEventType();
            culturalHall.AddEvent(CreateEvent(eventType));
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

            int eventHall = GetHall(eventTime);

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

        private int GetHall(DateTime eventTime)
        {
            Console.WriteLine("Enter hall:");
            int eventHall = GetInt();
            if (culturalHall.IsHallOccupied(eventTime, eventHall))
            {
                Console.WriteLine("This hall is occupied at this time.");
                Console.WriteLine("");
                return GetHall(eventTime);
            }
            else
            {
                return eventHall;
            }
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

        private Event CreateConcert(double length, DateTime time, int hall, int minimumAge)
        {
            Console.WriteLine("Enter musical instruments");
            Console.WriteLine("How many musical instruments are there in the concert?");
            int numberOfInstruments = GetInt();
            List<string> instrument = new List<string>();
            for (int i = 0; i < numberOfInstruments; i++)
            {
                Console.WriteLine($"{i} Enter musical instrument:");
                string newInstrument = Console.ReadLine();
                NullCheck(newInstrument);
                instrument.Add(newInstrument);
            }

            Concert newConcert = new Concert(instrument, length, time, hall, minimumAge);
            return newConcert;
        }

        private Event CreateShow(double length, DateTime time, int hall, int minimumAge)
        {
            Console.WriteLine("Enter title:");
            string eventTitle = Console.ReadLine();
            NullCheck(eventTitle);

            Show newShow = new Show(eventTitle, length, time, hall, minimumAge);
            return newShow;
        }
        

        private void GetEventsOnDate()
        {
            Console.WriteLine("Enter date:");
            string dateStr = Console.ReadLine();
            NullCheck(dateStr);
            DateTime date;
            while (!DateTime.TryParse(dateStr, out date))
            {
                Console.WriteLine($"Input in incorrect format (MM/dd/yyyy HH:mm:ss) The input received was - {dateStr}");
                Console.WriteLine("Please try again in the correct format: ");
                dateStr = Console.ReadLine();
            }

            List<Event> eventsOnDate = culturalHall.GetEventsByDate(date);

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

        private void DisplayTicketsOfUser()
        {
            Console.WriteLine("Enter the username whose tickets you would like to see:");
            string usernameToSee = Console.ReadLine();
            NullCheck(usernameToSee);
            
            culturalHall.DisplayTicketsOfUser(usernameToSee);
        }
    }
}
