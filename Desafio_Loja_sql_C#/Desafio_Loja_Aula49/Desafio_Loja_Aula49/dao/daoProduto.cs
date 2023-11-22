using Desafio_Loja_Aula49.Interfaces;
using Desafio_Loja_Aula49.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Desafio_Loja_Aula49.dao
{
    internal class daoProduto : ICrud<Produto>
    {
        public bool salvar(Produto produto)
        {
            using(SqlConnection con = new SqlConnection())
            {
                //Criar a conexão primeiramente
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_loja;Integrated Security=True;Connect Timeout=30;Encrypt=False";

                con.Open();


                //enviar comandos ao Db 
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                cn.CommandText = "insert into tb_produtos([Descricao], [id_categoria], [Valor], [Quantidade])Values(@descricao, @id_categoria, @valor, @quantidade)";

                //enviar dados ao db 
                cn.Parameters.Add("descricao", SqlDbType.VarChar).Value = produto.Descricao;
                cn.Parameters.Add("id_categoria", SqlDbType.Int).Value = produto.Categoria;
                cn.Parameters.Add("valor", SqlDbType.Float).Value = produto.Valor;
                cn.Parameters.Add("quantidade", SqlDbType.Int).Value = produto.Quantidade;

                cn.Connection = con;

                return cn.ExecuteNonQuery() > 0;

            }
        }
        public void listar()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_loja;Integrated Security=True;Connect Timeout=30;Encrypt=False";

                con.Open();

                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                cn.CommandText = "select * from tb_produtos";

                cn.Connection = con;

                SqlDataReader dr;
                dr = cn.ExecuteReader();

                while (dr.Read())
                {
                    Produto prod = new();
                    prod.Id = Convert.ToInt32(dr["id"]);
                    prod.Descricao = Convert.ToString(dr["descricao"]);
                    prod.Valor = Convert.ToSingle(dr["valor"]);
                    prod.Quantidade = Convert.ToInt32(dr["quantidade"]);

                    Console.WriteLine(prod.ToString());
                }
            }
        }
        public void editar(Produto produto)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_loja;Integrated Security=True;Connect Timeout=30;Encrypt=False";

                con.Open();

                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                cn.CommandText = "update tb_produtos set descricao = @descricao, quantidade = @quantidade, valor = @valor, id_categoria = @id_categoria where id = @id";

                cn.Parameters.AddWithValue("@id", produto.Id);
                cn.Parameters.AddWithValue("@descricao", produto.Descricao);
                cn.Parameters.AddWithValue("@id_categoria", produto.Categoria);
                cn.Parameters.AddWithValue("@quantidade", produto.Quantidade);
                cn.Parameters.AddWithValue("@valor", produto.Valor);

                cn.Connection = con;

                cn.ExecuteNonQuery();
                con.Close();
            }
        }
        public void excluir(int id)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_loja;Integrated Security=True;Connect Timeout=30;Encrypt=False";

                con.Open();

                SqlCommand cn = new SqlCommand();

                cn.CommandType = CommandType.Text;
                cn.CommandText = "delete from tb_produtos where id = @id";

                cn.Parameters.AddWithValue("@id", id);

                cn.Connection = con;

                cn.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
