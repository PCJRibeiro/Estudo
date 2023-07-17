using System;
using System.Globalization;


namespace Banco
{
    class Dados
    {
        public int _conta { get; private set; }
        private string _nome;
        public double saldo;
        
        public Dados() { }
        public Dados(int conta, string nome) {
            _conta = conta;
            _nome = nome;
        }


        public void Deposito(double Saldo)
        {
            saldo += Saldo;
        }

        public void Saque(double Saldo)
        {
            saldo -= (Saldo + 5) ;
        }

        public override string ToString()
        {
            return "conta " + _conta +", " + "Titular: " + _nome +", " + "saldo: $" + saldo.ToString("F2",CultureInfo.InvariantCulture);
        }

        public string Nome
        {
            get { return _nome; }
            set
            {
                if (value != null && value.Length > 1)
                {
                    _nome = value;
                }
            }
        }
    }
}
