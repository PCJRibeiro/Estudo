using Aluguel_de_Quartos;

namespace Aluguel
{
    class Program
    {
        static void Main(string[] args)
        {
            Estudante[] vect = new Estudante[10];
            Console.Write("Quantos quartos serão alugados?");
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Aluguel #{i}:");
                Console.Write("Nome:");
                string nome = Console.ReadLine();
                Console.Write("Email:");
                string email = (Console.ReadLine());
                Console.Write("Quarto:");
                int Quarto = int.Parse(Console.ReadLine());
                vect [Quarto] = new Estudante (nome, email);
            }
            Console.WriteLine();
            Console.WriteLine("Quartos ocupados:");
            for (int i = 0; i < 10; i++)
            {
                if (vect[i] != null)
                {
                    Console.WriteLine(i+ ": " + vect[i]);
                }
            }

        }
    }
}