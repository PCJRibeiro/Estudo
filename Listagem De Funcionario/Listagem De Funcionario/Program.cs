using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listagem_De_Funcionario
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Quantos funcionários serão registrados?");
            int n = int.Parse(Console.ReadLine());

            List<Funcionario> list = new List<Funcionario>();
            

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Funcionário #{i}:");
                Console.Write("id:");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Nome:");
                string Nome = Console.ReadLine();
                Console.Write("Salário:");
                double Salario = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                list.Add(new Funcionario(id, Nome, Salario));
                Console.WriteLine();

            }
            Console.Write("Entre com o id daquele que tera o salário aumentado: ");
            int VerificaroId = int.Parse(Console.ReadLine());

            Funcionario pos = list.Find( x => x.Id == VerificaroId);
            Console.Write("Entre a porcentagem: ");
            if (pos != null)
            {
                Console.Write("Entre com a porcentagem: ");
                double porcentagem = double.Parse(Console.ReadLine());
                pos.AumentarSalario(porcentagem);
            }
            else { Console.WriteLine("Esse Id não existe"); }

            Console.WriteLine();
            Console.WriteLine("Lista de funcionários atualizada: ");

            foreach (Funcionario funcionario in list) {
                Console.WriteLine(funcionario);
            }
        }
    }
}