using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIMIVRH.Models
{
    public class FolhaModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }
        public double VAuxilioAlim { get; set; }
        public double VAuxilioRef { get; set; }
        public string Email { get; set; }
        public string ValeTransporte { get; set; }
        public int Horas { get; set; }
        public double Imposto { get; set; }

    }
}
