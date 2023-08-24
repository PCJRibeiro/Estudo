using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files.Entite
{
    internal class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        
        public Product(string name , double price, int qunatity)
        { Name = name; Price = price; Quantity = qunatity;}

        public double Total()
        {
            return Price * Quantity;
        }
    }
}
