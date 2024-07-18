using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PIMIVRH.Interfaces;
using PIMIVRH.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PIMIVRH.Interfaces;

namespace PIMIVRH.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            List<FuncionarioModel> listaPonto = listarHome();
            return View(listaPonto);
        }

        public IActionResult Redirect()
        {
            return RedirectToAction("Index", "Alterar");
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public List<FuncionarioModel> listarHome()
        {
            conexaoSql Connectiostring = new conexaoSql();
            var conexaoSql = Connectiostring.ConnectionString;
            SqlConnection conexaoDB = new SqlConnection(conexaoSql);
            FuncionarioModel Home = new FuncionarioModel();

            
            List<FuncionarioModel> lista = new List<FuncionarioModel>();


            var NFuncional = HttpContext.Session.GetString("Funcional");


            conexaoDB.Open();

            string query = $"SELECT * FROM FUNCIONARIO AS A FULL JOIN ENDERECOFUNC AS B ON A.Cpf = B.Cpf WHERE Funcional = '{NFuncional}'";
            SqlCommand command = new SqlCommand(query, conexaoDB);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Home.Cpf = reader.GetString(0);
                HttpContext.Session.SetString("Cpf", Home.Cpf);
                Home.Nome = reader.GetString(1);
                Home.Telefone = reader.GetString(2);
                Home.CargoFunc = reader.GetString(3);
                Home.SalarioFunc = reader.GetDouble(4);
                Home.VAuxilioAlimentacao = reader.GetDouble(6);
                Home.VAuxilioRefeicao = reader.GetDouble(7);
                Home.Email = reader.GetString(9);
                Home.Endereco = reader.GetString(13);
                Home.Numero = reader.GetInt32(14);
                Home.Complemento = reader.IsDBNull(15) ? "Não inserido" : reader.GetString(15);
                Home.Cidade = reader.GetString(16);
                Home.Cep = reader.GetString(17);

                lista.Add(Home);
            }

            return lista;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
