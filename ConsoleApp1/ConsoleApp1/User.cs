using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class User : IDisplayable
    {
        public string UserName { get; set; }
        private List<Order> _orders;

        public User(string userName)
        {
            UserName = userName;
            List<Order> orders = new List<Order>();
            _orders = orders;
        }

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public void Display()
        {
            Console.WriteLine("");
            Console.WriteLine($"---- {UserName} - User's orders ----");
            Console.WriteLine("");
            foreach (Order order in _orders)
            {
                order.Display();
            }
        }

    }
}
