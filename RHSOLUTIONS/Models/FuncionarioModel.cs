namespace PIMIVRH.Models
{
    public class FuncionarioModel : ResidenciaModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string CargoFunc { get; set; }
        public string Email { get; set; }
        public double SalarioFunc { get; set; }
        public double VAuxilioAlimentacao { get; set; }
        public double VAuxilioRefeicao { get; set; }
        //public ResidenciaModel residencia { get; set; }
    }
}
