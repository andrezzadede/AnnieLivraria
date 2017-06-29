using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AnnieLivraria.Camadas.DAL
{
    public class Compra
    {
        private string strCon = Conexao.getConexao();

        public List<Model.Compra> Select()
        {
            List<Model.Compra> lstCompra = new List<Model.Compra>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "select * from Cliente;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Model.Compra compra = new Model.Compra();
                    compra.id = Convert.ToInt32(reader["ID"]);
                    compra.Livro = Convert.ToInt32(reader["Livro"].ToString());
                    compra.Cliente = Convert.ToInt32(reader["Cliente"].ToString());
                    compra.Valor = Convert.ToSingle(reader["Valor"].ToString());
                    compra.Data = Convert.ToDateTime(reader["Data"].ToString());                  

                    lstCompra.Add(compra);

                }
            }
            catch
            {
                Console.WriteLine("Erro - Sql Select.");
            }
            finally
            {
                conexao.Close();

            }
            return lstCompra;
        }

        public void Insert(Model.Compra compra)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Cliente values ";
            sql = sql + " (@Valor, @Data);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@Valor", compra.Valor);
            cmd.Parameters.AddWithValue("@Data", compra.Data);
            

            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro inserção da compra");
            }
            finally
            {
                conexao.Close();
            }
        }
        public void Update(Model.Compra compra)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Cliente set Data=@Data, cliente=@cliente ";
            sql = sql + " where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@Data", compra.Data);
            cmd.Parameters.AddWithValue("@Cliene", compra.Cliente);
            cmd.Parameters.AddWithValue("@id", compra.id);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de compra");
            }
            finally
            {
                conexao.Close();
            }

        }

        public void Delete(Model.Compra compra)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Compra where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", compra.id);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu Erro remocao Compra");
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
