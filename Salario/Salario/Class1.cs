using System;
using System.Globalization;

namespace Salario
{
     class Calculo
    {
        public string Nome;
        public double SalarioBruto, Imposto;

        public double SalarioLiquido() {
            return SalarioBruto - Imposto;
        }
        public void AumentarSalario(double porcetagem)
        {
            SalarioBruto += ((SalarioBruto * porcetagem) / 100);
        }
        public override string ToString()
        {
            return Nome
                + ", R$ "
                + SalarioLiquido().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
