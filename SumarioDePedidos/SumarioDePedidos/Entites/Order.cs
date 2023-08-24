using SumarioDePedidos.Entites.Enums;
using System.Globalization;
using System.Text;


namespace SumarioDePedidos.Entites
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Orders { get; set; } = new List<OrderItem>();

        public Order() { }

        public Order(DateTime moment, OrderStatus status,Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Orders.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            Orders.Remove(item);
        }
        public double Total()
        {
            double sum = 0;
            foreach(OrderItem SubTotal in Orders)
            {
               sum+= SubTotal.SubTotal();
            }
            return sum;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order moment: " + Moment.ToString("dd/mm/yyyy HH:mm:ss")); 
            sb.AppendLine("Order status" + Status.ToString());
            sb.AppendLine("Order items:");
            foreach (OrderItem item in Orders)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }

    }
}
