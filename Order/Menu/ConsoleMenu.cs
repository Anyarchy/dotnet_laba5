using Order.Models;
using System;

namespace Order.Menu
{
    public class ConsoleMenu
    {
        private readonly Client _client;

        private readonly Shop _shop;

        public ConsoleMenu(Client client)
        {
            _client = client;
            _shop = new Shop();
            _shop.AddClient(client);
        }

        public void StartShopping()
        {
            string subject, FIO;
            int choosen, submenu;
            bool isRun = true;
            try
            {

                while (isRun)
                {
                    Console.WriteLine("Enter 1 to add order\nEnter 2 to change order state like storekeeper\nEnter 3 to change state order like courier\nEnter 4 to change order`s state like administrator");
                    Console.Write("Your choice: ");
                    choosen = Convert.ToInt32(Console.ReadLine());
                    switch (choosen)
                    {
                        case 1:
                            {
                                Console.WriteLine("Enter text order(subject of order): ");
                                subject = Console.ReadLine();
                                _shop.MakeOrder(subject, _client.Id);
                                Console.WriteLine("Done");
                                break;
                            }
                        case 2:
                            {
                                int orderId;
                                Console.WriteLine("Enter order id to change its state");
                                orderId = Convert.ToInt32(Console.ReadLine());
                                _shop.ChangeOrderState(1, orderId);
                                break;
                            }
                        case 3:
                            {
                                int orderId;
                                Console.WriteLine("Enter order id to change its state");
                                orderId = Convert.ToInt32(Console.ReadLine());
                                _shop.ChangeOrderState(2, orderId);
                                break;
                            }
                        case 4:
                            {
                                int orderId;
                                Console.WriteLine("Enter order id to change its state");
                                orderId = Convert.ToInt32(Console.ReadLine());
                                _shop.ChangeOrderState(3, orderId);
                                break;
                            }
                    }
                    Console.WriteLine("\n\n\n");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
