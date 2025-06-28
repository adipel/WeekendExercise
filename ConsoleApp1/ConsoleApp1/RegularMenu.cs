using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class RegularMenu : Menu
    {
        public string UserName { get; set; }
        public RegularMenu(CulturalHall culturalHall, string userName) : base(culturalHall)
        {
            UserName = userName;
        }

        public void Start()
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
                        MainMenuStart();
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

        private void BuyTickets()
        {
            _culturalHall.DisplayOptionsForTickets();
            Event selectedEvent = GetSelectedTicket();
            Dictionary<string, int> invitedPeopleAndAge = GetInvitedPeople();

            bool allAgesAreValid = true;

            foreach (int age in invitedPeopleAndAge.Values)
            {
                if (age < 0 || age < selectedEvent.MinimumAge)
                {
                    allAgesAreValid = false;
                }
            }

            if (allAgesAreValid)
            {
                AddOrder(selectedEvent, invitedPeopleAndAge);
                Console.WriteLine("The order was placed successfully");
            }
            else
            {
                Console.WriteLine($"Sorry, it is not possible to book a ticket for the event. One or more of the people is under the age limit ({selectedEvent.MinimumAge}), or one or more of the ages are incorrect (below zero)");
            }
        }

        private void AddOrder(Event theEvent, Dictionary<string, int> invitedPeopleAndAge)
        {
            Order newOrder = new Order(theEvent, invitedPeopleAndAge);

            if(_culturalHall.IsUserExists(UserName))
            {
                _culturalHall.AddOrderToExistingUser(UserName, newOrder);
            }
            else
            {
                User newUser = new User(UserName);
                newUser.AddOrder(newOrder);
                _culturalHall.AddUser(newUser);
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
            if (confirm == "yes")
            {
                return selectedTicket;
            }
            else
            {
                return GetSelectedTicket();
            }
        }
    }
}
