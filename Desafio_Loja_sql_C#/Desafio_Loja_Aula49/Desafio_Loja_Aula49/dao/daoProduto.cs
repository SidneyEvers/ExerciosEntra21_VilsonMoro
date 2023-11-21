using Desafio_Loja_Aula49.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Desafio_Loja_Aula49.dao
{
    internal class daoProduto
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
    }
}
