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
    public class PontoController : Controller
    {
        public int TotalHorasTrabalhadas { get; set; }
        public int HorasFaltantes { get; set; }
        public int HorasACompensar { get; set; }

        public IActionResult Index()
        {
            
            List<PontoModel> listaPonto = ListarPontoEletronico();
            return View(listaPonto);
        }

        public List<PontoModel> ListarPontoEletronico()
        {
            conexaoSql Connectiostring = new conexaoSql();
            var conexaoSql = Connectiostring.ConnectionString;
            SqlConnection conexaoDB = new SqlConnection(conexaoSql);

            List<PontoModel> lista = new List<PontoModel>();

            var NCpf = HttpContext.Session.GetString("Cpf");

            conexaoDB.Open();

            string query = $"SELECT * FROM PONTO WHERE Cpf = '{NCpf}'";
            SqlCommand command = new SqlCommand(query, conexaoDB);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                PontoModel ponto = new PontoModel();

                ponto.PrimeiraBatida = reader.IsDBNull(0) ? TimeSpan.Zero: reader.GetTimeSpan(0);
                ponto.SegundaBatida = reader.IsDBNull(1) ? TimeSpan.Zero : reader.GetTimeSpan(1);
                ponto.TerceiraBatida = reader.IsDBNull(2) ? TimeSpan.Zero : reader.GetTimeSpan(2);
                ponto.QuartaBatida = reader.IsDBNull(3) ? TimeSpan.Zero : reader.GetTimeSpan(3);
                ponto.HorasTrabalhadas = reader.IsDBNull(4) ? TimeSpan.Zero : reader.GetTimeSpan(4);
                ponto.Cpf = reader.GetString(5);
                ponto.Dia = reader.GetDateTime(6).Date;

                lista.Add(ponto);
            }

            conexaoDB.Close();

            CalculoHoras(lista);

            return lista;
        }

        public void CalculoHoras(List<PontoModel> lista)
        {
            var horasReportar = 0.0;
            var horasTotais = TimeSpan.Zero;
            var horasNoMes = 176.00;
            foreach (var item in lista)
            {
                var horasDia = item.HorasTrabalhadas;
                horasTotais = horasTotais + horasDia;
            }
            horasReportar = horasNoMes - horasTotais.TotalHours;
            horasReportar = horasReportar + 8;

            HttpContext.Session.SetString("horasTotais", horasReportar.ToString("N2"));

            ViewBag.reportar = horasReportar.ToString("N2");
            ViewBag.data = $"{horasTotais.TotalHours}:{horasTotais.Minutes}";
        }

        public IActionResult BaterPonto()
        {
            conexaoSql Connectiostring = new conexaoSql();
            var conexaoSql = Connectiostring.ConnectionString;
            SqlConnection conexaoDB = new SqlConnection(conexaoSql);
            PontoModel ponto = new PontoModel();

            List<PontoModel> lista = new List<PontoModel>();

            var NCpf = HttpContext.Session.GetString("Cpf");

            DateTime dataHora = DateTime.Now;

            string HorasFormatada = dataHora.ToString("T");
            string dataFormatada = dataHora.ToString("dd/MM/yyyy"); 

            conexaoDB.Open();

            string query = "UPDATE PONTO " +
                            $"SET QuartaBatida = '{HorasFormatada}' " +
                            $"WHERE Cpf = '{NCpf}' AND Dia = '{dataFormatada}' AND PrimeiraBatida is not null AND SegundaBatida is not null AND TerceiraBatida is not null " +
                            "UPDATE PONTO " +
                            $"SET TerceiraBatida = '{HorasFormatada}' " +
                            $"WHERE Cpf = '{NCpf}' AND Dia = '{dataFormatada}' AND PrimeiraBatida is not null AND SegundaBatida is not null " +
                            "UPDATE PONTO " +
                            $"SET SegundaBatida = '{HorasFormatada}' " +
                            $"WHERE Cpf = '{NCpf}' AND Dia = '{dataFormatada}' AND PrimeiraBatida is not null " +
                            $"IF NOT EXISTS(SELECT 1 FROM PONTO WHERE Cpf = '{NCpf}' AND Dia = '{dataFormatada}' AND PrimeiraBatida is not null) " +
                            "BEGIN " +
                            "INSERT INTO PONTO(Cpf, Dia, PrimeiraBatida) " +
                            $"Values('{NCpf}', '{dataFormatada}', '{HorasFormatada}') " +
                            "END " +
                            $"SELECT * FROM PONTO WHERE Cpf = '{NCpf}' AND Dia = '{dataFormatada}'";

            SqlCommand command = new SqlCommand(query, conexaoDB);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ponto.PrimeiraBatida = reader.IsDBNull(0) ? TimeSpan.Zero : reader.GetTimeSpan(0);
                ponto.SegundaBatida = reader.IsDBNull(1) ? TimeSpan.Zero : reader.GetTimeSpan(1);
                ponto.TerceiraBatida = reader.IsDBNull(2) ? TimeSpan.Zero : reader.GetTimeSpan(2);
                ponto.QuartaBatida = reader.IsDBNull(3) ? TimeSpan.Zero : reader.GetTimeSpan(3);
                ponto.HorasTrabalhadas = reader.IsDBNull(4) ? TimeSpan.Zero : reader.GetTimeSpan(4);
                ponto.Cpf = reader.GetString(5);
                ponto.Dia = reader.GetDateTime(6).Date;

                lista.Add(ponto);
            }

            var horastrabalhadas = CalcularHorasTrabalhadas(lista);

            iserirHoras(dataFormatada, horastrabalhadas);

            conexaoDB.Close();

            

            return RedirectToAction("Index", "Home");

           

        }

        public void iserirHoras(string dataFormatada, TimeSpan horasTrabalhadas)
        {
            conexaoSql Connectiostring = new conexaoSql();
            var conexaoSql = Connectiostring.ConnectionString;
            SqlConnection conexaoDB = new SqlConnection(conexaoSql);

            conexaoDB.Open();

            var NCpf = HttpContext.Session.GetString("Cpf");

            string query = "UPDATE PONTO " +
                                        $"SET HorasTrabalhadas = '{horasTrabalhadas}' " +
                                        $"WHERE cpf = '{NCpf}' AND dia = '{dataFormatada}'";

            SqlCommand command = new SqlCommand(query, conexaoDB);
            SqlDataReader reader = command.ExecuteReader();
        }

        private TimeSpan CalcularHorasTrabalhadas(List<PontoModel> lista)
        {
            TimeSpan horaTrabalhadaTotal = TimeSpan.Zero;

            foreach (var item in lista)
            {

                if (item.SegundaBatida != TimeSpan.Zero && item.QuartaBatida != TimeSpan.Zero)
                {
                    var horasPrimeiroPeriodo = item.SegundaBatida - item.PrimeiraBatida;
                    var horasSegundoPeriodo = item.QuartaBatida - item.TerceiraBatida;
                    horaTrabalhadaTotal += horasPrimeiroPeriodo + horasSegundoPeriodo;
                }
                    
            }
            return horaTrabalhadaTotal;


        }
    }
}
