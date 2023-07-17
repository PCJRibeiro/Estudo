using MediaEscolar;
using System;
using System.Globalization;

namespace Media
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno al = new Aluno();

            Console.WriteLine("Digite o nome do aluno: ");
            al.Nome = Console.ReadLine();
            Console.WriteLine("Digite as três notas do aluno");
            al.Nota1 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            al.Nota2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            al.Nota3 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Nota Final = " + al.NotaFinal().ToString("F2", CultureInfo.InvariantCulture));

            if (al.NotaFinal() >= 60) {
                Console.WriteLine("Aprovado");
            }

            else { 
                Console.WriteLine("Reprovado");
                Console.WriteLine("Faltaram " + al.MediaFaltando().ToString("F2", CultureInfo.InvariantCulture) + " Pontos");
            }
        }
    }
}
