using AgendaMvc.Controllers.Dados;
using AgendaMvc.interfaces;
using AgendaMvc.Models;
using MySqlConnector;
using System.Data;

namespace AgendaMvc.Dao;

public class DaoLocais : ICrud<Locais>
{
    public bool alterar(Locais locais)
    {
        MySqlConnection con = db.Conectar();
        MySqlCommand command = con.CreateCommand();

        try
        {
            con.Open();
            command.CommandText = "update tb_locais set descricao = @descricao, rua = @rua, numero = @numero, cidade = @cidade where id = @id";

            command.Parameters.AddWithValue("@id", locais.Id);
            command.Parameters.AddWithValue("@descricao", locais.Descricao);
            command.Parameters.AddWithValue("@rua", locais.Rua);
            command.Parameters.AddWithValue("@numero", locais.Numero);
            command.Parameters.AddWithValue("@cidade", locais.Cidade);
            return command.ExecuteNonQuery() > 0;
        }
        finally
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }

    public Locais consultar(int id)
    {
        MySqlConnection con = db.Conectar();
        MySqlCommand command = con.CreateCommand();

        con.Open();
        command.CommandText = "select id, descricao, rua, numero, cidade from tb_locais where id = @id";

        command.Parameters.AddWithValue("@id", id);
        MySqlDataReader dr = command.ExecuteReader();
        Locais loc = new();
        while (dr.Read())
        {
            loc.Id = Convert.ToInt32(dr["id"]);
            loc.Descricao= Convert.ToString(dr["descricao"]);
            loc.Rua = Convert.ToString(dr["rua"]);
            loc.Numero = Convert.ToInt32(dr["numero"]);
            loc.Cidade = Convert.ToString(dr["cidade"]);
        }
        return loc;
    }

    public List<Locais> consultar()
    {
        List<Locais> local = new();

        MySqlConnection con = db.Conectar();
        MySqlCommand command = con.CreateCommand();

        try
        {
            con.Open();
            command.CommandText = "select * from tb_locais";
            MySqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                Locais loc = new();
                loc.Id = Convert.ToInt32(dr["id"]);
                loc.Descricao = Convert.ToString(dr["descricao"]);
                loc.Rua = Convert.ToString(dr["rua"]);
                loc.Numero = Convert.ToInt32(dr["numero"]);
                loc.Cidade = Convert.ToString(dr["cidade"]);

                return local;
            }
        }
        finally
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        return local;
    }

    public Locais Deletar(int id)
    {
        MySqlConnection con = db.Conectar();
        MySqlCommand command = con.CreateCommand();

        con.Open();
        command.CommandText = "select id, descricao, rua, numero, cidade from tb_locais where id = @id";

        command.Parameters.AddWithValue("@id", id);
        MySqlDataReader dr = command.ExecuteReader();
        Locais loc = new();
        while (dr.Read())
        {
            loc.Id = Convert.ToInt32(dr["id"]);
            loc.Descricao = Convert.ToString(dr["descricao"]);
            loc.Rua = Convert.ToString(dr["rua"]);
            loc.Numero = Convert.ToInt32(dr["numero"]);
            loc.Cidade = Convert.ToString(dr["cidade"]);
        }
        return loc;
    }
    public void excluir(int id)
    {
        MySqlConnection con = db.Conectar();
        MySqlCommand command = con.CreateCommand();

        con.Open();
        command.CommandText = "delete from tb_locais where id = @id";

        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
    }

    public bool salvar(Locais locais)
    {
        MySqlConnection con = db.Conectar();
        MySqlCommand command = con.CreateCommand();

        try
        {
            con.Open();
            command.CommandText = "insert into tb_locais(id, descricao, rua, numero, cidade)values(@id,@descricao, @rua, @numero, @cidade)";
            command.Parameters.Add("id", MySqlDbType.VarString).Value = locais.Id;
            command.Parameters.Add("descricao", MySqlDbType.VarString).Value = locais.Descricao;
            command.Parameters.Add("rua", MySqlDbType.VarString).Value = locais.Rua;
            command.Parameters.Add("numero", MySqlDbType.VarString).Value = locais.Numero;
            command.Parameters.Add("cidade", MySqlDbType.VarString).Value = locais.Cidade;
            command.ExecuteNonQuery();
        }
        finally
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
        return true;
    }
}
