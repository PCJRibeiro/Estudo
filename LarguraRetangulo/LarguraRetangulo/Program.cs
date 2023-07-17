using LarguraRetangulo;
using System;
using System.Globalization;

namespace Rentangulo
{
    class Promgram {
        static void Main(string[] args)
        {
            Calculo t = new Calculo();

            Console.WriteLine("Digite a largura do retângulo:");
            t.Largura = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("Digite a altura do retângulo");
            t.Altura = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Area = " + t.Area().ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Perímetro = " + t.Perimetro().ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Diagonal= " + t.Diagonal().ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}