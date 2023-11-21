using Desafio_Loja_Aula49.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Desafio_Loja_Aula49.dao;

internal class daoCategoria
{
    public bool salvar(Categoria categoria)
    {
        using (SqlConnection con = new SqlConnection())
        {
            //Primeiro criar a conexão
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_loja;Integrated Security=True;Connect Timeout=30;Encrypt=False";

            con.Open();

            //Enviar comandos DML ao database
            SqlCommand cn = new SqlCommand();
            cn.CommandType = CommandType.Text;
            cn.CommandText = "insert into tb_categoria([Descricao])Values(@descricao)";
            

            //envia itens para o Db 
            cn.Parameters.Add("Descricao", SqlDbType.VarChar).Value = categoria.Descricao;


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
            cn.CommandText = "select * from tb_categoria";

            cn.Connection = con;

            SqlDataReader dr;
            dr = cn.ExecuteReader();

            while (dr.Read())
            {
                Categoria cat = new();
                cat.Id = Convert.ToInt32(dr["id"]);
                cat.Descricao = Convert.ToString(dr["descricao"]);

                Console.WriteLine(cat.ToString());
            }
        }
    }

    public void editar(string descricao, int categoria)
    {
        using (SqlConnection con = new SqlConnection())
        {
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_loja;Integrated Security=True;Connect Timeout=30;Encrypt=False";

            con.Open();

            SqlCommand cn = new SqlCommand();
            cn.CommandType = CommandType.Text;
            cn.CommandText = "update tb_categoria set descricao = @descricao where id = @id";

            cn.Parameters.AddWithValue("@descricao", descricao);
            cn.Parameters.AddWithValue("@id", categoria);

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
            cn.CommandText = "delete from tb_categoria where id = @id";

            cn.Parameters.AddWithValue("@id", id);

            cn.Connection = con;

            cn.ExecuteNonQuery();
            con.Close();
        }
    }
}

