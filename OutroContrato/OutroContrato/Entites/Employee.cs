using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace OutroContrato.Entites
{
    internal class Employee
    {
        public string Name { get; set; }
        public int Hour { get; set; }
        public double Value { get; set; }

        public double ValuePerHour { get; set; }

        public Employee() { }
        public Employee(string name, int hour, double value)
        {
            Name = name;
            Hour = hour;
            Value = value;
        }

        public virtual double Payment()
        {
            return Hour * Value;
        }
       
    }
}
