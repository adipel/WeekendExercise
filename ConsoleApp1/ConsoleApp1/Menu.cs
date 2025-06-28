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
        protected CulturalHall culturalHall;
        protected string userName;

        public Menu(CulturalHall theCulturalHall)
        {
            culturalHall = theCulturalHall;
        }

        public void MainMenuStart()
        {
            Console.WriteLine("Please enter your username");
            userName = Console.ReadLine();
            NullCheck(userName);

            RegularMenu regularMenu = new RegularMenu(culturalHall, userName);
            AdminMenu adminMenu = new AdminMenu(culturalHall);
            CEOmenu theCEOmenu = new CEOmenu(culturalHall);

            if (IsAdmin(userName))
            {
                adminMenu.Start();
            }
            else if (IsCEO(userName))
            {
                theCEOmenu.Start();
            }
            else
            {
                regularMenu.Start();
            }
        }


        private bool IsAdmin(string userName)
        {
            return userName == "admin";
        }

        private bool IsCEO(string userName)
        {
            return userName == culturalHall.CEO.FullName;
        }

        protected void NullCheck(string input)
        {
            if (input == null || input == "")
            {
                throw new ArgumentNullException();
            }
        }

        protected int GetInt()
        {
            string str = Console.ReadLine();

            if (int.TryParse(str, out int number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return GetInt();
            }
        }
    }
}
