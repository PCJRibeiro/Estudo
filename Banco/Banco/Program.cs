using System;
using System.Globalization;
using Banco;
using static Banco.Dados;

namespace Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.Write("Entre o número de sua conta:");
            int conta = int.Parse(Console.ReadLine());
            Console.Write("Entre o titular da conta:");
            string nome = Console.ReadLine();
            Console.Write("Haverá depósito inicial (S/N)?");
            char escolha = char.Parse(Console.ReadLine());

            Dados p = new Dados(conta, nome);

            if (escolha == 'S' || escolha == 's')
            {
                Console.Write( "Entre o valor de depósito inicial: ");
                p.saldo = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            }

            Console.WriteLine();
            Console.WriteLine("Dados da conta:");
            Console.WriteLine(p);

            Console.WriteLine();
            Console.Write("Entre um valor para depósito: ");
            double Saldo = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            p.Deposito(Saldo);
            Console.WriteLine("Dados da conta atualizados");
            Console.WriteLine(p);

            Console.WriteLine();
            Console.Write("Entre um valor para saque: ");
            Saldo = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            p.Saque(Saldo);
            Console.WriteLine("Dados da conta atualizados");
            Console.WriteLine(p);
        } 
    }
}