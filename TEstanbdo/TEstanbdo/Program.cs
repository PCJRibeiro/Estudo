/* class minhaClasse
{

static void Main(string[] args)
{

   //implente sua solução aqui

   string[] notas = Console.ReadLine().Split(' ');
   double media= 0;
   for (int i = 0; i < notas.Length; i++)
   {
       if ((double.Parse(notas[i]) >= 0 && (double.Parse(notas[i]) <= 10))) {  media += (double.Parse(notas[i])); }
       else { Console.WriteLine("nota invalida"); }
   }
   Console.WriteLine("Nota = "+ media);
}
}
    do
   {
       if (nota >= 0 && nota <= 10)
       {
           notas = nota;
           contado++;
       }
       else
       {
           Console.WriteLine("nota invalida");
       }
   }
   while (contado < 2);
       double media = 0;
       foreach (double valor in notas)
   {
       media += valor;
       }
   media = media / 2;
       Console.WriteLine("media = " + media);

}

}
using System.Data;

class minhaClasse
{
int variavel = int.Parse(Console.ReadLine());
for (int )
}
   

using System.Xml;

class minhaclasse
{
    static void Main(string[] args)
    {
        int contador = 0;
        double media = 0;
        do
        {
            double nota = double.Parse(Console.ReadLine());
            if (nota >= 0 && nota <= 10) { media += nota; contador++; }
            else
            {
                Console.WriteLine("nota invalida");
            }

        }
        while (contador < 2);
        double mediaFinal = media/2;
        Console.WriteLine("media = "+ mediaFinal);
    }
}


namespace DIO
{
    class Program
    {
        static void Main(string[] args)
        {

            int N = int.Parse(Console.ReadLine());

            //Exibir "Ho" do papai noel
            for (int i = 0; i < N; i++)
            {
                if (i != N)
                {
                    Console.Write("Ho ");                  //Complete o código no espaço em branco
                }
                else
                {
                    Console.WriteLine("Ho!");
                }
            }
        }
    }
}
*/
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Usamos HashSet para armazenar tipos únicos de jóias
        HashSet<string> joias = new HashSet<string>();

        string linha;
        // Lê as linhas de entrada até o final (EOF)
        while ((linha = Console.ReadLine()) != null)
        {
            // Adiciona a string ao HashSet
            joias.Add(linha);
        }

        // A quantidade de elementos no HashSet será a quantidade de jóias distintas
        Console.WriteLine(joias.Count);
    }
}