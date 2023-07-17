using System;
using System.Globalization;

namespace CotacaoDolar
{
    class ConversorDeMoeda
    {
        public static double Conversao(double cot,double quant) {
            double IOF = ((quant * cot) *6) /100;
            return IOF + quant * cot;
        }
    }
}
