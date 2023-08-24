using OutroContrato.Entites;
using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Collections.Generic;

namespace Contrato
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of employees:");
            int n = int.Parse(Console.ReadLine());
            List<Employee> list = new List<Employee>();
            for (int i = 1; i <= n; i++)
            {
               
                Console.WriteLine($"Employye #{i} data:");
                Console.Write("Outsourced (y/n)? ");
                char choice = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Hours: ");
                int hours = int.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
               

               if (choice == 'y' || choice == 'Y')
                {
                    Console.Write("Additional charge: ");
                    double charge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture) ;
                    list.Add( new Outsourced(name, hours, value, charge));

                }
                else
                {
                    list.Add(new Employee(name, hours, value));
                }
               
            }
            Console.WriteLine();
            Console.WriteLine("PAYMENTS: ");
            foreach (Employee emp in list)
            {
                Console.WriteLine(emp.Name + " - $ " + emp.Payment().ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}