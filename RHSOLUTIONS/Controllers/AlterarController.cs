using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIMIVRH.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using PIMIVRH.Interfaces;

namespace PIMIVRH.Controllers
{
    public class AlterarController : Controller
    {
        public IActionResult Index()
        {
            var modelo = listarHome();
            return View(modelo);
        }

        public FuncionarioModel listarHome()
        {
            conexaoSql Connectiostring = new conexaoSql();
            var conexaoSql = Connectiostring.ConnectionString;
            SqlConnection conexaoDB = new SqlConnection(conexaoSql);
            FuncionarioModel Home = new FuncionarioModel();


            var NFuncional = HttpContext.Session.GetString("Funcional");



            conexaoDB.Open();

            string query = $"SELECT * FROM FUNCIONARIO AS A FULL JOIN ENDERECOFUNC AS B ON A.Cpf = B.Cpf WHERE Funcional = '{NFuncional}'";
            SqlCommand command = new SqlCommand(query, conexaoDB);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Home.Nome = reader.GetString(1);
                Home.Telefone = reader.GetString(2);
                Home.CargoFunc = reader.GetString(3);
                Home.SalarioFunc = reader.GetDouble(4);
                Home.VAuxilioAlimentacao = reader.GetDouble(6);
                Home.VAuxilioRefeicao = reader.GetDouble(7);
                Home.Email = reader.GetString(9);
                Home.Endereco = reader.GetString(13);
                Home.Numero = reader.GetInt32(14);
                Home.Complemento = reader.GetString(15);
                Home.Cidade = reader.GetString(16);
                Home.Cep = reader.GetString(18);

            }

            return Home;
        }

        public IActionResult AlterarDados(FuncionarioModel Modelo)
        {
            conexaoSql Connectiostring = new conexaoSql();
            var conexaoSql = Connectiostring.ConnectionString;
            SqlConnection conexaoDB = new SqlConnection(conexaoSql);
            FuncionarioModel Home = new FuncionarioModel();


            var NFuncional = HttpContext.Session.GetString("Funcional");
            var NCpf = HttpContext.Session.GetString("Cpf");


            conexaoDB.Open();

            string query = "UPDATE FUNCIONARIO" +
                " SET " +
                $"Nome = '{Modelo.Nome}'," +
                $"TelefoneFunc = '{Modelo.Telefone}'," +
                $"CargoFunc = '{Modelo.CargoFunc}'," +
                $"SalarioFunc = {Modelo.SalarioFunc}," +
                $"Funcional = '{NFuncional}'," +
                $"VAuxilioAlimentacao = {Modelo.VAuxilioAlimentacao}," +
                $"VAuxilioRefeicao = {Modelo.VAuxilioRefeicao}," +
                $"Email = '{Modelo.Email}'" +
                $"WHERE Cpf = '{NCpf}' ";

            SqlCommand command = new SqlCommand(query, conexaoDB);
            SqlDataReader reader = command.ExecuteReader();

            conexaoDB.Close();

            AlterarEndereco(Modelo);

            return RedirectToAction("Index", "Home");
        }
        private void AlterarEndereco(FuncionarioModel modelo)
        {
            conexaoSql Connectiostring = new conexaoSql();
            var conexaoSql = Connectiostring.ConnectionString;
            SqlConnection conexaoDB = new SqlConnection(conexaoSql);
            FuncionarioModel Home = new FuncionarioModel();


            var NFuncional = HttpContext.Session.GetString("Funcional");
            var NCpf = HttpContext.Session.GetString("Cpf");


            conexaoDB.Open();

            string query = "UPDATE ENDERECOFUNC " +
                $"SET Endereco = '{modelo.Endereco}'," +
                $"Numero = {modelo.Numero}," +
                $"Complemento = '{modelo.Complemento}'," +
                $"Cidade = '{modelo.Cidade}'," +
                $"Cpf = '{NCpf}'," +
                $"Cep = '{modelo.Cep}'" +
                $"WHERE Cpf = '{NCpf}'";

            SqlCommand command = new SqlCommand(query, conexaoDB);
            SqlDataReader reader = command.ExecuteReader();

            conexaoDB.Close();
        }
    }
}
