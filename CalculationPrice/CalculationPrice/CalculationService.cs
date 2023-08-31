using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationPrice
{
    internal class CalculationService
    {

        public t Max<t>(List<t> list) where t : IComparable 
        {
            if (list.Count == 0)
            {
                throw new ArgumentException("the list can not be empty");
            }

            t max = list[0];
            for (int i = 1 ; i < list.Count; i++)
            {
                if (list[i].CompareTo(max) > 0)
                {
                    max = list[i];
                }

            }
            return max;

        }
    }
}
