using System;
using SumarioDePedidos.Entites;
using SumarioDePedidos.Entites.Enums;
using System.Globalization;

namespace LojaEletrodomesticos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthdate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.WriteLine("How many items to order? ");
            int n = int.Parse(Console.ReadLine());

            Client c1 = new Client(name, email, birthdate);
            Order order = new Order(DateTime.Now,status,c1);
            

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string productname = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                Product product = new Product(productname, price);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                OrderItem orderItem = new OrderItem(price,quantity,product);
                
                order.AddItem(orderItem);
            }

            Console.WriteLine("Order Summary:");
            Console.WriteLine(order);
        }
    }
}