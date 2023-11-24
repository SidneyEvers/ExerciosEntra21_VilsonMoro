using Conexao_MySql_C.Models;
using Conexao_MySql_C.utlis;
using Microsoft.Win32.SafeHandles;
using MySql.Data.MySqlClient;
using System.Data;

namespace Conexao_MySql_C.daoContato;

internal class daoContato
{
    public bool salvar(Contato contato)
    {
        MySqlConnection con = Conexao.conectar();
        MySqlCommand command = con.CreateCommand();

        try
        {
            con.Open();
            command.CommandText = "insert into tb_contato(nome, email, telefone)values(@nome, @email, @telefone)";
            command.Parameters.Add("nome", MySqlDbType.VarString).Value = contato.Nome;
            command.Parameters.Add("email", MySqlDbType.VarString).Value = contato.Email;
            command.Parameters.Add("telefone", MySqlDbType.VarString).Value = contato.Telefone;
            command.ExecuteNonQuery();
        }
        finally
        {
            if(con.State == ConnectionState.Open)
                con.Close();
        }
        return true;
    }

    public List<Contato> consultar()
    {
        List<Contato> contatos = new();

        MySqlConnection con = Conexao.conectar();
        MySqlCommand command = con.CreateCommand();

        try
        {
            con.Open();
            command.CommandText = "select * from tb_contato";
            MySqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                Contato ct = new Contato();
                ct.Id = Convert.ToInt32(dr["id"]);
                ct.Nome = Convert.ToString(dr["nome"]);
                ct.Email = Convert.ToString(dr["email"]);
                ct.Telefone = Convert.ToString(dr["telefone"]);
                contatos.Add(ct);
            }
        }
        finally
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        return contatos;
    }
}
