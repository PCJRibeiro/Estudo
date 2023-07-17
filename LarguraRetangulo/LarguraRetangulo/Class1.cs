using System;
using System.Globalization;

namespace LarguraRetangulo
{
    class Calculo
    {
        public double Largura, Altura;
        
        public double Area()
        {
            return Largura * Altura;
        }
        public double Perimetro() { 
            return (Largura * 2) + (Altura * 2);
         }
        public double Diagonal()
        {
            return Math.Sqrt(Math.Pow(Largura,2) + Math.Pow(Altura,2));
        }
        public override string ToString()
        {
            return "Area = " + Area().ToString("F2", CultureInfo.InvariantCulture)
            + "Perímetro = "
            + Perimetro().ToString("F2", CultureInfo.InvariantCulture)
            + "Diagonal= " 
            + Diagonal().ToString ("F2", CultureInfo.InvariantCulture); 
        }
    }
}
