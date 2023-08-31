using System.Collections.Generic;
using System.Globalization;
using CalculationPrice.Entites;

namespace CalculationPrice
{
    class Program
    {
        static void Main(String[] args)
        {
            List<Product> list = new List<Product>();

            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] vect = Console.ReadLine().Split(',');
                string name = vect[0];
                double price = double.Parse(vect[1],CultureInfo.InvariantCulture);
                list.Add(new Product(name,price));
            }

            CalculationService calculationService = new CalculationService();

            Product max = calculationService.Max(list);
            Console.Write("MAX:");
            Console.Write(max);
        }
    }
}