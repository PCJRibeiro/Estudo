namespace Matriz
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] n = Console.ReadLine().Split(' ');
            int n1 = int.Parse(n[0]);
            int n2 = int.Parse(n[1]);

            int[,] mat = new int[n1, n2];

            for (int i = 0; i < n1; i++)
            {
                string[] values = Console.ReadLine().Split(' ');
                for (int j = 0; j < n2; j++)
                {
                    mat[i, j] = int.Parse(values[j]);
                }
            }
            int parametro = int.Parse (Console.ReadLine());

           
            
            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < n1; j++)
                {
                    if (mat[i, j] == parametro)
                    {
                        Console.WriteLine("posição:" + i + ", " + j + ": ");
                        if (j > 0)
                        {
                            Console.WriteLine("Esqueda: " + mat[i, j - 1]);
                        }
                        if (i > 0)
                        {
                            Console.WriteLine("Acima: " + mat[i - 1, j]);
                        }
                        if (j < n2 - 1)
                        {
                            Console.WriteLine("Direita: " + mat[i, j + 1]);
                        }
                        if (i < n1 - 1)
                        {
                            Console.WriteLine("Abaixo: " + mat[i + 1, j]);
                        }
                        Console.WriteLine();
                    }

                }
            }
           
        }
    }
}

