using CotacaoDolar;
using System;
using System.Globalization;

namespace Cotacao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Qual é a cotação do dólar?: ");
            double cot = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            Console.Write("Quantos dólares você ira comprar?: ");
            double quant = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            double valor = ConversorDeMoeda.Conversao(cot, quant);
            Console.WriteLine("Valor a ser pago em reais = " + valor.ToString("F2",CultureInfo.InvariantCulture));

        }
    }
}
