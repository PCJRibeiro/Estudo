using Pagamentos.Services;
using Pagamentos.Entites;
using System.Globalization;

namespace Pagamentos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.WriteLine("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Date (dd/MM/yyyy): ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine("Contract value: ");
            double totalvalue = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            Console.WriteLine("Enter number of installments: ");
            int months = int.Parse(Console.ReadLine());

            Contract myContract = new Contract(number, date, totalvalue);

            ContractService contractService = new ContractService(new PaypalService());
            contractService.ProcessContract(myContract, months);

            Console.WriteLine("Installments:");
            foreach (Installment installment in myContract.Installment)
            {
                Console.WriteLine(installment);
            }
        }
    }
}
