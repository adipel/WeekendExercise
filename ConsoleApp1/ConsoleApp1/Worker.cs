using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Worker : IDisplayable
    {

        public string FullName { get; set; }
        public int Id {  get; set; }
        public DateOnly StartDate {  get; set; }
        public double Salary { get; set; }
        public string Role { get; set; }

        public Worker(string fullName, int id, DateOnly startDate, double salary, string role)
        {
            FullName = fullName;
            Id = id;
            StartDate = startDate;
            Salary = salary;
            Role = role;
        }

        public void Display()
        {
            Console.WriteLine("");
            Console.WriteLine($"Full name: {FullName}");
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Start date: {StartDate.ToString()}");
            Console.WriteLine($"Salary: {Salary}");
            Console.WriteLine($"Role: {Role}");
            Console.WriteLine("");
        }
    }
}
