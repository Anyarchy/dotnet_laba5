using Order.Enums;
using System;
using System.Collections.Generic;

namespace Order.Models
{
    public class Shop
    {
        private List<Order> Orders { get; set; }

        private Publisher Publisher { get; set; }

        public Shop()
        {
            Orders = new List<Order>();
            Publisher = new Publisher();
        }

        public void AddClient(Client client)
        {
            Publisher.Subscribe(client);
        }

        public void DeleteClient(Client client)
        {
            Publisher.UnSubscribe(client);
        }

        public void MakeOrder(string textOrder, int clientID)
        {
            Orders.Add(new Order(clientID, textOrder));

        }

        public void ChangeOrderState(int person, int orderId)
        {
            int sub;
            OrderType type = OrderType.Cancelled;
            if (person == 1)
            {
                Console.WriteLine("Enter 1 to set Accepted\nEnter 2 to set Proccessing\nEnter 3 to set paid\nEnter 4 to set Cancelled");
                Console.Write("Your choice: ");
                sub = Convert.ToInt32(Console.ReadLine());
                switch (sub)
                {
                    case 1:
                        {
                            type = OrderType.Accepted;
                            break;
                        }
                    case 2:
                        {
                            type = OrderType.Processing;
                            break;
                        }
                    case 3:
                        {
                            type = OrderType.Paid;
                            break;
                        }
                    case 4:
                        {
                            type = OrderType.Cancelled;
                            break;
                        }
                }
            }
            else if (person == 2)
            {
                Console.WriteLine("Enter 1 to set ShipmentAllowed\nEnter 2 to set DeliveryAllowed\n");
                Console.Write("Your choice: ");
                sub = Convert.ToInt32(Console.ReadLine());
                switch (sub)
                {
                    case 1:
                        {
                            type = OrderType.ShipmentAllowed;
                            break;
                        }
                    case 2:
                        {
                            type = OrderType.DeliveryAllowed;
                            break;
                        }
                }
            }
            else if (person == 3)
            {
                Console.WriteLine("Enter 1 to set DeliveredToThePointOfIssue\nEnter 2 to set BuyerGot\n");
                Console.Write("Your choice: ");
                sub = Convert.ToInt32(Console.ReadLine());
                switch (sub)
                {
                    case 1:
                        {
                            type = OrderType.DeliveredToThePointOfIssue;
                            break;
                        }
                    case 2:
                        {
                            type = OrderType.BuyerGot;
                            break;
                        }
                }
            }
            foreach (var order in Orders)
            {
                if (order.Id == orderId)
                {
                    order.OrderType = type;
                }
            }
            Notify(orderId);
        }

        private void Notify(int orderId)
        {
            foreach (var order in Orders)
            {
                if(order.Id == orderId)
                {
                    Console.WriteLine(Publisher.Notify(order.ClientId) + " your Order: " + order.TextOrder + " has state: " + order.OrderType);
                }
            }
            Console.WriteLine("Done!");
        }
    }
}