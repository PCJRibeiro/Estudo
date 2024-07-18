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
    public class FeriasController : Controller
    {
        public IActionResult Index()
        {
            var modelo = selectFerias();
            return View(modelo);
        }

        public FeriasModel selectFerias()
        {
            conexaoSql Connectiostring = new conexaoSql();
            var conexaoSql = Connectiostring.ConnectionString;
            SqlConnection conexaoDB = new SqlConnection(conexaoSql);

            var NCpf = HttpContext.Session.GetString("Cpf");

            conexaoDB.Open();

            string query = $"select a.QtdDiasPrimeiroPeriodo," +
                            "a.QtdDiasSegundoPeriodo,"+
                            "a.QtdDiasTerceiroPeriodo,"+
                            "a.QtdPeriodos,"+
                            "b.DataInicio," +
                            "a.EntradaPrimeiroPeriodo,"+
                            "a.SaidaPrimeiroPeriodo,"+
                            "a.EntradaSegundoPeriodo,"+
                            "a.SaidaSegundoPeriodo, "+
                            "a.EntradaTerceiroPeriodo,"+ 
                            "a.SaidaTerceiroPeriodo " +
                            "FROM FERIAS as a " +
                            $"inner join FUNCIONARIO as b on a.Cpf = b.Cpf WHERE a.Cpf = '{NCpf}'";
            SqlCommand command = new SqlCommand(query, conexaoDB);
            SqlDataReader reader = command.ExecuteReader();
            FeriasModel ferias = new FeriasModel();
            while (reader.Read())
            {
                ferias.QtdDiasPrimeiroPeriodo = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                ferias.QtdDiasSegundoPeriodo = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                ferias.QtdDiasTerceiroPeriodo = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                ferias.QtdPeriodos = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                ferias.DataInicio = reader.IsDBNull(4) ? DateTime.Now.AddDays(30) : reader.GetDateTime(4).Date;
                ferias.DataLimiteGozo = ferias.DataInicio.AddYears(1).ToString("dd-MM-yyyy");
                ferias.EntradaPrimeiroPeriodo = reader.IsDBNull(5) ? DateTime.Now.AddDays(30) : reader.GetDateTime(5).Date;
                ferias.SaidaPrimeiroPeriodo = reader.IsDBNull(6) ? DateTime.Now.AddDays(30) : reader.GetDateTime(6).Date;
                ferias.EntradaSegundoPeriodo = reader.IsDBNull(7) ? DateTime.Now.AddDays(30) : reader.GetDateTime(7).Date;
                ferias.SaidaSegundoPeriodo = reader.IsDBNull(8) ? DateTime.Now.AddDays(30) : reader.GetDateTime(8).Date;
                ferias.EntradaTerceiroPeriodo = reader.IsDBNull(9) ? DateTime.Now.AddDays(30) : reader.GetDateTime(9).Date;
                ferias.SaidaTerceiroPeriodo = reader.IsDBNull(10) ? DateTime.Now.AddDays(30) : reader.GetDateTime(10).Date;
            }

            conexaoDB.Close();
            return ferias;
        }

        [HttpPost]
        public IActionResult insertFerias(FeriasModel modelo)
        {
            //var consulta_dados = consultarDados(modelo);
            modelo.QtdPeriodos = qutd_periodos(modelo);
            CalculaDiaRetorno(modelo);

            var DayValidator = ValidaQtdDias(modelo);
            var ValidaIni = ValidaDias(modelo);

            if (!DayValidator)
            {
                TempData["Erro"] = "Quantidade de dias inválido";
            }

            if(DayValidator && ValidaIni)
            {
                if (modelo.QtdPeriodos == 1)
                {
                    insert_com_um_periodo(modelo);
                }else if(modelo.QtdPeriodos == 2)
                {
                    insert_com_dois_periodos(modelo);
                }
                else if(modelo.QtdPeriodos == 3) 
                {
                    insert_com_tres_periodos(modelo);
                }
            }
            return RedirectToAction("Index", "Ferias");
        }

        private bool ValidaDias(FeriasModel modelo)
        {
            var diaValido = DateTime.Now.AddDays(30).Date;
            if(modelo.EntradaPrimeiroPeriodo < DateTime.Now.Date || modelo.EntradaSegundoPeriodo < DateTime.Now.Date || modelo.EntradaTerceiroPeriodo < DateTime.Now.Date)
            {
                TempData["Erro"] = "Data inválida, não é possivel inserir um dia menor que a data atual";
                return false;
            }
            if(modelo.EntradaPrimeiroPeriodo < diaValido || modelo.EntradaSegundoPeriodo < diaValido || modelo.EntradaTerceiroPeriodo < diaValido)
            {
                TempData["Erro"] = "Não é possivel agendar férias com menos de 30 dias de antecedência";
                return false;
            }
            return true;
        }
        private void CalculaDiaRetorno(FeriasModel modelo)
        {
                modelo.SaidaPrimeiroPeriodo = modelo.EntradaPrimeiroPeriodo.AddDays(modelo.QtdDiasPrimeiroPeriodo);
                modelo.SaidaSegundoPeriodo = modelo.EntradaSegundoPeriodo.AddDays(modelo.QtdDiasSegundoPeriodo);
                modelo.SaidaTerceiroPeriodo = modelo.EntradaTerceiroPeriodo.AddDays(modelo.QtdDiasTerceiroPeriodo);
        }

        private bool ValidaQtdDias(FeriasModel modelo)
        {
            if(modelo.QtdPeriodos == 1)
            {
                var dias = modelo.QtdDiasPrimeiroPeriodo;
                if(dias != 30)
                {
                    return false;
                }
            }
            if(modelo.QtdPeriodos == 2)
            {
                var dias = modelo.QtdDiasPrimeiroPeriodo + modelo.QtdDiasSegundoPeriodo;
                if(dias != 30)
                {
                    return false;
                }
                return true;
            }
            if (modelo.QtdPeriodos == 3)
            {
                var dias = modelo.QtdDiasPrimeiroPeriodo + modelo.QtdDiasSegundoPeriodo + modelo.QtdDiasTerceiroPeriodo;
                if (dias != 30)
                {
                    return false;
                }
                return true;
            } 
            return true;
        }

        private int qutd_periodos(FeriasModel modelo)
        {
            if (modelo.Periodos == "1")
            {
                modelo.QtdPeriodos = 1;
            }
            else if (modelo.Periodos == "2")
            {
                modelo.QtdPeriodos = 2;
            }
            else if (modelo.Periodos == "3")
            {
                modelo.QtdPeriodos = 3;
            }
            return modelo.QtdPeriodos;
            
        }
        
        private void insert_com_um_periodo(FeriasModel modelo)
        {
            conexaoSql Connectiostring = new conexaoSql();
            var conexaoSql = Connectiostring.ConnectionString;
            SqlConnection conexaoDB = new SqlConnection(conexaoSql);

            conexaoDB.Open();

            var NCpf = HttpContext.Session.GetString("Cpf");
            var query = $"DELETE FROM FERIAS WHERE Cpf ='{NCpf}'" +
                $"INSERT INTO FERIAS (QtdDiasPrimeiroPeriodo, " +
                $"EntradaPrimeiroPeriodo," +
                $"SaidaPrimeiroPeriodo," +
                $"QtdPeriodos," +
                $"Cpf)" +
                $"VALUES ({modelo.QtdDiasPrimeiroPeriodo}," +
                $"'{modelo.EntradaPrimeiroPeriodo.Date}'," +
                $"'{modelo.SaidaPrimeiroPeriodo.Date}'," +
                $"{modelo.QtdPeriodos}," +
                $"'{NCpf}')";

            SqlCommand command = new SqlCommand(query, conexaoDB);
            SqlDataReader reader = command.ExecuteReader();
        }
        private void insert_com_dois_periodos(FeriasModel modelo)
        {
            conexaoSql Connectiostring = new conexaoSql();
            var conexaoSql = Connectiostring.ConnectionString;
            SqlConnection conexaoDB = new SqlConnection(conexaoSql);
            conexaoDB.Open();
            var NCpf = HttpContext.Session.GetString("Cpf");
            var query = $"DELETE FROM FERIAS WHERE Cpf ='{NCpf}'" +
                $"INSERT INTO FERIAS (QtdDiasPrimeiroPeriodo," +
                $" EntradaPrimeiroPeriodo," +
                $" SaidaPrimeiroPeriodo," +
                $" QtdDiasSegundoPeriodo," +
                $" EntradaSegundoPeriodo," +
                $" SaidaSegundoPeriodo," +
                $" QtdPeriodos," +
                $"Cpf)" +
                $"  VALUES ({modelo.QtdDiasPrimeiroPeriodo}," +
                $"'{modelo.EntradaPrimeiroPeriodo}'," +
                $"'{modelo.SaidaPrimeiroPeriodo}'," +
                $"{modelo.QtdDiasSegundoPeriodo}," +
                $"'{modelo.EntradaSegundoPeriodo}'," +
                $"'{modelo.SaidaSegundoPeriodo}'," +
                $"{modelo.QtdPeriodos}," +
                $"'{NCpf}')";
                

            SqlCommand command = new SqlCommand(query, conexaoDB);
            SqlDataReader reader = command.ExecuteReader();
        }
        private void insert_com_tres_periodos(FeriasModel modelo)
        {

            conexaoSql Connectiostring = new conexaoSql();
            var conexaoSql = Connectiostring.ConnectionString;
            SqlConnection conexaoDB = new SqlConnection(conexaoSql);

            conexaoDB.Open();
            var NCpf = HttpContext.Session.GetString("Cpf");
            var query = $"DELETE FROM FERIAS WHERE Cpf ='{NCpf}'" +
                $"INSERT INTO FERIAS (QtdDiasPrimeiroPeriodo," +
                $" EntradaPrimeiroPeriodo," +
                $" SaidaPrimeiroPeriodo," +
                $" QtdDiasSegundoPeriodo," +
                $" EntradaSegundoPeriodo," +
                $" SaidaSegundoPeriodo," +
                $" QtdDiasTerceiroPeriodo," +
                $" EntradaTerceiroPeriodo," +
                $" SaidaTerceiroPeriodo," +
                $" QtdPeriodos," +
                $"  Cpf)" +
                $" VALUES ({modelo.QtdDiasPrimeiroPeriodo}," +
                $"'{modelo.EntradaPrimeiroPeriodo}'," +
                $"'{modelo.SaidaPrimeiroPeriodo}'," +
                $"{modelo.QtdDiasSegundoPeriodo}," +
                $"'{modelo.EntradaSegundoPeriodo}'," +
                $"'{modelo.SaidaSegundoPeriodo}'," +
                $"{modelo.QtdDiasTerceiroPeriodo}," +
                $"'{modelo.EntradaTerceiroPeriodo}'," +
                $"'{modelo.SaidaTerceiroPeriodo}'," +
                $"{modelo.QtdPeriodos}," +
                $"'{NCpf}')";
                

            SqlCommand command = new SqlCommand(query, conexaoDB);
            SqlDataReader reader = command.ExecuteReader();

        }
    }
}
