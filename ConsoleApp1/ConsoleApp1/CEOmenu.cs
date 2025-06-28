using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project
{
    internal class CEOmenu : Menu
    {
        public CEOmenu (CulturalHall culturalHall) : base(culturalHall)
        {
        }

        public void Start()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("------CEO MENU------");
                Console.WriteLine("Enter 1 - To exit");
                Console.WriteLine("Enter 2 - To change username");
                Console.WriteLine("Enter 3 - To see all the employees");
                Console.WriteLine("Enter 4 - To add an employee");
                Console.WriteLine("Enter 5 - To fire an employee");
                Console.WriteLine("Enter 6 - To appoint a new CEO");

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
                        culturalHall.DisplayWorkers();
                    break;

                    case 4:
                        AddWorker();
                    break;

                    case 5:
                        FireEmployee();
                    break;

                    case 6:
                        NewCEO();
                    break;

                    default:
                        Console.WriteLine("Please select one of the options");
                    break;

                }
            }
        }

        private void NewCEO()
        {
            Worker newCEO = CreateWorker();
            Console.WriteLine("Are you sure you want to appoint a new CEO? If you do this you will no longer have access to the CEO menu.");
            Console.WriteLine("To confirm please enter 'yes' (any other answer will be considered no)");
            string confirm = Console.ReadLine();
            if (confirm == "yes")
            {
                culturalHall.ReplaceCEO(newCEO);
                MainMenuStart();
            }
        }

        private void FireEmployee()
        {
            culturalHall.DisplayWorkers();
            int selection;
            do
            {
                Console.WriteLine("Please enter the number of the employee you would like to fire (one of the Options)");
                selection = GetInt();
            }
            while (!(selection >= 0 && selection < culturalHall.Workers.Count + 1));

            Worker selectedWorker =  culturalHall.Workers[selection];

            Console.WriteLine("Selected employee to fire -");
            selectedWorker.Display();
            Console.WriteLine("Confirm that this is the employee you want to fire ('yes', any other answer will be considered no)");
            string confirm = Console.ReadLine();
            if (confirm == "yes")
            {
                culturalHall.FireEmployee(selectedWorker);
            }
            else
            {
                FireEmployee();
            }
        }

        private void AddWorker()
        {
            culturalHall.AddWorker(CreateWorker());
            Console.WriteLine("Employee added successfully");
        }

        private Worker CreateWorker()
        {
            Console.WriteLine("");
            Console.WriteLine("Full name:");
            string fullName = Console.ReadLine();
            NullCheck(fullName);

            int Id = GetId();

            Console.WriteLine("Start date:");
            string dateStr = Console.ReadLine();
            DateOnly startDate;
            while (!DateOnly.TryParse(dateStr, out startDate))
            {
                Console.WriteLine($"Input in incorrect format (MM/dd/yyyy) The input received was - {dateStr}");
                Console.WriteLine("Please try again in the correct format: ");
                dateStr = Console.ReadLine();
                NullCheck(dateStr);
            }

            Console.WriteLine("Salary:");
            int salary = GetInt();

            Console.WriteLine("Role:");
            string role = Console.ReadLine();
            NullCheck(role);
            Console.WriteLine("");

            Worker newWorker = new Worker(fullName, Id, startDate, salary, role);
            return newWorker;
        }

        private int GetId()
        {
            Console.WriteLine("Id:");
            string idStr = Console.ReadLine();

            if (int.TryParse(idStr, out int id) && idStr.Length == 9)
            {
                return id;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a 9-digit number.");
                return GetId();
            }
        }

    }
}
