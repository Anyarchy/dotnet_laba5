using Order.Menu;
using Order.Models;
using System;

namespace Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fio;
            Console.WriteLine("Enter your FIO!");
            fio = Console.ReadLine();
            var menu = new ConsoleMenu(new Client(fio));
            menu.StartShopping();
        }
    }
}