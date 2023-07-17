using System;
using System.Globalization;


namespace Banco
{
    class Dados
    {
        public int _conta { get; private set; }
        private string _nome { get; set; }
        public double _saldo { get; private set; }

        public Dados(int conta, string nome)
        {
            _conta = conta;
            _nome = nome;
        }


        public Dados(int conta, string nome, double depositoinicial) : this(conta, nome)
        {
            Deposito(depositoinicial);
        }


        public void Deposito(double saldo)
        {
            _saldo += saldo;
        }

        public void Saque(double saldo)
        {
            _saldo -= (saldo + 5);
        }

        public override string ToString()
        {
            return "conta " + _conta + ", " + "Titular: " + _nome + ", " + "saldo: $" + _saldo.ToString("F2", CultureInfo.InvariantCulture);
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