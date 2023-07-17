using System;
using System.Globalization;

namespace MediaEscolar
{
    class Aluno
    {
        public string Nome;
        public double Nota1,Nota2,Nota3;

        public double NotaFinal()
        {
            return Nota1 + Nota2 +Nota3 ;
        }
        public double MediaFaltando()
        {
            return 60 - NotaFinal();
        }
    }
}
