using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AnnieLivraria.Camadas.DAL
{
    public class Cliente
    {
        private string strCon = Conexao.getConexao();

        public List<Model.Cliente> Select()
        {
            List<Model.Cliente> lstCliente = new List<Model.Cliente>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "select * from Cliente;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Model.Cliente cliente = new Model.Cliente();
                    cliente.ID = Convert.ToInt32(reader["ID"]);
                    cliente.Nome = reader["Nome"].ToString();
                    cliente.CPF = reader["CPF"].ToString();
                    cliente.RG = reader["RG"].ToString();
                    cliente.Contato = reader["Contato"].ToString();
                    cliente.Endereco = reader["Endereco"].ToString();
                    cliente.Cidade = reader["Cidade"].ToString();
                    cliente.Estado = reader["Estado"].ToString();

                    lstCliente.Add(cliente);

                }
            }
            catch
            {
                Console.WriteLine("Erro - Não selecionou clientes.");
            }
            finally
            {
                conexao.Close();

            }
            return lstCliente;
        }

        public void Insert(Model.Cliente cliente)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Cliente values ";
            sql = sql + " (@Nome, @CPF, @RG, @Contato, @Endereco, @Cidade, @Estado);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@CPF", cliente.CPF);
            cmd.Parameters.AddWithValue("@RG", cliente.RG);
            cmd.Parameters.AddWithValue("@Contato", cliente.Contato);
            cmd.Parameters.AddWithValue("@Endereco", cliente.Endereco);
            cmd.Parameters.AddWithValue("@Cidade", cliente.Cidade);
            cmd.Parameters.AddWithValue("@Estado", cliente.Estado);

            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro inserção de cliente");
            }
            finally
            {
                conexao.Close();
            }
        }
        public void Update(Model.Cliente cliente)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Cliente set Nome=@Nome, CPF=@CPF, RG=@RG, Contato=@Contato, ";
            sql = sql + "Endereco=@Endereco, Cidade=@Cidade, Estado=@Estado ";
            sql = sql + " where ID=@ID;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@CPF", cliente.CPF);
            cmd.Parameters.AddWithValue("@RG", cliente.RG);
            cmd.Parameters.AddWithValue("@Contato", cliente.Contato);
            cmd.Parameters.AddWithValue("@Endereco", cliente.Endereco);
            cmd.Parameters.AddWithValue("@Cidade", cliente.Cidade);
            cmd.Parameters.AddWithValue("@Estado", cliente.Estado);
            cmd.Parameters.AddWithValue("@ID", cliente.ID);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de clientes");
            }
            finally
            {
                conexao.Close();
            }

        }

        public void Delete(Model.Cliente cliente)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Cliente where ID=@ID;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@ID", cliente.ID);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu Erro remocao Cliente");
            }
            finally
            {
                conexao.Close();
            }
        }
    }

}
