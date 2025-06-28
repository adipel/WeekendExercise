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
        protected CulturalHall _culturalHall;
        protected string _userName;

        public Menu(CulturalHall culturalHall)
        {
            _culturalHall = culturalHall;
        }

        public void MainMenuStart()
        {
            Console.WriteLine("Please enter your username");
            _userName = Console.ReadLine();
            NullCheck(_userName);

            RegularMenu regularMenu = new RegularMenu(_culturalHall, _userName);
            AdminMenu adminMenu = new AdminMenu(_culturalHall);
            CEOmenu theCEOmenu = new CEOmenu(_culturalHall);

            if (IsAdmin(_userName))
            {
                adminMenu.Start();
            }
            else if (IsCEO(_userName))
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
            return userName == "CEO";
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
            NullCheck(str);
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
