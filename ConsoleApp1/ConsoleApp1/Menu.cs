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
            AdminMenu adminMenu = new AdminMenu(_culturalHall);
            RegularMenu regularMenu = new RegularMenu(_culturalHall);
            Console.WriteLine("Please enter your username");
            _userName = Console.ReadLine();

            if (IsAdmin(_userName))
            {
                adminMenu.Start();
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
    }
}
