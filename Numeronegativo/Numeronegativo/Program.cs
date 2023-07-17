using System;

namespace numerosNegativos
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ex 1
            Console.WriteLine("digite um número inteiro com seu sinal, para saber se ele é negativo ou não:");
            double numero = double.Parse(Console.ReadLine());

            if (numero < 0 ) {
                Console.WriteLine("Negativo");
                    }
            else
            {
                Console.WriteLine("Não Negativo");
            }

            //Ex 2
            Console.WriteLine("Agora escreva um número inteiro para saber se ele é par ou ímpar:");
            double parImpar = double.Parse(Console.ReadLine());
            if (parImpar % 2 == 0 ) {
                Console.WriteLine("Par");
            }
            else { Console.WriteLine("Ímpar"); }

            //Ex 3
            Console.WriteLine("Agora escrave dois números para saber se eles são múltiplos entre si" );
            string[] valores = Console.ReadLine().Split(' ');
            int A = int.Parse(valores[0]);
            int B = int.Parse(valores[1]);

            if (A % B == 0 || B % A == 0)
            {
                Console.WriteLine("Sao Multiplos");
            }
            else
            {
                Console.WriteLine("Nao sao Multiplos");
            }
        }
    }
}