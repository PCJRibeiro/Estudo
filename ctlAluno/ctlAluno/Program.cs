using System;
using System.Data;
using System.Data.OleDb;

namespace CentralAluno.Controle
{
    public class ctlAluno
    {
        public string conexaoAccess = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Códigos\Estudo\CentralAluno\CentralAluno\Teste.mdb";
        public bool incluirAluno(string nome, string cpf, string rg)
        {
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

        public bool Alterar(string nome, string cpf)
        {
            OleDbConnection conexaodb = new OleDbConnection(conexaoAccess);

            try
            {
                conexaodb.Open();

                string query = "UPDATE TB_Aluno set nome = @nome where cpf = @cpf";
                OleDbCommand cmd = new OleDbCommand(query, conexaodb);

                var pmtNome = cmd.CreateParameter();
                pmtNome.ParameterName = "@Nome";
                pmtNome.DbType = DbType.String;
                pmtNome.Value = nome;
                cmd.Parameters.Add(pmtNome);

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
                throw new Exception("Erro ao alterar aluno: " + ex.Message);
            }
        }
        public bool Excluir(string cpf)
        {
            OleDbConnection conexaodb = new OleDbConnection(conexaoAccess);

            try
            {
                conexaodb.Open();

                string query = "DELETE FROM TB_Aluno where cpf = @cpf";
                OleDbCommand cmd = new OleDbCommand(query, conexaodb);

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
                throw new Exception("Erro ao excluir aluno: " + ex.Message);
            }
        }
        public List<mdlAluno> Consultar(mdlAluno _mdlAluno)
        {
            OleDbConnection conexaodb = new OleDbConnection(conexaoAccess);
            List<mdlAluno> _lstmdlAluno = new List<mdlAluno>();
            try
            {
                conexaodb.Open();

                string query = "SELECT * FROM TB_Aluno WITH(NOLOCK) WHERE cpf = @cpf";
                OleDbCommand cmd = new OleDbCommand(query, conexaodb);

                var pmtCpf = cmd.CreateParameter();
                pmtCpf.ParameterName = "@Cpf";
                pmtCpf.DbType = DbType.String;
                pmtCpf.Value = _mdlAluno.cpf;
                cmd.Parameters.Add(pmtCpf);

                OleDbDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    _mdlAluno.nome = rd.GetString(1);
                    _mdlAluno.rg = rd.GetString(2);
                    _mdlAluno.cpf = rd.GetString(3);
                    _lstmdlAluno.Add(_mdlAluno);
                }
                return _lstmdlAluno;
            }
            catch (Exception ex)
            {
                conexaodb.Close();
                throw new Exception("Erro ao consultar dados do aluno: " + ex.Message);
            }
        }
        public List<mdlAluno> ConsultarTodosAluno()
        {
            OleDbConnection conexaodb = new OleDbConnection(conexaoAccess);
            List<mdlAluno> _lstmdlAluno = new List<mdlAluno>();
            mdlAluno _mdlAluno = new mdlAluno();

            try
            {
                conexaodb.Open();

                string query = "SELECT * FROM TB_Aluno with(nolock)";
                OleDbCommand cmd = new OleDbCommand(query, conexaodb);
                OleDbDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    _mdlAluno.nome = rd.GetString(1);
                    _mdlAluno.rg = rd.GetString(2);
                    _mdlAluno.cpf = rd.GetString(3);
                    _lstmdlAluno.Add(_mdlAluno);
                }
                return _lstmdlAluno;
            }
            catch (Exception ex)
            {
                conexaodb.Close();
                throw new Exception("Erro ao consultar dados do aluno: " + ex.Message);
            }
        }
    }
}