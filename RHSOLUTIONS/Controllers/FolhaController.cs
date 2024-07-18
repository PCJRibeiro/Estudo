using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIMIVRH.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using PIMIVRH.Interfaces;

namespace PIMIVRH.Controllers
{
    public class FolhaController : Controller
    {
        public IActionResult Index()
        {
            FolhaModel folha = GerarFolha();
            return View(folha);
        }
        public FolhaModel GerarFolha()
        {
            conexaoSql Connectiostring = new conexaoSql();
            var conexaoSql = Connectiostring.ConnectionString;
            SqlConnection conexaoDB = new SqlConnection(conexaoSql);

            FolhaModel folha = new FolhaModel();

            var NCpf = HttpContext.Session.GetString("Cpf");
            conexaoDB.Open();

            string query = $"SELECT Nome, TelefoneFunc, CargoFunc, SalarioFunc, VAuxilioAlimentacao, VAuxilioRefeicao, Email, ValeTransporte "+
                           $"from FUNCIONARIO WHERE Cpf = '{NCpf}'";

            SqlCommand command = new SqlCommand(query, conexaoDB);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                
                folha.Nome = reader.GetString(0);
                folha.Telefone = reader.GetString(1);
                folha.Cargo = reader.GetString(2);
                folha.Salario = reader.GetDouble(3);
                folha.VAuxilioAlim = reader.GetDouble(4);
                folha.VAuxilioRef = reader.GetDouble(5);
                folha.Email = reader.GetString(6);
                folha.ValeTransporte = reader.GetString(7);
                folha.Cpf = NCpf;

            }
            double descontoInss = CalculoInss(folha);
            double descontoIR = CalculoImpostoDeRenda(folha, descontoInss);
            double descontoVt = CalculoValeTransporte(folha);
            

            double salarioLiquido = folha.Salario - (descontoInss + descontoIR + descontoVt);
            ViewBag.salarioLiquido = $"{salarioLiquido}";
            conexaoDB.Close();

            return folha;

                
        }

        public double CalculoImpostoDeRenda(FolhaModel model, double Inss)
        {
            double x = model.Salario - Inss;
            if (x < 2112)
            {
                
                return x = 0;
            }
            else if (x > 2112 && x <= 2826.65)
            {
                
                x = (x * 7.5) / 100;
                x -= 158.40;
                return x;

            }
            else if (x > 2826.65 && x <= 3751.05)
            {
                
                x = (x * 15) / 100;
                x -= 370.40;
                return x;
            }
            else if (x > 3751.05 && x <= 4664.68)
            {
                
                x = (x * 22.5) / 100;
                x -= 651.73;
                return x;
            }
            else if (x > 4664.68)
            {
                
                x = (x * 27.5) / 100;
                x -= 884.96;
                return x;
            }
            else
            { return 0; }
        }

        public double CalculoInss(FolhaModel model)
        {
            try
            {
                double x = model.Salario;
                if (x <= 1320)
                {
                    
                    x = (x * 7) / 100;
                    return x;
                }
                else if (x >= 1321 && x <= 2571)
                {
                    
                    x -= 1320;
                    x = (x * 9) / 100;
                    x += 99;
                    return x;
                }
                else if (x >= 2572 && x <= 3856)
                {
                    
                    x -= 2571.29;
                    x = (x * 12) / 100;
                    x += 99;
                    x += 112.62;
                    return x;
                }
                else if (x >= 3857 && x <= 7507.49)
                {
                    
                    x -= 3856.94;
                    x = (x * 14) / 100;
                    x += 99;
                    x += 112.62;
                    x += 154.28;
                    return x;
                }
                else if (x > 7507.49)
                {
                    
                    return x = 876.97;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public double CalculoValeTransporte(FolhaModel model)
        {
            if(model.ValeTransporte == "S")
            {
                var descontoVT = model.Salario * 0.06;
                return descontoVT;
            }
            return 0.0;
            
        }
    }
}
