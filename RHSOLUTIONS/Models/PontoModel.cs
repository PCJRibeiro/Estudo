using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIMIVRH.Models
{
    public class PontoModel
    {
        public TimeSpan PrimeiraBatida { get; set; } = TimeSpan.Zero;
        public TimeSpan SegundaBatida { get; set; } = TimeSpan.Zero;
        public TimeSpan TerceiraBatida { get; set; } = TimeSpan.Zero;
        public TimeSpan QuartaBatida { get; set; } = TimeSpan.Zero;
        public TimeSpan HorasTrabalhadas { get; set; } = TimeSpan.Zero;
        public string Cpf { get; set; }
        public DateTime Dia { get; set; }

    }
}
