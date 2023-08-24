using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumarioDePedidos.Entites
{
     class OrderItem
    {
        
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }

        public OrderItem() { } 
        public OrderItem( double price, int quantity,Product product)
        {
            
            Price = price;
            Quantity = quantity;
            Product = product;
        }

        public double SubTotal() { return Quantity * Price; }

        public override string ToString()
        {
            return Product.Name
                + ", $"
                + Price.ToString("F2", CultureInfo.InvariantCulture)
                + ", Quantity: "
                + Quantity
                + ", Subtotal: $"
                + SubTotal().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
