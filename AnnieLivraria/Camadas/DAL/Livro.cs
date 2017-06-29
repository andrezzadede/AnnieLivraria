using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AnnieLivraria.Camadas.DAL
{
    public class Livro
    {
        private string strCon = Conexao.getConexao();

        public List<Model.Livro> Select()
        {

            List<Model.Livro> lstLivro = new List<Model.Livro>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "select * from Livro;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Model.Livro livro = new Model.Livro();
                    livro.id = Convert.ToInt32(reader["id"]);
                    livro.Nome = reader["Nome"].ToString();
                    livro.Autor = reader["Autor"].ToString();
                    livro.DataLancamento = Convert.ToDateTime(reader["DataLancamento"].ToString());
                    livro.Valor = Convert.ToSingle(reader["Valor"].ToString());
                    lstLivro.Add(livro);
                }
            }
            catch
            {
                Console.WriteLine("Erro - Sql Select Livro;");
            }
            finally
            {
                conexao.Close();
            }
            return lstLivro;


        }
        public List<Model.Livro> SelectByid(int id)
        {
            List<Model.Livro> lstLivro = new List<Model.Livro>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "select * from Livro where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Model.Livro livro = new Model.Livro();
                    livro.id = Convert.ToInt32(reader["id"]);
                    livro.Nome = reader["Nome"].ToString();
                    livro.Autor = reader["Autor"].ToString();
                    livro.DataLancamento = Convert.ToDateTime(reader["DataLancamento"].ToString());
                    livro.Valor = Convert.ToSingle(reader["Valor"].ToString());
                    lstLivro.Add(livro);
                }
            }
            catch
            {
                Console.WriteLine("Erro - Sql Select Livro;");
            }
            finally
            {
                conexao.Close();
            }

            return lstLivro;
        }

        public List<Model.Livro> SelectByNome(string Nome)
        {
            List<Model.Livro> lstLivro = new List<Model.Livro>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "select * from Livro where (Nome like @Nome);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@Nome", "%" + Nome.Trim() + "%");
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Model.Livro livro = new Model.Livro();
                    livro.id = Convert.ToInt32(reader["id"]);
                    livro.Nome = reader["Nome"].ToString();
                    livro.Autor = reader["Autor"].ToString();
                    livro.DataLancamento = Convert.ToDateTime(reader["DataLancamento"].ToString());
                    livro.Valor = Convert.ToSingle(reader["Valor"].ToString());
                    lstLivro.Add(livro);
                }
            }
            catch
            {
                Console.WriteLine("Erro - Sql Select Livro;");
            }
            finally
            {
                conexao.Close();
            }
            return lstLivro;
        }

        public void Insert(Model.Livro Livro)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Produto values ";
            sql = sql + " (@Nome, @Autor, @DataLancamento, @Valor);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@Nome", Livro.Nome);
            cmd.Parameters.AddWithValue("@Autor", Livro.Autor);
            cmd.Parameters.AddWithValue("@DataLancamento", DateTime.Now.ToLongDateString());
            cmd.Parameters.AddWithValue("@Valor", Livro.Valor);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro inserção do Livro;");
            }
            finally
            {
                conexao.Close();
            }
        }
        public void Update(Model.Livro Livro)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Produto set Nome=@Nome, Autor=@Autor, DataLancamento=@DataLancamento, Valor=@Valor ";
            sql += " where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@Nome", Livro.Nome);
            cmd.Parameters.AddWithValue("@Autor", Livro.Autor);
            cmd.Parameters.AddWithValue("@DataLancamento", Livro.DataLancamento);
            cmd.Parameters.AddWithValue("@Valor", Livro.Valor);
            cmd.Parameters.AddWithValue("@id", Livro.id);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de Livros...");
            }
            finally
            {
                conexao.Close();
            }
        }
        public void Delete(Model.Livro Livro)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Produto where id=@id; ";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", Livro.id);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro remocao do Livro");
            }
            finally
            {
                conexao.Close();
            }
        }
    }
 }