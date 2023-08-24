using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MaisUmaLoja.Entites
{
    internal class UsedProduct : Product
    {
        public DateTime ManufactureDate { get; set; }

        public UsedProduct() { }

        public UsedProduct(string name, double price, DateTime manufacture) : base(name, price)
        {
           ManufactureDate = manufacture;
        }
        public override string PriceTag()
        {
            return Name + " (used) " + " $ " + Price.ToString("F2", CultureInfo.InvariantCulture) + "(Manufacture date: " +ManufactureDate.ToString("dd/mm/yyyy")+")";
        }
    }
}
