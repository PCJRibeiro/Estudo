using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutroContrato.Entites
{
    internal class Outsourced : Employee
    {
        public double AC { get; set; }
        public Outsourced() { }

        public Outsourced(string name, int hour, double value, double ac) : base(name, hour, value)
        {
            AC = ac;
        }

       public override double Payment() { 
            
            return base.Payment() + AC + (AC*0.1);
           
        }
    }
}
