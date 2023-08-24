using MaisUmaLoja.Entites;
using System;
using System.Globalization;
using System.Collections.Generic;


namespace Loja
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of products:");
            int n = int.Parse(Console.ReadLine());
            List<Product> list = new List<Product>();

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i} data: ");
                Console.Write("Common, used or imported (c/u/i)?");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

                if (ch == 'c' || ch == 'C')
                {
                    list.Add(new Product(name, price));
                }
                else if (ch == 'u' || ch == 'U')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime mD = DateTime.Parse(Console.ReadLine());
                    list.Add(new UsedProduct(name, price, mD));
                }
                else if (ch == 'i' || ch == 'I')
                {
                    Console.Write("Customs fee: ");
                    double cf = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new ImportedProduct(name, price, cf));
                    
                }
            }
            Console.WriteLine("Price Tags:");
            foreach (Product product in list)
            {
                Console.WriteLine(product.PriceTag());
            }

        }
    }
}
