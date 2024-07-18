using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIMIVRH.Interfaces;
using PIMIVRH.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using PIMIVRH.Interfaces;

namespace PIMIVRH.Controllers
{
    public class LoginController : Controller
    {

        


        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult ValidaUsuario(LoginModel login)
        {
            if (Validacao(login))
            {
                return RedirectToAction("Index", "Home");
            } 
            return View("Index");
        }
        protected bool Validacao(LoginModel login)
        {
            LoginModel loginModel = new LoginModel();

            conexaoSql Connectiostring = new conexaoSql();
            var conexaoSql = Connectiostring.ConnectionString;
            SqlConnection conexaoDB = new SqlConnection(conexaoSql);

            conexaoDB.Open();

            if(login.Funcional == null  || login.Senha == null)
            {
                TempData["MensagemErro"] = "Não foi possivel fazer o login funcional ou senha incorretos";
                return false;
            }
            if (login.Funcional == " " || login.Senha == " ")
            {
                TempData["MensagemErro"] = "Não foi possivel fazer o login funcional ou senha incorretos";
                return false;
            }

            if (!login.Funcional.StartsWith("033"))
            {
                TempData["MensagemErro"] = "não foi possivel fazer o login";
                return false;
            }
            string query = $"SELECT Funcional, Senha FROM FUNCIONARIO WHERE Funcional = '{login.Funcional}' AND Senha = '{login.Senha}'";
            SqlCommand command = new SqlCommand(query, conexaoDB);
            SqlDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                
                TempData["MensagemErro"] = "Não foi possivel fazer o login funcional ou senha incorretos";
                return false;
                
            }
            else
            {
                loginModel.Funcional = reader.GetString(0);
                HttpContext.Session.SetString("Funcional", loginModel.Funcional);
                
                
            return true;
            }
        }
    }
}
