using Salario;
using System;
using System.Globalization;

namespace Funcionario
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculo f = new Calculo();
            Console.WriteLine("Nome:");
            f.Nome = Console.ReadLine();
            Console.WriteLine("Salário bruto:");
            f.SalarioBruto =double.Parse (Console.ReadLine(),CultureInfo.InvariantCulture);
            Console.WriteLine("Imposto:");
            f.Imposto = double.Parse (Console.ReadLine(),CultureInfo.InvariantCulture);
            Console.WriteLine();

            Console.WriteLine("Funcionário: " + f);
            Console.WriteLine( );

            Console.WriteLine("Digite a procentagem para aumentar o salário: ");
            double Asb = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            f.AumentarSalario(Asb);
            Console.WriteLine( );

            Console.WriteLine("Dados Atualizados: " + f);
        }
    }                           
}   