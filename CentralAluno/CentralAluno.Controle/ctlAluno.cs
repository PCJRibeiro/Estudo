using System;
using System.Data;
using System.Data.OleDb;

namespace CentralAluno.Controle
{
    public class ctlAluno
    {
        public bool incluirAluno(string nome, string cpf, string rg)
        {
            string conexaoAccess = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Códigos\Estudo\CentralAluno\CentralAluno\Teste.mdb";

            OleDbConnection conexaodb = new OleDbConnection(conexaoAccess);
            
            try
            {
                conexaodb.Open();

                string query = "INSERT INTO TB_Aluno (nome, rg, cpf) VALUES (@Nome, @Rg, @Cpf)";
                OleDbCommand cmd = new OleDbCommand(query, conexaodb);

                var pmtNome = cmd.CreateParameter();
                pmtNome.ParameterName = "@Nome";
                pmtNome.DbType = DbType.String;
                pmtNome.Value = nome;
                cmd.Parameters.Add(pmtNome);

                var pmtRg = cmd.CreateParameter();
                pmtRg.ParameterName = "@Rg";
                pmtRg.DbType = DbType.String;
                pmtRg.Value = rg;
                cmd.Parameters.Add(pmtRg);

                var pmtCpf = cmd.CreateParameter();
                pmtCpf.ParameterName = "@Cpf";
                pmtCpf.DbType = DbType.String;
                pmtCpf.Value = cpf;
                cmd.Parameters.Add(pmtCpf);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    conexaodb.Close();
                    return true;
                }
                else
                {
                    conexaodb.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                conexaodb.Close();
                throw;
            }
        }
    }
}
