using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        _culturalHall.DisplayWorkers();
                    break;

                    case 4:
                        AddWorker();
                    break;

                    case 5:
                        FireEmployee();
                    break;

                    default:
                        Console.WriteLine("Please select one of the options");
                    break;

                }
            }
        }

        private void FireEmployee()
        {
            _culturalHall.DisplayWorkers();
            int selection;
            do
            {
                Console.WriteLine("Please enter the number of the employee you would like to fire. (one of the Options)");
                selection = GetInt();
            }
            while (!(selection >= 0 && selection < _culturalHall.Workers.Count + 1));

            Worker selectedWorker =  _culturalHall.Workers[selection];

            Console.WriteLine("Selected employee to fire -");
            selectedWorker.Display();
            Console.WriteLine("Confirm that this is the employee you want to fire ('yes', any other answer will be considered no):");
            string confirm = Console.ReadLine();
            if (confirm == "yes")
            {
                _culturalHall.FireEmployee(selectedWorker);
            }
            else
            {
                FireEmployee();
            }
        }

        private void AddWorker()
        {
            Console.WriteLine("");
            Console.WriteLine("Full name:");
            string fullName = Console.ReadLine();
            NullCheck(fullName);

            int Id = GetId();

            Console.WriteLine("Start date:");
            string dateStr = Console.ReadLine();
            NullCheck(dateStr);
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
            NullCheck (role);
            Console.WriteLine("");

            Worker newWorker = new Worker(fullName, Id, startDate, salary, role);
            _culturalHall.AddWorker(newWorker);
            Console.WriteLine("Employee added successfully");
        }

        private int GetId()
        {
            Console.WriteLine("Id:");
            string idStr = Console.ReadLine();
            NullCheck(idStr);

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
